using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

//Author: TMSTKSBK
//Written for the RunUO Community.
namespace Server.Gumps
{
	#region GumpList
	/// <summary>
	/// GumpList is the primary class for the infinite list implementation.
	/// </summary>
	public class GumpList
	{
		#region Private Variables
		private int m_numperpage = 0;
		private Gump page = null;
		private Dictionary<int, GumpListEntry> listEntries = new Dictionary<int, GumpListEntry>();
		private string title = "";
		private bool m_Dividers = true;
		private bool m_Background = true;
		private GumpListEntry topbar;
		private int m_BackgroundID = 3004;
		private bool DebugMode = false;
		#endregion

		#region Internal & Public Variables
		internal BaseSkin sk = null;
		internal int columns = 1;
		internal int X,Y = 0;
		internal bool ShowDividers
		{
			get { return m_Dividers; }
			set
			{
				if (style == "details")
					m_Dividers = value;
				else
					m_Dividers = false;
			}
		}
		internal bool ShowBackground
		{
			get { return m_Background; }
			set	{m_Background = value;}
		}
		internal string style = "details";
		internal Dictionary<int, int> columnWidths = new Dictionary<int, int>();

		public int numperpage { get { return m_numperpage; } set { m_numperpage = value; } }
		#endregion

		/// <summary>
		/// Debug writing method.
		/// </summary>
		/// <param name="write">What to write.</param>
		internal void DebugWrite(string write)
		{
			if( DebugMode)
				Console.WriteLine("GumpList debug: "+write);
		}

		#region Constructors
		/// <summary>
		/// Constructor 1
		/// </summary>
		/// <param name="Page">The gump to which the list will be added.</param>
		/// <param name="Style">The style of the GumpList.</param>
		/// <param name="Skin">The skinning parameters of the list.</param>
		public GumpList( Gump Page, string Style, BaseSkin Skin )
		{			
			sk = Skin;
			page = Page;
			numperpage = sk.NumPerPage;
			style = Style;
			topbar = new GumpListEntry(sk.ListStartX, sk.ListStartY, this, sk.EntryDefaultWidth, sk.EntryDefaultHeight);
			listEntries.Add( topbar.GetHashCode(), topbar);
			DebugWrite("Constructor sans title end.");
		}
		/// <summary>
		/// Constructor 2
		/// </summary>
		/// <param name="Page">The gump to which the list will be added.</param>
		/// <param name="Style">The style of the GumpList.</param>
		/// <param name="Title">The title of the list.</param>
		/// <param name="Skin">The skinning parameters of the list.</param>
		public GumpList(Gump Page, string Style, string Title, BaseSkin Skin )
		{
			DebugWrite("Const. WITH title called.");
			sk = Skin;
			page = Page;
			numperpage = sk.NumPerPage;
			title = Title;
			style = Style;
			topbar = new GumpListEntry(sk.ListStartX, sk.ListStartY, this, sk.EntryDefaultWidth, sk.EntryDefaultHeight);
			topbar.AddColumn( "title" );
			listEntries.Add(topbar.GetHashCode(), topbar);
			DebugWrite("Const. WITH title end.");
		}
		#endregion

		#region Column Related
		/// <summary>
		/// Add a column to the list, with title.
		/// </summary>
		/// <param name="title">The title of the column.</param>		
		public void AddColumn(string title)
		{
			if (topbar != null)
				topbar.AddColumn(title);
			columns++;
		}
		/// <summary>
		/// Change the width of a given column.
		/// </summary>
		/// <param name="column">Which column to change.</param>
		/// <param name="width">What width to set the column to.</param>
		public void ChangeColumnWidth(int column, int width)
		{
			if (columnWidths.ContainsKey(column))
				columnWidths.Remove(column);
			columnWidths.Add(column, width);
		}
		/// <summary>
		/// Reset the number of columns in the list.
		/// </summary>
		/// <param name="count">The number of columns to reset.</param>
		public void SetColumnCount(int count)
		{
			columns = count;
		}
		/// <summary>
		/// Removes a column from the list.
		/// </summary>
		/// <param name="which">The column to be removed.</param>
		public void RemoveColumn(int which)
		{
			IEnumerator ie = listEntries.GetEnumerator();
			while (ie.MoveNext())
			{
				((GumpListEntry)((DictionaryEntry)ie.Current).Value).RemoveColumn(which);
			}
			if (columnWidths.ContainsKey(which))
				columnWidths.Remove(which);
		}
		#endregion

