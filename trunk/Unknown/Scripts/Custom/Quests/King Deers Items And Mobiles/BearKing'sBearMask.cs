// Created by Doctor Who

using System;
using Server;
using Server.Items;

namespace Server.Items
{

              public class DeerKingsDeerMask: DeerMask
{
              
              [Constructable]
              public DeerKingsDeerMask()
{

                          Weight = 3;
                          Name = "Deer King's ";
                          Hue = 1145;
              
              Attributes.AttackChance = 10;
              Attributes.BonusDex = 5;
              Attributes.BonusHits = 6;
              Attributes.BonusInt = 5;
              Attributes.BonusMana = 6;
              Attributes.BonusStam = 3;
              Attributes.CastRecovery = 0;
              Attributes.CastSpeed = 0;
              Attributes.DefendChance = 11;
              Attributes.EnhancePotions = 0;
              Attributes.LowerManaCost = 11;
              Attributes.Luck = 0;
              Attributes.NightSight = 1;
              Attributes.ReflectPhysical = 3;
              Attributes.RegenHits = 5;
              Attributes.SpellChanneling = 0;
              Attributes.WeaponDamage = 12;
                  }
              public DeerKingsDeerMask( Serial serial ) : base( serial )
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
