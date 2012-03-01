using System;
using System.Collections;
using Server;
using Server.Gumps; 
using Server.Network; 
using Server.Misc; 
using Server.Mobiles;
using Server.Targeting;
using Server.Items;

namespace Server.Items
{
	public class TreasureShovel : Item
	{
		private int m_Uses;
        private static int temp = Utility.RandomMinMax(100, 150);
		private bool m_IsDigging;
        private Point3D m_First;
        private Point3D m_Second;
        private Point3D m_Third;
        private Point3D m_Fourth;
        private Point3D m_Fifth;
        private int m_Count;

        [CommandProperty(AccessLevel.GameMaster)]
        public Point3D First
        {
            get { return m_First; }
            set { m_First = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Point3D Second
        {
            get { return m_Second; }
            set { m_Second = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Point3D Third
        {
            get { return m_Third; }
            set { m_Third = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Point3D Fourth
        {
            get { return m_Fourth; }
            set { m_Fourth = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Point3D Fifth
        {
            get { return m_Fifth; }
            set { m_Fifth = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Count
        {
            get { return m_Count; }
            set { m_Count = value; InvalidateProperties(); }
        }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Uses
		{
			get{ return m_Uses; }
			set{ m_Uses = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsDigging
		{
			get{ return m_IsDigging; }
			set{ m_IsDigging = value; }
		}

		[Constructable]
		public TreasureShovel() : this( temp )
		{
            m_Uses = temp;
			Weight = 0.0;
			Hue = 0x501;
			Name = "a treasure hunter's shovel";
            m_Count = 0;
            m_First = new Point3D(0,0,0);
            m_Second = new Point3D(0, 0, 0);
            m_Third = new Point3D(0, 0, 0);
            m_Fourth = new Point3D(0, 0, 0);
            m_Fifth = new Point3D(0, 0, 0);
        }

		[Constructable]
		public TreasureShovel(int uses) : base( 0xF39 )
		{
			Weight = 0.0;
			Hue = 0x501;
			Name = "a treasure hunter's shovel";
			m_Uses = uses;
            if (m_Uses <= 1)
                m_Uses = Utility.RandomMinMax( 100, 150 );
            m_Count = 0;
            m_First = new Point3D(0, 0, 0);
            m_Second = new Point3D(0, 0, 0);
            m_Third = new Point3D(0, 0, 0);
            m_Fourth = new Point3D(0, 0, 0);
            m_Fifth = new Point3D(0, 0, 0);
        }

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			list.Add( 1060662, "Uses\t{0}", m_Uses );
		}

		public TreasureShovel( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
            bool canDig = true;
			if ( !IsChildOf (from.Backpack))
			{
				from.SendMessage( "You must have this in your backpack in order to dig." );
                canDig = false;
			}
            else if (from.Mounted)
            {
                from.SendMessage("You can't dig while mounted.");
                canDig = false;
            }
            else if (from.IsBodyMod && !from.Body.IsHuman)
            {
                from.SendMessage("You can't dig while polymorphed.");
                canDig = false;
            }

			if ( !IsDigging )
			{
                if (canDig)
                {
                    from.Target = new GroundTarget(this, from);
                    from.SendMessage("Where would you like it dig?");
                }
			}
			else
			{
				from.SendMessage( "You are already digging!" );
			}
		}

        private static void GetRandomAOSStats(out int attributeCount, out int min, out int max)
        {
            int rnd = Utility.Random(15);

            if (rnd < 2)
            {
                attributeCount = Utility.RandomMinMax(5, 9);
                min = 50; max = 100;
            }
            else if (rnd < 4)
            {
                attributeCount = Utility.RandomMinMax(4, 8);
                min = 40; max = 80;
            }
            else if (rnd < 6)
            {
                attributeCount = Utility.RandomMinMax(3, 6);
                min = 30; max = 60;
            }
            else if (rnd < 8)
            {
                attributeCount = Utility.RandomMinMax(2, 5);
                min = 20; max = 50;
            }
            else if (rnd < 10)
            {
                attributeCount = Utility.RandomMinMax(1, 4);
                min = 10; max = 40;
            }
            else
            {
                attributeCount = 1;
                min = 10; max = 30;
            }
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version 

			writer.Write( m_Uses );
			writer.Write( m_IsDigging );
            writer.Write( m_First );
            writer.Write( m_Second );
            writer.Write( m_Third );
            writer.Write( m_Fourth );
            writer.Write( m_Fifth );
            writer.Write( m_Count );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			m_Uses = reader.ReadInt();
			m_IsDigging = reader.ReadBool();
            m_First = reader.ReadPoint3D();
            m_Second = reader.ReadPoint3D();
            m_Third = reader.ReadPoint3D();
            m_Fourth = reader.ReadPoint3D();
            m_Fifth = reader.ReadPoint3D();
            m_Count = reader.ReadInt();
        }

		private class DigTimer : Timer
		{ 
			private Mobile m_From;
			private TreasureShovel m_Item;

			public DigTimer( Mobile from, TreasureShovel shovel, TimeSpan duration ) : base( duration ) 
			{ 
				Priority = TimerPriority.OneSecond;
				m_From = from;
				m_Item = shovel;
			}

			protected override void OnTick() 
			{
				Item gem = Loot.RandomGem();
				Item reg = Loot.RandomPossibleReagent();

				Item loot;
				loot = Loot.RandomArmorOrShieldOrWeaponOrJewelry();

				if ( m_Item != null )
					m_Item.IsDigging = false;

				if ( loot is BaseWeapon )
				{
					BaseWeapon weapon = (BaseWeapon)loot;

					int attributeCount;
					int min, max;

					GetRandomAOSStats( out attributeCount, out min, out max );

					BaseRunicTool.ApplyAttributesTo( weapon, attributeCount, min, max );
				}
				else if ( loot is BaseArmor )
				{
					BaseArmor armor = (BaseArmor)loot;

					int attributeCount;
					int min, max;

					GetRandomAOSStats( out attributeCount, out min, out max );

					BaseRunicTool.ApplyAttributesTo( armor, attributeCount, min, max );
				}
				else if ( loot is BaseJewel )
				{
					int attributeCount;
					int min, max;

					GetRandomAOSStats( out attributeCount, out min, out max );

					BaseRunicTool.ApplyAttributesTo( (BaseJewel)loot, attributeCount, min, max );
				}

                if (m_From.Skills[SkillName.Mining].Value < 15.1)
				{
					if ( Utility.Random( 100 ) < 65 )
					{
						m_From.SendMessage( "You fail to dig anything up." );
                        if (Utility.RandomDouble() < 0.04)
                            m_From.CheckSkill(SkillName.Mining, 0.0, 120.0);	//Skill check for gain
                    }
					else
					{
						switch ( Utility.Random ( 3 ) )
						{
							case 0:
							m_From.AddToBackpack( gem );
							m_From.SendMessage( "You dig up a gem." );
							break;

							case 1:
							m_From.AddToBackpack( reg );
							m_From.SendMessage( "You dig up a reagent." );
							break;

							case 2:
							m_From.AddToBackpack( new Bone( Utility.RandomMinMax( 2, 10 ) ) );
							m_From.SendMessage( "You dig up some bones." );
							break;
						}
                        if (Utility.RandomDouble() < 0.08)
                            m_From.CheckSkill(SkillName.Mining, 0.0, 120.0);	//Skill check for gain
					}
				}
                else if (m_From.Skills[SkillName.Mining].Value < 35.1)
				{
					if ( Utility.Random( 100 ) < 55 )
					{
						m_From.SendMessage( "You fail to dig anything up." );
                        if (Utility.RandomDouble() < 0.04)
                            m_From.CheckSkill(SkillName.Mining, 0.0, 120.0);	//Skill check for gain
                    }
					else
					{
						gem.Amount = Utility.RandomMinMax( 2, 4 );
						reg.Amount = Utility.RandomMinMax( 2, 4 );

						switch ( Utility.Random ( 5 ) )
						{
							case 0:
							m_From.AddToBackpack( gem );
							m_From.SendMessage( "You dig up some gems." );
							break;

							case 1:
							m_From.AddToBackpack( reg );
							m_From.SendMessage( "You dig up some reagents." );
							break;

							case 2:
							m_From.AddToBackpack( new Bone( Utility.RandomMinMax( 2, 10 ) ) );
							m_From.SendMessage( "You dig up some bones." );
							break;

							case 3:
							m_From.AddToBackpack( Loot.RandomScroll( 0, 20, SpellbookType.Regular ) );
							m_From.SendMessage( "You dig up a scroll." );
							break;

							case 4:
							m_From.AddToBackpack( Loot.RandomScroll( 0, 5, SpellbookType.Necromancer ) );
							m_From.SendMessage( "You dig up a scroll." );
							break;
						}
                        if (Utility.RandomDouble() < 0.08)
                            m_From.CheckSkill(SkillName.Mining, 0.0, 120.0);	//Skill check for gain
					}
				}
                else if (m_From.Skills[SkillName.Mining].Value < 50.1)
				{
					if ( Utility.Random( 100 ) < 45 )
					{
						m_From.SendMessage( "You fail to dig anything up." );
                        if (Utility.RandomDouble() < 0.04)
                            m_From.CheckSkill(SkillName.Mining, 0.0, 120.0);	//Skill check for gain
                    }
					else
					{
						gem.Amount = Utility.RandomMinMax( 2, 10 );
						reg.Amount = Utility.RandomMinMax( 2, 10 );

						switch ( Utility.Random ( 6 ) )
						{
							case 0:
							m_From.AddToBackpack( gem );
							m_From.SendMessage( "You dig up some gems." );
							break;

							case 1:
							m_From.AddToBackpack( reg );
							m_From.SendMessage( "You dig up some reagents." );
							break;

							case 2:
							m_From.AddToBackpack( loot );
							m_From.SendMessage( "You dig up some equipment." );
							break;

							case 3:
							m_From.AddToBackpack( Loot.RandomScroll( 0, 40, SpellbookType.Regular ) );
							m_From.SendMessage( "You dig up a scroll." );
							break;

							case 4:
							m_From.AddToBackpack( Loot.RandomScroll( 0, 10, SpellbookType.Necromancer ) );
							m_From.SendMessage( "You dig up a scroll." );
							break;

							case 5:
							m_From.AddToBackpack( new Bone( Utility.RandomMinMax( 2, 10 ) ) );
							m_From.SendMessage( "You dig up some bones." );
							break;
						}
                        if (Utility.RandomDouble() < 0.08)
                            m_From.CheckSkill(SkillName.Mining, 0.0, 120.0);	//Skill check for gain
					}
				}
                else if (m_From.Skills[SkillName.Mining].Value < 75.1)
				{
					if ( Utility.Random( 100 ) < 35 )
					{
						m_From.SendMessage( "You fail to dig anything up." );
                        if (Utility.RandomDouble() < 0.04)
                            m_From.CheckSkill(SkillName.Mining, 0.0, 120.0);	//Skill check for gain
                    }
					else
					{
						gem.Amount = Utility.RandomMinMax( 2, 20 );
						reg.Amount = Utility.RandomMinMax( 2, 20 );

						switch ( Utility.Random ( 7 ) )
						{
							case 0:
							m_From.AddToBackpack( gem );
							m_From.SendMessage( "You dig up some gems." );
							break;

							case 1:
							m_From.AddToBackpack( reg );
							m_From.SendMessage( "You dig up some reagents." );
							break;

							case 2:
							m_From.AddToBackpack( loot );
							m_From.SendMessage( "You dig up some equipment." );
							break;

							case 3:
							m_From.AddToBackpack( Loot.RandomScroll( 0, 50, SpellbookType.Regular ) );
							m_From.SendMessage( "You dig up a scroll." );
							break;

							case 4:
							m_From.AddToBackpack( Loot.RandomScroll( 0, 13, SpellbookType.Necromancer ) );
							m_From.SendMessage( "You dig up a scroll." );
							break;
	
							case 5:
							m_From.AddToBackpack( new Bone( Utility.RandomMinMax( 2, 10 ) ) );
							m_From.SendMessage( "You dig up some bones." );
							break;

							case 6:
							m_From.AddToBackpack( new Gold( 50, 150 ) );
							m_From.SendMessage( "You dig up some gold." );
							break;
						}
                        if (Utility.RandomDouble() < 0.08)
                            m_From.CheckSkill(SkillName.Mining, 0.0, 120.0);	//Skill check for gain
					}
				}
                else if (m_From.Skills[SkillName.Mining].Value < 90.1)
				{
					if ( Utility.Random( 100 ) < 25 )
					{
						m_From.SendMessage( "You fail to dig anything up." );
                        if (Utility.RandomDouble() < 0.04)
                            m_From.CheckSkill(SkillName.Mining, 0.0, 120.0);	//Skill check for gain
                    }
					else
					{
						gem.Amount = Utility.RandomMinMax( 2, 30 );
						reg.Amount = Utility.RandomMinMax( 2, 30 );

						switch ( Utility.Random ( 9 ) )
						{
							case 0:
							m_From.AddToBackpack( gem );
							m_From.SendMessage( "You dig up some gems." );
							break;

							case 1:
							m_From.AddToBackpack( reg );
							m_From.SendMessage( "You dig up some reagents." );
							break;

							case 2:
							m_From.AddToBackpack( loot );
							m_From.SendMessage( "You dig up some equipment." );
							break;

							case 3:
							m_From.AddToBackpack( Loot.RandomScroll( 0, 63, SpellbookType.Regular ) );
							m_From.SendMessage( "You dig up a scroll." );
							break;

							case 4:
							m_From.AddToBackpack( Loot.RandomScroll( 0, 15, SpellbookType.Necromancer ) );
							m_From.SendMessage( "You dig up a scroll." );
							break;

							case 5:
							m_From.AddToBackpack( new Bone( Utility.RandomMinMax( 2, 10 ) ) );
							m_From.SendMessage( "You dig up some bones." );
							break;

							case 6:
							m_From.AddToBackpack( new Gold( 50, 150 ) );
							m_From.SendMessage( "You dig up some gold." );
							break;

							case 7:
                                if (m_From.Map == Map.Trammel || m_From.Map == Map.Felucca)
                                {
                                    m_From.AddToBackpack(new TreasureMap(Utility.Random(1, 3), m_From.Map));
                                    m_From.SendMessage("You dig up a treasure map.");
                                }
                                else
                                {/*
                                    switch (Utility.Random(1, 8))
                                    {
                                        case 1: m_From.AddToBackpack(new AlchemistBag()); break;
                                        case 2: m_From.AddToBackpack(new ToolBag()); break;
                                        case 3: m_From.AddToBackpack(new TailorKit()); break;
                                        case 4: m_From.AddToBackpack(new LumberBag()); break;
                                        case 5: m_From.AddToBackpack(new MinersBag()); break;
                                        case 6: m_From.AddToBackpack(new CampingKit()); break;
                                        case 7: m_From.AddToBackpack(new MedKit()); break;
                                        case 8:
                                            {
                                                int swtcha = Utility.RandomList(60, 70, 80, 90, 100);
                                                int swtchb = Utility.RandomList(10, 20, 30, 40, 50);
                                                if (Utility.RandomBool())
                                                    m_From.AddToBackpack(new BackpackOfReduction(swtcha));
                                                else
                                                    m_From.AddToBackpack(new BackpackOfReduction(swtchb));
                                            } break;
                                    }
                                    m_From.SendMessage("You dig up a special bag.");
                                */}
                                break;

                            case 8:
                                {
                                    m_From.AddToBackpack(new ArcaneGem());
                                    m_From.SendMessage("You dig up a strange, glowing stone.");
                                }
                                break;
						}
                        if (Utility.RandomDouble() < 0.08)
                            m_From.CheckSkill(SkillName.Mining, 0.0, 120.0);	//Skill check for gain
					}
				}
                else if (m_From.Skills[SkillName.Mining].Value >= 90.1 )
				{
					if ( Utility.Random( 100 ) < 7 )
					{
						m_From.SendMessage( "You dig up a relic." );/*
						switch ( Utility.Random ( 7 ) )
						{
							case 0: m_From.AddToBackpack( new ArmoredRobe() ); break;
							case 1: m_From.AddToBackpack( new ButchersResolve() ); break;
							case 2: m_From.AddToBackpack( new FollowerOfTheOldLord() ); break;
							case 3: m_From.AddToBackpack( new SkirtOfTheAmazon() ); break;
							case 4: m_From.AddToBackpack( new HolyHammerOfExorcism() ); break;
                            case 5: m_From.AddToBackpack( new FountainOfLifeDeed() ); break;
                            case 6: m_From.AddToBackpack( new BoxOfTransmutation() ); break;
						}*/
					}
					else
					{
						gem.Amount = Utility.RandomMinMax( 2, 40 );
						reg.Amount = Utility.RandomMinMax( 2, 40 );

						switch ( Utility.Random ( 9 ) )
						{
							case 0:
							m_From.AddToBackpack( gem );
							m_From.SendMessage( "You dig up some gems." );
							break;

							case 1:
							m_From.AddToBackpack( reg );
							m_From.SendMessage( "You dig up some reagents." );
							break;

							case 2:
							m_From.AddToBackpack( loot );
							m_From.SendMessage( "You dig up some equipment." );
							break;

							case 3:
							m_From.AddToBackpack( Loot.RandomScroll( 0, 63, SpellbookType.Regular ) );
							m_From.SendMessage( "You dig up a scroll." );
							break;

							case 4:
							m_From.AddToBackpack( Loot.RandomScroll( 0, 15, SpellbookType.Necromancer ) );
							m_From.SendMessage( "You dig up a scroll." );
							break;

							case 5:
							m_From.AddToBackpack( new Bone( Utility.RandomMinMax( 2, 10 ) ) );
							m_From.SendMessage( "You dig up some bones." );
							break;

							case 6:
							m_From.AddToBackpack( new Gold( 50, 150 ) );
							m_From.SendMessage( "You dig up some gold." );
							break;

							case 7:
                                if (m_From.Map == Map.Trammel || m_From.Map == Map.Felucca)
                                {
                                    m_From.AddToBackpack(new TreasureMap(Utility.Random(3, 6), m_From.Map));
                                    m_From.SendMessage("You dig up a treasure map.");
                                }
                                else
                                { 
                                    switch (Utility.Random(1, 8))
                                    {
                                        case 1: m_From.AddToBackpack(new Bag()); break;
                                        case 2: m_From.AddToBackpack(new Bag()); break;
                                        case 3: m_From.AddToBackpack(new Bag()); break;
                                        case 4: m_From.AddToBackpack(new Bag()); break;
                                        case 5: m_From.AddToBackpack(new Bag()); break;
                                        case 6: m_From.AddToBackpack(new Bag()); break;
                                        case 7: m_From.AddToBackpack(new Bag()); break;
                                        case 8:
                                            {
                                                int swtch = Utility.RandomList(10, 20, 30, 40, 50, 60, 70, 80, 90);
                                                if (Utility.RandomBool())
                                                    m_From.AddToBackpack(new BackpackOfReduction());
                                                else
                                                    m_From.AddToBackpack(new BackpackOfReduction(swtch));
                                            } break;
                                    }
                                    m_From.SendMessage("You dig up a special bag.");
                                }
                                break;

                            case 8:
                                {
                                    m_From.AddToBackpack(new ArcaneGem());
                                    m_From.SendMessage("You dig up a strange, glowing stone.");
                                    //if (Utility.RandomDouble() <= 0.05) { m_From.AddToBackpack(PowerScroll.CreateRandom(5, 20)); m_From.SendMessage("You dig up a strange scroll."); }
                                }
                                break;
						}
                        if (Utility.RandomDouble() < 0.08)
                            m_From.CheckSkill(SkillName.Mining, 0.0, 120.0);	//Skill check for gain
					}
				}
				else
				{
					m_From.SendMessage( "You fail to dig anything up." );
                    if( Utility.RandomDouble() < 0.04 )
                        m_From.CheckSkill(SkillName.Mining, 0.0, 120.0);	//Skill check for gain
                }

				Stop();
			}
		}

		private class GroundTarget : Target
		{
			public static int[] m_Ground = new int[]
			{
				3795, 3807, 3808, 3809, 3810, 3816, //Grave ItemIDs 
			    
                // Mountains and Caves
                220, 221, 222, 223, 224, 225, 226, 227, 228, 229,
				230, 231, 236, 237, 238, 239, 240, 241, 242, 243,
				244, 245, 246, 247, 252, 253, 254, 255, 256, 257,
				258, 259, 260, 261, 262, 263, 268, 269, 270, 271,
				272, 273, 274, 275, 276, 277, 278, 279, 286, 287,
				288, 289, 290, 291, 292, 293, 294, 296, 296, 297,
				321, 322, 323, 324, 467, 468, 469, 470, 471, 472,
				473, 474, 476, 477, 478, 479, 480, 481, 482, 483,
				484, 485, 486, 487, 492, 493, 494, 495, 543, 544,
				545, 546, 547, 548, 549, 550, 551, 552, 553, 554,
				555, 556, 557, 558, 559, 560, 561, 562, 563, 564,
				565, 566, 567, 568, 569, 570, 571, 572, 573, 574,
				575, 576, 577, 578, 579, 581, 582, 583, 584, 585,
				586, 587, 588, 589, 590, 591, 592, 593, 594, 595,
				596, 597, 598, 599, 600, 601, 610, 611, 612, 613,

				1010, 1741, 1742, 1743, 1744, 1745, 1746, 1747, 1748, 1749,
				1750, 1751, 1752, 1753, 1754, 1755, 1756, 1757, 1771, 1772,
				1773, 1774, 1775, 1776, 1777, 1778, 1779, 1780, 1781, 1782,
				1783, 1784, 1785, 1786, 1787, 1788, 1789, 1790, 1801, 1802,
				1803, 1804, 1805, 1806, 1807, 1808, 1809, 1811, 1812, 1813,
				1814, 1815, 1816, 1817, 1818, 1819, 1820, 1821, 1822, 1823,
				1824, 1831, 1832, 1833, 1834, 1835, 1836, 1837, 1838, 1839,
				1840, 1841, 1842, 1843, 1844, 1845, 1846, 1847, 1848, 1849,
				1850, 1851, 1852, 1853, 1854, 1861, 1862, 1863, 1864, 1865,
				1866, 1867, 1868, 1869, 1870, 1871, 1872, 1873, 1874, 1875,
				1876, 1877, 1878, 1879, 1880, 1881, 1882, 1883, 1884, 1981,
				1982, 1983, 1984, 1985, 1986, 1987, 1988, 1989, 1990, 1991,
				1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999, 2000, 2001,
				2002, 2003, 2004, 2028, 2029, 2030, 2031, 2032, 2033, 2100,
				2101, 2102, 2103, 2104, 2105,

				0x453B, 0x453C, 0x453D, 0x453E, 0x453F, 0x4540, 0x4541,
				0x4542, 0x4543, 0x4544,	0x4545, 0x4546, 0x4547, 0x4548,
				0x4549, 0x454A, 0x454B, 0x454C, 0x454D, 0x454E,	0x454F,
                //End Mountains and Caves

                //Sand
				22, 23, 24, 25, 26, 27, 28, 29, 30, 31,
				32, 33, 34, 35, 36, 37, 38, 39, 40, 41,
				42, 43, 44, 45, 46, 47, 48, 49, 50, 51,
				52, 53, 54, 55, 56, 57, 58, 59, 60, 61,
				62, 68, 69, 70, 71, 72, 73, 74, 75,

				286, 287, 288, 289, 290, 291, 292, 293, 294, 295,
				296, 297, 298, 299, 300, 301, 402, 424, 425, 426,
				427, 441, 442, 443, 444, 445, 446, 447, 448, 449,
				450, 451, 452, 453, 454, 455, 456, 457, 458, 459,
				460, 461, 462, 463, 464, 465, 642, 643, 644, 645,
				650, 651, 652, 653, 654, 655, 656, 657, 821, 822,
				823, 824, 825, 826, 827, 828, 833, 834, 835, 836,
				845, 846, 847, 848, 849, 850, 851, 852, 857, 858,
				859, 860, 951, 952, 953, 954, 955, 956, 957, 958,
				967, 968, 969, 970,

				1447, 1448, 1449, 1450, 1451, 1452, 1453, 1454, 1455,
				1456, 1457, 1458, 1611, 1612, 1613, 1614, 1615, 1616,
				1617, 1618, 1623, 1624, 1625, 1626, 1635, 1636, 1637,
				1638, 1639, 1640, 1641, 1642, 1647, 1648, 1649, 1650
                // End Sand
			};

			private TreasureShovel m_Item;
			private Mobile m_From;

            public GroundTarget(TreasureShovel item, Mobile from) : base(6, true, TargetFlags.None)
			{
				m_Item = item;
				m_From = from;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
                bool isGround = false;
                IPoint3D p = targeted as IPoint3D;

			    if (p == null)
				return;
                Point3D loc = new Point3D( p );

                if (m_Item.Count != 0)
                {
                    if (Utility.InRange(loc, m_Item.First, 2))
                    {
                        m_From.SendMessage("You are to close to your last digging location.");
                        return;
                    }
                    else if (Utility.InRange(loc, m_Item.Second, 2))
                    {
                        m_From.SendMessage("You are to close to your last digging location.");
                        return;
                    }
                    else if (Utility.InRange(loc, m_Item.Third, 2))
                    {
                        m_From.SendMessage("You are to close to your last digging location.");
                        return;
                    }
                    else if (Utility.InRange(loc, m_Item.Fourth, 2))
                    {
                        m_From.SendMessage("You are to close to your last digging location.");
                        return;
                    }
                    else if (Utility.InRange(loc, m_Item.Fifth, 2))
                    {
                        m_From.SendMessage("You are to close to your last digging location.");
                        return;
                    }
                    if ((Utility.InRange(loc, m_Item.First, 2) || Utility.InRange(loc, m_Item.Second, 2) || Utility.InRange(loc, m_Item.Third, 2) || Utility.InRange(loc, m_Item.Fourth, 2) || Utility.InRange(loc, m_Item.Fifth, 2)))
                    {
                        m_From.SendMessage("You are to close to one of your last five digging locations.");
                        return;
                    }
                }
                switch (m_Item.Count)
                {
                    case 0:
                        m_Item.First = loc; m_Item.Third = new Point3D(0, 0, 0); m_Item.Count += 1; break;
                    case 1:
                        m_Item.Second = loc; m_Item.Fourth = new Point3D(0, 0, 0); m_Item.Count += 1; break;
                    case 2:
                        m_Item.Third = loc; m_Item.Fifth = new Point3D(0, 0, 0); m_Item.Count += 1; break;
                    case 3:
                        m_Item.Fourth = loc; m_Item.First = new Point3D(0, 0, 0); ; m_Item.Count += 1; break;
                    case 4:
                        m_Item.Fifth = loc; m_Item.Second = new Point3D(0, 0, 0); m_Item.Count += 1; break;
                    case 5: m_Item.Count = 0; break;
                    default: m_Item.Count = 0; break; // Added as a Just in case, shouldn't get past 5!!!
                }

                if (targeted is LandTarget)
                {
                    if (Utility.InsensitiveCompare(((LandTarget)targeted).Name, "grass") == 0 || Utility.InsensitiveCompare(((LandTarget)targeted).Name, "snow") == 0 || Utility.InsensitiveCompare(((LandTarget)targeted).Name, "forest") == 0 || Utility.InsensitiveCompare(((LandTarget)targeted).Name, "grasses") == 0 || Utility.InsensitiveCompare(((LandTarget)targeted).Name, "dirt") == 0 || Utility.InsensitiveCompare(((LandTarget)targeted).Name, "sand") == 0 || Utility.InsensitiveCompare(((LandTarget)targeted).Name, "rock") == 0)
                        isGround = true;

                    if (isGround)
                    {
                        m_Item.Uses -= 1;
                        if (m_Item.Uses <= 0)
                        {
                            m_Item.Delete();
                            if (m_From != null)
                                m_From.SendMessage("Your shovel has broken.");
                        }

                        if (m_From != null)
                            m_From.SendMessage("You start to dig.");

                        DigTimer dt = new DigTimer(m_From, m_Item, TimeSpan.FromSeconds(10.0));
                        dt.Start();
                        m_From.PlaySound(Utility.RandomList(0x125, 0x126));
                        m_From.Animate(11, 1, 3, true, true, 0);
                        m_Item.IsDigging = true;
                    }
                }
				else if ( targeted is Item )
				{
					Item i = (Item)targeted;

					foreach ( int check in m_Ground )
					{
  						if ( check == i.ItemID )
    							isGround = true;
					}
				
					if ( isGround == true )
					{
						m_Item.Uses -= 1;
						if ( m_Item.Uses == 0 )
						{
							m_Item.Delete();
							if ( m_From != null )
								m_From.SendMessage( "Your shovel has broken." );
						}

						if ( m_From != null )
							m_From.SendMessage( "You start to dig." );

						DigTimer dt = new DigTimer( m_From, m_Item, TimeSpan.FromSeconds( 10.0 ) );
						dt.Start();
						m_From.PlaySound( Utility.RandomList( 0x125, 0x126 ) );
                        m_From.Animate(11, 1, 3, true, true, 0);
                        m_Item.IsDigging = true;
					}
					else
					{
						if ( m_From != null )
							m_From.SendMessage( "You can not dig there." );
					}

				}
                else if (targeted is StaticTarget)
                {
                    StaticTarget i = (StaticTarget)targeted;

                    foreach (int check in m_Ground)
                    {
                        if (check == i.ItemID)
                            isGround = true;
                    }

                    if (isGround)
                    {
                        m_Item.Uses -= 1;
                        if (m_Item.Uses <= 0)
                        {
                            m_Item.Delete();
                            if (m_From != null)
                                m_From.SendMessage("Your shovel has broken.");
                        }

                        if (m_From != null)
                            m_From.SendMessage("You start to dig.");

                        DigTimer dt = new DigTimer(m_From, m_Item, TimeSpan.FromSeconds(10.0));
                        dt.Start();
                        m_From.PlaySound(Utility.RandomList(0x125, 0x126));
                        m_From.Animate(11, 1, 3, true, true, 0);
                        m_Item.IsDigging = true;
                    }
                }
                else
                {
                    m_From.SendMessage("You can not dig there.");
                }
			}
		}
	}
}