		#region List Setup
		/// <summary>
		/// Sets the background of the list.
		/// </summary>
		/// <param name="id">The ID of the background.</param>
		internal void SetBackgroundID(int id)
		{
			m_BackgroundID = id;
		}
		/// <summary>
		/// Remove a particular entry from the list.
		/// </summary>
		/// <param name="id">The id of the entry to be removed.</param>
		internal void Remove(int id)
		{
			if( listEntries.ContainsKey(id ) )
				listEntries.Remove(id);
		}
		/// <summary>
		/// Adds an entry to the list.
		/// </summary>
		/// <param name="entry">The entry to be added.</param>
		/// <returns></returns>
		internal int Add(GumpListEntry entry)
		{
			if( !listEntries.ContainsKey(entry.GetHashCode() ) )
				listEntries.Add( entry.GetHashCode(), entry );
			return entry.GetHashCode();
		}
		/// <summary>
		/// Adds the list to the gump. Called "commit", since no further operations on the list will have any effect.
		/// </summary>
		internal void CommitList()
		{
			DebugWrite("CommitList called.");
			IEnumerator ie = listEntries.GetEnumerator();
			int loc = 0;
			int count = 0;
			int pageID = 1;
			int heightsum = topbar == null ? 0 : topbar.Height + sk.ListEntrySpacer;
			int widthsum = topbar == null && style == "icons" ? 0 : topbar.Width + sk.ListEntrySpacer;
			DebugWrite("Topbar: " + topbar + " heightsum: " + heightsum);
			//SetupPage(title, true, false, 1);
			while (ie.MoveNext())
			{
				bool first = loc<numperpage;
				bool last = loc > (listEntries.Count-numperpage - (topbar!=null?1:0));
				DebugWrite("First: "+first+" Last: "+last );
				DebugWrite("Current loc: "+loc+" numperpage: "+numperpage+" Mod: "+loc%numperpage);
				if (loc % numperpage == 0 && count < listEntries.Count-1 )
				{ 
					SetupPage(title, first, last, pageID); 
					loc++; 
					pageID++;
					heightsum = topbar == null ? 0 : topbar.Height + sk.ListEntrySpacer;
					widthsum = topbar == null && style == "icons" ? 0 : topbar.Width + sk.ListEntrySpacer;
				}
				GumpListEntry gle = (GumpListEntry)((KeyValuePair<int, GumpListEntry>)ie.Current).Value;
				if (gle != topbar)
				{
					switch (style)
					{
						case "details":
							gle.Y = Y+heightsum; //sk.ListStartY +
							gle.X = X;//sk.ListStartX +
							gle.AppendTo(page);
							heightsum += sk.ListEntrySpacer + gle.Height;
							break;
						case "icons":
							gle.Y = Y + heightsum;//+sk.ListStartY
							gle.X = X + widthsum;//sk.ListStartX + 
							gle.AppendTo(page);
							heightsum += sk.ListEntrySpacer + gle.Height;
							widthsum += sk.ListEntrySpacer + gle.Width;
							break;
					}
					loc++;
					count++;
				}						
			}
		}
		/// <summary>
		/// Sets up a new page for the GumpList to add items to.
		/// </summary>
		/// <param name="title">The title of the page.</param>
		/// <param name="first">Determines if actions for the first page should be taken.</param>
		/// <param name="last">Determines if actions for the last page should be taken.</param>
		/// <param name="pg">The page number of this page.</param>
		private void SetupPage(string title, bool first, bool last, int pg)
		{
			if (topbar != null)
			{
				topbar.X = X;//+sk.ListStartX;
				topbar.Y = Y;//+sk.ListStartY;
				topbar.AppendTo(page);				
			}
			ButtonInfo ListPrevButton = sk.ButtonInfo["ListPrevButton"];
			ButtonInfo ListNextButton = sk.ButtonInfo["ListNextButton"];
			//ButtonInfo inf2 = sk.ButtonInfo["ListDoneButton"];
			page.AddPage(pg);
			page.AddLabel( sk.ListTitleX, sk.ListTitleY, sk.ListTitleHue, title);
			DebugWrite("Page: "+pg);
			if (!first)
			{
				DebugWrite("Adding previous button: "+(pg-1));
				if( ListPrevButton.bgID != 0 )
					this.AddSuperButton(X + ListPrevButton.X, Y + ListPrevButton.Y, ListPrevButton.H, ListPrevButton.W, ListPrevButton.bgID, sk.ListUnderButtonN, sk.ListUnderButtonP, ListPrevButton.text, GumpButtonType.Page, 0, pg-1); 
				else
					page.AddButton( ListPrevButton.X, ListPrevButton.Y, ListPrevButton.up, ListPrevButton.down, 1, GumpButtonType.Page, pg-1 );
			}
			if (!last)
			{
				DebugWrite("Adding next button: " + (pg+1));
				if (ListNextButton.bgID != 0)
					this.AddSuperButton(X + ListNextButton.X, Y + ListNextButton.Y, ListNextButton.H, ListNextButton.W, ListNextButton.bgID, sk.ListUnderButtonN, sk.ListUnderButtonP, ListNextButton.text, GumpButtonType.Page, 0, pg+1);
				else
					page.AddButton(ListNextButton.X, ListNextButton.Y, ListNextButton.up, ListNextButton.down, 1, GumpButtonType.Page, pg + 1);
			}			
			//AddSuperButton(inf2.X, inf2.Y, inf2.H, inf2.W, inf2.bgID, sk.EntryButtonUnderlay, sk.EntryButtonUnderlay, inf2.text, GumpButtonType.Reply, 1, 0);
		}
		/// <summary>
		/// Long as poo. Adds a "super button" with a graphic overlay and text.
		/// </summary>
		/// <param name="x">X location of button.</param>
		/// <param name="y">Y location of button.</param>
		/// <param name="height">Height of graphical background.</param>
		/// <param name="width">Width of graphical background.</param>
		/// <param name="overlayID">ID of graphical background.</param>
		/// <param name="underID">Button ID of underlying button.</param>
		/// <param name="underIDpr">Button ID of pressed button.</param>
		/// <param name="text">The text the button should bear.</param>
		/// <param name="type">The GumpButtonType of the button.</param>
		/// <param name="replyID">The reply ID of the button (if any).</param>
		/// <param name="pageNum">The page number of the button (if ButtonType.Reply, leave 0) Also is the "param" entry for GumpButton.</param>
		private void AddSuperButton(int x, int y, int height, int width, int overlayID, int underID, int underIDpr, string text, GumpButtonType type, int replyID, int pageNum)
		{
			//page.AddButton(x + 1, y + 1, underID, underIDpr, replyID, type, pageNum);
			page.AddImageTiledButton(x, y, underID, underIDpr, replyID, type, pageNum, 0, 0, width, height );
			page.AddImageTiled(x, y, width, height, overlayID);
			page.AddLabel(x + 2, y + 2, sk.NormalText, text);
		}
		/// <summary>
		/// Returns the background of the list.
		/// </summary>
		/// <returns>An int representing the background ID.</returns>
		internal int GetBackground()
		{
			return m_BackgroundID;
		}
		#endregion
	}
	#endregion

