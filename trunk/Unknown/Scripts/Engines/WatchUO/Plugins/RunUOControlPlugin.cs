using System;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

using Server;
using Server.Items;
using Server.Commands;

namespace Server.Engines.WatchUO.Plugins {
	public class RunUOControlPlugin : BasePlugin {
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button Button_WorldSave;
		private System.Windows.Forms.Button Button_RestartServer;
		private System.Windows.Forms.Button Button_Shutdown;
		private System.Windows.Forms.Button Button_CrashServer;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox TextBox_Message;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RadioButton RB_Lockdown_None;
		private System.Windows.Forms.RadioButton RB_Lockdown_Counselor;
		private System.Windows.Forms.ComboBox CB_Broadcast_ACL;
		private System.Windows.Forms.Button Button_SendMessage;
		private System.Windows.Forms.RadioButton RB_Lockdown_GM;
		private System.Windows.Forms.RadioButton RB_Lockdown_Seer;
		private System.Windows.Forms.RadioButton RB_Lockdown_Administrator;
		private System.Windows.Forms.Button Button_ApplyLockdownLevel;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button Button_PacketProfiles;
		private System.Windows.Forms.Button Button_TimerProfiles;
		private System.Windows.Forms.Button Button_ProfileWorld;
		private System.Windows.Forms.Button Button_CountObjects;
		private System.Windows.Forms.Button Button_TraceInternal;
		private System.Windows.Forms.Button Button_HideConsole;
		private System.Windows.Forms.Button Button_EnableAutosave;
		private System.Windows.Forms.Button Button_EnableCoreProfiling;
		private System.Windows.Forms.Button Button_RebuildCategorisation;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button Button_GenerateTeleporters;
		private System.Windows.Forms.Button Button_GenerateMoongates;
		private System.Windows.Forms.Button Button_GenerateDoors;
		private System.Windows.Forms.Button Button_GenerateSecretLocations;
		private System.Windows.Forms.Button Button_GenerateSigns;
		private System.Windows.Forms.Button Button_GenerateVendors;
		private System.Windows.Forms.Button Button_GenerateDocs;

