//Property of Milkman Dan
// Demonic Ridez http://www.demonicridez.com
using System;using Server;namespace Server.Items
{
public class ProxyHead : Item
{
[Constructable]
public ProxyHead() : this( 1 )
{}
[Constructable]
public ProxyHead( int amountFrom, int amountTo ) : this( Utility.RandomMinMax( amountFrom, amountTo ) )
{}
[Constructable]

///////////The hexagon value ont he line below is the ItemID
public ProxyHead( int amount ) : base( 7401 )
{


///////////Item name
Name = "Proxy Head";

///////////Item hue
Hue = 1372;

///////////Stackable
Stackable = false;

///////////Weight of one item
Weight = 0.01;
Amount = amount;

}
public ProxyHead( Serial serial ) : base( serial )
{}
public override void Serialize( GenericWriter writer )
{
base.Serialize( writer );
writer.Write( (int) 0 ); // version
}
public override void Deserialize( GenericReader reader )
{
base.Deserialize( reader ); int version = reader.ReadInt(); }}}
