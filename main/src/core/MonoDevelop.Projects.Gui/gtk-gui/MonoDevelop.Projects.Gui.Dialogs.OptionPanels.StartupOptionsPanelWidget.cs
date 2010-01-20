
// This file has been generated by the GUI designer. Do not modify.
namespace MonoDevelop.Projects.Gui.Dialogs.OptionPanels
{
	internal partial class StartupOptionsPanelWidget
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.RadioButton radioSingle;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Label label1;

		private global::Gtk.ComboBox comboItems;

		private global::Gtk.RadioButton radioMulti;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label label2;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TreeView treeItems;

		private global::Gtk.VBox vbox3;

		private global::Gtk.Button buttonUp;

		private global::Gtk.Button buttonDown;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MonoDevelop.Projects.Gui.Dialogs.OptionPanels.StartupOptionsPanelWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "MonoDevelop.Projects.Gui.Dialogs.OptionPanels.StartupOptionsPanelWidget";
			// Container child MonoDevelop.Projects.Gui.Dialogs.OptionPanels.StartupOptionsPanelWidget.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.radioSingle = new global::Gtk.RadioButton (global::MonoDevelop.Core.GettextCatalog.GetString ("Single startup project:"));
			this.radioSingle.CanFocus = true;
			this.radioSingle.Name = "radioSingle";
			this.radioSingle.Active = true;
			this.radioSingle.DrawIndicator = true;
			this.radioSingle.UseUnderline = true;
			this.radioSingle.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.vbox2.Add (this.radioSingle);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.radioSingle]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.WidthRequest = 12;
			this.label1.Name = "label1";
			this.hbox2.Add (this.label1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.label1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.comboItems = global::Gtk.ComboBox.NewText ();
			this.comboItems.Name = "comboItems";
			this.hbox2.Add (this.comboItems);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.comboItems]));
			w3.Position = 1;
			this.vbox2.Add (this.hbox2);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox2]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.radioMulti = new global::Gtk.RadioButton (global::MonoDevelop.Core.GettextCatalog.GetString ("Multiple startup projects:"));
			this.radioMulti.CanFocus = true;
			this.radioMulti.Name = "radioMulti";
			this.radioMulti.DrawIndicator = true;
			this.radioMulti.UseUnderline = true;
			this.radioMulti.Group = this.radioSingle.Group;
			this.vbox2.Add (this.radioMulti);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.radioMulti]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.WidthRequest = 12;
			this.label2.Name = "label2";
			this.hbox1.Add (this.label2);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label2]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.treeItems = new global::Gtk.TreeView ();
			this.treeItems.CanFocus = true;
			this.treeItems.Name = "treeItems";
			this.GtkScrolledWindow.Add (this.treeItems);
			this.hbox1.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.GtkScrolledWindow]));
			w8.Position = 1;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.buttonUp = new global::Gtk.Button ();
			this.buttonUp.CanFocus = true;
			this.buttonUp.Name = "buttonUp";
			this.buttonUp.UseStock = true;
			this.buttonUp.UseUnderline = true;
			this.buttonUp.Label = "gtk-go-up";
			this.vbox3.Add (this.buttonUp);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.buttonUp]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.buttonDown = new global::Gtk.Button ();
			this.buttonDown.CanFocus = true;
			this.buttonDown.Name = "buttonDown";
			this.buttonDown.UseStock = true;
			this.buttonDown.UseUnderline = true;
			this.buttonDown.Label = "gtk-go-down";
			this.vbox3.Add (this.buttonDown);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.buttonDown]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			this.hbox1.Add (this.vbox3);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vbox3]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			this.vbox2.Add (this.hbox1);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
			w12.Position = 3;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.radioSingle.Toggled += new global::System.EventHandler (this.OnRadioSingleToggled);
			this.buttonUp.Clicked += new global::System.EventHandler (this.OnButtonUpClicked);
			this.buttonDown.Clicked += new global::System.EventHandler (this.OnButtonDownClicked);
		}
	}
}