	#region GumpListEntry
	/// <summary>
	/// This class is the "entry" for the List. Much like ListViewItem.
	/// </summary>
	public class GumpListEntry
	{
		#region Private Variables
		/// <summary>
		/// These are all relatively self-explanatory. Tooltip is not yet implemented.
		/// </summary>
		private int m_X, m_Y, m_Width, m_Height, m_TooltipID, m_BackgroundID;
		/// <summary>
		/// m_Tooltip turns tooltip on and off (unsupported), m_Background specifies if a background should be shown.
		/// </summary>
		private bool m_Tooltip, m_Background;
		/// <summary>
		/// The major Dictionary, containing the values of the columns for this entry.
		/// </summary>
		private Dictionary<int, object> columnValues = new Dictionary<int, object>();
		/// <summary>
		/// I forgot.
		/// </summary>
		private Dictionary<string, object> arguments = new Dictionary<string,object>();
		/// <summary>
		/// Number of columns, and I dunno.
		/// </summary>
		private int m_ColCount, captionID = 0;
		/// <summary>
		/// Whether or not dividers should be shown.
		/// </summary>
		private bool m_Dividers = true;
		/// <summary>
		/// What GumpList this entry is a part of.
		/// </summary>
		private GumpList m_ParentList = null;
		/// <summary>
		/// What skin the entry should use when displaying itself.
		/// </summary>
		private BaseSkin skin = null;
		/// <summary>
		/// The style the entry should display itself in. ("details" or "icons")
		/// </summary>
		private string m_Style = "details";
		/// <summary>
		/// The text for the tooltip (unsupported).
		/// </summary>
		private string m_TooltipText = "";
		#endregion
		
