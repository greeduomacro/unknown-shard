/* This file was created with
Ilutzio's Questmaker. Enjoy! */
using System;using Server;namespace Server.Items
{
public class LightningVial : Item
{
[Constructable]
public LightningVial() : this( 1 )
{}
[Constructable]
public LightningVial( int amountFrom, int amountTo ) : this( Utility.RandomMinMax( amountFrom, amountTo ) )
{}
[Constructable]

///////////The hexagon value ont he line below is the ItemID
public LightningVial( int amount ) : base( 0xE24 )
{


///////////Item name
Name = "LightningVial";

///////////Item hue
Hue = 2964;

///////////Stackable
Stackable = true;

///////////Weight of one item
Weight = 0.01;
Amount = amount;

}
public LightningVial( Serial serial ) : base( serial )
{}
public override void Serialize( GenericWriter writer )
{
base.Serialize( writer );
writer.Write( (int) 0 ); // version
}
public override void Deserialize( GenericReader reader )
{
base.Deserialize( reader ); int version = reader.ReadInt(); }}}
