using System;
using System.Net;
using System.Collections;
using System.Windows.Forms;

using Server;
using Server.Network;
using Server.Accounting;

namespace Server.Engines.WatchUO.Plugins {
	public class FirewallPlugin : BasePlugin {
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox TB_Manual;
		private System.Windows.Forms.Button Button_ManualAdd;
		private System.Windows.Forms.Button Button_ManualRemove;
		private System.Windows.Forms.Button Button_ManualFind;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ListBox EffectedAccountsList;
		private System.Windows.Forms.Button Button_RefreshAccountList;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ListBox ListBox_Firewalled;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button Button_RefreshIngame;
		public System.Windows.Forms.ListBox ListBox_Ingame;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button Button_RefreshCFList;
		private System.Windows.Forms.Button Button_IG_AddSelected;
		private System.Windows.Forms.Button Button_IG_SelectAll;
		private System.Windows.Forms.Button Button_IG_DeselectAll;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Button Button_CF_DeselectAll;
		private System.Windows.Forms.Button Button_CF_SelectAll;
		private System.Windows.Forms.Button Button_CF_RemoveSelected;
		private System.Windows.Forms.Button Button_CF_SelectExtended;
		private System.Windows.Forms.Button Button_CF_SortExtended;
		private System.Windows.Forms.Button Button_IG_SortExtended;
		private System.Windows.Forms.Button Button_IG_SelectExtended;

