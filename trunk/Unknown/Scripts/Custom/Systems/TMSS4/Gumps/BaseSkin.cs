using System;
using System.Collections;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;
using System.Reflection;
using Server.Commands;
using System.Collections.Generic;
using System.Runtime.Remoting;

namespace Server.Gumps
{
	#region Structs
	public struct WindowInfo
	{
		internal int X, Y, W, H, bgID;
		internal WindowInfo(int x, int y, int w, int h, int bg)
		{
			X = x; Y = y; W = w; H = h; bgID = bg;
		}
	}
	public struct ButtonInfo
	{
		internal int X, Y, W, H, bgID, textX, textY, up, down;
		internal string text;
		internal ButtonInfo(int x, int y, int w, int h, int bg, string Text)
		{
			X = x; Y = y; W = w; H = h; bgID = bg;
			textX = 0; textY = 0;
			up = 0; down = 0;
			text = Text;
		}

		internal ButtonInfo(int x, int y, int w, int h, int bg, string Text, int tx, int ty)
		{
			X = x; Y = y; W = w; H = h; bgID = bg; textX = tx; textY = ty;
			text = Text;
			up = 0; down = 0;
		}

		internal ButtonInfo(int x, int y, int w, int h, int u, int d)
		{
			X = x; Y = y; W = w; H = h; 
			text = "";
			textX = 0; textY = 0;
			bgID = 0;
			up = u; down = d;
		}

		internal ButtonInfo(int x, int y, int w, int h, int bg, string txt, int tx, int ty, int u, int d)
		{
			if (bg == 0)
			{
				textX = 0;
				textY = 0;
				this.text = "";
				this.X = x;
				this.Y = y;
				this.up = u;
				this.down = d;
				W = 0;
				H = 0;
				bgID = 0;
			}
			else
			{
				this.up = 0;
				this.down = 0;
				text = txt;
				this.W = w;
				this.H = h;
				this.X = x;
				this.Y = y;
				bgID = bg;
				this.textX = tx;
				this.textY = ty;
			}
		}
	}
	#endregion

	#region Base TMSkin
	public class BaseSkin
	{
		public int NumPerPage = 8;
		public int DefaultBackgroundColor = 0;
		public int EntryDividerWidth = 2;
		public int EntryDividerHeight = 20;
		public int EntryDividerID = 2700;
		public int EntryCaptionPositionY = 50;
		public int EntryCaptionWidth = 80;
		public int EntryCaptionHeight = 40;
		public int EntryDefaultIcon = 2115;
		public int EntryIconY = 2;
		public int EntryIconWidth = 50;
		public int EntryIconHeight = 50;
		public int EntryButtonUnderlay = 3004;
		public int EntryDefaultHeight = 20;
		public int EntryDefaultWidth = 400;
		public int EntryDefaultCheckUp = 2474;
		public int EntryDefaultCheckDn = 9730;

		public int ListTitleX = 0;
		public int ListTitleY = 0;
		public int ListTitleHue = 1152;
		public int ListStartX = 45;
		public int ListStartY = 100;
		public int ListWidth = 425;
		public int ListHeight = 400;
		public int ListEntrySpacer = 2;
		public int ListButtonOverlay = 3004;
		public int ListUnderButtonN = 1795;
		public int ListUnderButtonP = 1795;
		public int ListColumnIndent = 3;

		public string SkinName = "Unnamed Skin";
		public int NormalText = 1891;
		public int HighlightText = 53;
		public int White = 1152;
		public int Black = 1;
		public int Red = 32;
		//WindowInfo should contain X, Y, width, height and background.
		public Dictionary<string, WindowInfo> WindowInfo = new Dictionary<string, WindowInfo>();
		public Dictionary<string, ButtonInfo> ButtonInfo = new Dictionary<string, ButtonInfo>();

