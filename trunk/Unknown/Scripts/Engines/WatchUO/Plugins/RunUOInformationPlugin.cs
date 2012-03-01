using System;
using System.Windows.Forms;
using System.Diagnostics;

using Server.Accounting;

namespace Server.Engines.WatchUO.Plugins {
	public class RunUOInformationPlugin : BasePlugin {
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label PInfo_Priority;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label PInfo_ID;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label PInfo_Name;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label PInfo_ThreadCount;
		private System.Windows.Forms.Label PInfo_HandleCount;
		private System.Windows.Forms.Label PInfo_StartTime;
		private System.Windows.Forms.Label PInfo_CPUTime;
		private System.Windows.Forms.Label PInfo_BaseDirectory;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label PInfo_ModulesCount;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label PInfo_MaxVirtualMemory;
		private System.Windows.Forms.Label PInfo_VirtualMemory;
		private System.Windows.Forms.Label PInfo_MaxMemoryUsage;
		private System.Windows.Forms.Label PInfo_MemoryUsage;
		private System.Windows.Forms.Label PInfo_Uptime;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Button Button_RefreshProcessInfo;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label WInfo_MobileCount;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label WInfo_ItemCount;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label WInfo_PlayerMobileCount;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label WInfo_AccountCount;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label WInfo_ConnectedClients;
		private System.Windows.Forms.Label WInfo_GuildCount;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label WInfo_MobileScriptsCount;
		private System.Windows.Forms.Label WInfo_ItemScriptsCount;
		private System.Windows.Forms.Button Button_RefreshWorldInformation;
		private System.Windows.Forms.Label WInfo_BannedAccounts;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label WInfo_FirewalledIPs;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label WInfo_MyRunUOEnabled;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label WInfo_FactionsEnabled;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label WInfo_ExpansionInfo;
		private System.Windows.Forms.Label label26;
		
