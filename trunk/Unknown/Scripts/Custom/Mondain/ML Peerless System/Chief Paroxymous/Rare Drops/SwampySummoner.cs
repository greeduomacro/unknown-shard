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
    public class SwampySummoner : Item 
    { 
        [Constructable] 
        public SwampySummoner() : base( 9753 ) 
        { 
            Hue = 0x851; 
            Movable = true; 
            Name = "Proxymous Swamp Dragon. Will bond instantly on double Click."; 
        } 

        public SwampySummoner( Serial serial ) : base( serial ) 
        { 
        } 

        public override void OnDoubleClick( Mobile from ) 
        { 
           ProxySwampy ps = new ProxySwampy();
ps.Controlled = true;
ps.ControlMaster = from;
ps.Location = from.Location;
ps.Map = from.Map;
ps.IsBonded = true;
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