		public BaseSkin(string name)
		{
			SkinName = name;
			ButtonInfo prevbtn = new ButtonInfo(240, 177, 80, 25, ListButtonOverlay, "PREV");
			ButtonInfo nextbtn = new ButtonInfo(322, 177, 80, 25, ListButtonOverlay, "NEXT");
			ButtonInfo finbtn = new ButtonInfo(158, 177, 80, 25, ListButtonOverlay, "OK");
			ButtonInfo.Add("ListPrevButton", prevbtn);
			ButtonInfo.Add("ListNextButton", nextbtn);
			ButtonInfo.Add("ListDoneButton", finbtn);
		}
		public BaseSkin()
			: this("Unnamed Skin")
		{ }
		public void AddWindow(string name, int x, int y, int w, int h, int bgid)
		{
			if (!WindowInfo.ContainsKey(name))
				WindowInfo.Add(name, new WindowInfo(x, y, w, h, bgid));
			else
				Console.WriteLine("Entry: " + name + " already exists as a window in this skin.");
		}
		internal void BaseSerialize(XmlWriter write)
		{
			try
			{
				IEnumerator vals = WindowInfo.GetEnumerator();
				IEnumerator btns = ButtonInfo.GetEnumerator();

				write.WriteStartElement("WindowCount");
				write.WriteValue(WindowInfo.Count);
				write.WriteEndElement();
				while (vals.MoveNext())
				{
					WindowInfo c = (WindowInfo)((KeyValuePair<string, WindowInfo>)vals.Current).Value;
					write.WriteStartElement((string)((KeyValuePair<string, WindowInfo>)vals.Current).Key);
					write.WriteAttributeString("X", "" + c.X);
					write.WriteAttributeString("Y", "" + c.Y);
					write.WriteAttributeString("W", "" + c.W);
					write.WriteAttributeString("H", "" + c.H);
					write.WriteAttributeString("BG", "" + c.bgID);
					write.WriteEndElement();
				}
				write.WriteStartElement("ButtonCount");
				write.WriteValue(ButtonInfo.Count);
				write.WriteEndElement();
				while (btns.MoveNext())
				{
					//SkillSettings.DoTell2("Type of btns.Current: " + btns.Current.GetType());
					//SkillSettings.doTell("Type of btns.Current.Value: "+(((DictionaryEntry)btns.Current).Value).GetType());
					ButtonInfo b = (ButtonInfo)((KeyValuePair<string, ButtonInfo>)btns.Current).Value;
					write.WriteStartElement((string)((KeyValuePair<string, ButtonInfo>)btns.Current).Key);
					write.WriteAttributeString("X", "" + b.X);
					write.WriteAttributeString("Y", "" + b.Y);
					write.WriteAttributeString("W", "" + b.W);
					write.WriteAttributeString("H", "" + b.H);
					write.WriteAttributeString("BG", "" + b.bgID);
					write.WriteAttributeString("TXT", b.text);
					write.WriteAttributeString("TX", ""+b.textX );
					write.WriteAttributeString("TY", "" + b.textY);
					write.WriteAttributeString("U", "" + b.up);
					write.WriteAttributeString("D", "" + b.down);
					write.WriteEndElement();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while writing out Button and Window info: " + e);
			}
		}

		internal void BaseDeserialize(XmlReader read)
		{
			try
			{
				read.ReadStartElement();
				int count = read.ReadContentAsInt();
				read.ReadEndElement();
				int i = 0;
				while (i < count)
				{
					string name = read.LocalName;
					//SkillSettings.DoTell2("Current Name (win): " + name);
					int x = Int32.Parse(read.GetAttribute(0));
					int y = Int32.Parse(read.GetAttribute(1));
					int w = Int32.Parse(read.GetAttribute(2));
					int h = Int32.Parse(read.GetAttribute(3));
					int bg = Int32.Parse(read.GetAttribute(4));
					WindowInfo inf = new WindowInfo(x, y, w, h, bg);
					ReplaceWindow(name, inf);
					read.Read();
					i++;
				}
				read.ReadStartElement();
				int count2 = read.ReadContentAsInt();
				i = 0;
				read.ReadEndElement();
				while (i < count2)
				{
					string name = read.LocalName;
					//SkillSettings.DoTell2("Current Name (btn): " + name);
					int x = Int32.Parse(read.GetAttribute(0));
					int y = Int32.Parse(read.GetAttribute(1));
					int w = Int32.Parse(read.GetAttribute(2));
					int h = Int32.Parse(read.GetAttribute(3));
					int bg = Int32.Parse(read.GetAttribute(4));
					string txt = read.GetAttribute(5);
					int tx = Int32.Parse(read.GetAttribute(6) );
					int ty = Int32.Parse(read.GetAttribute(7) );
					int up = Int32.Parse(read.GetAttribute(8));
					int dn = Int32.Parse(read.GetAttribute(9));
					ButtonInfo inf = new ButtonInfo( x, y, w, h, bg, txt, tx, ty, up, dn );
					ReplaceButton(name, inf);
					read.Read();
					i++;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while reading in Button and Window info: " + e);
			}
		}

		private void ReplaceButton(string name, ButtonInfo inf)
		{
			if (ButtonInfo.ContainsKey(name))
				ButtonInfo.Remove(name);
			ButtonInfo.Add(name, inf);
		}

		private void ReplaceWindow(string name, WindowInfo inf)
		{
			if (WindowInfo.ContainsKey(name))
				WindowInfo.Remove(name);
			WindowInfo.Add(name, inf);
		}
	}
	#endregion

	#region SkinHelper
	public class SkinHelper
	{
		//This is probably only going to have one thing in it, but I'm planning for expansion.
		public static Dictionary<string, BaseSkin> skList = new Dictionary<string, BaseSkin>();
		#region Save Skin
		public static void WriteSkin(object ds)
		{
			if (ds == null)
			{ Console.WriteLine("Invalid skin -- it is null."); return; }

			if (!Directory.Exists("TMSS/Data/Skins"))
				Directory.CreateDirectory("TMSS/Data/Skins");

			string FileName = ((BaseSkin)ds).SkinName + ".tskn";
			string path = @"TMSS/Data/Skins/" + FileName;

			if (File.Exists(path))
				File.Delete(path);

			DateTime start = DateTime.Now;
			Console.Write(" - Saving TMSS Skin " + ((BaseSkin)ds).SkinName + "...");

			//Getting values to save.
			ArrayList dsNames = new ArrayList();
			ArrayList dsValues = new ArrayList();
			try
			{
				//Loop through all vars in DynaSkin
				Type t = ds.GetType();
				foreach (FieldInfo field in t.GetFields())
				{					
					if (field.FieldType != typeof(Dictionary<string, WindowInfo>) && field.FieldType != typeof(Dictionary<string, ButtonInfo>))
					{
						dsNames.Add(field.Name);
						dsValues.Add(field.GetValue(ds));
					}
				}

				//Actual saving starts here. Enumerators of names and values.
				IEnumerator iNames = dsNames.GetEnumerator();
				IEnumerator iValues = dsValues.GetEnumerator();

				XmlWriterSettings settings = new XmlWriterSettings();
				settings.Indent = true;
				settings.IndentChars = "	";
				XmlWriter write = XmlWriter.Create(path, settings);
				//Writing
				write.WriteStartElement("TMSkin");
				write.WriteStartElement("FieldCount");
				write.WriteValue(dsNames.Count);
				write.WriteEndElement();
				while (iNames.MoveNext())
				{
					iValues.MoveNext();
					write.WriteStartElement((string)iNames.Current);
					write.WriteValue(iValues.Current);
					write.WriteEndElement();
				}
				((BaseSkin)ds).BaseSerialize(write);
				write.WriteEndElement();
				Console.WriteLine("done");
				write.Close();
			}
			catch (Exception e)
			{ Console.WriteLine("Unable to save skin - Exception: " + e); }
		}
		#endregion

		#region Load Skin
		
		public static object LoadSkin(string name, Type type, bool reload)
		{
			if (!reload)
				return LoadSkin(name, type);
			else
			{
				if( skinExists(name) )
					skList.Remove(name);
				return LoadSkin(name,type);
			}
		}
		public static object LoadSkin(string name, Type t )
		{
			if (skinExists(name))
			{ return getSkin(name); }
			if (!Directory.Exists("TMSS/Data/Skins"))
				Directory.CreateDirectory("TMSS/Data/Skins");
			ObjectHandle objhand = Activator.CreateInstance(null, t.FullName);
			
			object o = objhand.Unwrap();
			
			BaseSkin sk = new BaseSkin();
			string FileName = name+".tskn";
			string path = @"TMSS/Data/Skins/" + FileName;

			Console.Write(" - //Skin// - Loading Skin " + name + " on path: "+path+"...");
			if (!File.Exists(path)) { Console.WriteLine("ERROR: Skin Not Found "); return null; }

			XmlReaderSettings settings = new XmlReaderSettings();
			settings.IgnoreWhitespace = true;
			XmlReader read = XmlReader.Create(path, settings);

			read.ReadStartElement("TMSkin");
			read.ReadStartElement("FieldCount");
			int count = read.ReadContentAsInt();
			read.ReadEndElement();
			int i = 0;
			FieldInfo inf = null;;
			Type t2 = null;
			while (i < count)
			{
				try
				{
					string blah = read.LocalName;
					//string blah = (string)read.ReadElementContentAs( typeof(string), null );
					inf = t.GetField(blah);
					t2 = inf.FieldType;//inf.GetType();
					inf.SetValue(o, read.ReadElementContentAs(t2, null));
				}
				catch (Exception e)
				{
					Console.WriteLine("Invalid operation while setting up Base Skin. " + e+" inf: "+inf+" t2: "+t2+" o: "+o);
				}
				i++;
			}
			try
			{
				((BaseSkin)o).BaseDeserialize(read);
				//sk.BaseDeserialize(read);
				read.Close();
				skList.Add(((BaseSkin)o).SkinName, (BaseSkin)o);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unable to deserialize a base skin of type: "+t+". Please examine format. "+ex);
			}
			Console.WriteLine("done");
			return o;
		}
		#endregion

		private static bool skinExists(string name)
		{
			if (skList.ContainsKey(name))
				return true;
			else
				return false;
		}		
		public static BaseSkin getSkin(string name)
		{
			try
			{
				BaseSkin sk = skList[name];
				if (sk != null)
					return sk;
				else
				{ Console.WriteLine("No Such Skin: " + name); return null; }
			}
			catch (Exception e)
			{ 
				Console.WriteLine("Unable to fetch skin: "+name );
				if( Core.Debug )
					Console.WriteLine( ""+e );
				return null;
			}			
		}		
	}
	#endregion
}