////////////////////
// Shepherd Script//
//    by Liacs    //
//  Version 1.0   //
////////////////////
using Server;
using System;
using Server.Mobiles;
using System.Collections;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a shepherd's corpse" )]
	public class Shepherd : BaseCreature
	{
		private ArrayList m_sheep;
		int sheepCount = Utility.RandomMinMax( 5, 10 ); // change for more or less sheep

        private ArrayList m_dog;
        int dogCount = 1;

        private ShepherdsDog m_dog1;

        [CommandProperty(AccessLevel.GameMaster)]
        public ShepherdsDog DogA
        {
            get { return m_dog1; }
            set { m_dog1 = value; }
        }

		[CommandProperty( AccessLevel.GameMaster )]
		public bool RespawnSheep
		{
			get{ return false; }
			set{ if( value ) SpawnBabies(); }
		}

		[Constructable]
        public Shepherd() : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.1, 0.3)
		{
            Title = "the Shepherd";

            Hue = Utility.RandomSkinHue();
            Body = 0x190;
            Name = NameList.RandomName("male");
            BaseSoundID = 1094;

            AddItem(new LongPants(Utility.RandomNeutralHue()));
            AddItem(new Shirt(Utility.RandomNeutralHue()));
            AddItem(new ShepherdsCrook());
            AddItem(new Cloak(Utility.RandomNeutralHue()));
            AddItem(new StrawHat(Utility.RandomNeutralHue()));
            AddItem(new Shoes(Utility.RandomNeutralHue()));

			SetStr( 91, 110 );
			SetDex( 76, 95 );
			SetInt( 31, 50 );

			SetHits( 42, 68 );
			SetMana( 0 );

			SetDamage( 11, 21 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 25 );
			SetResistance( ResistanceType.Fire, 1, 10 );
			SetResistance( ResistanceType.Cold, 20, 25 );
			SetResistance( ResistanceType.Poison, 10, 15 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 30.6, 45.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.Wrestling, 60.1, 75.0 );

			Fame = 300;
			Karma = 0;

			VirtualArmor = 22;

            Tamable = false;

			m_sheep = new ArrayList();
            m_dog = new ArrayList();

			Timer m_timer = new ShepherdTimer( this );
			m_timer.Start();

		}

        public override bool OnBeforeDeath()
        {	
            foreach( Mobile m in m_sheep )
            {
                if (m is ShepherdsSheep && m.Alive && ((ShepherdsSheep)m).ControlMaster == null)
                {
                    Point3D sheeploc = m.Location;
                    Sheep sheepa = new Sheep();
                    sheepa.Location = sheeploc;
                    sheepa.MoveToWorld(sheeploc, m.Map);
                    sheepa.Hue = m.Hue;
                    m.Delete();
                }
            }

            foreach (Mobile m in m_dog)
            {
                if (m is ShepherdsDog && m.Alive && ((ShepherdsDog)m).ControlMaster == null)
                {
                    Point3D dogloc = m.Location;
                    Dog doga = new Dog();
                    doga.Location = dogloc;
                    doga.MoveToWorld(dogloc, m.Map);
                    doga.Hue = m.Hue;
                    m.Delete();
                }
            }
			
            return base.OnBeforeDeath();
        }

        public void SpawnBabies()
        {

            Defrag();
            int family1 = m_dog.Count;
            int family = m_sheep.Count;

            Map map = this.Map;

            if (map == null)
                return;

            int hr = (int)((this.RangeHome + 1) / 2);

            if (family1 == 0)
            {
                for (int i = family1; i < dogCount; ++i)
                {
                    ShepherdsDog dog = new ShepherdsDog();

                    bool validLocation = false;
                    Point3D loc = this.Location;

                    for (int j = 0; !validLocation && j < 10; ++j)
                    {
                        int x = X + Utility.Random(5) - 1;
                        int y = Y + Utility.Random(5) - 1;
                        int z = map.GetAverageZ(x, y);

                        if (validLocation = map.CanFit(x, y, this.Z, 16, false, false))
                            loc = new Point3D(x, y, Z);
                        else if (validLocation = map.CanFit(x, y, z, 16, false, false))
                            loc = new Point3D(x, y, z);
                    }

                    dog.ShepherdA = this;
                    this.DogA = dog;
                    dog.Home = this.Location;
                    dog.RangeHome = (hr > 4 ? 4 : hr);
                    dog.MoveToWorld(loc, map);
                    m_dog.Add(dog);                    
                }
            }

            if (family == 0)
            {

                for (int i = family; i < sheepCount; ++i)
                {
                    ShepherdsSheep sheep = new ShepherdsSheep();

                    bool validLocation = false;
                    Point3D loc = this.Location;

                    for (int j = 0; !validLocation && j < 10; ++j)
                    {
                        int x = X + Utility.Random(5) - 1;
                        int y = Y + Utility.Random(5) - 1;
                        int z = map.GetAverageZ(x, y);

                        if (validLocation = map.CanFit(x, y, this.Z, 16, false, false))
                            loc = new Point3D(x, y, Z);
                        else if (validLocation = map.CanFit(x, y, z, 16, false, false))
                            loc = new Point3D(x, y, z);
                    }

                    sheep.ShepherdA = this;
                    sheep.DogA = this.DogA;
                    //sheep.Team = this.Team;
                    sheep.Home = this.Location;
                    sheep.RangeHome = (hr > 4 ? 4 : hr);
                    sheep.MoveToWorld(loc, map);
                    m_sheep.Add(sheep);

                }
            }

            else
                return;
        }

        public override void OnCombatantChange()
        {
            if (Combatant != null && Combatant.Alive && m_dog1 != null && m_dog1.Combatant == null)
            {
                m_dog1.Combatant = Combatant;
                this.Say(" Hasso, help me!");
            }
        }

		protected override void OnLocationChange( Point3D oldLocation )
		{

			try
			{
				foreach( Mobile m in m_sheep )
				{
                    if (m is ShepherdsSheep && m.Alive && ((ShepherdsSheep)m).ControlMaster == null && m.Combatant == null)
					{
						((ShepherdsSheep)m).Home = this.Location;
					}
                }
                foreach (Mobile m in m_dog)
                {
                    if (m is ShepherdsDog && m.Alive && ((ShepherdsDog)m).ControlMaster == null && m.Combatant == null)
                    {
                        ((ShepherdsDog)m).Home = this.Location;
                    }
                }
			}
			catch{}

			base.OnLocationChange( oldLocation );
		}
		
		public void Defrag()
		{
			for ( int i = 0; i < m_sheep.Count; ++i )
			{
				try
				{
					object o = m_sheep[i];

					ShepherdsSheep sheep= o as ShepherdsSheep;

					if (sheep== null || !sheep.Alive )
					{
						m_sheep.RemoveAt( i );
						--i;
					}

					else if ( sheep.Controlled || sheep.IsStabled )
					{
						sheep.ShepherdA = null;
						m_sheep.RemoveAt( i );
						--i;
					}
				}
				catch{}
			}
            for (int i = 0; i < m_dog.Count; ++i)
            {
                try
                {
                    object o = m_dog[i];

                    ShepherdsDog dog = o as ShepherdsDog;

                    if (dog == null || !dog.Alive)
                    {
                        m_dog.RemoveAt(i);
                        --i;
                    }

                    else if (dog.Controlled || dog.IsStabled)
                    {
                        dog.ShepherdA = null;
                        m_dog.RemoveAt(i);
                        --i;
                    }
                }
                catch { }
            }
		}

        public override void OnDelete()
        {
            Defrag();

            foreach( Mobile m in m_sheep )
            {
                if (m is ShepherdsSheep && m.Alive && ((ShepherdsSheep)m).ControlMaster == null)
                {
                    /*Point3D sheeploc = m.Location;
                    Sheep sheepa = new Sheep();
                    sheepa.Location = sheeploc;
                    sheepa.MoveToWorld(sheeploc, m.Map);
                    sheepa.Hue = m.Hue;
                    m.Say("Maaah!");*/
                    m.Delete();
                }
            }

            foreach (Mobile m in m_dog)
            {
                if (m is ShepherdsDog && m.Alive && ((ShepherdsDog)m).ControlMaster == null)
                {
                    /*Point3D dogloc = m.Location;
                    Dog doga = new Dog();
                    doga.Location = dogloc;
                    doga.MoveToWorld(dogloc, m.Map);
                    doga.Hue = m.Hue;
                    m.Say("Woof!");*/
                    m.Delete();
                }
            }

            base.OnDelete();
        }

        public Shepherd(Serial serial) : base(serial)
		{
			m_sheep = new ArrayList();
			Timer m_timer = new ShepherdTimer( this );
			m_timer.Start();
            m_dog = new ArrayList();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
			writer.WriteMobileList( m_sheep, true );
            writer.WriteMobileList(m_dog, true);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			m_sheep = reader.ReadMobileList();
            m_dog = reader.ReadMobileList(); 
		}
	}

	public class ShepherdTimer : Timer
	{
		private Shepherd m_from;

		public ShepherdTimer( Shepherd from  ) : base( TimeSpan.FromMinutes( 1 ), TimeSpan.FromMinutes( 20 ) )
		{
			Priority = TimerPriority.OneMinute; 
			m_from = from;
		}

		protected override void OnTick()
		{
			if ( m_from != null && m_from.Alive )
				m_from.SpawnBabies();
			else
				Stop();
		}
	}
}