		public FirewallPlugin() : base("RunUO Firewall") {
			this.Order = 20;
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.Button_CF_SortExtended = new System.Windows.Forms.Button();
			this.Button_CF_SelectExtended = new System.Windows.Forms.Button();
			this.Button_CF_DeselectAll = new System.Windows.Forms.Button();
			this.Button_CF_SelectAll = new System.Windows.Forms.Button();
			this.Button_CF_RemoveSelected = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.Button_IG_SortExtended = new System.Windows.Forms.Button();
			this.Button_IG_SelectExtended = new System.Windows.Forms.Button();
			this.Button_IG_DeselectAll = new System.Windows.Forms.Button();
			this.Button_IG_SelectAll = new System.Windows.Forms.Button();
			this.Button_IG_AddSelected = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.Button_RefreshIngame = new System.Windows.Forms.Button();
			this.ListBox_Ingame = new System.Windows.Forms.ListBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.Button_RefreshCFList = new System.Windows.Forms.Button();
			this.ListBox_Firewalled = new System.Windows.Forms.ListBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.Button_RefreshAccountList = new System.Windows.Forms.Button();
			this.EffectedAccountsList = new System.Windows.Forms.ListBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.Button_ManualFind = new System.Windows.Forms.Button();
			this.Button_ManualRemove = new System.Windows.Forms.Button();
			this.Button_ManualAdd = new System.Windows.Forms.Button();
			this.TB_Manual = new System.Windows.Forms.TextBox();
			
			this.groupBox1.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			
			this.Controls.Add(this.groupBox1);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox7);
			this.groupBox1.Controls.Add(this.groupBox6);
			this.groupBox1.Controls.Add(this.groupBox5);
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Location = new System.Drawing.Point(24, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(736, 472);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "RunUO Firewall";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.Button_CF_SortExtended);
			this.groupBox7.Controls.Add(this.Button_CF_SelectExtended);
			this.groupBox7.Controls.Add(this.Button_CF_DeselectAll);
			this.groupBox7.Controls.Add(this.Button_CF_SelectAll);
			this.groupBox7.Controls.Add(this.Button_CF_RemoveSelected);
			this.groupBox7.Location = new System.Drawing.Point(168, 176);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(88, 272);
			this.groupBox7.TabIndex = 9;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Remove";
			// 
			// Button_CF_SortExtended
			// 
			this.Button_CF_SortExtended.Location = new System.Drawing.Point(8, 216);
			this.Button_CF_SortExtended.Name = "Button_CF_SortExtended";
			this.Button_CF_SortExtended.Size = new System.Drawing.Size(72, 40);
			this.Button_CF_SortExtended.TabIndex = 4;
			this.Button_CF_SortExtended.Text = "Sort...";
			this.Button_CF_SortExtended.Click += new EventHandler(Button_CF_SortExtended_Click);
			// 
			// Button_CF_SelectExtended
			// 
			this.Button_CF_SelectExtended.Location = new System.Drawing.Point(8, 168);
			this.Button_CF_SelectExtended.Name = "Button_CF_SelectExtended";
			this.Button_CF_SelectExtended.Size = new System.Drawing.Size(72, 40);
			this.Button_CF_SelectExtended.TabIndex = 3;
			this.Button_CF_SelectExtended.Text = "Select...";
			this.Button_CF_SelectExtended.Click += new EventHandler(Button_CF_SelectExtended_Click);
			// 
			// Button_CF_DeselectAll
			// 
			this.Button_CF_DeselectAll.Location = new System.Drawing.Point(8, 120);
			this.Button_CF_DeselectAll.Name = "Button_CF_DeselectAll";
			this.Button_CF_DeselectAll.Size = new System.Drawing.Size(72, 40);
			this.Button_CF_DeselectAll.TabIndex = 2;
			this.Button_CF_DeselectAll.Text = "Deselect all";
			this.Button_CF_DeselectAll.Click += new EventHandler(Button_CF_DeselectAll_Click);
			// 
			// Button_CF_SelectAll
			// 
			this.Button_CF_SelectAll.Location = new System.Drawing.Point(8, 72);
			this.Button_CF_SelectAll.Name = "Button_CF_SelectAll";
			this.Button_CF_SelectAll.Size = new System.Drawing.Size(72, 40);
			this.Button_CF_SelectAll.TabIndex = 1;
			this.Button_CF_SelectAll.Text = "Select all";
			this.Button_CF_SelectAll.Click += new EventHandler(Button_CF_SelectAll_Click);
			// 
			// Button_CF_RemoveSelected
			// 
			this.Button_CF_RemoveSelected.Location = new System.Drawing.Point(8, 24);
			this.Button_CF_RemoveSelected.Name = "Button_CF_RemoveSelected";
			this.Button_CF_RemoveSelected.Size = new System.Drawing.Size(72, 40);
			this.Button_CF_RemoveSelected.TabIndex = 0;
			this.Button_CF_RemoveSelected.Text = "Remove Selected";
			this.Button_CF_RemoveSelected.Click += new EventHandler(Button_CF_RemoveSelected_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.Button_IG_SortExtended);
			this.groupBox6.Controls.Add(this.Button_IG_SelectExtended);
			this.groupBox6.Controls.Add(this.Button_IG_DeselectAll);
			this.groupBox6.Controls.Add(this.Button_IG_SelectAll);
			this.groupBox6.Controls.Add(this.Button_IG_AddSelected);
			this.groupBox6.Location = new System.Drawing.Point(464, 176);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(88, 272);
			this.groupBox6.TabIndex = 8;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Add";
			// 
			// Button_IG_SortExtended
			// 
			this.Button_IG_SortExtended.Location = new System.Drawing.Point(8, 216);
			this.Button_IG_SortExtended.Name = "Button_IG_SortExtended";
			this.Button_IG_SortExtended.Size = new System.Drawing.Size(72, 40);
			this.Button_IG_SortExtended.TabIndex = 6;
			this.Button_IG_SortExtended.Text = "Sort...";
			this.Button_IG_SortExtended.Click += new EventHandler(Button_IG_SortExtended_Click);
			// 
			// Button_IG_SelectExtended
			// 
			this.Button_IG_SelectExtended.Location = new System.Drawing.Point(8, 168);
			this.Button_IG_SelectExtended.Name = "Button_IG_SelectExtended";
			this.Button_IG_SelectExtended.Size = new System.Drawing.Size(72, 40);
			this.Button_IG_SelectExtended.TabIndex = 5;
			this.Button_IG_SelectExtended.Text = "Select...";
			this.Button_IG_SelectExtended.Click += new EventHandler(Button_IG_SelectExtended_Click);
			// 
			// Button_IG_DeselectAll
			// 
			this.Button_IG_DeselectAll.Location = new System.Drawing.Point(8, 120);
			this.Button_IG_DeselectAll.Name = "Button_IG_DeselectAll";
			this.Button_IG_DeselectAll.Size = new System.Drawing.Size(72, 40);
			this.Button_IG_DeselectAll.TabIndex = 2;
			this.Button_IG_DeselectAll.Text = "Deselect all";
			this.Button_IG_DeselectAll.Click += new EventHandler(Button_IG_DeselectAll_Click);
			// 
			// Button_IG_SelectAll
			// 
			this.Button_IG_SelectAll.Location = new System.Drawing.Point(8, 72);
			this.Button_IG_SelectAll.Name = "Button_IG_SelectAll";
			this.Button_IG_SelectAll.Size = new System.Drawing.Size(72, 40);
			this.Button_IG_SelectAll.TabIndex = 1;
			this.Button_IG_SelectAll.Text = "Select all";
			this.Button_IG_SelectAll.Click += new EventHandler(Button_IG_SelectAll_Click);
			// 
			// Button_IG_AddSelected
			// 
			this.Button_IG_AddSelected.Location = new System.Drawing.Point(8, 24);
			this.Button_IG_AddSelected.Name = "Button_IG_AddSelected";
			this.Button_IG_AddSelected.Size = new System.Drawing.Size(72, 40);
			this.Button_IG_AddSelected.TabIndex = 0;
			this.Button_IG_AddSelected.Text = "Add Selected";
			this.Button_IG_AddSelected.Click += new EventHandler(Button_IG_AddSelected_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.Button_RefreshIngame);
			this.groupBox5.Controls.Add(this.ListBox_Ingame);
			this.groupBox5.Location = new System.Drawing.Point(568, 32);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(152, 416);
			this.groupBox5.TabIndex = 7;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Currently Ingame";
			// 
			// Button_RefreshIngame
			// 
			this.Button_RefreshIngame.Location = new System.Drawing.Point(16, 376);
			this.Button_RefreshIngame.Name = "Button_RefreshIngame";
			this.Button_RefreshIngame.Size = new System.Drawing.Size(112, 24);
			this.Button_RefreshIngame.TabIndex = 3;
			this.Button_RefreshIngame.Text = "Refresh";
			this.Button_RefreshIngame.Click += new EventHandler(Button_RefreshIngame_Click);
			// 
			// ListBox_Ingame
			// 
			this.ListBox_Ingame.Location = new System.Drawing.Point(16, 24);
			this.ListBox_Ingame.Name = "ListBox_Ingame";
			this.ListBox_Ingame.Size = new System.Drawing.Size(112, 342);
			this.ListBox_Ingame.TabIndex = 2;
			this.ListBox_Ingame.SelectionMode = SelectionMode.MultiExtended;
			this.ListBox_Ingame.SelectedIndexChanged += new EventHandler(ListBox_Ingame_SelectedIndexChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.Button_RefreshCFList);
			this.groupBox4.Controls.Add(this.ListBox_Firewalled);
			this.groupBox4.Location = new System.Drawing.Point(16, 32);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(144, 416);
			this.groupBox4.TabIndex = 6;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Currenty Firewalled";
			// 
			// Button_RefreshCFList
			// 
			this.Button_RefreshCFList.Location = new System.Drawing.Point(16, 376);
			this.Button_RefreshCFList.Name = "Button_RefreshCFList";
			this.Button_RefreshCFList.Size = new System.Drawing.Size(112, 24);
			this.Button_RefreshCFList.TabIndex = 3;
			this.Button_RefreshCFList.Text = "Refresh";
			// 
			// ListBox_Firewalled
			// 
			this.ListBox_Firewalled.Location = new System.Drawing.Point(16, 24);
			this.ListBox_Firewalled.Name = "ListBox_Firewalled";
			this.ListBox_Firewalled.Size = new System.Drawing.Size(112, 342);
			this.ListBox_Firewalled.TabIndex = 2;
			this.ListBox_Firewalled.SelectionMode = SelectionMode.MultiExtended;
			this.ListBox_Firewalled.SelectedIndexChanged += new EventHandler(ListBox_Firewalled_SelectedIndexChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.Button_RefreshAccountList);
			this.groupBox3.Controls.Add(this.EffectedAccountsList);
			this.groupBox3.Location = new System.Drawing.Point(276, 152);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(168, 296);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Affected Accounts";
			// 
			// Button_RefreshAccountList
			// 
			this.Button_RefreshAccountList.Location = new System.Drawing.Point(16, 256);
			this.Button_RefreshAccountList.Name = "Button_RefreshAccountList";
			this.Button_RefreshAccountList.Size = new System.Drawing.Size(136, 24);
			this.Button_RefreshAccountList.TabIndex = 1;
			this.Button_RefreshAccountList.Text = "Refresh";
			// 
			// EffectedAccountsList
			// 
			this.EffectedAccountsList.Location = new System.Drawing.Point(16, 24);
			this.EffectedAccountsList.Name = "EffectedAccountsList";
			this.EffectedAccountsList.Size = new System.Drawing.Size(136, 212);
			this.EffectedAccountsList.TabIndex = 0;
			this.EffectedAccountsList.SelectionMode = SelectionMode.One;
			this.EffectedAccountsList.DoubleClick += new EventHandler(EffectedAccountsList_DoubleClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.Button_ManualFind);
			this.groupBox2.Controls.Add(this.Button_ManualRemove);
			this.groupBox2.Controls.Add(this.Button_ManualAdd);
			this.groupBox2.Controls.Add(this.TB_Manual);
			this.groupBox2.Location = new System.Drawing.Point(228, 32);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(268, 96);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Manual Changes";
			// 
			// Button_ManualFind
			// 
			this.Button_ManualFind.Location = new System.Drawing.Point(176, 56);
			this.Button_ManualFind.Name = "Button_ManualFind";
			this.Button_ManualFind.Size = new System.Drawing.Size(72, 24);
			this.Button_ManualFind.TabIndex = 3;
			this.Button_ManualFind.Text = "Find";
			this.Button_ManualFind.Click += new EventHandler(Button_ManualFind_Click);
			// 
			// Button_ManualRemove
			// 
			this.Button_ManualRemove.Location = new System.Drawing.Point(96, 56);
			this.Button_ManualRemove.Name = "Button_ManualRemove";
			this.Button_ManualRemove.Size = new System.Drawing.Size(72, 24);
			this.Button_ManualRemove.TabIndex = 2;
			this.Button_ManualRemove.Text = "Remove";
			this.Button_ManualRemove.Click += new EventHandler(Button_ManualRemove_Click);
			// 
			// Button_ManualAdd
			// 
			this.Button_ManualAdd.Location = new System.Drawing.Point(16, 56);
			this.Button_ManualAdd.Name = "Button_ManualAdd";
			this.Button_ManualAdd.Size = new System.Drawing.Size(72, 24);
			this.Button_ManualAdd.TabIndex = 1;
			this.Button_ManualAdd.Text = "Add";
			this.Button_ManualAdd.Click += new System.EventHandler(this.Button_ManualAdd_Click);
			// 
			// TB_Manual
			// 
			this.TB_Manual.Location = new System.Drawing.Point(16, 24);
			this.TB_Manual.Name = "TB_Manual";
			this.TB_Manual.Size = new System.Drawing.Size(232, 20);
			this.TB_Manual.TabIndex = 0;
			this.TB_Manual.Text = "";
		}

