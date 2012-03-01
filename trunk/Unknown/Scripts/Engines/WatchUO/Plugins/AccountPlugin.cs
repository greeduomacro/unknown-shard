using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using Server;
using Server.Accounting;

namespace Server.Engines.WatchUO.Plugins {
	public class AccountPlugin : BasePlugin {
		private System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox TextBox_AccountName;
		private System.Windows.Forms.TextBox TextBox_AccountPassword;
		private System.Windows.Forms.Button Button_AddAccount;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button Button_DeleteAccount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label Label_InfoName;
		private System.Windows.Forms.Label Label_InfoAccessLevel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label Label_InfoActive;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label Label_InfoLastLogin;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label Label_MobileCount;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label Label_CommentCount;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label Label_TagCount;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label Label_InfoTotalGametime;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button Button_IncreaseACL;
		private System.Windows.Forms.Button Button_DecreaseACL;
		private System.Windows.Forms.Button Button_ChangePassword;
		private System.Windows.Forms.Button Button_BanAccount;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button Button_SelectAllBannedAccounts;
		private System.Windows.Forms.Button Button_BanAllAccounts;
		private System.Windows.Forms.Button Button_DeleteAllAccounts;
		private System.Windows.Forms.Button Button_SelectAllAccounts;
		private System.Windows.Forms.Button Button_RefreshList;
		private System.Windows.Forms.Label Label_InfoCreated;
		private System.Windows.Forms.Label label8;

