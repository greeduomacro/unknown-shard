using System;
using Server;
using Server.Targeting;

//////////////////////////////////////////////////////////////
// Author: Alambik                                          //
// Feel free to modify this script according to your shard. //
//////////////////////////////////////////////////////////////

namespace Server.Items
{
	public class Guillotine: Item
	{	

		public Mobile m_Target;

		[Constructable]
		public Guillotine() : this( 1 )
		{
		}

		[Constructable]
		public Guillotine( int amount ) : base( 4656 )
		{
			Name = "guillotine";
		}

		public Guillotine( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

		public override void OnDoubleClick( Mobile from )
		{
			if (from.AccessLevel >= AccessLevel.GameMaster)
			{
				// Only Game Master and better can use this to avoid bad players.
				if (ItemID == 4656)
					// The Guillotine is up: choose a target to kill
					from.Target = new TargetSystem(this);
				else
					if (ItemID == 4679)
					{
						// Guillotine is down now. We can reactivate it
						ItemID = 4656;
						from.PlaySound(565);
					}
			}
			else
			{
				//from.SendMessage("Cela semble bloqué.");
				from.SendMessage("This seems to be blocked.");
			}
		}

		public void StartToKill( Mobile UnluckyGuy )
		{
			if (ItemID == 4656)
			{
				// Guillotine is up, start to move it
				ItemID = 4678;
				m_Target=UnluckyGuy;
				new DelayTimer(this).Start();
				UnluckyGuy.PlaySound(903);
			}
		}

		private class DelayTimer : Timer
		{
			private Guillotine m_Guillotine;

			public DelayTimer( Guillotine guillotine ) : base( TimeSpan.FromSeconds( 0.4 ) )
			{
				m_Guillotine = guillotine;
			}

			protected override void OnTick()
			{
				// Guillotine is in the middle, we kill the unlucky guy...
				m_Guillotine.ItemID = 4679;
				Head item = new Head();
				item.Name=m_Guillotine.m_Target.Name;
				item.Location=new Point3D(m_Guillotine.X,m_Guillotine.Y-1,m_Guillotine.Z+1);
				item.Map=m_Guillotine.Map;
				m_Guillotine.m_Target.Location=new Point3D(m_Guillotine.X,m_Guillotine.Y+1,m_Guillotine.Z);
				m_Guillotine.m_Target.Kill();
			}
		}

		private class TargetSystem : Target
		{
			private Guillotine m_Guillotine;

			public TargetSystem( Guillotine guillotine ) : base(-1, false, TargetFlags.None)
			{
				m_Guillotine = guillotine;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
				{
					// A Mobile has been targeted. We can kill this unlucky guy.
					Mobile m = (Mobile)o;
					m_Guillotine.StartToKill(m);
				}
				else
				{
					// Not a mobile! We cannot kill things.
					//from.SendMessage("Vous ne pouvez le tuer.");
					from.SendMessage("You cannot order to kill this.");
				}
			}
		}
	}
}

