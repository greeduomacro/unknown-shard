//Written By Milkman Dan 2006
//Property of DemonicRidez.com
using System;
using Server;
using Server.Items;

namespace Server.Items
{
              public class CorruptedTree: Item
{
              
              [Constructable]
              public CorruptedTree() : base( 8442 )
{
                          
						  Hue = Utility.RandomList( 0x0, 0x973, 0x966, 0x96D, 0x972, 0x8A5, 0x979, 0x89F, 0x8AB, 0x489, 1151, 1175 );
                          Weight = 2;
                          Name = "Corrupted Tree";
						  LootType = LootType.Cursed;
                          
 
                  }
              public CorruptedTree( Serial serial ) : base( serial )
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
