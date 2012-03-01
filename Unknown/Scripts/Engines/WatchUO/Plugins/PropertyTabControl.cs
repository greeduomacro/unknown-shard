using System;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;

using Server;
using Server.Engines.WatchUO;

namespace Server.Engines.WatchUO.Plugins {
	public class PropertyTabControl : TabControl {
		private object m_ActualObject;

		private const int ComponentHeight = 22;
		private const int LabelWidth = 150;
		private const int TextBoxWidth = 110;
		private const int ButtonWidth = 22;
		private const int VerticalMargin = 5;
		private const int HorizontalMargin = 5;

		private static Type typeofbyte = typeof(byte);
		private static Type typeofsbyte = typeof(sbyte);
		private static Type typeofushort = typeof(ushort);
		private static Type typeofshort = typeof(short);
		private static Type typeofuint = typeof(uint);
		private static Type typeofint = typeof(int);
		private static Type typeofulong = typeof(ulong);
		private static Type typeoflong = typeof(long);
		private static Type typeoffloat = typeof(float);
		private static Type typeofdouble = typeof(double);
		private static Type typeofdecimal = typeof(decimal);
		private static Type typeofstring = typeof(string);
		private static Type typeofbool = typeof(bool);
		private static Type typeofobject = typeof(object);
		private static Type typeofCommandPropertyAttribute = typeof(CommandPropertyAttribute);

		private struct PropertySet {
			public Label Description;
			public TextBox Input;
			public Button ConfirmButton;
			public PropertyInfo PropertyInfo;
			public object Owner;

			public PropertySet(PropertyInfo info, object owner) {
				this.PropertyInfo = info;
				this.Owner = owner;

				this.Description = new Label();
				this.Description.Text = this.PropertyInfo.Name;
				this.Description.Size = new System.Drawing.Size(LabelWidth, ComponentHeight);

				this.Input = new TextBox();
				this.Input.Size = new System.Drawing.Size(TextBoxWidth, ComponentHeight);

				this.ConfirmButton = new Button();
				this.ConfirmButton.Text = ">";
				this.ConfirmButton.Size = new System.Drawing.Size(ButtonWidth, ComponentHeight);
				this.ConfirmButton.Click += new EventHandler(ConfirmButton_Click);

				this.UpdateValue();
					
				if (!this.PropertyInfo.CanWrite) {
					this.Input.Enabled = false;
					this.ConfirmButton.Enabled = false;
				}
			}

			private void ConfirmButton_Click(object sender, EventArgs e) {
				if (this.PropertyInfo.PropertyType == typeof(string)) {
					this.PropertyInfo.SetValue(this.Owner, this.Input.Text, null);
				} else if (this.PropertyInfo.PropertyType == typeof(byte)) {
					try {
						this.PropertyInfo.SetValue(this.Owner, byte.Parse(this.Input.Text), null);
					} catch {
						MessageBox.Show(Core.MainForm, "Error parsing the value", "Error");
					}
				} else if (this.PropertyInfo.PropertyType == typeof(sbyte)) {
					try {
						this.PropertyInfo.SetValue(this.Owner, sbyte.Parse(this.Input.Text), null);
					} catch {
						MessageBox.Show(Core.MainForm, "Error parsing the value", "Error");
					}
				} else if (this.PropertyInfo.PropertyType == typeof(ushort)) {
					try {
						this.PropertyInfo.SetValue(this.Owner, ushort.Parse(this.Input.Text), null);
					} catch {
						MessageBox.Show(Core.MainForm, "Error parsing the value", "Error");
					}
				} else if (this.PropertyInfo.PropertyType == typeof(short)) {
					try {
						this.PropertyInfo.SetValue(this.Owner, short.Parse(this.Input.Text), null);
					} catch {
						MessageBox.Show(Core.MainForm, "Error parsing the value", "Error");
					}
				} else if (this.PropertyInfo.PropertyType == typeof(uint)) {
					try {
						this.PropertyInfo.SetValue(this.Owner, uint.Parse(this.Input.Text), null);
					} catch {
						MessageBox.Show(Core.MainForm, "Error parsing the value", "Error");
					}
				} else if (this.PropertyInfo.PropertyType == typeof(int)) {
					try {
						this.PropertyInfo.SetValue(this.Owner, int.Parse(this.Input.Text), null);
					} catch {
						MessageBox.Show(Core.MainForm, "Error parsing the value", "Error");
					}
				} else if (this.PropertyInfo.PropertyType == typeof(ulong)) {
					try {
						this.PropertyInfo.SetValue(this.Owner, ulong.Parse(this.Input.Text), null);
					} catch {
						MessageBox.Show(Core.MainForm, "Error parsing the value", "Error");
					}
				} else if (this.PropertyInfo.PropertyType == typeof(long)) {
					try {
						this.PropertyInfo.SetValue(this.Owner, long.Parse(this.Input.Text), null);
					} catch {
						MessageBox.Show(Core.MainForm, "Error parsing the value", "Error");
					}
				} else if (this.PropertyInfo.PropertyType == typeof(float)) {
					try {
						this.PropertyInfo.SetValue(this.Owner, float.Parse(this.Input.Text), null);
					} catch {
						MessageBox.Show(Core.MainForm, "Error parsing the value", "Error");
					}
				} else if (this.PropertyInfo.PropertyType == typeof(double)) {
					try {
						this.PropertyInfo.SetValue(this.Owner, double.Parse(this.Input.Text), null);
					} catch {
						MessageBox.Show(Core.MainForm, "Error parsing the value", "Error");
					}
				} else if (this.PropertyInfo.PropertyType == typeof(decimal)) {
					try {
						this.PropertyInfo.SetValue(this.Owner, decimal.Parse(this.Input.Text), null);
					} catch {
						MessageBox.Show(Core.MainForm, "Error parsing the value", "Error");
					}
				} else if (this.PropertyInfo.PropertyType == typeof(bool)) {
					try {
						this.PropertyInfo.SetValue(this.Owner, bool.Parse(this.Input.Text), null);
					} catch {
						MessageBox.Show(Core.MainForm, "Error parsing the value", "Error");
					}
				}
			}

