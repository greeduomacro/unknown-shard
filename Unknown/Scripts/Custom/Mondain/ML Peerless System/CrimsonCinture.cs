//Written By Milkman Dan 2006
//Property of DemonicRidez.com
using System;
using Server;
using Server.Items;

namespace Server.Items
{
              public class CrimsonCinture: HalfApron
{
              
              [Constructable]
              public CrimsonCinture()
{

                          Weight = 2;
                          Name = "CrimsonCinture";
                          Hue = 1152;
              
              Attributes.BonusDex = 5;
              Attributes.BonusHits = 10;
              Attributes.RegenHits = 2;
              //LootType = LootType.Blessed; 
                  }
              public CrimsonCinture( Serial serial ) : base( serial )
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
