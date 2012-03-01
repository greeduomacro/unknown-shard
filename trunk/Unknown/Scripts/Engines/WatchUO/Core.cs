using System;
using System.Threading;

using Server;
using Server.Commands;

namespace Server.Engines.WatchUO {
	public abstract class Core {

		// configuration
		public static bool Enabled = true;
		public static bool OpenOnStartup = true;

		public static string Version = "1.0_2";
		

		private static Thread m_Thread = null;
		public static Thread Thread {
			get { return m_Thread; }
		}

		private static MainForm m_MainForm = null;
		public static MainForm MainForm {
			get { return m_MainForm; }
		}

		private static PluginLoader m_PluginLoader = null;
		public static PluginLoader PluginLoader {
			get { return m_PluginLoader; }
		}


		[CallPriority(5)]
		public static void Initialize() {
			Server.Commands.CommandSystem.Register("WatchUO", AccessLevel.Administrator, new CommandEventHandler(
				WatchUO_OnCommand));
			Server.Commands.CommandSystem.Register("HideWatchUO", AccessLevel.Administrator, new CommandEventHandler(HideWatchUO_OnCommand));
			if (Enabled && OpenOnStartup) {
				CreateMainForm();
			}
		}

		public static void RunApp() {
			System.Windows.Forms.Application.Run(m_MainForm);
		}

		[Usage("WatchUO")]
		[Description("Shows the WatchUO GUI if enabled")]
		public static void WatchUO_OnCommand(CommandEventArgs args) {
			if (!Enabled) {
				args.Mobile.SendMessage(0x21, "WatchUO GUI is not active");
				return;
			}
			if (m_MainForm != null && !m_MainForm.Disposing) {
				try {
					m_MainForm.Visible = true;
				} catch { //(ObjectDisposedException ode) {
					CreateMainForm();
				}
			} else {
				CreateMainForm();
			}
		}

		[Usage("HideWatchUO")]
		[Description("Hides the WatchUO GUI if enabled")]
		public static void HideWatchUO_OnCommand(CommandEventArgs args) {
			if (!Enabled) {
				args.Mobile.SendMessage(0x21, "WatchUO GUI is not enabled");
				return;
			}
			
			if (m_MainForm != null) {
				m_MainForm.Visible = false;
			}
		}

		public static void CreateMainForm() {
			Console.Write("Initializing WatchUO GUI... ");
			m_MainForm = new MainForm();

			m_PluginLoader = new PluginLoader("Server.Engines.WatchUO.Plugins");
			m_PluginLoader.LoadPlugins();
			m_PluginLoader.AppendPluginsTo(m_MainForm);

			m_Thread = new Thread(new ThreadStart(RunApp));
			m_Thread.Priority = ThreadPriority.BelowNormal;
			m_Thread.Start();
			Console.WriteLine(" done");
		}
	}
}