		#region Public and Internal Variables
		/// <summary>
		/// This variable will be reset by the GumpList programmatically.
		/// </summary>
		public int X
		{
			get	{ return m_X; }
			set { m_X=value; }
		}
		/// <summary>
		/// This variable will be reset by the GumpList programmatically.
		/// </summary>
		public int Y
		{
			get	{ return m_Y; }
			set { m_Y=value; }
		}
		/// <summary>
		/// The width of the entry. This will be reset by GumpList.
		/// </summary>
		public int Width
		{
			get { return m_Width; }
			set { m_Width=value; }
		}
		/// <summary>
		/// The height of the entry. This will be reset by GumpList.
		/// </summary>
		public int Height
		{
			get	{ return m_Height; }
			set	{ m_Height = value; }
		}
		/// <summary>
		/// The tooltip the item should display. Unsupported.
		/// </summary>
		internal string Tooltip { get { return m_TooltipText; } set { m_Tooltip = true; m_TooltipText = value; } }
		/// <summary>
		/// The ID of the tooltip. Unsupported.
		/// </summary>
		internal int TooltipID { get { return m_TooltipID; } set { m_TooltipID = value; m_Tooltip = true; } }
		/// <summary>
		/// The style the entry should assume.
		/// </summary>
		internal string Style { get { return m_Style; } set { if (m_Style != value) { m_Style = value; } } }
		#endregion

		#region Constructors
		//par has skin and location info. Also contains column count info.
		//style is "details" or "icons".
		/// <summary>
		/// Creates a new Gump List Entry.
		/// </summary>
		/// <param name="x">X location within the GumpList object.</param>
		/// <param name="y">Y location within the GumpList object.</param>
		/// <param name="par">Parent GumpList object.</param>
		/// <param name="width">Full width of GLE</param>
		/// <param name="height">Full height of GLE</param>
		public GumpListEntry( int x, int y, GumpList par, int width, int height )
		{
			skin = par.sk;
			m_X = x;
			m_Y = y;
			m_Width = width;
			m_Height = height;
			m_ParentList = par;
			m_Dividers = par.ShowDividers;
			m_Tooltip = false;
			m_TooltipID = 0;
			m_Background = par.ShowBackground;
			if( m_Background )
				m_BackgroundID = par.GetBackground();
			else
				m_BackgroundID = 0;
			m_Style = par.style;
		}
		//par has skin and location info. Also contains column count info.
		//style is "details" or "icons".
		/// <summary>
		/// Creates a new Gump List Entry.
		/// </summary>
		/// <param name="x">X location within the GumpList object.</param>
		/// <param name="y">Y location within the GumpList object.</param>
		/// <param name="par">Parent GumpList object.</param>
		/// <param name="width">Full width of GLE</param>
		/// <param name="height">Full height of GLE</param>
		/// <param name="iconID">ID of icon in icons mode.</param>
		public GumpListEntry(int x, int y, GumpList par, int width, int height, int iconID)
		{
			skin = par.sk;
			m_X = x;
			m_Y = y;
			m_Width = width;
			m_Height = height;
			m_ParentList = par;
			m_Dividers = par.ShowDividers;
			m_Tooltip = false;
			m_TooltipID = 0;
			m_Background = par.ShowBackground;
			if (m_Background)
				m_BackgroundID = par.GetBackground();
			else
				m_BackgroundID = 0;
			m_Style = par.style;
		}
		#endregion