		public override void OnLoad() {
			base.OnLoad ();
			this.RefreshCFList();
			this.RefreshIGList();
		}


		public static void DeSelectAllFrom(ListBox box, bool selected) {
			if (box.Items.Count <= 0)
				return;
			for (int i = 0; i < box.Items.Count; i++) {
				box.SetSelected(i, selected);
			}
		}

		private void RefreshIGList() {
			this.ListBox_Ingame.Items.Clear();
			for (int i = 0; i < NetState.Instances.Count; i++) {
				if (NetState.Instances[i] != null) {
					NetState ns = NetState.Instances[i] as NetState;
					if (ns != null && ns.Running && ns.Address != null) {
						this.ListBox_Ingame.Items.Add(ns.Address.ToString());
					} else {
						Console.WriteLine((ns != null));
						Console.WriteLine(ns.Running);
						Console.WriteLine((ns.Address != null));
					}
				} else {
					Console.WriteLine("instances null");
				}
			}
			this.RefreshEffectedAccountsList(null);
		}

		private void RefreshCFList() {
			this.ListBox_Firewalled.Items.Clear();
			for (int i = 0; i < Server.Firewall.List.Count; i++) {
				object obj = Server.Firewall.List[i];
				if (obj is string) 
					this.ListBox_Firewalled.Items.Add(obj);
				else if (obj is IPAddress)
					this.ListBox_Firewalled.Items.Add(obj.ToString());
			}
			this.RefreshEffectedAccountsList(null);
		}

