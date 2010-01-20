
// This file has been generated by the GUI designer. Do not modify.
namespace MonoDevelop.Projects.Gui.Dialogs
{
	public partial class ProjectFileSelectorDialog
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.HPaned hpaned1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TreeView projectTree;

		private global::Gtk.ScrolledWindow GtkScrolledWindow1;

		private global::Gtk.TreeView fileList;

		private global::Gtk.HBox typeBox;

		private global::Gtk.Label label2;

		private global::Gtk.ComboBox fileTypeCombo;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Button buttonOk;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MonoDevelop.Projects.Gui.Dialogs.ProjectFileSelectorDialog
			this.Name = "MonoDevelop.Projects.Gui.Dialogs.ProjectFileSelectorDialog";
			this.Title = global::MonoDevelop.Core.GettextCatalog.GetString ("Select Project File...");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child MonoDevelop.Projects.Gui.Dialogs.ProjectFileSelectorDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			this.vbox2.BorderWidth = ((uint)(6));
			// Container child vbox2.Gtk.Box+BoxChild
			this.hpaned1 = new global::Gtk.HPaned ();
			this.hpaned1.CanFocus = true;
			this.hpaned1.Name = "hpaned1";
			this.hpaned1.Position = 182;
			// Container child hpaned1.Gtk.Paned+PanedChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.projectTree = new global::Gtk.TreeView ();
			this.projectTree.CanFocus = true;
			this.projectTree.Name = "projectTree";
			this.GtkScrolledWindow.Add (this.projectTree);
			this.hpaned1.Add (this.GtkScrolledWindow);
			global::Gtk.Paned.PanedChild w3 = ((global::Gtk.Paned.PanedChild)(this.hpaned1[this.GtkScrolledWindow]));
			w3.Resize = false;
			// Container child hpaned1.Gtk.Paned+PanedChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.fileList = new global::Gtk.TreeView ();
			this.fileList.CanFocus = true;
			this.fileList.Name = "fileList";
			this.GtkScrolledWindow1.Add (this.fileList);
			this.hpaned1.Add (this.GtkScrolledWindow1);
			this.vbox2.Add (this.hpaned1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hpaned1]));
			w6.Position = 0;
			// Container child vbox2.Gtk.Box+BoxChild
			this.typeBox = new global::Gtk.HBox ();
			this.typeBox.Name = "typeBox";
			this.typeBox.Spacing = 6;
			// Container child typeBox.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::MonoDevelop.Core.GettextCatalog.GetString ("File _type:");
			this.label2.UseUnderline = true;
			this.typeBox.Add (this.label2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.typeBox[this.label2]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child typeBox.Gtk.Box+BoxChild
			this.fileTypeCombo = global::Gtk.ComboBox.NewText ();
			this.fileTypeCombo.Name = "fileTypeCombo";
			this.typeBox.Add (this.fileTypeCombo);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.typeBox[this.fileTypeCombo]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			this.vbox2.Add (this.typeBox);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.typeBox]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(w1[this.vbox2]));
			w10.Position = 0;
			// Internal child MonoDevelop.Projects.Gui.Dialogs.ProjectFileSelectorDialog.ActionArea
			global::Gtk.HButtonBox w11 = this.ActionArea;
			w11.Name = "dialog1_ActionArea";
			w11.Spacing = 6;
			w11.BorderWidth = ((uint)(5));
			w11.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w12 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w11[this.buttonCancel]));
			w12.Expand = false;
			w12.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w13 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w11[this.buttonOk]));
			w13.Position = 1;
			w13.Expand = false;
			w13.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 522;
			this.DefaultHeight = 416;
			this.label2.MnemonicWidget = this.fileTypeCombo;
			this.typeBox.Hide ();
			this.Show ();
		}
	}
}
