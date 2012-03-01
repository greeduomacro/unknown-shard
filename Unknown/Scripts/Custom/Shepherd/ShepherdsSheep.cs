////////////////////
// Shepherd Script//
//    by Liacs    //
//  Version 1.0   //
////////////////////

using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a sheep's corpse" )]
	public class ShepherdsSheep: BaseCreature, ICarvable
	{
		private DateTime m_NextWoolTime;

		private Shepherd m_shepherd;
        private ShepherdsDog m_dog;

		[CommandProperty( AccessLevel.GameMaster )]
		public Shepherd ShepherdA
		{
			get{ return m_shepherd; }
			set{ m_shepherd = value; }
		}

        [CommandProperty(AccessLevel.GameMaster)]
        public ShepherdsDog DogA
        {
            get { return m_dog; }
            set { m_dog = value; }
        }


		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime NextWoolTime
		{
			get{ return m_NextWoolTime; }
			set{ m_NextWoolTime = value; Body = ( DateTime.Now >= m_NextWoolTime ) ? 0xCF : 0xDF; }
		}

		public void Carve( Mobile from, Item item )
		{
			if ( DateTime.Now < m_NextWoolTime )
			{
				// This sheep is not yet ready to be shorn.
				PrivateOverheadMessage( MessageType.Regular, 0x3B2, 500449, from.NetState );
				return;
			}

			from.SendLocalizedMessage( 500452 ); // You place the gathered wool into your backpack.
			from.AddToBackpack( new Wool( Map == Map.Felucca ? 2 : 1 ) );

			NextWoolTime = DateTime.Now + TimeSpan.FromHours( 3.0 ); // TODO: Proper time delay
		}

		public override void OnThink()
		{
			base.OnThink();
			Body = ( DateTime.Now >= m_NextWoolTime ) ? 0xCF : 0xDF;
		}

		[Constructable]
		public ShepherdsSheep() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a sheep";
			Body = 0xCF;
			BaseSoundID = 0xD6;

			SetStr( 19 );
			SetDex( 25 );
			SetInt( 5 );

			SetHits( 12 );
			SetMana( 0 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 5, 10 );

			SetSkill( SkillName.MagicResist, 5.0 );
			SetSkill( SkillName.Tactics, 6.0 );
			SetSkill( SkillName.Wrestling, 5.0 );

			Fame = 300;
			Karma = 0;

			VirtualArmor = 6;
            Tamable = false;
		}

		public override int Meat{ get{ return 2; } }
		public override MeatType MeatType{ get{ return MeatType.LambLeg; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public override int Wool{ get{ return (Body == 0xCF ? 3 : 0); } }
        
        #region wolves attack addition 
        public override OppositionGroup OppositionGroup
        {
            get { return OppositionGroup.PredatorAndPrey; }
        }
        #endregion

        public ShepherdsSheep( Serial serial ) : base( serial )
		{
		}

		public override void OnCombatantChange()
		{
            if (Combatant != null && Combatant.Alive && m_shepherd != null && m_shepherd.Combatant == null)
            {
                    m_shepherd.Combatant = Combatant;
                    m_shepherd.Say("Hey, leave my sheep alone!");

                    if (m_dog != null && m_dog.Combatant == null)
                    {
                        m_dog.Combatant = Combatant;
                    }
            }
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); 

			writer.WriteDeltaTime( m_NextWoolTime );

			writer.Write( m_shepherd );
            writer.Write(m_dog);

		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					NextWoolTime = reader.ReadDeltaTime();
					break;
				}
			}

			m_shepherd = (Shepherd)reader.ReadMobile();
            m_dog = (ShepherdsDog)reader.ReadMobile();
		}
	}
}