		#region Add/Remove
		/// <summary>
		/// Used to add a pure-text (html or label is autodetected) column to the entry in DETAILS mode.
		/// </summary>
		/// <param name="text">the text to add to a column.</param>
		public void AddColumn( string text )
		{
			if (m_Style == "details")
			{
				columnValues.Add(m_ColCount, text);
				m_ColCount++;
			}
		}
		/// <summary>
		/// Used to add a Button column to the list in DETAILS mode.
		/// </summary>
		/// <param name="button">The button to be added.</param>
		public void AddColumn(GumpButton button)
		{
			if (m_Style == "details")
			{
				columnValues.Add(m_ColCount, button);
				if( !arguments.ContainsKey("button") )
				arguments.Add( "button", button );
				m_ColCount++;
			}
			m_ParentList.DebugWrite("Column Count: " + m_ColCount);
		}
		/// <summary>
		/// Used to a a Checkbox column to the list in DETAILS mode.
		/// </summary>
		/// <param name="check"></param>
		public void AddColumn(GumpCheck check)
		{
			if (m_Style == "details")
			{
				columnValues.Add(m_ColCount, check);
				m_ColCount++;
			}
			m_ParentList.DebugWrite("Column Count: "+m_ColCount);
		}
		/// <summary>
		/// Used to add a text entry to the list in DETAILS mode.
		/// </summary>
		/// <param name="entry">The text entry to be added.</param>
		public void AddColumn(GumpTextEntry entry)
		{
			if (m_Style == "details")
			{
				columnValues.Add(m_ColCount, entry);
				m_ColCount++;
			}
			m_ParentList.DebugWrite("Column Count: " + m_ColCount);
		}
		/// <summary>
		/// Creates an entry for an icon-based list in ICONS mode.
		/// </summary>
		/// <param name="caption">The entry's caption.</param>
		/// <param name="iconID">The icon ID of the icon.</param>
		/// <param name="button">The button the icon represents.</param>
		public void SetupIcon(string caption, int iconID, GumpButton button )
		{
			columnValues.Add(m_ColCount, caption );
			captionID = m_ColCount;
			arguments.Add("icon", iconID );
			arguments.Add("button", button);
			m_ColCount++;
			m_ParentList.DebugWrite("Column Count: " + m_ColCount);
		}
		/// <summary>
		/// Should the need arise, you can remove a column from the list BEFORE sending the gump.
		/// </summary>
		/// <param name="which">The 0-based column to remove.</param>
		internal void RemoveColumn(int which)
		{
			if (columnValues.ContainsKey(which))
				columnValues.Remove(which);
		}
		#endregion

