// Created by Doctor Who

using System;
using Server;
using Server.Items;

namespace Server.Items
{

              public class BearKingsBearMask: BearMask
{
              
              [Constructable]
              public BearKingsBearMask()
{

                          Weight = 2;
                          Name = "Bear King's ";
                          Hue = 1157;
              
              Attributes.AttackChance = 10;
              Attributes.BonusDex = 5;
              Attributes.BonusHits = 5;
              Attributes.BonusInt = 5;
              Attributes.BonusMana = 5;
              Attributes.BonusStam = 2;
              Attributes.CastRecovery = 0;
              Attributes.CastSpeed = 0;
              Attributes.DefendChance = 10;
              Attributes.EnhancePotions = 0;
              Attributes.LowerManaCost = 10;
              Attributes.Luck = 0;
              Attributes.NightSight = 1;
              Attributes.ReflectPhysical = 0;
              Attributes.RegenHits = 5;
              Attributes.SpellChanneling = 0;
              Attributes.WeaponDamage = 10;
                  }
              public BearKingsBearMask( Serial serial ) : base( serial )
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
