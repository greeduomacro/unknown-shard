/*
ColorCycling.cs
snicker7 20060909 v0.4
RunUO 2.0 RC1

Desc:
Class that can be called on deserialize or
in the constructors of items to make items
that will cycle through a list or range of
hues with a certain frequency.

Use:
In item constructors and deserialize overrides,
call ColorCycling.Add to make a color cycling
item. CCType can be ForwardLoop, ReverseLoop,
or Bounce.
ColorCycling.Add(Item item, int[] huelist, TimeSpan frequency, CCType type)
ColorCycling.Add(Item item, int rangemin, int rangemax, TimeSpan frequency, CCType type)

Includes:
StaticColorCycle
	An example item that inherits static, which can be used for decoration.
*/
using System;
using System.Collections.Generic;
using Server;
using Server.Network;
using Server.Misc;

namespace Server.Misc {
	public enum CCType {
		ForwardLoop,
		ReverseLoop,
		Bounce
	}
	public class ColorCycling {
		private static CCTimer m_Timer;
		public static CCTimer Timer { get { return m_Timer; } set { m_Timer = value; } }
		
		private static List<CycleData> m_CycleTable;
		public static List<CycleData> CycleTable { get { return m_CycleTable; } set { m_CycleTable = value; } }
		
		static ColorCycling() {
			m_CycleTable = new List<CycleData>();
			Start();
		}
		
		public static void Start() {
			if(m_Timer == null)
				m_Timer = new CCTimer();
			if(!m_Timer.Running)
				m_Timer.Start();
		}
		
		public static CycleData GetCycleDataFor(Item i){
			foreach(CycleData cd in CycleTable)
				if(cd.Item == i)
					return cd;
			return null;
		}
		
		public static void Remove( Item i ) {
			CycleData cd = GetCycleDataFor(i);
			if(cd != null && CycleTable.Contains(cd))
				CycleTable.Remove(cd);
		}
		
		public static void Add( Item i, int min, int max ) {
			Add(i,new int[] { min, max });
		}
		
		public static void Add( Item i, int[] range ) {
			Add(i,range, TimeSpan.FromSeconds( 0.5 ), CCType.Bounce);
		}
		
		public static void Add( Item i, int min, int max, TimeSpan freq, CCType type ) {
			Add(i,new int[] { min, max }, freq, type);
		}
		
		public static void Add( Item i, int[] range, TimeSpan freq, CCType type ) {
			CycleData cd = GetCycleDataFor(i);
			if( cd == null )
				CycleTable.Add(new CycleData(i,range,freq,type));
			else {
				cd.HueRange = range;
				cd.Frequency = freq;
				cd.CycleType = type;
				cd.LastUpdate = DateTime.Now - freq;
				cd.Forward = cd.CycleType != CCType.ReverseLoop;
			}
			Start();
		}

		public class CCTimer : Timer {
			List<CycleData> toRemove = new List<CycleData>();
			public CCTimer() : base(TimeSpan.FromSeconds(0.1),TimeSpan.FromSeconds(0.1)) {
				Priority=TimerPriority.FiftyMS;
			}
			protected override void OnTick() {
				toRemove.Clear();
				foreach(CycleData cd in ColorCycling.CycleTable){
					if(cd.Deleted)
						toRemove.Add(cd);
					else
						if(cd.CanCycle)
							cd.Cycle();
				}
				foreach(CycleData cd in toRemove)
					if(ColorCycling.CycleTable.Contains(cd))
						ColorCycling.CycleTable.Remove(cd);
			}
		}
		
		public class CycleData {
			private Item m_Item;
			private int[] m_Range;
			private int m_I = 0;
			private TimeSpan m_Frequency;
			private DateTime m_LastUpdate = DateTime.Now;
			private CCType m_Type;
			private bool m_Forward;
			
			public Item Item { get { return m_Item; } set { m_Item = value; } }
			public int[] HueRange { get { return m_Range; } set { m_Range = value; m_I = 0; } }
			public TimeSpan Frequency { get { return m_Frequency; } set { m_Frequency = value; } }
			public DateTime LastUpdate { get { return m_LastUpdate; } set { m_LastUpdate = value; } }
			public CCType CycleType { get { return m_Type; } set { m_Type = value; } }
			public bool Forward { get { return m_Forward; } set { m_Forward = value; } }
			
			public bool Deleted { get { return m_Item == null || m_Item.Deleted; } }
			public bool CanCycle { get { return !Deleted && LastUpdate + Frequency < DateTime.Now && m_Item.Map != Map.Internal && ( ( m_Item.Map.GetSector(m_Item).Active && m_Item.Parent == null ) || m_Item.Parent != null ); } }
			public bool IsRange { get { return m_Range.Length == 2; } }
						