		#region AppendTo
		/// <summary>
		/// The main method for putting the entry on the page. This method is accessed from the GumpList class when CommitList() is called.
		/// </summary>
		/// <param name="page">The gump to which the entry should be appended.</param>
		public void AppendTo(Gump page)
		{	
			m_ColCount = columnValues.Count < m_ParentList.columns? columnValues.Count: m_ParentList.columns;
			if( m_ColCount == 0 )
				return;
			if (m_Background)
			{
				GumpImageTiled b = new GumpImageTiled( m_X, m_Y, m_Width, m_Height, m_BackgroundID );
				page.Add(b);
			}			
			if (m_Style == "details")
			{
				m_ParentList.DebugWrite("Details mode.");
				int i = 0;
				//int columnval = -1;
				
				int colWidth = Width / m_ColCount;
				int xbase = m_X;
				while (i < columnValues.Count && i < m_ParentList.columns)
				{				
					colWidth = getWidthOfColumn(i);
					xbase = m_X + getCurrentXLocation(i+1);
					m_ParentList.DebugWrite("Appending Columns.");
					try
					{
						object o = columnValues[i];
						if (o is GumpButton)
						{
							GumpButton btn = (GumpButton)o;
							btn.X = xbase+skin.ListColumnIndent;
							btn.Y = m_Y;
							page.Add(btn);
						}
						else if (o is GumpCheck)
						{
							GumpCheck c = (GumpCheck)o;
							c.X = xbase + skin.ListColumnIndent;
							c.Y = m_Y;
							page.Add(c);
						}
						else if (o is GumpTextEntry)
						{
							GumpTextEntry t = (GumpTextEntry)o;
							t.X = xbase + skin.ListColumnIndent;
							t.Y = m_Y;
							t.Width = colWidth;
							t.Height = m_Height;
							page.Add(t);
						}
						else if (o is string)
						{
							string s = (string)o;
							m_ParentList.DebugWrite("stringy! " + s);
							if (s.Contains("</"))
							{
								GumpHtml h = new GumpHtml(xbase + skin.ListColumnIndent, m_Y, colWidth, m_Height, s, false, false);
								h.Parent = page;
								page.Add(h);
						}
							else
							{
								m_ParentList.DebugWrite("text");
								GumpLabel g = new GumpLabel(xbase + skin.ListColumnIndent, m_Y, skin.NormalText, s);
								g.Parent = page;
								page.Add(g);
							}
						}
						i++;
					}
					catch (Exception e)
					{
						Console.WriteLine("Problem in AppendTo - " + e);
						i = columnValues.Count;
					}
					if (m_Dividers)
					{
						GumpImageTiled t = new GumpImageTiled(xbase + colWidth, m_Y, skin.EntryDividerWidth, skin.EntryDividerHeight, skin.EntryDividerID);
						page.Add(t);
					}
				}
				m_ParentList.DebugWrite("Done, details.");
			}
			else if (m_Style == "icons")
			{
				m_ParentList.DebugWrite("Icons mode.");
				Hashtable table = (Hashtable)columnValues[0];
				string s = (string)table["caption"];
				if (m_Background)
				{
					GumpImageTiled t = new GumpImageTiled( m_X, m_Y, m_Width, m_Height, m_BackgroundID );
					page.Add(t);
				}
				GumpButton button;
				if ( arguments.ContainsKey("button") )
				{
					button = (GumpButton)arguments["button"];
					page.Add(button);
				}
				else
				{ 
					return; 
				}
				
				int icon = arguments["icon"] != null ? (int)arguments["icon"] : skin.EntryDefaultIcon;
				GumpImage im = new GumpImage( (skin.EntryCaptionWidth-m_X)-skin.EntryIconWidth/2, m_Y+skin.EntryIconY, icon );
				page.Add(im);
				if (s.Contains("</"))
				{
					GumpHtml h = new GumpHtml(m_X, m_Y, m_Width, m_Height, s, false, false);
					h.Parent = page;
					page.Add(h);
				}
				else
				{
					GumpLabel g = new GumpLabel(m_X, m_Y+skin.EntryCaptionPositionY, skin.NormalText, s);
					g.Parent = page;
					page.Add(g);
				}
			}
			else
				Console.WriteLine("Unknown style: "+m_Style);
			 
		}

		private int getWidthOfColumn(int i)
		{
			if (m_ParentList.columnWidths.ContainsKey(i))
				return m_ParentList.columnWidths[i];
			else
			{
				int countcol = m_ParentList.columnWidths.Count;
				int wsum = 0;
				IEnumerator ie = m_ParentList.columnWidths.GetEnumerator();
				while (ie.MoveNext())
				{
					wsum += ((KeyValuePair<int,int>)ie.Current).Value;
				}
				int totalcol = columnValues.Count;
				return (m_Width - wsum)/(totalcol-countcol);
			}
		}

		private int getCurrentXLocation(int i)
		{
			int sumx = 0;
			int x = 0;
			while (i > 1)
			{
				sumx+=getWidthOfColumn( x );
				x++;
				i--;
			}
			return sumx;
		}
		#endregion

