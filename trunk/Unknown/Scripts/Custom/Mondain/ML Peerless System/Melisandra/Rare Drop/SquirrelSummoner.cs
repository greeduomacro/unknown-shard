using System;
using System.Net;
using Server;
using Server.Accounting;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Regions;
using System.Collections;
using Server.Engines.PartySystem;

namespace Server.Items 
{ 
    public class SquirrelSummoner : Item 
    { 
        [Constructable] 
        public SquirrelSummoner() : base( 11671 ) 
        { 
            Hue = 1150; 
            Movable = true; 
            Name = "Albino Squirrel. Will bond instantly on double Click."; 
        } 

        public SquirrelSummoner( Serial serial ) : base( serial ) 
        { 
        } 

        public override void OnDoubleClick( Mobile from ) 
        { 
           squirrel s = new squirrel();
s.Controlled = true;
s.ControlMaster = from;
s.Location = from.Location;
s.Map = from.Map;
s.IsBonded = true;
 this.Delete();
        }
        public override void Serialize( GenericWriter writer ) 
        { 
            base.Serialize( writer ); 

            writer.Write( (int) 0 ); // version 
        } 

        public override void Deserialize( GenericReader reader ) 
        { 
            base.Deserialize( reader ); 

            int version = reader.ReadInt(); 
        } 
    } 
}