using System;
using System.Collections;
using System.Reflection;

namespace Server.Engines.WatchUO {
	public class PluginLoader {
		private string m_PluginNamespace;
		public string PluginNamespace {
			get { return this.m_PluginNamespace; }
		}

		private ArrayList m_LoadedPlugins;
		public ArrayList LoadedPlugins {
			get { return this.m_LoadedPlugins; }
		}

		private static object[] m_EmptyObjectArray = new object[0];

		public PluginLoader(string _namespace) {
			this.m_PluginNamespace = _namespace;
			this.m_LoadedPlugins = new ArrayList();
		}

		public void LoadPlugins() {
			for (int asm = 0; asm < ScriptCompiler.Assemblies.Length; asm++) {
				Type[] types = ScriptCompiler.Assemblies[asm].GetTypes();
				for (int t = 0; t < types.Length; t++) {
					if (types[t].Namespace == this.m_PluginNamespace) {
						if (types[t].BaseType != typeof(BasePlugin))
							continue;

						ConstructorInfo[] ctors = types[t].GetConstructors();
						BasePlugin plugin = null;
						for (int c = 0; c < ctors.Length; c++) {
							if (ctors[c].GetParameters().Length == 0) {
								plugin = ctors[c].Invoke(m_EmptyObjectArray) as BasePlugin;
								break;
							}
						}
						if (plugin != null) {
							this.m_LoadedPlugins.Add(plugin);
							plugin.OnLoad();
						}
					}
				}
			}

			this.m_LoadedPlugins.Sort(new PluginComparer());
		}

		public void AppendPluginsTo(MainForm form) {
			for (int i = 0; i < m_LoadedPlugins.Count; i++) {
				form.AddPlugin((BasePlugin)m_LoadedPlugins[i]);
			}
		}

		public void MainformClosed() {
			for (int i = 0; i < m_LoadedPlugins.Count; i++) {
				((BasePlugin)m_LoadedPlugins[i]).OnClose();
			}
		}

		private class PluginComparer : IComparer {
			public int Compare(object _x, object _y) {
				if (_x is BasePlugin && _y is BasePlugin) {
					BasePlugin x = _x as BasePlugin;
					BasePlugin y = _y as BasePlugin;

					if (x.Order > y.Order)
						return 1;
					else if (x.Order < y.Order)
						return -1;
					else
						return 0;
				} else
					throw new ArgumentException();
			}
		}
	}
}