//////////////////////
//Created by KyleMan//
//////////////////////

using System;
using Server;

namespace Server.Items
{
	public class NobleSword : Longsword
	{
	 	public override int ArtifactRarity{ get{ return 15; } }
	 	public override int InitMinHits{ get{ return 250; } }
	 	public override int InitMaxHits{ get{ return 255; } }
	 	[Constructable]
	 	public NobleSword()
	 	{
	 	 	Name = "Noble Sword";
	 	 	Hue = 1259;
	 	 	Attributes.SpellChanneling = 1;
	 	 	Attributes.BonusHits = 10;
	 	 	Attributes.RegenHits = 5;
	 	 	Attributes.AttackChance = 20;
	 	 	Attributes.WeaponDamage = 70;
	 	 	Attributes.WeaponSpeed = 25;
	 	 	//WeaponAttributes.HitFireArea = 40;
	 	 	WeaponAttributes.ResistFireBonus = 20;
	 	 	WeaponAttributes.HitFireball = 70;
	 	}

	 	public NobleSword(Serial serial) : base( serial )
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