			private void UpdateValue() {
				object val = this.PropertyInfo.GetValue(this.Owner, null);
				if (val != null)
					this.Input.Text = val.ToString();
				else
					this.Input.Text = "null";
			}
		}

		public PropertyTabControl() : base() {
		}

		private Hashtable GetPropertySetsFor(object o) {
			Hashtable ret = new Hashtable();

			PropertyInfo[] props = o.GetType().GetProperties();
			for (int i = 0; i < props.Length; i++) {
				if (IsSupportedType(props[i].PropertyType) && props[i].DeclaringType != typeofobject && Attribute.IsDefined(props[i], typeofCommandPropertyAttribute)) {
					PropertySet act = new PropertySet(props[i], o);

					ArrayList list = (ArrayList)ret[act.PropertyInfo.DeclaringType];
					if (list == null)
						ret[act.PropertyInfo.DeclaringType] = list = new ArrayList();

					list.Add(act);
				}
			}

			return ret;
		}

		private void ShowPropertiesFor(object o) {
			this.m_ActualObject = o;
			this.EmptyPropsInfo();

			Hashtable table = this.GetPropertySetsFor(this.m_ActualObject);

			ArrayList keys = new ArrayList(table.Keys);
			foreach (Type t in keys) {
				TabPage page = new TabPage(t.Name);
				page.AutoScroll = true;

				int x = 10, y = VerticalMargin;
				ArrayList actList = table[t] as ArrayList;
				actList.Sort(new PropertyNameComparer());

				foreach (PropertySet act in actList) {
					act.Description.Location = new System.Drawing.Point(x, y);
					act.Input.Location = new System.Drawing.Point(x + act.Description.Width + HorizontalMargin, y);
					act.ConfirmButton.Location = new System.Drawing.Point(x + act.Description.Width + HorizontalMargin + act.Input.Width + HorizontalMargin, y);

					page.Controls.Add(act.Description);
					page.Controls.Add(act.Input);
					page.Controls.Add(act.ConfirmButton);

					y += ComponentHeight + VerticalMargin;
				}

				this.Controls.Add(page);
			}
		}

		private class PropertyNameComparer : IComparer {
			public int Compare(object l, object r) {
				if ((r == null && l == null))
					return 0;
				else if ( r == null )
					return -1;
				else if ( l == null )
					return 1;

				PropertySet pr = (PropertySet)r;
				PropertySet pl = (PropertySet)l;

				return pl.PropertyInfo.Name.CompareTo(pr.PropertyInfo.Name);
			}
		}

		private void EmptyPropsInfo() {
			if (this.Controls.Count > 0 && this.m_ActualObject != null)
				this.RemoveAll();
		}

		public static bool IsSupportedType(Type t) {
			return t == typeofstring ||
				t == typeofbyte ||
				t == typeofsbyte ||
				t == typeofushort ||
				t == typeofshort ||
				t == typeofuint ||
				t == typeofint ||
				t == typeofulong ||
				t == typeoflong ||
				t == typeoffloat ||
				t == typeofdouble ||
				t == typeofdecimal ||
				t == typeofbool;
		}

		public void RefreshProps(object o) {
			if (o != null) {
				this.m_ActualObject = o;
				if (this.Visible)
					this.ShowPropertiesFor(o);
			} else {
				if (this.Visible)
					this.EmptyPropsInfo();
			}
		}

		protected override void OnVisibleChanged(EventArgs e) {
			base.OnVisibleChanged (e);

			this.RefreshProps(this.m_ActualObject);
		}
	}
}