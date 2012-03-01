using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Server.Engines.WatchUO.Plugins {
	public class AboutPlugin : BasePlugin {
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;

		public AboutPlugin() : base("About") {
			this.Order = 50;

			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox1.SuspendLayout();

			this.Controls.Add(groupBox1);

			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(24, 24);
			this.groupBox1.Name = "About";
			this.groupBox1.Size = new System.Drawing.Size(736, 472);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "About";

			this.label1.Location = new System.Drawing.Point(16, 160);
			this.label1.Name = "About-Text";
			this.label1.Size = new System.Drawing.Size(696, 296);
			this.label1.TabIndex = 0;
			this.label1.Text =
@"Credits:
---------------
Arahil: Lead Developer, Project Manager
      Basics, Plugin-System, Plugins for RunUO Information, RunUO Control, 
      Account Management, Firewall, parts of the currently online Plugin and this one  
ssalter: Plugin Developer, Idea Factory
      Plugin for currently online players, brilliant ideas
wagenhuis: Betatester, Idea Factory
      Testing WatchUO on a live shard, lots of excellent ideas
The whole RunUO Team (Krrios, Zippy, Mark, Ryan and everyone else who partizipated) for RunUO
tehToFu: Original idea for a GUI like this one
... and everybody else, who had good ideas for WatchUO or just motivated us
to go on with this project
 
 
'The Rich must live more simply so that the Poor may simply live.'
'Earth provides enough to satisfy every man’s need, but not any man’s greed.'
- Mahatma Gandhi";

			try {
				this.pictureBox1.Image = Image.FromFile(@".\Scripts\Engines\WatchUO\Plugins\data\watchuo.jpg");
			} catch (Exception e) {
				Console.WriteLine(e);
			}
			this.pictureBox1.Location = new System.Drawing.Point(16, 32);
			this.pictureBox1.Name = "RunUO-Logo";
			this.pictureBox1.Size = new System.Drawing.Size(696, 120);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
		}
	}
}