			public CycleData(Item i, int min, int max, TimeSpan freq, CCType type) : this(i,GetMinMax(min,max),freq,type) {}
			public CycleData(Item i, int[] range, TimeSpan freq, CCType type) {
				m_Item = i;
				m_Range = range;
				m_Frequency = freq;
				m_Type = type;
				m_Forward = m_Type != CCType.ReverseLoop;
			}
			
			private static int[] GetMinMax(int min, int max){
				if(min<=max)
					return new int[] { min, max };
				return new int[] { max, min };
			}
			
			public void Cycle() {
				if(Deleted)
					return;
				int hue = m_Item.Hue;
				if(IsRange) {
					hue += m_Forward ? 1 : -1 ;
					if( ( hue <= m_Range[0] && !m_Forward ) || ( hue >= m_Range[1] && m_Forward ) ) {
						switch(m_Type){
							case CCType.ForwardLoop: hue=m_Range[0]; break;
							case CCType.ReverseLoop: hue=m_Range[1]; break;
							case CCType.Bounce: m_Forward = !m_Forward; break;
						}
					} 
				} else {
					int i = m_I;
					i += m_Forward ? 1 : -1 ;
					if( i < 0 || i >= m_Range.Length ) {
						switch(m_Type) {
							case CCType.ForwardLoop: i = 0; break;
							case CCType.ReverseLoop: i = m_Range.Length - 1; break;
							case CCType.Bounce:	m_Forward = !m_Forward; break;
						}
					}
					if( i < 0 )
						i = 0;
					if( i >= m_Range.Length )
						i = m_Range.Length - 1;
					m_I = i;
					hue = m_Range[m_I];
				}
				m_Item.Hue = hue;
				LastUpdate = DateTime.Now;
			}
		}
	}
}

namespace Server.Items {
	public class StaticColorCycle : Static {
		private int m_HueBegin;
		private int m_HueEnd;
		private TimeSpan m_Frequency;
		private CCType m_CycleType;
		
		[CommandProperty(AccessLevel.GameMaster)]
		public int HueBegin { get { return m_HueBegin; } set { m_HueBegin = value; UpdateColorCycling(); } }
		[CommandProperty(AccessLevel.GameMaster)]
		public int HueEnd { get { return m_HueEnd; } set { m_HueEnd = value; UpdateColorCycling(); } }
		[CommandProperty(AccessLevel.GameMaster)]
		public TimeSpan Frequency { get { return m_Frequency; } set { m_Frequency = value; UpdateColorCycling(); } }
		[CommandProperty(AccessLevel.GameMaster)]
		public CCType CycleType { get { return m_CycleType; } set { m_CycleType = value; UpdateColorCycling(); } }
		
		[Constructable]
		public StaticColorCycle() : this(115) {}
		[Constructable]
		public StaticColorCycle(int itemid) : this(itemid,0,1) {}
		[Constructable]
		public StaticColorCycle(int itemid, int hueb, int huee) : this(itemid,hueb,huee,TimeSpan.FromSeconds(0.5),CCType.Bounce) {}
		[Constructable]
		public StaticColorCycle(int itemid, int hueb, int huee, TimeSpan freq, CCType type) : base(itemid) {
			m_HueBegin = hueb;
			m_HueEnd = huee;
			m_Frequency = freq;
			m_CycleType = type;
			UpdateColorCycling();
		}
		public StaticColorCycle(Serial s) : base(s) {}
		
		private void UpdateColorCycling(){
			Hue = m_HueBegin;
			ColorCycling.Add(this,m_HueBegin,m_HueEnd,m_Frequency,m_CycleType);
		}
		
		public override void Serialize(GenericWriter writer) {
			base.Serialize(writer);
			writer.Write((int)0); // Zippy is ghey
			writer.Write((int)m_HueBegin);
			writer.Write((int)m_HueEnd);
			writer.Write((TimeSpan)m_Frequency);
			writer.Write((int)m_CycleType);
		}
		public override void Deserialize(GenericReader reader) {
			base.Deserialize(reader);
			int version = reader.ReadInt(); // Zippy is ghey
			m_HueBegin = reader.ReadInt();
			m_HueEnd = reader.ReadInt();
			m_Frequency = reader.ReadTimeSpan();
			m_CycleType = (CCType)reader.ReadInt();
			UpdateColorCycling();
		}
	}
}