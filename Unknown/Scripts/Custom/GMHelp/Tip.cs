/* --------------------------->
 * Tip script by Kaon 
 * Version 1.1
 * Creation : 21.09.2005
 * Revision : 20.12.2007
 * --------------------------->
 */
// Décommentez la ligne suivante si vous utilisez RunUO1.0
// Uncomment this line if you're using RunUO 1.0
//#define USE_RUNUO_1

using System.Text.RegularExpressions;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Prompts;
using Server.Targeting;
using System.Collections;
#if !USE_RUNUO_1
using System.Collections.Generic;
#endif

#if USE_RUNUO_1
namespace Server.Scripts.Commands
#else
namespace Server.Commands
#endif
{
	/// <summary>
	/// Fonction .tip, permettant à un GM de notifier à un joueur quelque chose
	/// Function .tip, allowing a GM to notify something to a player
	/// </summary>
#if USE_RUNUO_1
    public class Tip_Command
#else
    public static class Tip_Command
#endif
	{
        private const string stCommandName = "tip";
        private const string stDescriptionFR = "Envoi le message au joueur ciblé";
        private const string stDescriptionEN = "Send the message to the selected player";

        private static string[] stTextFR = {
            "Entrez votre message, utilisez le point virgule pour indiquer la fin du tip.",
            "Cliquez sur le personnage à qui envoyer le message",
            "Entrez la suite de votre message, utilisez le point virgule pour indiquer la fin du tip.",
            "Vous avez reçu un tip d'un GM!",
            "Entrez votre réponse, celle-ci sera envoyée au GM.",
            "Désolé, le GM n'est plus là.",
            /*from.Name + */" vous répond :",
        };
        private static string[] stTextEN = {
            "Enter your message, use the ';' character to end the tip",
            "Click on the character you want to notify",
            "Enter the sequel of your message, use the ';' character to end the Tip",
            "You get a tip from a GM!",
            "Enter your answer, it will be send to the GM.",
            "Sorry, the GM can't be found.",
            /*from.Name + */" is answering :",
        };

        private static string[] stText = stTextFR;
        private const string stDescription = stDescriptionFR;
        //private static string[] stText = stTextEN;
        //private const string stDescription = stDescriptionEN;

		/// <summary>
		/// Initialisation du handler de la fonction
		/// Handler initialization
		/// </summary>
		public static void Initialize()
		{
#if USE_RUNUO_1
            Server.Commands.Register(stCommandName, AccessLevel.Counselor, new CommandEventHandler(Tip_OnCommand));
#else
            CommandSystem.Register(stCommandName, AccessLevel.Counselor, new CommandEventHandler(Tip_OnCommand));
#endif
		}

		[Usage( stCommandName + " <msg>" )]
        [Description(stDescription)]
		private static void Tip_OnCommand(CommandEventArgs e)
		{
			if( e.Arguments.Length > 0)
				e.Mobile.Target = new InternalTarget( new Tip( e.Mobile, e.ArgString, null ));
			else
			{
                e.Mobile.SendMessage(stText[0]);
				e.Mobile.Prompt = new InternalPrompt( "" );
			}
		}

		/// <summary>
		/// Cible déterminant à qui reviendra le message
		/// Target to select the player to notify
		/// </summary>
		private class InternalTarget : Target
		{
			private Tip objMsg;

			public InternalTarget( Tip msg ) : base( 12, false, TargetFlags.None )
			{
				msg.GM.SendMessage(stText[1]);
				objMsg = msg;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
				{
					objMsg.Player = (Mobile) o;
					objMsg.Display();
				}
			}
		}
		
		/// <summary>
		/// Prompt visant à récupérer la réponse du joueur
		/// Prompt for the message of the Tip
		/// </summary>
		private class InternalPrompt : Prompt
		{
			string stTxt;

			public InternalPrompt( string txt )
			{
				stTxt = txt;
			}

			public override void OnResponse(Mobile from, string text)
			{
				// Deleting the ';' ending character
				stTxt += " " + Regex.Replace(text, ";", "");

				// If we find a ';', we can send the target to choose the player
				if(Regex.IsMatch(text, ";"))
					from.Target = new InternalTarget( new Tip( from, stTxt, null ));
				else
				{
					// Else, there is a sequel to the message
					from.SendMessage(stText[2]);
					from.Prompt = new InternalPrompt( stTxt );
				}
			}
		}
		/// <summary>
		/// Message à envoyer
		/// Tip to send
		/// </summary>
		private class Tip
		{
			#region VARIABLES
				private Mobile objGM;
				private string stTxt;
				private Mobile objPlayer;
			#endregion

			#region PROPRIETES
				/// <summary>
				/// Sender (GM)
				/// </summary>
				public Mobile GM
				{
					get { return objGM; }
					set { objGM = value; }
				}

				/// <summary>
				/// Message to send
				/// </summary>
				public string Texte
				{
					get { return stTxt; }
					set { stTxt = value; }
				}

				/// <summary>
				/// Reciever (Player)
				/// </summary>
				public Mobile Player
				{
					get { return objPlayer; }
					set { objPlayer = value; }
				}
			#endregion

			#region CONSTRUCTEURS
				/// <summary>
				/// Message to a player
				/// </summary>
				/// <param name="gm">Sender (GM)</param>
				/// <param name="txt">Text to send</param>
				/// <param name="pl">Reciever (Player)</param>
				public Tip( Mobile gm, string txt, Mobile pl )
				{
					objGM = gm;
					stTxt = txt;
					objPlayer = pl;
				}
			#endregion

			#region METHODES PUBLIQUES
				/// <summary>
				/// Affiche l'icône du tip, notifiant sa présence au joueur
				/// Display the Tip icone in the upper left corner
				/// Notify the player he get a Tip
				/// </summary>
				public void Display()
				{
					// On vérifie que le joueur est toujours existant
					// Verify that the player is still here
					if(objPlayer == null || objPlayer.Deleted )
						return;

					// On cherche à savoir où afficher le Tip
                    // Searching for a place to show the tip
#if USE_RUNUO_1
                    ArrayList Ys = new ArrayList();
#else
                    List<int> Ys = new List<int>();
#endif

                    for (int i = 0; i < 20; i++) Ys.Add(20 + i * 20);

                    if (objPlayer.NetState != null)
                    {
#if USE_RUNUO_1
                        IEnumerator eable = objPlayer.NetState.Gumps.GetEnumerator();
#else
                        IEnumerator<Gump> eable = objPlayer.NetState.Gumps.GetEnumerator();
#endif
                        while (eable.MoveNext())
                        {
                            if (eable.Current is Tip_Gump)
                            {
#if USE_RUNUO_1
                                Ys.Remove(((Gump)eable.Current).Y);
#else
                                Ys.Remove(eable.Current.Y);
#endif
                            }
                        }
                    }
                    // Sécurité
                    // Security
                    if (Ys.Count == 0) Ys.Add(20);

                    // On notifie le joueur du Tip
					// Notify the player of the Tip
                    objPlayer.SendMessage(stText[3]);
#if USE_RUNUO_1
                    objPlayer.SendGump( new Tip_Gump( this, (int)Ys[0]) );
#else
                    objPlayer.SendGump( new Tip_Gump( this, Ys[0]) );
#endif
				}

				/// <summary>
				/// Déroule le tip
				/// Open the Tip
				/// </summary>
				public void Open()
				{
					// On vérifie que le joueur est toujours existant
					// Verify that the player is still here
					if(objPlayer == null || objPlayer.Deleted )
						return;

					// On affiche le Tip au joueur
					// Display the Tip to the player
					objPlayer.SendGump( new Tip_Detailled_Gump( this ) );
				}

				/// <summary>
				/// Demande au joueur la réponse qu'il souhaite envoyer au GM
				/// Ask the player for the answer he want to send to the sender
				/// </summary>
				public void Reply()
				{
					// On vérifie que le joueur est toujours existant
					// Verify that the player is still here
					if(objPlayer == null || objPlayer.Deleted )
						return;

					// On demande au joueur la réponse
					// Ask the player for the answer
					objPlayer.SendMessage(stText[4]);
					objPlayer.Prompt = new Tip_Prompt( this );
				}
				
				/// <summary>
				/// Envoie la réponse du joueur au GM
				/// Send the player's reply to the GM
				/// </summary>
				/// <param name="from">Joueur/Player</param>
				/// <param name="text">Réponse/Answer</param>
				public void Reply( Mobile from, string text)
				{
					// On vérifie que le GM est toujours existant
					// Verify that the GM is still here
					if(objGM == null || objGM.Deleted )
					{
						from.SendMessage(stText[5]);
						return;
					}

					// On notifie le GM de la réponse du joueur
					// Notify the GM of the answer
					objGM.SendMessage(from.Name + stText[6]);
					objGM.SendMessage( text );
				}
			#endregion

			/// <summary>
			/// Gump de notification de Tip
			/// Tip's notification Gump (small)
			/// </summary>
			private class Tip_Gump : Gump
			{
				private Tip objMsg;

				public Tip_Gump( Tip msg, int y ) : base(0,y)
				{
					objMsg = msg;

					this.Closable=false;
					this.Disposable=false;
					this.Dragable=false;
					this.Resizable=false;
					this.AddPage(0);
					this.AddButton(0, 0, 2507, 2507, (int)Buttons.Button1, GumpButtonType.Reply, 0);
				}

				public enum Buttons
				{
					Button1,
				}

				public override void OnResponse(NetState sender, RelayInfo info)
				{
					switch( info.ButtonID )
					{
						case (int)Buttons.Button1:
							objMsg.Open();
							break;
					}
				}
			}


			/// <summary>
			/// Gump d'affichage du Tip
			/// Tip Gump
			/// </summary>
			private class Tip_Detailled_Gump : Gump
			{
				private Tip objMsg;

				public Tip_Detailled_Gump( Tip msg ) : base(50, 40)
				{
					objMsg = msg;

					this.Closable=true;
					this.Disposable=true;
					this.Dragable=true;
					this.Resizable=false;
					this.AddPage(0);
					this.AddBackground(0, 0, 250, 250, 5170);
					this.AddHtml( 20, 24, 210, 200, "<BASEFONT COLOR=BLACK>" + msg.Texte + "</BASEFONT>", false, true);
					this.AddButton(190, 228, 2180, 2180, (int)Buttons.Button3, GumpButtonType.Reply, 0);
					this.AddImage(100, 8, 2506);
				}

				public enum Buttons
				{
					Exit,
					Button3,
				}

				public override void OnResponse(NetState sender, RelayInfo info)
				{
					switch( info.ButtonID )
					{
						case (int)Buttons.Button3:
							objMsg.Reply();
							break;
						case (int)Buttons.Exit : break;
					}
				}
			}

			/// <summary>
			/// Prompt visant à récupérer la réponse du joueur
			/// Prompt to get the player's answer
			/// </summary>
			private class Tip_Prompt : Prompt
			{
				Tip objMsg;
				public Tip_Prompt( Tip msg )
				{
					objMsg = msg;
				}

				public override void OnResponse(Mobile from, string text)
				{
					objMsg.Reply(from, text);
				}
			}
		}
	}
}
