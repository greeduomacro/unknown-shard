using System;
using System.Windows.Forms;

namespace Server.Engines.WatchUO {
	public abstract class BasePlugin : TabPage {
		private int m_Order;
		public int Order {
			get { return this.m_Order; }
			set { this.m_Order = value; }
		}

		public BasePlugin(string guiName) : base(guiName) {
			this.m_Order = 25;
		}

		public virtual void OnLoad() {
		}

		public virtual void OnClose() {
		}

		protected override void Dispose(bool disposing) {
		}
	}
}