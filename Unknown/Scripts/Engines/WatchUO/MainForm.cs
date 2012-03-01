using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Server.Engines.WatchUO.Plugins;

namespace Server.Engines.WatchUO {
	public class MainForm : System.Windows.Forms.Form {
		private TabControl m_TabControl;
		public TabControl TabControl {
			get { return this.m_TabControl; }
		}


		public MainForm() {
			this.Text = string.Format("WatchUO {0}", Core.Version);
			this.Size = new Size(800, 600);
			this.MaximizeBox = false;
			this.ShowInTaskbar = true;
			this.FormBorderStyle = FormBorderStyle.Fixed3D;

			InitMenu();

			this.m_TabControl = new TabControl();
			this.m_TabControl.Location = new Point(0, 0);
			this.m_TabControl.Size = new Size(792, 543);
			this.Controls.Add(this.m_TabControl);

			this.Closing += new CancelEventHandler(MainForm_Closing);
		}

		private void InitMenu() {
			this.Menu = new MainMenu();

			MenuItem infoMenu = new MenuItem("Info");

			MenuItem infoMenu_about = new MenuItem("About WatchUO");
			infoMenu_about.Click += new EventHandler(infoMenu_about_Click);
			infoMenu.MenuItems.Add(infoMenu_about);

			MenuItem infoMenu_pluginList = new MenuItem("Plugin List");
			infoMenu_pluginList.Click += new EventHandler(infoMenu_pluginList_Click);
			infoMenu.MenuItems.Add(infoMenu_pluginList);
			
			this.Menu.MenuItems.Add(infoMenu);
		}

		public void AddPlugin(BasePlugin plugin) {
			this.m_TabControl.TabPages.Add(plugin);
		}

		private void MainForm_Closing(object sender, CancelEventArgs e) {
			Core.PluginLoader.MainformClosed();
		}

		private void infoMenu_pluginList_Click(object sender, EventArgs e) {
			string list = string.Empty;
			for (int i = 0; i < Core.PluginLoader.LoadedPlugins.Count; i++) {
				BasePlugin plugin = Core.PluginLoader.LoadedPlugins[i] as BasePlugin;
				if (plugin != null) {
					list += plugin.Text;
					if (i < Core.PluginLoader.LoadedPlugins.Count-1)
						list += "\n";
				}
			}

			MessageBox.Show(Core.MainForm, list, "Plugin List");
		}

		private void infoMenu_about_Click(object sender, EventArgs e) {
			for (int i = 0; i < Core.PluginLoader.LoadedPlugins.Count; i++) {
				if (Core.PluginLoader.LoadedPlugins[i] is AboutPlugin) {
					AboutPlugin ab = Core.PluginLoader.LoadedPlugins[i] as AboutPlugin;
					if (ab != null) {
						Core.MainForm.TabControl.SelectedTab = Core.MainForm.TabControl.TabPages[Core.MainForm.TabControl.TabPages.IndexOf(ab)];
							return;
					} else {
						MessageBox.Show(Core.MainForm, "Error switchting to the AboutPlugin", "Error");
						return;
					}
				}
			}

			MessageBox.Show(Core.MainForm, "AboutPlugin not loaded", "Error");
		}
	}
}
