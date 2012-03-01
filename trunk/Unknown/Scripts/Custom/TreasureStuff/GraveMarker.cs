// A RunUO script by David

using System;
using Server;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
    #region GraveMarker class
    [FlipableAttribute( 4453,4454,4455,4456,4457,4458,4459,4460,4461,4462,4463,4464,4465,4466,4467,4468,4469,4470,4471,4472,4473,4474,4475,4476,4477,4478,4479,4480,4481,4482,4483,4484 )]
	public class GraveMarker : Item
	{
		private string i_Epitaph = "A Gravestone";

		[CommandProperty( AccessLevel.GameMaster )]
		public string Epitaph
		{
			get { return i_Epitaph; }
			set 
			{ 
				i_Epitaph = value; 
				InvalidateProperties(); 
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Style
		{
			get { return this.ItemID - 4453; }
            set { this.ItemID = value % 32 + 4453; }
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( i_Epitaph.Replace( "<BR>", " " ) );
		}

		public override void OnSingleClick( Mobile from ) 
		{ 
			this.LabelTo( from, i_Epitaph.Replace( "<BR>", " " ) ); 
		} 

		public override void OnDoubleClick( Mobile from ) 
		{ 
			from.SendGump( new epitaphgump( from, this ) );
		} 

		[Constructable]
		public GraveMarker() : base( 0x1165 )
		{
			Movable = false;
		}

		[Constructable]
		public GraveMarker( int style ) : base( 0x1165 + ( style & 0x1F ) )
		{
			Movable = false;
		}

		public GraveMarker( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); 
			writer.Write( i_Epitaph );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			i_Epitaph = reader.ReadString();
		}
    }
    #endregion

    #region epitaphgump class
    public class epitaphgump : Gump
	{
		private Mobile m_Owner;
		private GraveMarker m_Marker;
		private int m_index;

		private static readonly string[] epitaphs = 
			{
				"<BASEFONT COLOR=DARKRED>NOTE:<BR>Set custom epitaph from Props gump</BASEFONT>",
				//Ultima V
				"<BR>Here lies a valiant Knight, Meridin",
				"<BR>Here lies a valiant Knight, Arionis",
				"<BR>Here lies a valiant Knight, Roin",
				"<BR>Here lies a valiant Knight, Noin",
				"<BR>Here lies a valiant Knight, Geraci",
				"Alas poor Fred,<BR>he lost his head",
				"Here lies Pat,<BR>got eaten by a rat",
				"Here lies the upper half of Blackthorn's old jester",
				"Here lies the lower half of Blackthorn's old jester",
				"Here lies Headwood,<BR>no better than deadwood",
				"Underneath is Leif,<BR>who turned out<BR>to be a thief",
				"Here lies Yellowberg,<BR>cold as an iceberg",
				"John was satanical,<BR>he died on the manacles",
				"Here lies Jack,<BR>who was stretched<BR>on the rack",
				"Here lies the<BR>tale end of<BR>a bard",
				"Here lies poor<BR>Richard<BR>buried alive,<BR>trying to finish<BR>Ultima V",
				"Here lies Lebling<BR>in his coffin,<BR>kicked the dragon<BR>once too often",
				"He's no longer alive,<BR>he tried to drink<BR>and drive,<BR>this has been a public<BR>service tombstone",
				"Here lies poor<BR>Colin,<BR>off a cliff<BR>he had fallen",
				"Here we sadly<BR>buried Ian,<BR>what a bad boy<BR>he was bein'",
				"Lost a fight<BR>did old Kirk,<BR>with the wrong<BR>side of a dirk",
				"Tried to fly<BR>did poor young Tim,<BR>fatal choice<BR>for a whim",
				"Strong and daring was young Laurel,<BR>tried the falls in a barrel",
				"Andre lies under Earth's umbrella,<BR>alas he died of salmonella",
				"In the pub was last seen Dale,<BR>the food he ate was more than stale",
				"Loved the women dashing Kurt,<BR>with the wrong one did he flirt",
				"Work harder said Miss Jean,<BR>never again was<BR>she seen",
				"Far too frugal was Sir Robert,<BR>his employees lynched him to ease their poverty",
				//Ultima VI
				"<BR>The crypt of<BR>Cantrell",
				"<BR>The crypt of<BR>Spector",
				"<BR>The crypt of<BR>Malone",
				"<BR>The crypt of<BR>Bourbonnais",
				"<BR>The crypt of<BR>Beyvin",
				"<BR>The crypt of<BR>Jannati",
				"<BR>The crypt of<BR>Romero",
				"<BR>The crypt of<BR>Dwyer",
				"<BR>The crypt of<BR>Gabriella",
				"Here lie the honored remains of those who have been sacrificed.",
				"Within this<BR>chamber rest the<BR>bones of kings.",
				"Here lie those that<BR>had no names.",
				"Seeking a present<BR>to give a druid<BR>try a bottle of our<BR>enbalming fluid",
				"As you are now<BR>so once was I<BR>as I am now<BR>you soon shall be<BR>prepare for death<BR>when this you see",
				"On his wifes birthday Ralph was clever a tombstones the gift that lasts forever",
				"Golden lads and lasses must like chimney sweepers come to dust",
				"This great musician is not just dozing<BR>here he lies now decomposing",
				"Here lies Johns body<BR>we lost his head<BR>but he doesnt need it<BR>because hes dead",
				"Hinges rusty on your loved ones coffin<BR>tis not a box youll open often",
				"Here lies a man<BR>twas known as Ed<BR>so loud alive<BR>so quiet dead",
				"Husband the first<BR>Sir Cedric burned with fire bold till his life was quenched with a dagger cold",
				"Husband the second<BR>Roderic passed with an awful wail when someone served him poisoned ale",
				"Husband the third<BR>Walter passed on in his sleep his last thoughts a secret that death will keep",
				"Husband the fourth<BR>Rogers manner was formal and stiff till one day he fell off a cliff but now his bodys a cordial host to worms and maggots for hes a ghost",
				"Husband the fifth<BR>Martin left this world of toil when he fell in a vat of boiling oil",
				"Though she outlasted husbands five now Beth too is no more alive but as she drew her final breath she smiled a smile to scoff at death",
				"Here lies<BR>Captain Hawkins<BR>he died a hard death<BR>and he deserved it"
			};

		public epitaphgump( Mobile owner, GraveMarker marker ) : this( owner, marker, -1 )
		{
		}

		public epitaphgump( Mobile owner, GraveMarker marker, int index ) : base( 25, 25 )
		{
			owner.CloseGump( typeof( epitaphgump ) );

			//bool initialState = false;
			string text;

			m_Owner = owner;
			m_Marker = marker;
			m_index = index;

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage( 0 );

			AddImage( 0, 0, 0x66 );

			if( index > -1 ) 
				text = epitaphs[index];
			else 
				text = marker.Epitaph;

			text = "<center>" + text + "</center>";
			AddHtml( 49, 63, 135, 107, text, false, false );
			
			if( owner.AccessLevel > AccessLevel.Player )
			{
				AddButton( 87, 175, 0x995, 0x996, 1, GumpButtonType.Reply, 0 ); // Cancel
				AddButton( 92, 200, 0x992, 0x993, 2, GumpButtonType.Reply, 0 ); // Okay
				AddButton( 135, 247, 0x9CD, 0x9CD, 3, GumpButtonType.Reply, 0 ); // Next
				AddButton( 60, 247, 0x9CC, 0x9CC, 4, GumpButtonType.Reply, 0 ); // Previous
			}
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile;

			switch( info.ButtonID )
			{
				case 1: break;
				case 2:
				{
					if( m_index > 0 ) // First index not allowed
						m_Marker.Epitaph = epitaphs[m_index];

					break;
				}
				case 3:
				{
					if( ++m_index >= epitaphs.Length )
						m_index = 0;

					from.SendGump( new epitaphgump( from, m_Marker, m_index ) );
					break;
				}
				case 4:
				{
					if( --m_index <= 0 )
						m_index = epitaphs.Length -1;

					from.SendGump( new epitaphgump( from, m_Marker, m_index ) );
					break;
				}
			}
		}
    }
    #endregion
} 
