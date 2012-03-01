//Created by Milkman Dan 07/24/2006
using System;
using Server;

namespace Server.Items

{
              
              public class SceptorOfTheChief : Scepter
              {
              
		 public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
                      [Constructable]
                      public SceptorOfTheChief() 
                      {
                                        Weight = 1;
                                        Name = "Sceptor Of The Chief";
                                        Hue = 1150;
              
                                        WeaponAttributes.HitDispel = 100;
                                        WeaponAttributes.HitLeechMana = 60;
                                        WeaponAttributes.ResistPhysicalBonus = 15;
										SkillBonuses.SetValues( 0, SkillName.Tactics, 5.0 );
              
                                        Attributes.RegenHits = 2;
              
              
                     			switch ( Utility.Random( 4 ))
			{
			case 0: SkillBonuses.SetValues( 1, SkillName.Fencing, 5.0 ); break;
			case 1: SkillBonuses.SetValues( 1, SkillName.Swords, 5.0 ); break;
			case 2: SkillBonuses.SetValues( 1, SkillName.Archery, 5.0 ); break;
			case 3: SkillBonuses.SetValues( 1, SkillName.Macing, 5.0 ); break;
			}
			
			}
					  public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy )
		{
			phys = fire = cold = nrgy = 0;
			pois = 100;
		}
					  public SceptorOfTheChief( Serial serial ) : base( serial )  
                                    {
                                    }
              
                      public override void Serialize( GenericWriter writer )
                                    {
                                                      base.Serialize( writer );
              
                                                      writer.Write( (int) 0 );
                                    }
              
                      public override void Deserialize(GenericReader reader)
                                    {
                                                      base.Deserialize( reader );
                            
                                                      int version = reader.ReadInt();
                                    }
                  }
}