		public AccountPlugin() : base("Accounts") {
			this.Order = 5;

			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.TextBox_AccountName = new System.Windows.Forms.TextBox();
			this.TextBox_AccountPassword = new System.Windows.Forms.TextBox();
			this.Button_AddAccount = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.Button_DeleteAccount = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.Label_InfoName = new System.Windows.Forms.Label();
			this.Label_InfoAccessLevel = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.Label_InfoActive = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.Label_InfoLastLogin = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.Label_MobileCount = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.Label_CommentCount = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.Label_TagCount = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.Label_InfoTotalGametime = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.Button_IncreaseACL = new System.Windows.Forms.Button();
			this.Button_DecreaseACL = new System.Windows.Forms.Button();
			this.Button_ChangePassword = new System.Windows.Forms.Button();
			this.Button_BanAccount = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.Button_SelectAllBannedAccounts = new System.Windows.Forms.Button();
			this.Button_BanAllAccounts = new System.Windows.Forms.Button();
			this.Button_DeleteAllAccounts = new System.Windows.Forms.Button();
			this.Button_SelectAllAccounts = new System.Windows.Forms.Button();
			this.Button_RefreshList = new System.Windows.Forms.Button();
			this.Label_InfoCreated = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();

			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			
			this.Controls.Add(groupBox1);

			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.Button_RefreshList);
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.listBox1);
			this.groupBox1.Location = new System.Drawing.Point(24, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(736, 472);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Accounts";
			// 
			// listBox1
			// 
			this.listBox1.HorizontalScrollbar = true;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Location = new System.Drawing.Point(16, 29);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(192, 396);
			this.listBox1.TabIndex = 0;
			this.listBox1.SelectionMode = SelectionMode.MultiExtended;
			this.listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.Button_AddAccount);
			this.groupBox2.Controls.Add(this.TextBox_AccountPassword);
			this.groupBox2.Controls.Add(this.TextBox_AccountName);
			this.groupBox2.Location = new System.Drawing.Point(472, 24);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(248, 160);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Add Account";
			// 
			// TextBox_AccountName
			// 
			this.TextBox_AccountName.Location = new System.Drawing.Point(88, 32);
			this.TextBox_AccountName.Name = "TextBox_AccountName";
			this.TextBox_AccountName.Size = new System.Drawing.Size(144, 22);
			this.TextBox_AccountName.TabIndex = 0;
			this.TextBox_AccountName.Text = string.Empty;
			// 
			// TextBox_AccountPassword
			// 
			this.TextBox_AccountPassword.Location = new System.Drawing.Point(88, 72);
			this.TextBox_AccountPassword.Name = "TextBox_AccountPassword";
			this.TextBox_AccountPassword.Size = new System.Drawing.Size(144, 22);
			this.TextBox_AccountPassword.TabIndex = 1;
			this.TextBox_AccountPassword.Text = string.Empty;
			// 
			// Button_AddAccount
			// 
			this.Button_AddAccount.Location = new System.Drawing.Point(16, 112);
			this.Button_AddAccount.Name = "Button_AddAccount";
			this.Button_AddAccount.Size = new System.Drawing.Size(216, 24);
			this.Button_AddAccount.TabIndex = 3;
			this.Button_AddAccount.Text = "Add Account";
			this.Button_AddAccount.Click += new EventHandler(Button_AddAccount_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.Label_InfoCreated);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.Button_BanAccount);
			this.groupBox3.Controls.Add(this.Button_ChangePassword);
			this.groupBox3.Controls.Add(this.Button_DecreaseACL);
			this.groupBox3.Controls.Add(this.Button_IncreaseACL);
			this.groupBox3.Controls.Add(this.Label_InfoTotalGametime);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.Label_TagCount);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.Label_CommentCount);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.Label_MobileCount);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.Label_InfoLastLogin);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.Label_InfoActive);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.Label_InfoAccessLevel);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.Label_InfoName);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.Button_DeleteAccount);
			this.groupBox3.Location = new System.Drawing.Point(224, 200);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(496, 256);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Account Information";
			// 
			// Button_DeleteAccount
			// 
			this.Button_DeleteAccount.Location = new System.Drawing.Point(328, 188);
			this.Button_DeleteAccount.Name = "Button_DeleteAccount";
			this.Button_DeleteAccount.Size = new System.Drawing.Size(152, 24);
			this.Button_DeleteAccount.TabIndex = 0;
			this.Button_DeleteAccount.Text = "Delete Account";
			this.Button_DeleteAccount.Click += new EventHandler(Button_DeleteAccount_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Name";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Name";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Password";
			// 
			// Label_InfoName
			// 
			this.Label_InfoName.Location = new System.Drawing.Point(152, 20);
			this.Label_InfoName.Name = "Label_InfoName";
			this.Label_InfoName.Size = new System.Drawing.Size(136, 16);
			this.Label_InfoName.TabIndex = 2;
			this.Label_InfoName.Text = "-";
			// 
			// Label_InfoAccessLevel
			// 
			this.Label_InfoAccessLevel.Location = new System.Drawing.Point(152, 40);
			this.Label_InfoAccessLevel.Name = "Label_InfoAccessLevel";
			this.Label_InfoAccessLevel.Size = new System.Drawing.Size(136, 16);
			this.Label_InfoAccessLevel.TabIndex = 4;
			this.Label_InfoAccessLevel.Text = "-";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 16);
			this.label5.TabIndex = 3;
			this.label5.Text = "AccessLevel";
			// 
			// Label_InfoActive
			// 
			this.Label_InfoActive.Location = new System.Drawing.Point(152, 60);
			this.Label_InfoActive.Name = "Label_InfoActive";
			this.Label_InfoActive.Size = new System.Drawing.Size(136, 16);
			this.Label_InfoActive.TabIndex = 6;
			this.Label_InfoActive.Text = "-";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(24, 60);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(104, 16);
			this.label7.TabIndex = 5;
			this.label7.Text = "Active";
			// 
			// Label_InfoLastLogin
			// 
			this.Label_InfoLastLogin.Location = new System.Drawing.Point(152, 80);
			this.Label_InfoLastLogin.Name = "Label_InfoLastLogin";
			this.Label_InfoLastLogin.Size = new System.Drawing.Size(136, 16);
			this.Label_InfoLastLogin.TabIndex = 8;
			this.Label_InfoLastLogin.Text = "-";
			
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(24, 80);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(104, 16);
			this.label9.TabIndex = 7;
			this.label9.Text = "Last Login";
			// 
			// Label_MobileCount
			// 
			this.Label_MobileCount.Location = new System.Drawing.Point(152, 100);
			this.Label_MobileCount.Name = "Label_MobileCount";
			this.Label_MobileCount.Size = new System.Drawing.Size(136, 16);
			this.Label_MobileCount.TabIndex = 10;
			this.Label_MobileCount.Text = "-";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(24, 100);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(104, 16);
			this.label11.TabIndex = 9;
			this.label11.Text = "Mobile Count";
			// 
			// Label_CommentCount
			// 
			this.Label_CommentCount.Location = new System.Drawing.Point(152, 120);
			this.Label_CommentCount.Name = "Label_CommentCount";
			this.Label_CommentCount.Size = new System.Drawing.Size(136, 16);
			this.Label_CommentCount.TabIndex = 12;
			this.Label_CommentCount.Text = "-";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(24, 120);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(104, 16);
			this.label13.TabIndex = 11;
			this.label13.Text = "Comment Count";
			//
			// Label_TagCount
			// 
			this.Label_TagCount.Location = new System.Drawing.Point(152, 140);
			this.Label_TagCount.Name = "Label_TagCount";
			this.Label_TagCount.Size = new System.Drawing.Size(136, 16);
			this.Label_TagCount.TabIndex = 14;
			this.Label_TagCount.Text = "-";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(24, 140);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(104, 16);
			this.label15.TabIndex = 13;
			this.label15.Text = "Tag Count";
			// 
			// Label_InfoTotalGametime
			// 
			this.Label_InfoTotalGametime.Location = new System.Drawing.Point(152, 180);
			this.Label_InfoTotalGametime.Name = "Label_InfoTotalGametime";
			this.Label_InfoTotalGametime.Size = new System.Drawing.Size(136, 16);
			this.Label_InfoTotalGametime.TabIndex = 16;
			this.Label_InfoTotalGametime.Text = "-";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(24, 180);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 16);
			this.label6.TabIndex = 15;
			this.label6.Text = "Total Gametime";
			// 
			// Button_IncreaseACL
			// 
			this.Button_IncreaseACL.Location = new System.Drawing.Point(328, 20);
			this.Button_IncreaseACL.Name = "Button_IncreaseACL";
			this.Button_IncreaseACL.Size = new System.Drawing.Size(152, 24);
			this.Button_IncreaseACL.TabIndex = 17;
			this.Button_IncreaseACL.Text = "Increase AccessLevel";
			this.Button_IncreaseACL.Click += new EventHandler(Button_IncreaseACL_Click);
			// 
			// Button_DecreaseACL
			// 
			this.Button_DecreaseACL.Location = new System.Drawing.Point(328, 52);
			this.Button_DecreaseACL.Name = "Button_DecreaseACL";
			this.Button_DecreaseACL.Size = new System.Drawing.Size(152, 24);
			this.Button_DecreaseACL.TabIndex = 18;
			this.Button_DecreaseACL.Text = "Decrease AccessLevel";
			this.Button_DecreaseACL.Click += new EventHandler(Button_DecreaseACL_Click);
			// 
			// Button_ChangePassword
			// 
			this.Button_ChangePassword.Location = new System.Drawing.Point(328, 124);
			this.Button_ChangePassword.Name = "Button_ChangePassword";
			this.Button_ChangePassword.Size = new System.Drawing.Size(152, 24);
			this.Button_ChangePassword.TabIndex = 19;
			this.Button_ChangePassword.Text = "Change Password";
			// 
			// Button_BanAccount
			// 
			this.Button_BanAccount.Location = new System.Drawing.Point(328, 156);
			this.Button_BanAccount.Name = "Button_BanAccount";
			this.Button_BanAccount.Size = new System.Drawing.Size(152, 24);
			this.Button_BanAccount.TabIndex = 20;
			this.Button_BanAccount.Text = "Ban Account";
			this.Button_BanAccount.Click += new EventHandler(Button_BanAccount_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.Button_SelectAllAccounts);
			this.groupBox4.Controls.Add(this.Button_DeleteAllAccounts);
			this.groupBox4.Controls.Add(this.Button_BanAllAccounts);
			this.groupBox4.Controls.Add(this.Button_SelectAllBannedAccounts);
			this.groupBox4.Location = new System.Drawing.Point(224, 24);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(224, 160);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "AccountList - Actions";
			// 
			// Button_SelectAllBannedAccounts
			// 
			this.Button_SelectAllBannedAccounts.Location = new System.Drawing.Point(16, 56);
			this.Button_SelectAllBannedAccounts.Name = "Button_SelectAllBannedAccounts";
			this.Button_SelectAllBannedAccounts.Size = new System.Drawing.Size(192, 24);
			this.Button_SelectAllBannedAccounts.TabIndex = 0;
			this.Button_SelectAllBannedAccounts.Text = "Select all banned Accounts";
			this.Button_SelectAllBannedAccounts.Click += new EventHandler(Button_SelectAllBannedAccounts_Click);
			// 
			// Button_BanAllAccounts
			// 
			this.Button_BanAllAccounts.Location = new System.Drawing.Point(16, 88);
			this.Button_BanAllAccounts.Name = "Button_BanAllAccounts";
			this.Button_BanAllAccounts.Size = new System.Drawing.Size(192, 24);
			this.Button_BanAllAccounts.TabIndex = 1;
			this.Button_BanAllAccounts.Text = "Ban all selected Accounts";
			this.Button_BanAllAccounts.Click += new EventHandler(Button_BanAllAccounts_Click);
			// 
			// Button_DeleteAllAccounts
			// 
			this.Button_DeleteAllAccounts.Location = new System.Drawing.Point(16, 120);
			this.Button_DeleteAllAccounts.Name = "Button_DeleteAllAccounts";
			this.Button_DeleteAllAccounts.Size = new System.Drawing.Size(192, 24);
			this.Button_DeleteAllAccounts.TabIndex = 2;
			this.Button_DeleteAllAccounts.Text = "Delete all selected Accounts";
			this.Button_DeleteAllAccounts.Click += new EventHandler(Button_DeleteAllAccounts_Click);
			// 
			// Button_SelectAllAccounts
			// 
			this.Button_SelectAllAccounts.Location = new System.Drawing.Point(16, 24);
			this.Button_SelectAllAccounts.Name = "Button_SelectAllAccounts";
			this.Button_SelectAllAccounts.Size = new System.Drawing.Size(192, 24);
			this.Button_SelectAllAccounts.TabIndex = 3;
			this.Button_SelectAllAccounts.Text = "Select all Accounts";
			this.Button_SelectAllAccounts.Click += new EventHandler(Button_SelectAllAccounts_Click);
			// 
			// Button_RefreshList
			// 
			this.Button_RefreshList.Location = new System.Drawing.Point(16, 432);
			this.Button_RefreshList.Name = "Button_RefreshList";
			this.Button_RefreshList.Size = new System.Drawing.Size(192, 24);
			this.Button_RefreshList.TabIndex = 4;
			this.Button_RefreshList.Text = "Refresh List";
			this.Button_RefreshList.Click += new EventHandler(Button_RefreshList_Click);
			// 
			// Label_InfoCreated
			// 
			this.Label_InfoCreated.Location = new System.Drawing.Point(152, 160);
			this.Label_InfoCreated.Name = "Label_InfoCreated";
			this.Label_InfoCreated.Size = new System.Drawing.Size(136, 16);
			this.Label_InfoCreated.TabIndex = 22;
			this.Label_InfoCreated.Text = "-";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(24, 160);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(104, 16);
			this.label8.TabIndex = 21;
			this.label8.Text = "Created";

		}

		public override void OnLoad() {
			base.OnLoad();
			RefreshAccountList();
		}

		private void RefreshAccountList() {
			this.listBox1.Items.Clear();
			IEnumerator<IAccount> ide = Accounts.GetAccounts().GetEnumerator();
			while (ide.MoveNext()) {
				string accname = ide.Current.Username;
				if (accname != null)
					listBox1.Items.Add(accname);
			}

			if (listBox1.Items.Count > 0) {
				listBox1.SetSelected(0, true);
			} else {
				EmptyAccountInfo();
			}
		}

		private void Button_AddAccount_Click(object sender, EventArgs e) {
			if (this.TextBox_AccountPassword.Text != string.Empty && this.TextBox_AccountName.Text != string.Empty) {
				if (Accounts.GetAccount(this.TextBox_AccountName.Text) == null) {
					string[] data = new string[] { 
													  this.TextBox_AccountName.Text,
													  this.TextBox_AccountPassword.Text
												  };
					Timer.DelayCall(TimeSpan.Zero, new TimerStateCallback(TimerCallback_AddAccount), data);
				} else {
					MessageBox.Show(Core.MainForm, "Account already exists", "Error", MessageBoxButtons.OK);
				}
			} else {
				MessageBox.Show(Core.MainForm, "Please type in a username and password", "Error", MessageBoxButtons.OK);
			}
		}

		private void TimerCallback_AddAccount(object state) {
			string[] data = state as string[];
			if (data != null && data.Length == 2) {
				Accounts.Add(new Account(data[0], data[1]));
				this.TextBox_AccountName.Text = string.Empty;
				this.TextBox_AccountPassword.Text = string.Empty;
				MessageBox.Show(Core.MainForm, "Account added successfully", "Successful", MessageBoxButtons.OK);
				this.RefreshAccountList();
			} else {
				MessageBox.Show(Core.MainForm, "Error deleting the account", "Error", MessageBoxButtons.OK);
			}
		}

		private void Button_RefreshList_Click(object sender, EventArgs e) {
			this.RefreshAccountList();
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
			if (listBox1.SelectedItems.Count == 0) {
				EmptyAccountInfo();
				return;
			}
			string accname = listBox1.SelectedItems[0] as string;
			if (accname != null) {
				Account acct = Accounts.GetAccount(accname) as Account;
				if (acct != null) {
					UpdateAccountInfo(acct);
				}
			} else {
				MessageBox.Show(Core.MainForm, "No account selected", "Error", MessageBoxButtons.OK);
			}
		}

		private void UpdateAccountInfo(Account acct) {
			if (acct != null) {
				this.Label_InfoName.Text = acct.Username;
				this.Label_InfoAccessLevel.Text = acct.AccessLevel.ToString();
				this.Label_InfoCreated.Text = acct.Created.ToString();
				this.Label_InfoTotalGametime.Text = acct.TotalGameTime.ToString();
				this.Label_CommentCount.Text = acct.Comments.Count + string.Empty;
				this.Label_InfoActive.Text = acct.Banned ? "Banned" : "Active";
				this.Label_InfoLastLogin.Text = acct.LastLogin.ToString();
				this.Label_MobileCount.Text = acct.Count + string.Empty;
				this.Label_TagCount.Text = acct.Tags.Count + string.Empty;

				this.Button_BanAccount.Text = acct.Banned ? "Unban Account" : "Ban Account";
			}
		}

		private void EmptyAccountInfo() {
			this.Label_InfoName.Text = "-";
			this.Label_InfoAccessLevel.Text = "-";
			this.Label_InfoCreated.Text = "-";
			this.Label_InfoTotalGametime.Text = "-";
			this.Label_CommentCount.Text = "-";
			this.Label_InfoActive.Text = "-";
			this.Label_InfoLastLogin.Text = "-";
			this.Label_MobileCount.Text = "-";
			this.Label_TagCount.Text = "-";

			this.Button_BanAccount.Text = "Ban Account";
		}

		private void Button_DeleteAccount_Click(object sender, EventArgs e) {
			if (listBox1.SelectedItems.Count == 0) {
				return;
			}
			string accname = listBox1.SelectedItems[0] as string;
			if (accname != null) {
				Account acct = Accounts.GetAccount(accname) as Account;
				if (acct != null) {
					if (MessageBox.Show(Core.MainForm, "Are you sure you want to delete this account?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes) {
						Timer.DelayCall(TimeSpan.Zero, new TimerStateCallback(TimerCallback_DeleteAccount), acct);
					}
				}
			} else {
				MessageBox.Show(Core.MainForm, "No account selected", "Error", MessageBoxButtons.OK);
			}
		}

		private void TimerCallback_DeleteAccount(object state) {
			Account acct = state as Account;
			if (acct != null) {
				acct.Delete();
				MessageBox.Show(Core.MainForm, "Account deleted sucessfully", "Success", MessageBoxButtons.OK);
				this.RefreshAccountList();
			} else {
				MessageBox.Show(Core.MainForm, "Acount could not be deleted", "Error", MessageBoxButtons.OK);
			}
		}

		private void Button_IncreaseACL_Click(object sender, EventArgs e) {
			if (listBox1.SelectedItems.Count == 0) {
				return;
			}
			string accname = listBox1.SelectedItems[0] as string;
			if (accname != null) {
				Account acct = Accounts.GetAccount(accname) as Account;
				if (acct != null) {
					Timer.DelayCall(TimeSpan.Zero, new TimerStateCallback(TimerCallback_IncreaseACL), acct);
				}
			} else {
				MessageBox.Show(Core.MainForm, "No account selected", "Error", MessageBoxButtons.OK);
			}
		}

		private void TimerCallback_IncreaseACL(object state) {
			Account acct = state as Account;
			if (acct != null && acct.AccessLevel < AccessLevel.Administrator) {
				acct.AccessLevel++;
				this.UpdateAccountInfo(acct);
			} else {
				MessageBox.Show(Core.MainForm, "AccessLevel could not be increased", "Error", MessageBoxButtons.OK);
			}
		}

		private void Button_DecreaseACL_Click(object sender, EventArgs e) {
			if (listBox1.SelectedItems.Count == 0) {
				return;
			}
			string accname = listBox1.SelectedItems[0] as string;
			if (accname != null) {
				Account acct = Accounts.GetAccount(accname) as Account;
				if (acct != null) {
					Timer.DelayCall(TimeSpan.Zero, new TimerStateCallback(TimerCallback_DecreaseACL), acct);
				}
			} else {
				MessageBox.Show(Core.MainForm, "No account selected", "Error", MessageBoxButtons.OK);
			}
		}

		private void TimerCallback_DecreaseACL(object state) {
			Account acct = state as Account;
			if (acct != null && acct.AccessLevel > AccessLevel.Player) {
				acct.AccessLevel--;
				this.UpdateAccountInfo(acct);
			} else {
				MessageBox.Show(Core.MainForm, "AccessLevel could not be decreased", "Error", MessageBoxButtons.OK);
			}
		}

		private void Button_BanAccount_Click(object sender, EventArgs e) {
			if (listBox1.SelectedItems.Count == 0) {
				return;
			}
			string accname = listBox1.SelectedItems[0] as string;
			if (accname != null) {
				Account acct = Accounts.GetAccount(accname) as Account;
				if (acct != null) {
					Timer.DelayCall(TimeSpan.Zero, new TimerStateCallback(TimerCallback_BanAccount), acct);
				}
			} else {
				MessageBox.Show(Core.MainForm, "No account selected", "Error", MessageBoxButtons.OK);
			}
		}

		private void TimerCallback_BanAccount(object state) {
			Account acct = state as Account;
			if (acct != null) {
				acct.Banned = !acct.Banned;
				MessageBox.Show(Core.MainForm, "Account (un)banned sucessfully", "Success", MessageBoxButtons.OK);
				this.UpdateAccountInfo(acct);
			} else {
				MessageBox.Show(Core.MainForm, "Acount could not be (un)banned", "Error", MessageBoxButtons.OK);
			}
		}

		private void Button_SelectAllAccounts_Click(object sender, EventArgs e) {
			FirewallPlugin.DeSelectAllFrom(listBox1, true);
		}

		private void Button_SelectAllBannedAccounts_Click(object sender, EventArgs e) {
			for (int i = 0; i < listBox1.Items.Count; i++) {
				string accname = listBox1.Items[i] as string;
				if (accname == null) {
					listBox1.SetSelected(i, false);
					continue;
				}
				Account acct = Accounts.GetAccount(accname) as Account;
				if (acct == null) {
					listBox1.SetSelected(i, false);
					continue;
				}
				if (acct.Banned)
					listBox1.SetSelected(i, true);
				else
					listBox1.SetSelected(i, false);
			}
		}

		private void Button_BanAllAccounts_Click(object sender, EventArgs e) {
			if (listBox1.SelectedIndices.Count > 0) {
				Timer.DelayCall(TimeSpan.Zero, new TimerCallback(TimerCall_BanAllAccounts));
			} else {
				MessageBox.Show(Core.MainForm, "No accounts selected", "Error", MessageBoxButtons.OK);
			}
		}

		private void TimerCall_BanAllAccounts() {
			int counter = 0;
			int errcounter = 0;
			for (int i = 0; i < listBox1.SelectedItems.Count; i++) {
				string accname = listBox1.SelectedItems[i] as string;
				if (accname != null) {
					Account acct = Accounts.GetAccount(accname) as Account;
					if (acct != null) {
						acct.Banned = true;
						counter++;
					} else {
						errcounter++;
					}
				} else {
					errcounter++;
				}
			}
			MessageBox.Show(Core.MainForm, (counter + " accounts banned successfully, " + errcounter + " errors"), "Done", MessageBoxButtons.OK);
			this.RefreshAccountList();
		}

		private void Button_DeleteAllAccounts_Click(object sender, EventArgs e) {
			if (listBox1.SelectedIndices.Count > 0) {
				Timer.DelayCall(TimeSpan.Zero, new TimerCallback(TimerCall_DeleteAllAccounts));
			} else {
				MessageBox.Show(Core.MainForm, "No accounts selected", "Error", MessageBoxButtons.OK);
			}
		}

		private void TimerCall_DeleteAllAccounts() {
			int counter = 0;
			int errcounter = 0;
			for (int i = 0; i < listBox1.SelectedItems.Count; i++) {
				string accname = listBox1.SelectedItems[i] as string;
				if (accname != null) {
					Account acct = Accounts.GetAccount(accname) as Account;
					if (acct != null) {
						acct.Delete();
						counter++;
					} else {
						errcounter++;
					}
				} else {
					errcounter++;
				}
			}
			MessageBox.Show(Core.MainForm, (counter + " accounts deleted successfully, " + errcounter + " errors"), "Done", MessageBoxButtons.OK);
			this.RefreshAccountList();
		}
	}
}