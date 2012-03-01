/* This file was created with
Ilutzio's Questmaker. Enjoy! */
using System;using Server;namespace Server.Items
{
public class TaintedSeeds : Item
{
[Constructable]
public TaintedSeeds() : this( 1 )
{}
[Constructable]
public TaintedSeeds( int amountFrom, int amountTo ) : this( Utility.RandomMinMax( amountFrom, amountTo ) )
{}
[Constructable]

///////////The hexagon value ont he line below is the ItemID
public TaintedSeeds( int amount ) : base( 3582 )
{


///////////Item name
Name = "Tainted Seeds";

///////////Item hue
Hue = 1161;

///////////Stackable
Stackable = false;

///////////Weight of one item
Weight = 0.01;
Amount = amount;

}
public TaintedSeeds( Serial serial ) : base( serial )
{}
public override void Serialize( GenericWriter writer )
{
base.Serialize( writer );
writer.Write( (int) 0 ); // version
}
public override void Deserialize( GenericReader reader )
{
base.Deserialize( reader ); int version = reader.ReadInt(); }}}