		private void RefreshEffectedAccountsList(IPAddress addr) {
			this.EffectedAccountsList.Items.Clear();
			if (addr == null) {
			} else {
				string pattern = addr.ToString();

				foreach ( Account acct in Accounts.GetAccounts() ) {
					IPAddress[] loginList = acct.LoginIPs;
					bool contains = false;
					for ( int i = 0; !contains && i < loginList.Length; ++i )
						contains = ( pattern == null ? loginList[i].Equals( addr ) : Utility.IPMatch( pattern, loginList[i] ) );
					if ( contains )
						this.EffectedAccountsList.Items.Add(acct.Username);
				}
			}
		}

		private IPAddress ConvertToIPAddress(string pattern) {
			try {
				IPAddress addr = IPAddress.Parse(pattern);
				if (addr != null)
					return addr;
				else
					return null;
			} catch {
				return null;
			}
		}

		private void Button_CF_SortExtended_Click(object sender, EventArgs e) {
			MessageBox.Show(Core.MainForm, "Not implemented yet. Stay tuned for the next version", "Under construction");
		}

		private void Button_CF_SelectExtended_Click(object sender, EventArgs e) {
			MessageBox.Show(Core.MainForm, "Not implemented yet. Stay tuned for the next version", "Under construction");
		}

		private void Button_IG_SortExtended_Click(object sender, EventArgs e) {
			MessageBox.Show(Core.MainForm, "Not implemented yet. Stay tuned for the next version", "Under construction");
		}

