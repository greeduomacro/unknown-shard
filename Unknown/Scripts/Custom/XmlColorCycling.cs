/*
XmlColorCycling.cs
snicker7 20060909 v1.0

Desc:
XmlAttachment (for ArteGordon's XMLSpawner2 package)
for the ColorCycling class which allows ColorCycling
to be added to any items.

Use:
Add the XmlColorCycling attachment to any item and
modify the properties.
*/
using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server.Engines.XmlSpawner2 {
	public class XmlColorCycling : XmlAttachment {
		private int m_OriginalHue;
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
		[CommandProperty(AccessLevel.GameMaster)]
		public Item AttachedItem { get { return AttachedTo as Item; } }

		private void UpdateColorCycling(){
			if(AttachedItem != null){
				AttachedItem.Hue = m_HueBegin;
				ColorCycling.Add(AttachedItem,m_HueBegin,m_HueEnd,m_Frequency,m_CycleType);
			}
		}

		public XmlColorCycling(ASerial serial) : base(serial) {}
		[Attachable]
		public XmlColorCycling() : this(0,1) {}
		[Attachable]
		public XmlColorCycling(int hueb, int huee) : this(hueb,huee,0.5,CCType.Bounce) {}
		[Attachable]
		public XmlColorCycling(int hueb, int huee, double frequency, CCType type) : this(hueb, huee, frequency, type, 0) {}
		[Attachable]
		public XmlColorCycling(int hueb, int huee, double frequency, CCType type, double expiration) : base() {
			m_HueBegin = hueb;
			m_HueEnd = huee;
			m_Frequency = TimeSpan.FromSeconds(frequency);
			m_CycleType = type;
			if(expiration>0)
				Expiration = TimeSpan.FromSeconds(expiration);
		}

		public override void OnAttach() {
		    base.OnAttach();
            if(AttachedItem != null) {
				m_OriginalHue = AttachedItem.Hue;
                UpdateColorCycling();
            } else
				Timer.DelayCall(TimeSpan.Zero, new TimerCallback(Delete));
		}
		
		public override void OnReattach() {
			base.OnReattach();
            if(AttachedItem != null)
                UpdateColorCycling();
            else
				Timer.DelayCall(TimeSpan.Zero, new TimerCallback(Delete));
		}

		public override void OnDelete() {
			base.OnDelete();
			if(AttachedItem != null){
				ColorCycling.Remove(AttachedItem);
				AttachedItem.Hue = m_OriginalHue;
			}
		}

		public override void Serialize(GenericWriter writer) {
			base.Serialize(writer);
			writer.Write((int)0); // Zippy is ghey
			writer.Write((int)m_HueBegin);
			writer.Write((int)m_HueEnd);
			writer.Write((TimeSpan)m_Frequency);
			writer.Write((int)m_CycleType);
			writer.Write((int)m_OriginalHue);
		}

		public override void Deserialize(GenericReader reader) {
			base.Deserialize(reader);
			int version = reader.ReadInt(); // Zippy is ghey
			m_HueBegin = reader.ReadInt();
			m_HueEnd = reader.ReadInt();
			m_Frequency = reader.ReadTimeSpan();
			m_CycleType = (CCType)reader.ReadInt();
			m_OriginalHue = reader.ReadInt();
		}
	}
}