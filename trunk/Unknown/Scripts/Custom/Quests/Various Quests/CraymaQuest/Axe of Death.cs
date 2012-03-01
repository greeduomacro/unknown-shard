//////////////////////
//Created by KyleMan//
//////////////////////
using System;
using Server;

namespace Server.Items
{
	public class DeathAxe : ExecutionersAxe
	{
	 	public override int ArtifactRarity{ get{ return 15; } }
	 	public override int InitMinHits{ get{ return 250; } }
	 	public override int InitMaxHits{ get{ return 255; } }
	 	[Constructable]
	 	public DeathAxe()
	 	{
	 	 	Name = "Axe of Death";
	 	 	Hue = 1157;
	 	 	Attributes.SpellChanneling = 1;
	 	 	//Attributes.BonusStr = 10;
	 	 	Attributes.BonusHits = 5;
	 	 	Attributes.BonusInt = 10;
	 	 	//Attributes.BonusMana = 5;
	 	 	//Attributes.RegenHits = 5;
	 	 	Attributes.RegenMana = 5;
	 	 	Attributes.AttackChance = 20;
	 	 	Attributes.WeaponDamage = 50;
	 	 	Attributes.WeaponSpeed = 20;
	 	 	WeaponAttributes.HitFireArea = 30;
	 	 	WeaponAttributes.ResistFireBonus = 10;
	 	 	WeaponAttributes.DurabilityBonus = 70;
	 	 	WeaponAttributes.SelfRepair = 20;
	 	 	Attributes.CastSpeed = 2;
	 	 	//Attributes.CastRecovery = 1;
	 	 	WeaponAttributes.HitFireball = 60;
	 	}

	 	public DeathAxe(Serial serial) : base( serial )
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
