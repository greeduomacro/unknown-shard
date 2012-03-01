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
    public class GrizzleSummoner : Item 
    { 
        [Constructable] 
        public GrizzleSummoner() : base( 9751 ) 
        { 
            Hue = 0; 
            Movable = true; 
            Name = "Grizzled Mare. Will bond instantly on double Click."; 
        } 

        public GrizzleSummoner( Serial serial ) : base( serial ) 
        { 
        } 

        public override void OnDoubleClick( Mobile from ) 
        { 
           GrizzledMare gm = new GrizzledMare();
gm.Controlled = true;
gm.ControlMaster = from;
gm.Location = from.Location;
gm.Map = from.Map;
gm.IsBonded = true;
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