		private void Button_IG_SelectExtended_Click(object sender, EventArgs e) {
			MessageBox.Show(Core.MainForm, "Not implemented yet. Stay tuned for the next version", "Under construction");
		}

		private void Button_IG_SelectAll_Click(object sender, EventArgs e) {
			DeSelectAllFrom(this.ListBox_Ingame, true);
			if (this.ListBox_Ingame.Items.Count <= 0)
				this.RefreshEffectedAccountsList(null);
			else
				this.RefreshEffectedAccountsList(this.ConvertToIPAddress(this.ListBox_Ingame.SelectedItems[this.ListBox_Ingame.SelectedItems.Count-1].ToString()));
		}

		private void Button_IG_DeselectAll_Click(object sender, EventArgs e) {
			DeSelectAllFrom(this.ListBox_Ingame, false);
			this.RefreshEffectedAccountsList(null);
		}

		private void Button_CF_DeselectAll_Click(object sender, EventArgs e) {
			DeSelectAllFrom(this.ListBox_Firewalled, false);
			this.RefreshEffectedAccountsList(null);
		}

		private void Button_CF_SelectAll_Click(object sender, EventArgs e) {
			DeSelectAllFrom(this.ListBox_Firewalled, true);
			if (this.ListBox_Firewalled.Items.Count <= 0)
				this.RefreshEffectedAccountsList(null);
			else
				this.RefreshEffectedAccountsList(this.ConvertToIPAddress(this.ListBox_Firewalled.SelectedItems[this.ListBox_Firewalled.SelectedItems.Count-1].ToString()));
		}

		
		private void Button_ManualAdd_Click(object sender, System.EventArgs e) {
			IPAddress addr = this.ConvertToIPAddress(this.TB_Manual.Text);
			if (addr != null) {
				Server.Firewall.Add(addr);
				Server.Firewall.Save();
				this.RefreshCFList();
			} else {
				MessageBox.Show(Core.MainForm, "Invalid Address", "Error");
			}
		}

		private void Button_ManualRemove_Click(object sender, EventArgs e) {
			IPAddress addr = this.ConvertToIPAddress(this.TB_Manual.Text);
			if (addr != null) {
				if (Server.Firewall.List.Contains(addr.ToString())) {
					Server.Firewall.List.Remove(addr.ToString());
					Server.Firewall.Save();
					this.RefreshCFList();
				} else if (Server.Firewall.List.Contains(addr)) {
					Server.Firewall.List.Remove(addr);
					Server.Firewall.Save();
					this.RefreshCFList();
				} else {
					MessageBox.Show(Core.MainForm, "This Address is currently not firewalled", "Error");
				}
			} else {
				MessageBox.Show(Core.MainForm, "Invalid Address", "Error");
			}
		}

		
		private void Button_ManualFind_Click(object sender, EventArgs e) {
			IPAddress addr = this.ConvertToIPAddress(this.TB_Manual.Text);
			if (addr != null) {
				if (Server.Firewall.List.Contains(addr.ToString())) {
					DeSelectAllFrom(this.ListBox_Firewalled, false);
					this.ListBox_Firewalled.SetSelected(this.ListBox_Firewalled.Items.IndexOf(addr.ToString()), true);
				} else if (Server.Firewall.List.Contains(addr)) {
					DeSelectAllFrom(this.ListBox_Firewalled, false);
					this.ListBox_Firewalled.SetSelected(this.ListBox_Firewalled.Items.IndexOf(addr), true);
				} else {
					MessageBox.Show(Core.MainForm, "This Address is currently not firewalled", "Error");
				}
			} else {
				MessageBox.Show(Core.MainForm, "Invalid Address", "Error");
			}
		}

