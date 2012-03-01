using System; 
using Server.Network; 
  
  namespace Server.Misc 
  { 
  
public class AnnounceLoginLogoutUserCount
  
{ 
  

public static void Initialize() 
  

{ 
  


// Register event handlers 
  


EventSink.Login += new LoginEventHandler( EventSink_Login ); 
  


EventSink.Disconnected += new DisconnectedEventHandler( EventSink_Disconnected ); 
  

}
  
  

private static void EventSink_Login( LoginEventArgs args ) 
  

{ 
  


Mobile m = args.Mobile; 
  


int userCount = NetState.Instances.Count;
  
  


World.Broadcast( 0x35, true, "{0} has now logged in! There {1} now {2} player{3} online!", args.Mobile.Name,
  


userCount == 1 ? "is" : "are",
  


userCount, userCount == 1 ? "" : "s" );
  

}
  
  

private static void EventSink_Disconnected( DisconnectedEventArgs args ) 
  

{ 
  


Mobile m = args.Mobile; 
  


int userCount = NetState.Instances.Count;
  
  


World.Broadcast( 0x35, true, "{0} has now logged off! There {1} now {2} player{3} online!", args.Mobile.Name,
  


userCount-1 == 1 ? "is" : "are",
  


userCount-1, userCount == 1 ? "" : "s" );
  

}
  
}
  }