		public RunUOControlPlugin() : base("RunUO Control") {
			this.Order = 3;

			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.Button_GenerateVendors = new System.Windows.Forms.Button();
			this.Button_GenerateSigns = new System.Windows.Forms.Button();
			this.Button_GenerateSecretLocations = new System.Windows.Forms.Button();
			this.Button_GenerateDoors = new System.Windows.Forms.Button();
			this.Button_GenerateMoongates = new System.Windows.Forms.Button();
			this.Button_GenerateTeleporters = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.Button_TraceInternal = new System.Windows.Forms.Button();
			this.Button_CountObjects = new System.Windows.Forms.Button();
			this.Button_ProfileWorld = new System.Windows.Forms.Button();
			this.Button_TimerProfiles = new System.Windows.Forms.Button();
			this.Button_PacketProfiles = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.Button_ApplyLockdownLevel = new System.Windows.Forms.Button();
			this.RB_Lockdown_Administrator = new System.Windows.Forms.RadioButton();
			this.RB_Lockdown_Seer = new System.Windows.Forms.RadioButton();
			this.RB_Lockdown_GM = new System.Windows.Forms.RadioButton();
			this.RB_Lockdown_Counselor = new System.Windows.Forms.RadioButton();
			this.RB_Lockdown_None = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.Button_SendMessage = new System.Windows.Forms.Button();
			this.CB_Broadcast_ACL = new System.Windows.Forms.ComboBox();
			this.TextBox_Message = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.Button_GenerateDocs = new System.Windows.Forms.Button();
			this.Button_RebuildCategorisation = new System.Windows.Forms.Button();
			this.Button_EnableCoreProfiling = new System.Windows.Forms.Button();
			this.Button_EnableAutosave = new System.Windows.Forms.Button();
			this.Button_HideConsole = new System.Windows.Forms.Button();
			this.Button_CrashServer = new System.Windows.Forms.Button();
			this.Button_Shutdown = new System.Windows.Forms.Button();
			this.Button_RestartServer = new System.Windows.Forms.Button();
			this.Button_WorldSave = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
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
			this.groupBox1.Text = "RunUO Control";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.Button_GenerateVendors);
			this.groupBox6.Controls.Add(this.Button_GenerateSigns);
			this.groupBox6.Controls.Add(this.Button_GenerateSecretLocations);
			this.groupBox6.Controls.Add(this.Button_GenerateDoors);
			this.groupBox6.Controls.Add(this.Button_GenerateMoongates);
			this.groupBox6.Controls.Add(this.Button_GenerateTeleporters);
			this.groupBox6.Location = new System.Drawing.Point(264, 256);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(448, 104);
			this.groupBox6.TabIndex = 4;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Generate ...";
			// 
			// Button_GenerateVendors
			// 
			this.Button_GenerateVendors.Location = new System.Drawing.Point(304, 64);
			this.Button_GenerateVendors.Name = "Button_GenerateVendors";
			this.Button_GenerateVendors.Size = new System.Drawing.Size(128, 24);
			this.Button_GenerateVendors.TabIndex = 5;
			this.Button_GenerateVendors.Text = "... Vendors";
			this.Button_GenerateVendors.Click += new System.EventHandler(this.Button_GenerateVendors_Click);
			// 
			// Button_GenerateSigns
			// 
			this.Button_GenerateSigns.Location = new System.Drawing.Point(160, 64);
			this.Button_GenerateSigns.Name = "Button_GenerateSigns";
			this.Button_GenerateSigns.Size = new System.Drawing.Size(128, 24);
			this.Button_GenerateSigns.TabIndex = 4;
			this.Button_GenerateSigns.Text = "... Signs";
			this.Button_GenerateSigns.Click += new System.EventHandler(this.Button_GenerateSigns_Click);
			// 
			// Button_GenerateSecretLocations
			// 
			this.Button_GenerateSecretLocations.Location = new System.Drawing.Point(304, 32);
			this.Button_GenerateSecretLocations.Name = "Button_GenerateSecretLocations";
			this.Button_GenerateSecretLocations.Size = new System.Drawing.Size(128, 24);
			this.Button_GenerateSecretLocations.TabIndex = 3;
			this.Button_GenerateSecretLocations.Text = "... Secret Locations";
			this.Button_GenerateSecretLocations.Click += new System.EventHandler(this.Button_GenerateSecretLocations_Click);
			// 
			// Button_GenerateDoors
			// 
			this.Button_GenerateDoors.Location = new System.Drawing.Point(160, 32);
			this.Button_GenerateDoors.Name = "Button_GenerateDoors";
			this.Button_GenerateDoors.Size = new System.Drawing.Size(128, 24);
			this.Button_GenerateDoors.TabIndex = 2;
			this.Button_GenerateDoors.Text = "... Doors";
			this.Button_GenerateDoors.Click += new System.EventHandler(this.Button_GenerateDoors_Click);
			// 
			// Button_GenerateMoongates
			// 
			this.Button_GenerateMoongates.Location = new System.Drawing.Point(16, 64);
			this.Button_GenerateMoongates.Name = "Button_GenerateMoongates";
			this.Button_GenerateMoongates.Size = new System.Drawing.Size(128, 24);
			this.Button_GenerateMoongates.TabIndex = 1;
			this.Button_GenerateMoongates.Text = "... Moongates";
			this.Button_GenerateMoongates.Click += new System.EventHandler(this.Button_GenerateMoongates_Click);
			// 
			// Button_GenerateTeleporters
			// 
			this.Button_GenerateTeleporters.Location = new System.Drawing.Point(16, 32);
			this.Button_GenerateTeleporters.Name = "Button_GenerateTeleporters";
			this.Button_GenerateTeleporters.Size = new System.Drawing.Size(128, 24);
			this.Button_GenerateTeleporters.TabIndex = 0;
			this.Button_GenerateTeleporters.Text = "... Teleporters";
			this.Button_GenerateTeleporters.Click += new System.EventHandler(this.Button_GenerateTeleporters_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.Button_TraceInternal);
			this.groupBox5.Controls.Add(this.Button_CountObjects);
			this.groupBox5.Controls.Add(this.Button_ProfileWorld);
			this.groupBox5.Controls.Add(this.Button_TimerProfiles);
			this.groupBox5.Controls.Add(this.Button_PacketProfiles);
			this.groupBox5.Location = new System.Drawing.Point(264, 32);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(216, 200);
			this.groupBox5.TabIndex = 3;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Statistics";
			// 
			// Button_TraceInternal
			// 
			this.Button_TraceInternal.Location = new System.Drawing.Point(16, 160);
			this.Button_TraceInternal.Name = "Button_TraceInternal";
			this.Button_TraceInternal.Size = new System.Drawing.Size(184, 24);
			this.Button_TraceInternal.TabIndex = 5;
			this.Button_TraceInternal.Text = "Trace Internal";
			this.Button_TraceInternal.Click += new System.EventHandler(this.Button_TraceInternal_Click);
			// 
			// Button_CountObjects
			// 
			this.Button_CountObjects.Location = new System.Drawing.Point(16, 32);
			this.Button_CountObjects.Name = "Button_CountObjects";
			this.Button_CountObjects.Size = new System.Drawing.Size(184, 24);
			this.Button_CountObjects.TabIndex = 4;
			this.Button_CountObjects.Text = "Count Objects";
			this.Button_CountObjects.Click += new System.EventHandler(this.Button_CountObjects_Click);
			// 
			// Button_ProfileWorld
			// 
			this.Button_ProfileWorld.Location = new System.Drawing.Point(16, 96);
			this.Button_ProfileWorld.Name = "Button_ProfileWorld";
			this.Button_ProfileWorld.Size = new System.Drawing.Size(184, 24);
			this.Button_ProfileWorld.TabIndex = 3;
			this.Button_ProfileWorld.Text = "Profile World";
			this.Button_ProfileWorld.Click += new System.EventHandler(this.Button_ProfileWorld_Click);
			// 
			// Button_TimerProfiles
			// 
			this.Button_TimerProfiles.Location = new System.Drawing.Point(16, 128);
			this.Button_TimerProfiles.Name = "Button_TimerProfiles";
			this.Button_TimerProfiles.Size = new System.Drawing.Size(184, 24);
			this.Button_TimerProfiles.TabIndex = 2;
			this.Button_TimerProfiles.Text = "Timer Profiles";
			this.Button_TimerProfiles.Click += new System.EventHandler(this.Button_TimerProfiles_Click);
			// 
			// Button_PacketProfiles
			// 
			this.Button_PacketProfiles.Location = new System.Drawing.Point(16, 64);
			this.Button_PacketProfiles.Name = "Button_PacketProfiles";
			this.Button_PacketProfiles.Size = new System.Drawing.Size(184, 24);
			this.Button_PacketProfiles.TabIndex = 1;
			this.Button_PacketProfiles.Text = "Packet Profiles";
			this.Button_PacketProfiles.Click += new System.EventHandler(this.Button_PacketProfiles_Click);
			//
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.Button_ApplyLockdownLevel);
			this.groupBox4.Controls.Add(this.RB_Lockdown_Administrator);
			this.groupBox4.Controls.Add(this.RB_Lockdown_Seer);
			this.groupBox4.Controls.Add(this.RB_Lockdown_GM);
			this.groupBox4.Controls.Add(this.RB_Lockdown_Counselor);
			this.groupBox4.Controls.Add(this.RB_Lockdown_None);
			this.groupBox4.Location = new System.Drawing.Point(504, 32);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(184, 192);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Lockdown Level";
			// 
			// Button_ApplyLockdownLevel
			// 
			this.Button_ApplyLockdownLevel.Location = new System.Drawing.Point(16, 152);
			this.Button_ApplyLockdownLevel.Name = "Button_ApplyLockdownLevel";
			this.Button_ApplyLockdownLevel.Size = new System.Drawing.Size(152, 24);
			this.Button_ApplyLockdownLevel.TabIndex = 5;
			this.Button_ApplyLockdownLevel.Text = "Apply Lockdown Level";
			this.Button_ApplyLockdownLevel.Click += new System.EventHandler(this.Button_ApplyLockdownLevel_Click);
			// 
			// RB_Lockdown_Administrator
			// 
			this.RB_Lockdown_Administrator.Location = new System.Drawing.Point(16, 128);
			this.RB_Lockdown_Administrator.Name = "RB_Lockdown_Administrator";
			this.RB_Lockdown_Administrator.Size = new System.Drawing.Size(104, 16);
			this.RB_Lockdown_Administrator.TabIndex = 4;
			this.RB_Lockdown_Administrator.Text = "Administrator";
			// 
			// RB_Lockdown_Seer
			// 
			this.RB_Lockdown_Seer.Location = new System.Drawing.Point(16, 104);
			this.RB_Lockdown_Seer.Name = "RB_Lockdown_Seer";
			this.RB_Lockdown_Seer.Size = new System.Drawing.Size(104, 16);
			this.RB_Lockdown_Seer.TabIndex = 3;
			this.RB_Lockdown_Seer.Text = "Seer";
			// 
			// RB_Lockdown_GM
			// 
			this.RB_Lockdown_GM.Location = new System.Drawing.Point(16, 80);
			this.RB_Lockdown_GM.Name = "RB_Lockdown_GM";
			this.RB_Lockdown_GM.Size = new System.Drawing.Size(104, 16);
			this.RB_Lockdown_GM.TabIndex = 2;
			this.RB_Lockdown_GM.Text = "GameMaster";
			// 
			// RB_Lockdown_Counselor
			// 
			this.RB_Lockdown_Counselor.Location = new System.Drawing.Point(16, 56);
			this.RB_Lockdown_Counselor.Name = "RB_Lockdown_Counselor";
			this.RB_Lockdown_Counselor.Size = new System.Drawing.Size(104, 16);
			this.RB_Lockdown_Counselor.TabIndex = 1;
			this.RB_Lockdown_Counselor.Text = "Counselor";
			// 
			// RB_Lockdown_None
			// 
			this.RB_Lockdown_None.Location = new System.Drawing.Point(16, 32);
			this.RB_Lockdown_None.Name = "RB_Lockdown_None";
			this.RB_Lockdown_None.Size = new System.Drawing.Size(104, 16);
			this.RB_Lockdown_None.TabIndex = 0;
			this.RB_Lockdown_None.Text = "None";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.Button_SendMessage);
			this.groupBox3.Controls.Add(this.CB_Broadcast_ACL);
			this.groupBox3.Controls.Add(this.TextBox_Message);
			this.groupBox3.Location = new System.Drawing.Point(16, 384);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(704, 72);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Messaging";
			// 
			// Button_SendMessage
			// 
			this.Button_SendMessage.Location = new System.Drawing.Point(600, 32);
			this.Button_SendMessage.Name = "Button_SendMessage";
			this.Button_SendMessage.Size = new System.Drawing.Size(88, 24);
			this.Button_SendMessage.TabIndex = 2;
			this.Button_SendMessage.Text = "Send";
			this.Button_SendMessage.Click += new EventHandler(Button_SendMessage_Click);
			// 
			// CB_Broadcast_ACL
			// 
			this.CB_Broadcast_ACL.Items.AddRange(new object[] {
																  "To all online",
																  "To Staff",
																  "To GM +",
																  "To Seer +",
																  "To Admin +",
																  "To Console"});
			this.CB_Broadcast_ACL.Location = new System.Drawing.Point(456, 32);
			this.CB_Broadcast_ACL.Name = "CB_Broadcast_ACL";
			this.CB_Broadcast_ACL.Size = new System.Drawing.Size(136, 24);
			this.CB_Broadcast_ACL.TabIndex = 1;
			this.CB_Broadcast_ACL.Text = "Send To...";
			// 
			// TextBox_Message
			// 
			this.TextBox_Message.Location = new System.Drawing.Point(16, 32);
			this.TextBox_Message.Name = "TextBox_Message";
			this.TextBox_Message.Size = new System.Drawing.Size(424, 22);
			this.TextBox_Message.TabIndex = 0;
			this.TextBox_Message.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.Button_GenerateDocs);
			this.groupBox2.Controls.Add(this.Button_RebuildCategorisation);
			this.groupBox2.Controls.Add(this.Button_EnableCoreProfiling);
			this.groupBox2.Controls.Add(this.Button_EnableAutosave);
			this.groupBox2.Controls.Add(this.Button_HideConsole);
			this.groupBox2.Controls.Add(this.Button_CrashServer);
			this.groupBox2.Controls.Add(this.Button_Shutdown);
			this.groupBox2.Controls.Add(this.Button_RestartServer);
			this.groupBox2.Controls.Add(this.Button_WorldSave);
			this.groupBox2.Location = new System.Drawing.Point(24, 32);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(216, 336);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "General";
			// 
			// Button_GenerateDocs
			// 
			this.Button_GenerateDocs.Location = new System.Drawing.Point(16, 288);
			this.Button_GenerateDocs.Name = "Button_GenerateDocs";
			this.Button_GenerateDocs.Size = new System.Drawing.Size(184, 24);
			this.Button_GenerateDocs.TabIndex = 8;
			this.Button_GenerateDocs.Text = "Generate Docs";
			this.Button_GenerateDocs.Click += new System.EventHandler(this.Button_GenerateDocs_Click);
			// 
			// Button_RebuildCategorisation
			// 
			this.Button_RebuildCategorisation.Location = new System.Drawing.Point(16, 256);
			this.Button_RebuildCategorisation.Name = "Button_RebuildCategorisation";
			this.Button_RebuildCategorisation.Size = new System.Drawing.Size(184, 24);
			this.Button_RebuildCategorisation.TabIndex = 7;
			this.Button_RebuildCategorisation.Text = "Rebuild Categorisation";
			this.Button_RebuildCategorisation.Click += new System.EventHandler(this.Button_RebuildCategorisation_Click);
			// 
			// Button_EnableCoreProfiling
			// 
			this.Button_EnableCoreProfiling.Location = new System.Drawing.Point(16, 224);
			this.Button_EnableCoreProfiling.Name = "Button_EnableCoreProfiling";
			this.Button_EnableCoreProfiling.Size = new System.Drawing.Size(184, 24);
			this.Button_EnableCoreProfiling.TabIndex = 6;
			this.Button_EnableCoreProfiling.Text = "Enable Core Profiling";
			this.Button_EnableCoreProfiling.Click += new System.EventHandler(this.Button_EnableCoreProfiling_Click);
			// 
			// Button_EnableAutosave
			// 
			this.Button_EnableAutosave.Location = new System.Drawing.Point(16, 192);
			this.Button_EnableAutosave.Name = "Button_EnableAutosave";
			this.Button_EnableAutosave.Size = new System.Drawing.Size(184, 24);
			this.Button_EnableAutosave.TabIndex = 5;
			this.Button_EnableAutosave.Text = "Enable Autosave";
			this.Button_EnableAutosave.Click += new System.EventHandler(this.Button_EnableAutosave_Click);
			// 
			// Button_HideConsole
			// 
			this.Button_HideConsole.Location = new System.Drawing.Point(16, 160);
			this.Button_HideConsole.Name = "Button_HideConsole";
			this.Button_HideConsole.Size = new System.Drawing.Size(184, 24);
			this.Button_HideConsole.TabIndex = 4;
			this.Button_HideConsole.Text = "Hide Console";
			this.Button_HideConsole.Click += new System.EventHandler(this.Button_HideConsole_Click);
			// 
			// Button_CrashServer
			// 
			this.Button_CrashServer.Location = new System.Drawing.Point(16, 128);
			this.Button_CrashServer.Name = "Button_CrashServer";
			this.Button_CrashServer.Size = new System.Drawing.Size(184, 24);
			this.Button_CrashServer.TabIndex = 3;
			this.Button_CrashServer.Text = "Crash Server";
			this.Button_CrashServer.Click += new System.EventHandler(this.Button_CrashServer_Click);
			// 
			// Button_Shutdown
			// 
			this.Button_Shutdown.Location = new System.Drawing.Point(16, 96);
			this.Button_Shutdown.Name = "Button_Shutdown";
			this.Button_Shutdown.Size = new System.Drawing.Size(184, 24);
			this.Button_Shutdown.TabIndex = 2;
			this.Button_Shutdown.Text = "Shutdown Server";
			this.Button_Shutdown.Click += new System.EventHandler(this.Button_Shutdown_Click);
			// 
			// Button_RestartServer
			// 
			this.Button_RestartServer.Location = new System.Drawing.Point(16, 64);
			this.Button_RestartServer.Name = "Button_RestartServer";
			this.Button_RestartServer.Size = new System.Drawing.Size(184, 24);
			this.Button_RestartServer.TabIndex = 1;
			this.Button_RestartServer.Text = "Restart Server";
			this.Button_RestartServer.Click += new System.EventHandler(this.Button_RestartServer_Click);
			// 
			// Button_WorldSave
			// 
			this.Button_WorldSave.Location = new System.Drawing.Point(16, 32);
			this.Button_WorldSave.Name = "Button_WorldSave";
			this.Button_WorldSave.Size = new System.Drawing.Size(184, 24);
			this.Button_WorldSave.TabIndex = 0;
			this.Button_WorldSave.Text = "Save World";
			this.Button_WorldSave.Click += new System.EventHandler(this.Button_WorldSave_Click);

		}

		private void Button_WorldSave_Click(object sender, System.EventArgs e) {
			Timer.DelayCall(TimeSpan.Zero, new TimerCallback(World.Save));
		}

		private void Button_RestartServer_Click(object sender, System.EventArgs e) {
			if (MessageBox.Show(Core.MainForm, "Are you sure you want to restart the server?", "Seriously?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				Timer.DelayCall(TimeSpan.Zero, new TimerCallback(RestartServer_Callback));
			}
		}

		private void RestartServer_Callback() {
			Process.Start(Server.Core.ExePath);
			Server.Core.Process.Kill();
		}

		private void Button_Shutdown_Click(object sender, System.EventArgs e) {
			if (MessageBox.Show(Core.MainForm, "Are you sure you want to shut the server down?\nThis will close WatchUO, too.", "Seriously?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				Timer.DelayCall(TimeSpan.Zero, new TimerCallback(ShutdownServer_Callback));
			}
		}

		private void ShutdownServer_Callback() {
			Server.Core.Process.Kill();
		}

		private void Button_CrashServer_Click(object sender, System.EventArgs e) {
			if (MessageBox.Show(Core.MainForm, "Are you sure you want to crash the server?", "Seriously?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				Timer.DelayCall(TimeSpan.Zero, new TimerCallback(CrashServer_Callback));
			}
		}

		private void CrashServer_Callback() {
			Core.MainForm.Dispose();
			throw new Exception("Server was intentionally crashed through WatchUO-GUI");
		}

		[DllImport("User32", EntryPoint = "ShowWindow")]
		private static extern bool ShowWindow(IntPtr hWnd, Int32 state);

		[DllImport("User32", EntryPoint = "IsWindowVisible")]
		private static extern bool IsWindowVisible(IntPtr hWnd);

		private const Int32 SW_HIDE = 0;
		private const Int32 SW_NORMAL = 1;

		[DllImport("Kernel32.dll")] 
		private static extern IntPtr GetConsoleWindow();

		private void Button_HideConsole_Click(object sender, System.EventArgs e) {
			IntPtr hWnd = GetConsoleWindow();
			if (hWnd != IntPtr.Zero) {
				if (IsWindowVisible(hWnd))
					ShowWindow(hWnd, SW_HIDE);
				else
					ShowWindow(hWnd, SW_NORMAL);
			} else {
				MessageBox.Show("Error - count not find the Console Handle", "Error");
			}

			UpdateHideConsoleButton();
		}

		private void UpdateHideConsoleButton() {
			IntPtr hWnd = GetConsoleWindow();
			if (hWnd != IntPtr.Zero) {
				if (IsWindowVisible(hWnd))
					this.Button_HideConsole.Text = "Hide Console";
				else
					this.Button_HideConsole.Text = "Show Console";
			} 
		}

		private void Button_EnableAutosave_Click(object sender, System.EventArgs e) {
			Server.Misc.AutoSave.SavesEnabled = !Server.Misc.AutoSave.SavesEnabled;
			UpdateAutosaveButton();
		}

		private void UpdateAutosaveButton() {
			if (Server.Misc.AutoSave.SavesEnabled)
				this.Button_EnableAutosave.Text = "Disable AutoSaves";
			else
				this.Button_EnableAutosave.Text = "Enable AutoSaves";
		}

		private void Button_EnableCoreProfiling_Click(object sender, System.EventArgs e) {
			Server.Core.Profiling = !Server.Core.Profiling;
			UpdateCoreProfilingButton();
		}

		private void UpdateCoreProfilingButton() {
			if (Server.Core.Profiling)
				this.Button_EnableCoreProfiling.Text = "Disable Core Profiling";
			else
				this.Button_EnableCoreProfiling.Text = "Enable Core Profiling";
		}

		private void Button_RebuildCategorisation_Click(object sender, System.EventArgs e) {
			Timer.DelayCall(TimeSpan.Zero, new TimerCallback(RebuildCategorisation_Callback));
		}

		private void RebuildCategorisation_Callback() {
			CategoryEntry root = new CategoryEntry( null, "Add Menu", new CategoryEntry[]{ Categorization.Items, Categorization.Mobiles } );
			Categorization.Export( root, "Data/objects.xml", "Objects" );

			MessageBox.Show(Core.MainForm, "Categorisation updated successfully", "Success");
		}

		private void Button_GenerateDocs_Click(object sender, System.EventArgs e) {
			Timer.DelayCall(TimeSpan.Zero, new TimerCallback(GenerateDocs_TimerCallback));
		
		}

		private void GenerateDocs_TimerCallback() {
			CommandEntry cmde = Server.Commands.CommandSystem.Entries["DocGen"] as CommandEntry;
			if (cmde != null) {
				cmde.Handler.BeginInvoke(null, new AsyncCallback(GenerateDocs_CmdCallback), null);
			} else {
				MessageBox.Show(Core.MainForm, "Error invoking the command", "Error");
			}
		}

		private void GenerateDocs_CmdCallback(IAsyncResult ares) {
			if (ares.IsCompleted) {
				MessageBox.Show(Core.MainForm, "Docs generated successfully", "Success");
			}
		}

		private void Button_CountObjects_Click(object sender, System.EventArgs e) {
			Timer.DelayCall(TimeSpan.Zero, new TimerCallback(CountObjects_Callback));
		}

		// copied from commandhandlers.cs
		private class CountSorter : IComparer {
			public int Compare( object x, object y ) {
				DictionaryEntry a = (DictionaryEntry)x;
				DictionaryEntry b = (DictionaryEntry)y;

				int aCount = (int)a.Value;
				int bCount = (int)b.Value;

				int v = -aCount.CompareTo( bCount );

				if ( v == 0 ) {
					Type aType = (Type)a.Key;
					Type bType = (Type)b.Key;

					v = aType.FullName.CompareTo( bType.FullName );
				}

				return v;
			}
		}

		private void CountObjects_Callback() {
			using ( StreamWriter op = new StreamWriter( "objects.log" ) ) {
				Hashtable table = new Hashtable();

				foreach ( Item item in World.Items.Values ) {
					Type type = item.GetType();

					object o = (object)table[type];

					if ( o == null )
						table[type] = 1;
					else
						table[type] = 1 + (int)o;
				}

				ArrayList items = new ArrayList( table );

				table.Clear();

				foreach ( Mobile m in World.Mobiles.Values ) {
					Type type = m.GetType();

					object o = (object)table[type];

					if ( o == null )
						table[type] = 1;
					else
						table[type] = 1 + (int)o;
				}

				ArrayList mobiles = new ArrayList( table );

				items.Sort( new CountSorter() );
				mobiles.Sort( new CountSorter() );

				op.WriteLine( "# Object count table generated on {0}", DateTime.Now );
				op.WriteLine();
				op.WriteLine();

				op.WriteLine( "# Items:" );

				foreach ( DictionaryEntry de in items )
					op.WriteLine( "{0}\t{1:F2}%\t{2}", de.Value, (100 * (int)de.Value) / (double)World.Items.Count, de.Key );

				op.WriteLine();
				op.WriteLine();

				op.WriteLine( "#Mobiles:" );

				foreach ( DictionaryEntry de in mobiles )
					op.WriteLine( "{0}\t{1:F2}%\t{2}", de.Value, (100 * (int)de.Value) / (double)World.Mobiles.Count, de.Key );
			}

			MessageBox.Show(Core.MainForm, "ObjectCount generated successfully", "Success");
		}

		private void Button_PacketProfiles_Click(object sender, System.EventArgs e) {
			Timer.DelayCall(TimeSpan.Zero, new TimerCallback(PacketProfiles_Callback));
		}

		private void PacketProfiles_Callback() {
			CommandHandlers.PacketProfiles_OnCommand(null);
			MessageBox.Show(Core.MainForm, "Packet Profiles generated successfully", "Success");
		}

		private void Button_ProfileWorld_Click(object sender, System.EventArgs e) {
			Timer.DelayCall(TimeSpan.Zero, new TimerCallback(ProfileWorld_Callback));
		}

		private void ProfileWorld_Callback() {
			CommandHandlers.ProfileWorld_OnCommand(null);
			MessageBox.Show(Core.MainForm, "WorldProfile generated successfully", "Success");
		}

		private void Button_TimerProfiles_Click(object sender, System.EventArgs e) {
			Timer.DelayCall(TimeSpan.Zero, new TimerCallback(TimerProfiles_Callback));
		}

		private void TimerProfiles_Callback() {
			CommandHandlers.TimerProfiles_OnCommand(null);
			MessageBox.Show(Core.MainForm, "Timer Profiles generated successfully", "Success");
		}

		private void Button_TraceInternal_Click(object sender, System.EventArgs e) {
			Timer.DelayCall(TimeSpan.Zero, new TimerCallback(TraceInternal_Callback));
		}

		private void TraceInternal_Callback() {
			CommandHandlers.TraceInternal_OnCommand(null);
			MessageBox.Show(Core.MainForm, "Internal Trace successfully", "Success");
		}

		private void Button_ApplyLockdownLevel_Click(object sender, System.EventArgs e) {
			if (MessageBox.Show(Core.MainForm, "Are you sure you want to set this Lockdown Level?", "Seriously?", MessageBoxButtons.YesNo) == DialogResult.Yes)
				Timer.DelayCall(TimeSpan.Zero, new TimerCallback(ApplyLockdownLevel_Callback));
		}

		private void ApplyLockdownLevel_Callback() {
			if (this.RB_Lockdown_Administrator.Checked) {
				Server.Misc.AccountHandler.LockdownLevel = AccessLevel.Administrator;
			} else if (this.RB_Lockdown_Seer.Checked) {
				Server.Misc.AccountHandler.LockdownLevel = AccessLevel.Seer;
			} else if (this.RB_Lockdown_GM.Checked) {
				Server.Misc.AccountHandler.LockdownLevel = AccessLevel.GameMaster;
			} else if (this.RB_Lockdown_Counselor.Checked) {
				Server.Misc.AccountHandler.LockdownLevel = AccessLevel.Counselor;
			} else if (this.RB_Lockdown_None.Checked) {
				Server.Misc.AccountHandler.LockdownLevel = AccessLevel.Player;
			}

			MessageBox.Show(Core.MainForm, string.Format("Lockdown Level set to {0}", Server.Misc.AccountHandler.LockdownLevel.ToString()), "Success");
		}

		private void Button_GenerateTeleporters_Click(object sender, System.EventArgs e) {
			Timer.DelayCall(TimeSpan.Zero, new TimerCallback(GenerateTeleporters_Callback));
		}

		private void GenerateTeleporters_Callback() {
			int count = new GenTeleporter.TeleportersCreator().CreateTeleporters();
			count += new Server.Items.SHTeleporter.SHTeleporterCreator().CreateSHTeleporters();

			MessageBox.Show(Core.MainForm, string.Format("{0} Teleporters created successfully", count), "Success");
		}

		private void Button_GenerateDoors_Click(object sender, System.EventArgs e) {
			Timer.DelayCall(TimeSpan.Zero, new TimerCallback(GenerateDoors_Callback));
		}

		private void GenerateDoors_Callback() {
			DoorGenerator.Generate();
			MessageBox.Show(Core.MainForm, "Doors generated successfully", "Success");
		}

		private void Button_GenerateSecretLocations_Click(object sender, System.EventArgs e) {
			Timer.DelayCall(TimeSpan.Zero, new TimerCallback(GenerateSecretLocations_Callback));
		}

		// copied from markcontainer.cs
		private static bool FindMarkContainer( Point3D p, Map map ) {
			IPooledEnumerable eable = map.GetItemsInRange( p, 0 );

			foreach ( Item item in eable ) {
				if ( item.Z == p.Z && item is MarkContainer ) {
					eable.Free();
					return true;
				}
			}

			eable.Free();
			return false;
		}

		private static void CreateMalasPassage( int x, int y, int z, int xTarget, int yTarget, int zTarget, bool bone, bool locked ) {
			Point3D location = new Point3D( x, y, z );

			if ( FindMarkContainer( location, Map.Malas ) )
				return;

			MarkContainer cont = new MarkContainer( bone, locked );
			cont.TargetMap = Map.Malas;
			cont.Target = new Point3D( xTarget, yTarget, zTarget );
			cont.Description = "strange location";

			cont.MoveToWorld( location, Map.Malas );
		}

		private void GenerateSecretLocations_Callback() {
			CreateMalasPassage( 951, 546, -70, 1006, 994, -70, false, false );
			CreateMalasPassage( 914, 192, -79, 1019, 1062, -70, false, false );
			CreateMalasPassage( 1614, 143, -90, 1214, 1313, -90, false, false );
			CreateMalasPassage( 2176, 324, -90, 1554, 172, -90, false, false );
			CreateMalasPassage( 864, 812, -90, 1061, 1161, -70, false, false );
			CreateMalasPassage( 1051, 1434, -85, 1076, 1244, -70, false, true );
			CreateMalasPassage( 1326, 523, -87, 1201, 1554, -70, false, false );
			CreateMalasPassage( 424, 189, -1, 2333, 1501, -90, true, false );
			CreateMalasPassage( 1313, 1115, -85, 1183, 462, -45, false, false );

			MessageBox.Show(Core.MainForm, "Secret Locations created successfully", "Success");
		}

		private void Button_GenerateMoongates_Click(object sender, System.EventArgs e) {
			Timer.DelayCall(TimeSpan.Zero, new TimerCallback(GenerateMoongates_Callback));
		}

		private void GenerateMoongates_Callback() {
			Server.Items.PublicMoongate.MoonGen_OnCommand(null);
			MessageBox.Show(Core.MainForm, "Moongate Generation completed successfully", "Success");
		}

		private void Button_GenerateSigns_Click(object sender, System.EventArgs e) {
			Timer.DelayCall(TimeSpan.Zero, new TimerCallback(GenerateSigns_Callback));
		}

		// copied from scripts\commands\signparser.cs
		private class SignEntry {
			public string m_Text;
			public Point3D m_Location;
			public int m_ItemID;
			public int m_Map;

			public SignEntry( string text, Point3D pt, int itemID, int mapLoc ) {
				m_Text = text;
				m_Location = pt;
				m_ItemID = itemID;
				m_Map = mapLoc;
			}
		}

		private void GenerateSigns_Callback() {
			string cfg = Path.Combine( Server.Core.BaseDirectory, "Data/signs.cfg" );

			if ( File.Exists( cfg ) ) {
				ArrayList list = new ArrayList();

				using ( StreamReader ip = new StreamReader( cfg ) ) {
					string line;

					while ( (line = ip.ReadLine()) != null ) {
						string[] split = line.Split( ' ' );

						SignEntry e = new SignEntry(
							line.Substring( split[0].Length + 1 + split[1].Length + 1 + split[2].Length + 1 + split[3].Length + 1 + split[4].Length + 1 ),
							new Point3D( Utility.ToInt32( split[2] ), Utility.ToInt32( split[3] ), Utility.ToInt32( split[4] ) ),
							Utility.ToInt32( split[1] ), Utility.ToInt32( split[0] ) );

						list.Add( e );
					}
				}

				Map[] brit = new Map[]{ Map.Felucca, Map.Trammel };
				Map[] fel = new Map[]{ Map.Felucca };
				Map[] tram = new Map[]{ Map.Trammel };
				Map[] ilsh = new Map[]{ Map.Ilshenar };
				Map[] malas = new Map[]{ Map.Malas };
				Map[] tokuno = new Map[]{ Map.Tokuno };

				for ( int i = 0; i < list.Count; ++i ) {
					SignEntry e = (SignEntry)list[i];
					Map[] maps = null;

					switch ( e.m_Map ) {
						case 0: maps = brit; break; // Trammel and Felucca
						case 1: maps = fel; break;  // Felucca
						case 2: maps = tram; break; // Trammel
						case 3: maps = ilsh; break; // Ilshenar
						case 4: maps = malas; break; // Malas
						case 5: maps = tokuno; break; // Tokuno Islands
					}

					for ( int j = 0; maps != null && j < maps.Length; ++j )
						SignParser.Add_Static( e.m_ItemID, e.m_Location, maps[j], e.m_Text );
				}

				MessageBox.Show(Core.MainForm, "Signs successfully generated", "Success");
			}
			else {
				MessageBox.Show(Core.MainForm, string.Format("{0} not found!", cfg) ,"Error");
			}
		}

		private void Button_GenerateVendors_Click(object sender, System.EventArgs e) {
			Timer.DelayCall(TimeSpan.Zero, new TimerCallback(GenerateVendors_TimerCallback));
		}

		private void GenerateVendors_TimerCallback() {
			CommandEntry cmde = Server.Commands.CommandSystem.Entries["VendorGen"] as CommandEntry;
			if (cmde != null) {
				cmde.Handler.BeginInvoke(null, new AsyncCallback(GenerateVendors_CmdCallback), null);
			}
		}

		private void GenerateVendors_CmdCallback(IAsyncResult ares) {
			MessageBox.Show(Core.MainForm, "Vendor Generation finished successfully", "Success");
		}

		
		private void Button_SendMessage_Click(object sender, EventArgs e) {
			if (this.TextBox_Message.Text != null && this.TextBox_Message.Text != string.Empty && this.TextBox_Message.Text.Length > 0) {
				if (this.CB_Broadcast_ACL.SelectedIndex < 5 && this.CB_Broadcast_ACL.SelectedIndex >= 0) {
					CommandHandlers.BroadcastMessage((AccessLevel)this.CB_Broadcast_ACL.SelectedIndex, 0x21, this.TextBox_Message.Text);
				} else if (this.CB_Broadcast_ACL.SelectedIndex == 5) {
					Console.WriteLine(this.TextBox_Message.Text);
				}
			} else {
				MessageBox.Show(Core.MainForm, "There's no message to send", "Error");
			}
		}

		protected override void OnPaint(PaintEventArgs e) {
			switch(Server.Misc.AccountHandler.LockdownLevel) {
				case AccessLevel.Administrator:
					this.RB_Lockdown_Administrator.PerformClick();
					break;
				case AccessLevel.Seer: 
					this.RB_Lockdown_Seer.PerformClick();
					break;
				case AccessLevel.GameMaster: 
					this.RB_Lockdown_GM.PerformClick();
					break;
				case AccessLevel.Counselor: 
					this.RB_Lockdown_Counselor.PerformClick();
					break;
				case AccessLevel.Player: 
					this.RB_Lockdown_None.PerformClick();
					break;
			}
			base.OnPaint(e);
		}

		public override void OnLoad() {
			this.UpdateHideConsoleButton();
			this.UpdateAutosaveButton();
			this.UpdateCoreProfilingButton();
			base.OnLoad ();
		}
	}
}