		private void EffectedAccountsList_DoubleClick(object sender, EventArgs e) {
			if (this.EffectedAccountsList.SelectedItem != null) {
				for (int i = 0; i < Core.PluginLoader.LoadedPlugins.Count; i++) {
					if (Core.PluginLoader.LoadedPlugins[i] is AccountPlugin) {
						AccountPlugin acctp = Core.PluginLoader.LoadedPlugins[i] as AccountPlugin;
						if (acctp != null) {
							int idx = acctp.listBox1.Items.IndexOf(this.EffectedAccountsList.SelectedItem as string);
							if (idx >= 0) {
								DeSelectAllFrom(acctp.listBox1, false);
								acctp.listBox1.SetSelected(idx, true);
								Core.MainForm.TabControl.SelectedTab = Core.MainForm.TabControl.TabPages[Core.MainForm.TabControl.TabPages.IndexOf(acctp)];
								return;
							} else{
								MessageBox.Show(Core.MainForm, "Account not found", "Error");
								return;
							}
						} else {
							MessageBox.Show(Core.MainForm, "Account not found", "Error");
							return;
						}
					}
				}
				MessageBox.Show(Core.MainForm, "AccountPlugin not loaded", "Error");
			}
		}

		private void Button_IG_AddSelected_Click(object sender, EventArgs e) {
			if (this.ListBox_Ingame.SelectedItems.Count > 0) {
				for (int i = 0; i < this.ListBox_Ingame.SelectedItems.Count; i++) {
					IPAddress addr = this.ConvertToIPAddress(this.ListBox_Ingame.SelectedItems[i].ToString());
					if (addr != null) {
						Server.Firewall.Add(this.ListBox_Ingame.SelectedItems[i].ToString());
					} else {
						MessageBox.Show(Core.MainForm, string.Format("{0} is not a valid IP Address. Don't know how it got there...", this.ListBox_Ingame.SelectedItems[i].ToString()), "Error");
					}
				}
				MessageBox.Show(Core.MainForm, string.Format("{0} address(es) firewalled.", this.ListBox_Ingame.SelectedItems.Count), "Successful");
				Server.Firewall.Save();
				this.RefreshCFList();
			} else {
				MessageBox.Show(Core.MainForm, "No Items selected", "Error");
			}
		}

		private void Button_CF_RemoveSelected_Click(object sender, EventArgs e) {
			if (this.ListBox_Firewalled.SelectedItems.Count > 0) {
				for (int i = 0; i < this.ListBox_Firewalled.SelectedItems.Count; i++) {
					IPAddress addr = ConvertToIPAddress(this.ListBox_Firewalled.SelectedItems[i].ToString());
					if (addr != null) {
						Server.Firewall.Remove(addr);
						Server.Firewall.Remove(addr.ToString());
					} else {
						MessageBox.Show(Core.MainForm, string.Format("{0} is not a valid IP Address. Don't know how it got there...", this.ListBox_Firewalled.SelectedItems[i].ToString()), "Error");
					}
				}
				MessageBox.Show(Core.MainForm, string.Format("{0} address(es) removed from firewall.", this.ListBox_Firewalled.SelectedItems.Count), "Successful");
				Server.Firewall.Save();
				this.RefreshCFList();
			} else {
				MessageBox.Show(Core.MainForm, "No Items selected", "Error");
			}
		}

		private void ListBox_Firewalled_SelectedIndexChanged(object sender, EventArgs e) {
			if (this.ListBox_Firewalled.SelectedItems.Count > 0) {
				IPAddress addr = this.ConvertToIPAddress(this.ListBox_Firewalled.SelectedItems[this.ListBox_Firewalled.SelectedItems.Count-1].ToString());
				if (addr != null) {
					this.RefreshEffectedAccountsList(addr);
				}
			}
		}

		private void ListBox_Ingame_SelectedIndexChanged(object sender, EventArgs e) {
			if (this.ListBox_Ingame.SelectedItems.Count > 0) {
				IPAddress addr = this.ConvertToIPAddress(this.ListBox_Ingame.SelectedItems[this.ListBox_Ingame.SelectedItems.Count-1].ToString());
				if (addr != null) {
					this.RefreshEffectedAccountsList(addr);
				}
			}
		}

		private void Button_RefreshIngame_Click(object sender, EventArgs e) {
			this.RefreshIGList();
		}

		protected override void OnVisibleChanged(EventArgs e) {
			base.OnVisibleChanged (e);

			this.RefreshCFList();
			this.RefreshIGList();
			this.RefreshEffectedAccountsList(null);
		}
	}
}