		public RunUOInformationPlugin() : base("RunUO Information") {
			this.Order = 1;
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.PInfo_ModulesCount = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.PInfo_MaxVirtualMemory = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.PInfo_VirtualMemory = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.PInfo_HandleCount = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.PInfo_ThreadCount = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.PInfo_MaxMemoryUsage = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.PInfo_MemoryUsage = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.PInfo_BaseDirectory = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.PInfo_CPUTime = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.PInfo_Uptime = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.PInfo_StartTime = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.PInfo_ID = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.PInfo_Name = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.PInfo_Priority = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.Button_RefreshProcessInfo = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.WInfo_MobileCount = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.WInfo_ItemCount = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.WInfo_PlayerMobileCount = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.WInfo_AccountCount = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.WInfo_ConnectedClients = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.WInfo_MobileScriptsCount = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.WInfo_ItemScriptsCount = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.WInfo_GuildCount = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.Button_RefreshWorldInformation = new System.Windows.Forms.Button();
			this.WInfo_BannedAccounts = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.WInfo_FirewalledIPs = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.WInfo_MyRunUOEnabled = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.WInfo_FactionsEnabled = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.WInfo_ExpansionInfo = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();

			this.Controls.Add(this.groupBox1);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Location = new System.Drawing.Point(24, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(736, 472);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "RunUO Information";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.Button_RefreshProcessInfo);
			this.groupBox2.Controls.Add(this.PInfo_ModulesCount);
			this.groupBox2.Controls.Add(this.label23);
			this.groupBox2.Controls.Add(this.PInfo_MaxVirtualMemory);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.PInfo_VirtualMemory);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.PInfo_HandleCount);
			this.groupBox2.Controls.Add(this.label19);
			this.groupBox2.Controls.Add(this.PInfo_ThreadCount);
			this.groupBox2.Controls.Add(this.label17);
			this.groupBox2.Controls.Add(this.PInfo_MaxMemoryUsage);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.PInfo_MemoryUsage);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.PInfo_BaseDirectory);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.PInfo_CPUTime);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.PInfo_Uptime);
			this.groupBox2.Controls.Add(this.label25);
			this.groupBox2.Controls.Add(this.PInfo_StartTime);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.PInfo_ID);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.PInfo_Name);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.PInfo_Priority);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(24, 32);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(328, 416);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Process Information";
			// 
			// PInfo_ModulesCount
			// 
			this.PInfo_ModulesCount.Location = new System.Drawing.Point(192, 336);
			this.PInfo_ModulesCount.Name = "PInfo_ModulesCount";
			this.PInfo_ModulesCount.Size = new System.Drawing.Size(128, 16);
			this.PInfo_ModulesCount.TabIndex = 31;
			this.PInfo_ModulesCount.Text = "-";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(16, 336);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(160, 16);
			this.label23.TabIndex = 30;
			this.label23.Text = "Loaded Modules Count";
			// 
			// PInfo_MaxVirtualMemory
			// 
			this.PInfo_MaxVirtualMemory.Location = new System.Drawing.Point(192, 264);
			this.PInfo_MaxVirtualMemory.Name = "PInfo_MaxVirtualMemory";
			this.PInfo_MaxVirtualMemory.Size = new System.Drawing.Size(128, 16);
			this.PInfo_MaxVirtualMemory.TabIndex = 25;
			this.PInfo_MaxVirtualMemory.Text = "-";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 264);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(160, 16);
			this.label10.TabIndex = 24;
			this.label10.Text = "Max. Virtual Memory (KB)";
			// 
			// PInfo_VirtualMemory
			// 
			this.PInfo_VirtualMemory.Location = new System.Drawing.Point(192, 240);
			this.PInfo_VirtualMemory.Name = "PInfo_VirtualMemory";
			this.PInfo_VirtualMemory.Size = new System.Drawing.Size(128, 16);
			this.PInfo_VirtualMemory.TabIndex = 23;
			this.PInfo_VirtualMemory.Text = "-";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 240);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(160, 16);
			this.label7.TabIndex = 22;
			this.label7.Text = "Virtual Memory (KB)";
			// 
			// PInfo_HandleCount
			// 
			this.PInfo_HandleCount.Location = new System.Drawing.Point(192, 312);
			this.PInfo_HandleCount.Name = "PInfo_HandleCount";
			this.PInfo_HandleCount.Size = new System.Drawing.Size(128, 16);
			this.PInfo_HandleCount.TabIndex = 21;
			this.PInfo_HandleCount.Text = "-";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(16, 312);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(160, 16);
			this.label19.TabIndex = 20;
			this.label19.Text = "Handle Count";
			// 
			// PInfo_ThreadCount
			// 
			this.PInfo_ThreadCount.Location = new System.Drawing.Point(192, 288);
			this.PInfo_ThreadCount.Name = "PInfo_ThreadCount";
			this.PInfo_ThreadCount.Size = new System.Drawing.Size(128, 16);
			this.PInfo_ThreadCount.TabIndex = 19;
			this.PInfo_ThreadCount.Text = "-";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(16, 288);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(160, 16);
			this.label17.TabIndex = 18;
			this.label17.Text = "Thread Count";
			// 
			// PInfo_MaxMemoryUsage
			// 
			this.PInfo_MaxMemoryUsage.Location = new System.Drawing.Point(192, 216);
			this.PInfo_MaxMemoryUsage.Name = "PInfo_MaxMemoryUsage";
			this.PInfo_MaxMemoryUsage.Size = new System.Drawing.Size(128, 16);
			this.PInfo_MaxMemoryUsage.TabIndex = 17;
			this.PInfo_MaxMemoryUsage.Text = "-";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(16, 216);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(160, 16);
			this.label15.TabIndex = 16;
			this.label15.Text = "Max. Memory Usage (KB)";
			// 
			// PInfo_MemoryUsage
			// 
			this.PInfo_MemoryUsage.Location = new System.Drawing.Point(192, 192);
			this.PInfo_MemoryUsage.Name = "PInfo_MemoryUsage";
			this.PInfo_MemoryUsage.Size = new System.Drawing.Size(128, 16);
			this.PInfo_MemoryUsage.TabIndex = 15;
			this.PInfo_MemoryUsage.Text = "-";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(16, 192);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(160, 16);
			this.label13.TabIndex = 14;
			this.label13.Text = "Memory Usage (KB)";
			// 
			// PInfo_BaseDirectory
			// 
			this.PInfo_BaseDirectory.Location = new System.Drawing.Point(192, 168);
			this.PInfo_BaseDirectory.Name = "PInfo_BaseDirectory";
			this.PInfo_BaseDirectory.Size = new System.Drawing.Size(128, 16);
			this.PInfo_BaseDirectory.TabIndex = 13;
			this.PInfo_BaseDirectory.Text = "-";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(16, 168);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(160, 16);
			this.label11.TabIndex = 12;
			this.label11.Text = "Base Directory";
			// 
			// PInfo_CPUTime
			// 
			this.PInfo_CPUTime.Location = new System.Drawing.Point(192, 144);
			this.PInfo_CPUTime.Name = "PInfo_CPUTime";
			this.PInfo_CPUTime.Size = new System.Drawing.Size(128, 16);
			this.PInfo_CPUTime.TabIndex = 11;
			this.PInfo_CPUTime.Text = "-";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 144);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(160, 16);
			this.label9.TabIndex = 10;
			this.label9.Text = "CPU Time";
			// 
			// PInfo_Uptime
			// 
			this.PInfo_Uptime.Location = new System.Drawing.Point(192, 120);
			this.PInfo_Uptime.Name = "PInfo_Uptime";
			this.PInfo_Uptime.Size = new System.Drawing.Size(128, 16);
			this.PInfo_Uptime.TabIndex = 9;
			this.PInfo_Uptime.Text = "-";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(16, 120);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(160, 16);
			this.label25.TabIndex = 8;
			this.label25.Text = "Uptime";
			// 
			// PInfo_StartTime
			// 
			this.PInfo_StartTime.Location = new System.Drawing.Point(192, 96);
			this.PInfo_StartTime.Name = "PInfo_StartTime";
			this.PInfo_StartTime.Size = new System.Drawing.Size(128, 16);
			this.PInfo_StartTime.TabIndex = 7;
			this.PInfo_StartTime.Text = "-";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 96);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(160, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "Start Time";
			// 
			// PInfo_ID
			// 
			this.PInfo_ID.Location = new System.Drawing.Point(192, 24);
			this.PInfo_ID.Name = "PInfo_ID";
			this.PInfo_ID.Size = new System.Drawing.Size(128, 16);
			this.PInfo_ID.TabIndex = 5;
			this.PInfo_ID.Text = "-";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(160, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "Process ID";
			// 
			// PInfo_Name
			// 
			this.PInfo_Name.Location = new System.Drawing.Point(192, 48);
			this.PInfo_Name.Name = "PInfo_Name";
			this.PInfo_Name.Size = new System.Drawing.Size(128, 16);
			this.PInfo_Name.TabIndex = 3;
			this.PInfo_Name.Text = "-";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(160, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Process Name";
			// 
			// PInfo_Priority
			// 
			this.PInfo_Priority.Location = new System.Drawing.Point(192, 72);
			this.PInfo_Priority.Name = "PInfo_Priority";
			this.PInfo_Priority.Size = new System.Drawing.Size(128, 16);
			this.PInfo_Priority.TabIndex = 1;
			this.PInfo_Priority.Text = "-";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Priority";
			// 
			// Button_RefreshProcessInfo
			// 
			this.Button_RefreshProcessInfo.Location = new System.Drawing.Point(64, 368);
			this.Button_RefreshProcessInfo.Name = "Button_RefreshProcessInfo";
			this.Button_RefreshProcessInfo.Size = new System.Drawing.Size(200, 24);
			this.Button_RefreshProcessInfo.TabIndex = 32;
			this.Button_RefreshProcessInfo.Text = "Refresh Process Info";
			this.Button_RefreshProcessInfo.Click += new EventHandler(Button_RefreshProcessInfo_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.WInfo_MyRunUOEnabled);
			this.groupBox3.Controls.Add(this.label42);
			this.groupBox3.Controls.Add(this.WInfo_FactionsEnabled);
			this.groupBox3.Controls.Add(this.label40);
			this.groupBox3.Controls.Add(this.WInfo_ExpansionInfo);
			this.groupBox3.Controls.Add(this.label26);
			this.groupBox3.Controls.Add(this.WInfo_FirewalledIPs);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.WInfo_BannedAccounts);
			this.groupBox3.Controls.Add(this.label36);
			this.groupBox3.Controls.Add(this.Button_RefreshWorldInformation);
			this.groupBox3.Controls.Add(this.WInfo_GuildCount);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.WInfo_ItemScriptsCount);
			this.groupBox3.Controls.Add(this.label34);
			this.groupBox3.Controls.Add(this.WInfo_MobileScriptsCount);
			this.groupBox3.Controls.Add(this.label32);
			this.groupBox3.Controls.Add(this.WInfo_ConnectedClients);
			this.groupBox3.Controls.Add(this.label22);
			this.groupBox3.Controls.Add(this.WInfo_AccountCount);
			this.groupBox3.Controls.Add(this.label20);
			this.groupBox3.Controls.Add(this.WInfo_PlayerMobileCount);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.WInfo_ItemCount);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.WInfo_MobileCount);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Location = new System.Drawing.Point(384, 32);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(328, 416);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "World Information";
			// 
			// WInfo_MobileCount
			// 
			this.WInfo_MobileCount.Location = new System.Drawing.Point(192, 24);
			this.WInfo_MobileCount.Name = "WInfo_MobileCount";
			this.WInfo_MobileCount.Size = new System.Drawing.Size(128, 16);
			this.WInfo_MobileCount.TabIndex = 7;
			this.WInfo_MobileCount.Text = "-";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(160, 16);
			this.label6.TabIndex = 6;
			this.label6.Text = "Mobile Count";
			// 
			// WInfo_ItemCount
			// 
			this.WInfo_ItemCount.Location = new System.Drawing.Point(192, 48);
			this.WInfo_ItemCount.Name = "WInfo_ItemCount";
			this.WInfo_ItemCount.Size = new System.Drawing.Size(128, 16);
			this.WInfo_ItemCount.TabIndex = 9;
			this.WInfo_ItemCount.Text = "-";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(16, 48);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(160, 16);
			this.label12.TabIndex = 8;
			this.label12.Text = "Item Count";
			// 
			// WInfo_PlayerMobileCount
			// 
			this.WInfo_PlayerMobileCount.Location = new System.Drawing.Point(192, 144);
			this.WInfo_PlayerMobileCount.Name = "WInfo_PlayerMobileCount";
			this.WInfo_PlayerMobileCount.Size = new System.Drawing.Size(128, 16);
			this.WInfo_PlayerMobileCount.TabIndex = 11;
			this.WInfo_PlayerMobileCount.Text = "-";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(16, 144);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(160, 16);
			this.label16.TabIndex = 10;
			this.label16.Text = "PlayerMobile Count";
			// 
			// WInfo_AccountCount
			// 
			this.WInfo_AccountCount.Location = new System.Drawing.Point(192, 72);
			this.WInfo_AccountCount.Name = "WInfo_AccountCount";
			this.WInfo_AccountCount.Size = new System.Drawing.Size(128, 16);
			this.WInfo_AccountCount.TabIndex = 13;
			this.WInfo_AccountCount.Text = "-";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(16, 72);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(160, 16);
			this.label20.TabIndex = 12;
			this.label20.Text = "Account Count";
			// 
			// WInfo_ConnectedClients
			// 
			this.WInfo_ConnectedClients.Location = new System.Drawing.Point(192, 192);
			this.WInfo_ConnectedClients.Name = "WInfo_ConnectedClients";
			this.WInfo_ConnectedClients.Size = new System.Drawing.Size(128, 16);
			this.WInfo_ConnectedClients.TabIndex = 15;
			this.WInfo_ConnectedClients.Text = "-";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(16, 192);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(160, 16);
			this.label22.TabIndex = 14;
			this.label22.Text = "Connected Clients";
			// 
			// WInfo_MobileScriptsCount
			// 
			this.WInfo_MobileScriptsCount.Location = new System.Drawing.Point(192, 216);
			this.WInfo_MobileScriptsCount.Name = "WInfo_MobileScriptsCount";
			this.WInfo_MobileScriptsCount.Size = new System.Drawing.Size(128, 16);
			this.WInfo_MobileScriptsCount.TabIndex = 23;
			this.WInfo_MobileScriptsCount.Text = "-";
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(16, 216);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(160, 16);
			this.label32.TabIndex = 22;
			this.label32.Text = "Mobile Scripts Count";
			this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// WInfo_ItemScriptsCount
			// 
			this.WInfo_ItemScriptsCount.Location = new System.Drawing.Point(192, 240);
			this.WInfo_ItemScriptsCount.Name = "WInfo_ItemScriptsCount";
			this.WInfo_ItemScriptsCount.Size = new System.Drawing.Size(128, 16);
			this.WInfo_ItemScriptsCount.TabIndex = 25;
			this.WInfo_ItemScriptsCount.Text = "-";
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(16, 240);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(160, 16);
			this.label34.TabIndex = 24;
			this.label34.Text = "Item Scripts Count";
			// 
			// WInfo_GuildCount
			// 
			this.WInfo_GuildCount.Location = new System.Drawing.Point(192, 168);
			this.WInfo_GuildCount.Name = "WInfo_GuildCount";
			this.WInfo_GuildCount.Size = new System.Drawing.Size(128, 16);
			this.WInfo_GuildCount.TabIndex = 35;
			this.WInfo_GuildCount.Text = "-";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 168);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(160, 16);
			this.label8.TabIndex = 34;
			this.label8.Text = "Guild Count";
			// 
			// Button_RefreshWorldInformation
			// 
			this.Button_RefreshWorldInformation.Location = new System.Drawing.Point(64, 368);
			this.Button_RefreshWorldInformation.Name = "Button_RefreshWorldInformation";
			this.Button_RefreshWorldInformation.Size = new System.Drawing.Size(200, 24);
			this.Button_RefreshWorldInformation.TabIndex = 36;
			this.Button_RefreshWorldInformation.Text = "Refresh World Info";
			this.Button_RefreshWorldInformation.Click += new EventHandler(Button_RefreshWorldInformation_Click);
			// 
			// WInfo_BannedAccounts
			// 
			this.WInfo_BannedAccounts.Location = new System.Drawing.Point(192, 96);
			this.WInfo_BannedAccounts.Name = "WInfo_BannedAccounts";
			this.WInfo_BannedAccounts.Size = new System.Drawing.Size(128, 16);
			this.WInfo_BannedAccounts.TabIndex = 38;
			this.WInfo_BannedAccounts.Text = "-";
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(16, 96);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(160, 16);
			this.label36.TabIndex = 37;
			this.label36.Text = "Banned Accounts";
			// 
			// WInfo_FirewalledIPs
			// 
			this.WInfo_FirewalledIPs.Location = new System.Drawing.Point(192, 120);
			this.WInfo_FirewalledIPs.Name = "WInfo_FirewalledIPs";
			this.WInfo_FirewalledIPs.Size = new System.Drawing.Size(128, 16);
			this.WInfo_FirewalledIPs.TabIndex = 40;
			this.WInfo_FirewalledIPs.Text = "-";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(16, 120);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(160, 16);
			this.label14.TabIndex = 39;
			this.label14.Text = "Firewalled IPs";
			// 
			// WInfo_MyRunUOEnabled
			// 
			this.WInfo_MyRunUOEnabled.Location = new System.Drawing.Point(192, 336);
			this.WInfo_MyRunUOEnabled.Name = "WInfo_MyRunUOEnabled";
			this.WInfo_MyRunUOEnabled.Size = new System.Drawing.Size(128, 16);
			this.WInfo_MyRunUOEnabled.TabIndex = 48;
			this.WInfo_MyRunUOEnabled.Text = "-";
			// 
			// label42
			// 
			this.label42.Location = new System.Drawing.Point(16, 336);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(160, 16);
			this.label42.TabIndex = 47;
			this.label42.Text = "MyRunUO Enabled";
			// 
			// WInfo_FactionsEnabled
			// 
			this.WInfo_FactionsEnabled.Location = new System.Drawing.Point(192, 312);
			this.WInfo_FactionsEnabled.Name = "WInfo_FactionsEnabled";
			this.WInfo_FactionsEnabled.Size = new System.Drawing.Size(128, 16);
			this.WInfo_FactionsEnabled.TabIndex = 46;
			this.WInfo_FactionsEnabled.Text = "-";
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(16, 312);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(160, 16);
			this.label40.TabIndex = 45;
			this.label40.Text = "Factions Enabled";
			// 
			// WInfo_ExpansionInfo
			// 
			this.WInfo_ExpansionInfo.Location = new System.Drawing.Point(192, 264);
			this.WInfo_ExpansionInfo.Name = "WInfo_ExpansionInfo";
			this.WInfo_ExpansionInfo.Size = new System.Drawing.Size(128, 16);
			this.WInfo_ExpansionInfo.TabIndex = 42;
			this.WInfo_ExpansionInfo.Text = "-";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(16, 264);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(160, 16);
			this.label26.TabIndex = 41;
			this.label26.Text = "Current Expansion";
		}

		private void Button_RefreshProcessInfo_Click(object sender, EventArgs e) {
			RefreshProcessInfo();
		}

		private void Button_RefreshWorldInformation_Click(object sender, EventArgs e) {
			RefreshWorldInfo();
		}

		public override void OnLoad() {
			RefreshProcessInfo();
			RefreshWorldInfo();
			base.OnLoad ();
		}


		private void RefreshProcessInfo() {
			Process p = Server.Core.Process;
			this.PInfo_BaseDirectory.Text = p.StartInfo.WorkingDirectory;
			this.PInfo_CPUTime.Text = p.TotalProcessorTime.ToString();
			this.PInfo_HandleCount.Text = p.HandleCount + "";
			this.PInfo_ID.Text = p.Id + "";
			this.PInfo_MaxMemoryUsage.Text = string.Format("{0:0,0}", ((long)(p.PeakWorkingSet64/1000)));
			this.PInfo_MaxVirtualMemory.Text = string.Format("{0:0,0}", ((long)(p.PeakVirtualMemorySize64/1000)));
			this.PInfo_MemoryUsage.Text = string.Format("{0:0,0}", ((long)(p.WorkingSet64/1000)));
			this.PInfo_ModulesCount.Text = p.Modules.Count + "";
			this.PInfo_Name.Text = p.ProcessName;
			this.PInfo_Priority.Text = p.BasePriority + "";
			this.PInfo_StartTime.Text = p.StartTime.ToString();
			this.PInfo_ThreadCount.Text = p.Threads.Count + "";
			this.PInfo_Uptime.Text = (DateTime.Now - p.StartTime).ToString();
			this.PInfo_VirtualMemory.Text = string.Format("{0:0,0}", ((long)(p.VirtualMemorySize64/1000)));
		}

		private void RefreshWorldInfo() {
			this.WInfo_AccountCount.Text = string.Format("{0:0,0}", Accounts.Count);
			this.WInfo_ExpansionInfo.Text = Server.ExpansionInfo.CurrentExpansion.Name;

			int bannedcounter = 0;
			foreach(Account acct in Accounts.GetAccounts()) {
				if (acct == null) {
					continue;
				}
				if (acct.Banned)
					bannedcounter++;
			}
			this.WInfo_BannedAccounts.Text = string.Format("{0:0,0}", bannedcounter);

			this.WInfo_ConnectedClients.Text = string.Format("{0:0,0}", Server.Network.NetState.Instances.Count);
			this.WInfo_FactionsEnabled.Text = (Server.Factions.FactionPersistance.Instance != null).ToString();
			this.WInfo_FirewalledIPs.Text = string.Format("{0:0,0}", Server.Firewall.List.Count);
			this.WInfo_GuildCount.Text = string.Format("{0:0,0}", Server.Guilds.Guild.List.Count);
			this.WInfo_ItemCount.Text = string.Format("{0:0,0}", World.Items.Count);
			this.WInfo_ItemScriptsCount.Text = string.Format("{0:0,0}", Server.Core.ScriptItems);
			this.WInfo_MobileCount.Text = string.Format("{0:0,0}", World.Mobiles.Count);
			this.WInfo_MobileScriptsCount.Text = string.Format("{0:0,0}", Server.Core.ScriptMobiles);
			this.WInfo_MyRunUOEnabled.Text = Server.Engines.MyRunUO.Config.Enabled.ToString();

			int pmcount = 0;
			foreach(Mobile mob in World.Mobiles.Values) {
				if (mob is Server.Mobiles.PlayerMobile)
					pmcount++;
			}
			this.WInfo_PlayerMobileCount.Text = string.Format("{0:0,0}", pmcount);
		}
	}
}