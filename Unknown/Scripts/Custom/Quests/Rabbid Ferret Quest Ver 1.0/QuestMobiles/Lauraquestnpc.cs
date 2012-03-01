//thanks to daat99 for the tony script i reworked to make this : evilfreak rabbid ferret quest v1.0

using System;
using System.Collections;
using Server;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Commands;
using System.Collections.Generic;

namespace Server.Mobiles
{
	#region Laura
	[CorpseName( "Laura's Corpse" )]
	public class Laura : Mobile
	{
		private static ArrayList alFinished = new ArrayList();
		public static ArrayList Finished{ get{ return alFinished; } set{ alFinished = value; } }

		[Constructable]
		public Laura()
		{
			alFinished = new ArrayList();
			Name = "Laura";
			Title = "The Ferret Breeder";
			Body = 401;
			CantWalk = true;
			Hue = 33784;
			AddItem( new Sandals() );
			AddItem( new FullApron( 1436 ) );
			AddItem( new Skirt( 1436 ) );
			AddItem( new ShepherdsCrook() );
			AddItem( new ShortHair( 1741 ) );
			AddItem( new StrawHat( 1436 ) );
		}

		public virtual bool IsInvulnerable{ get{ return true; } }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list) 
		{ 
			base.GetContextMenuEntries( from, list ); 
			list.Add( new LauraEntry( from, this ) ); 
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{          		
			if ( from == null )
				return false;

			if( dropped is GrandmasBrace )
			{
				if ( alFinished.Contains( from ) )
				{
					from.SendMessage(32, "You can do the quest only once");
					return false;
				}
				alFinished.Add( from );
				from.AddToBackpack( new Gold( 5000 ) );
				if (dropped.Amount > 1)
					dropped.Amount--;
				else
					dropped.Delete();
				from.SendMessage( "Thank you kind neighbor!" );
				from.SendGump( new LauraFinishGump());
			}
			else
				PrivateOverheadMessage( MessageType.Regular, 1153, false, "I have no use of this!", from.NetState );
			return false;
		}
		
		public static void Initialize() 
		{
            CommandSystem.Register("LauraGump", AccessLevel.GameMaster, new CommandEventHandler(LauraGump_OnCommand));
            CommandSystem.Register("RemoveFromLaurasList", AccessLevel.Seer, new CommandEventHandler(RemoveFromLaurasList_OnCommand));
		} 

		private static void LauraGump_OnCommand( CommandEventArgs e ) 
		{
			e.Mobile.SendGump( new LauraGump( e.Mobile ) ); 
		}
		private static void RemoveFromLaurasList_OnCommand ( CommandEventArgs e )
		{
			e.Mobile.Target = new RemoveFromLaurasListTarget(); 
		}

		public Laura( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );

			writer.WriteMobileList( alFinished, true );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			alFinished = reader.ReadMobileList();
		}
	}
	#endregion

	#region Context Menu
	public class LauraEntry : ContextMenuEntry
	{
		private Mobile mFrom;
		private Mobile mLaura;
			
		public LauraEntry( Mobile from, Mobile laura ) : base( 6146, 3 )
		{
			mFrom = from;
			mLaura = laura;
		}

		public override void OnClick()
		{
			if( !( mFrom is PlayerMobile ) )
				return;
			if ( !( mFrom.HasGump( typeof( LauraGump ) ) ) )
			{
				mFrom.SendGump( new LauraGump( mFrom ));
			}
		}
	}
	#endregion

	#region Lauras gump
	public class LauraGump : Gump 
	{
		public LauraGump( Mobile owner ) : base( 50,50 ) 
		{ 
			AddPage(0);
			AddBackground(50, 50, 400, 415, 9250);
			AddImageTiled(411, 62, 44, 389, 203);
			AddImage(93, 83, 9005);
			AddLabel(155, 83, 52, @"The Grandmother's Bracelet Quest");
			AddHtml( 93, 149, 315, 249, "<BODY>" +
				"<BASEFONT COLOR=YELLOW>*Laura looks up with a grin*<BR><BR>" +
				"Say, hey, hey you! Come over here.<BR>" + 
				"My best ferret was bitten by a rabbid gopher, and got very sick.<BR><BR>" + 
				"This ferret ran away with my Grandma's White Bracelet!!Please help me!!<BR>" +
				"Find the rabbid ferret and kill him, and return to me, my Grandma's Bracelet.<BR>" +
				"The female companion, was once mine as well, please retame her, after his death.<BR><BR>" +
				"To Find them you must enter the Ferret Tunnels.<BR>"+
				"To do this go to my field, watch the ferrets there,<BR>"+
				"Once you see one dig a tunnel hurry to it and double click it.<BR><BR>"+
				"For all of your efforts I would be willing to give you some gold in return.<BR><BR>" +
				"Please consider my offer!!</BODY>", (bool)true, (bool)true);
			AddImageTiled(44, 61, 17, 391, 9263);
			AddImage(10, 52, 10421);
			AddImageTiled(63, 63, 375, 15, 10304);
			AddImageTiled(63, 434, 375, 15, 10304);
			AddImage(-7, 344, 10402);
			AddImage(108, 99, 2103);
			AddImage(162, 105, 96);
			AddButton(224, 405, 247, 248, 0, GumpButtonType.Reply, 0);
			AddImageTiled(411, 61, 30, 390, 10460);
			AddImageTiled(61, 61, 30, 390, 10460);
			AddImage(423, 33, 10441);
			AddImage(37, 47, 10420);
			AddImage(31, 187, 10411);
		} 
	}
	#endregion

	#region Lauras finish gump
	public class LauraFinishGump : Gump
	{
		public LauraFinishGump() : base( 200, 200 )
		{
			AddPage(0);
			AddBackground(0, 0, 353, 118, 9270);
			AddAlphaRegion( 2, 2, 349, 114 );
			AddLabel(118, 15, 1149, "Quest Complete");
			AddLabel(48, 39, 255, "Oh wonderful. Thank you so much!.");
			AddLabel(48, 55, 255, "Please, take this as a sign of my gratitude.");
			AddLabel(48, 71, 255, "If you retamed the female, keep her.");
		}
	}
	#endregion

	#region Remove from lauras list
	public class RemoveFromLaurasListTarget : Target 
	{ 
		public RemoveFromLaurasListTarget() : base( 15, false, TargetFlags.None ) 
		{ 
		}

		protected override void OnTarget( Mobile from, object target ) 
		{ 
			if ( !( target is PlayerMobile ) )
				return;
			
			if ( Laura.Finished.Contains( (Mobile)target ) )
			{
				Laura.Finished.Remove( (Mobile)target );
				from.SendMessage(88, "You removed the player from Lauras list and he can do the quest again.");
			}
			else
				from.SendMessage(32, "This player is not in Lauras list. ");
		} 
	} 
	#endregion


}