		#region Compile
		/// <summary>
		/// Honestly...I don't know why this is here.
		/// </summary>
		/// <param name="page">The gump to reference.</param>
		/// <returns>A string of the specially formatted gump entries.</returns>
		public string Compile( Gump page)
		{
			string ret = "";
			switch (m_Style)
			{
				case "details":
					if( m_Background )
						ret+= String.Format("{{ gumppictiled {0} {1} {2} {3} {4} }}", m_X, m_Y, m_Width, m_Height, m_BackgroundID );
					int colWidth = Width/m_ColCount;
					int i = 0;
					int xbase = m_X;
					while (i < columnValues.Count && i < m_ParentList.columns)
					{
						xbase = m_X + (i * colWidth);
						object obj = columnValues[i];
						if (obj is string)
						{
							string caption = (string)obj;
							if (caption.Contains("</"))
								ret += String.Format("{{ htmlgump {0} {1} {2} {3} {4} {5} {6} }}", m_X + (i * colWidth), m_Y, colWidth, m_Height, page.Intern(caption), false, false);
							else
								ret += String.Format("{{ text {0} {1} {2} {3} }}", m_X + (i * colWidth), m_Y, skin.NormalText, page.Intern(caption));
						}
						else if (obj is GumpButton)
						{
							GumpButton btn = (GumpButton)obj;
							ret+= String.Format("{{ button {0} {1} {2} {3} {4} {5} {6} }}", xbase, m_Y, btn.NormalID, btn.PressedID, (int)btn.Type, btn.Param, btn.ButtonID );
						}
						else if (obj is GumpCheck)
						{
							GumpCheck chk = (GumpCheck)obj;
							ret += String.Format("{{ checkbox {0} {1} {2} {3} {4} {5} }}", xbase, m_Y, chk.ActiveID, chk.InactiveID, chk.InitialState, chk.SwitchID);
						}
						ret+= String.Format("{{gumppictiled {0} {1} {2} {3} {4} }}", m_X+(i*colWidth), m_Y, skin.EntryDividerWidth, skin.EntryDividerHeight, skin.EntryDividerID );
						i++;
					}
					break;
				case "icons":
					string caption2 = (string)columnValues[captionID];
					if (caption2.Contains("</"))
						ret += String.Format("{{ htmlgump {0} {1} {2} {3} {4} {5} {6} }}", m_X, m_Y+skin.EntryCaptionPositionY, skin.EntryCaptionWidth, skin.EntryCaptionHeight, page.Intern(caption2), false, false);
					else
						ret += String.Format("{{ text {0} {1} {2} {3} }}", m_X, m_Y + skin.EntryCaptionPositionY, skin.NormalText, page.Intern(caption2));
					int id = skin.EntryDefaultIcon;
					ret+= String.Format("{{ gumppictiled {0} {1} {2} {3} {4} }}", m_X, m_Y, m_Width, m_Height, m_BackgroundID);
					if( arguments.ContainsKey( "icon" ) )
						id = (int)arguments["icon"];
					ret+= String.Format("{{ gumppictiled {0} {1} {2} {3} {4} }}", ((skin.EntryCaptionWidth-m_X)-skin.EntryIconWidth)/2, m_Y+skin.EntryIconY, skin.EntryIconWidth, skin.EntryIconHeight, id );
					GumpButton btn2 = null;
					if( arguments.ContainsKey("button") )
					{
						btn2 = (GumpButton)arguments["button"];
						ret+= String.Format("{{ buttontileart {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} }}", m_X, m_Y, skin.EntryButtonUnderlay, skin.EntryButtonUnderlay, (int)btn2.Type, btn2.Param, btn2.ButtonID, skin.EntryButtonUnderlay, skin.DefaultBackgroundColor, skin.EntryIconWidth, skin.EntryIconHeight );
					}					
					break;
			}
			if (m_Tooltip)
				ret += String.Format("{{ tooltip {0} }}", TooltipID);
			return ret;
		}
		#endregion		
	}
	#endregion
}