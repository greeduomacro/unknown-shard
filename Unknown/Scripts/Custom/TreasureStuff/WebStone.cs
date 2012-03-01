using System;
using System.Collections.Generic;

using Server;

namespace Server.Items
{
    public class WebStone : Item
    {
        private string m_Url;
        
        [CommandProperty( AccessLevel.GameMaster )]
        public string Url
        {
            get
            {
                return m_Url;
            }
            set
            {
                m_Url = value;
            }
        }

        [Constructable]
        public WebStone() : this( "Generic Web Stone" )
        {
        }

        [Constructable]
        public WebStone( string name ) : base( 0xED4 )
        {
            Name = name;
        }

        public override void OnDoubleClick( Mobile from )
        {
            from.LaunchBrowser( m_Url );
        }

        public override void GetProperties( ObjectPropertyList list )
        {
            base.GetProperties( list );

            list.Add( "Web Stone" );
        }

        public WebStone( Serial serial ) : base( serial )
        {
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
            m_Url = reader.ReadString();
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int)0 );
            writer.Write( (string)m_Url );
        }
    }
}
