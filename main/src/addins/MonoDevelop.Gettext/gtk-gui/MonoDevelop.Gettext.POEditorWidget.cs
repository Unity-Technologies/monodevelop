// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace MonoDevelop.Gettext {
    
    
    public partial class POEditorWidget {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Notebook notebookPages;
        
        private Gtk.VBox vbox7;
        
        private Gtk.HBox hbox2;
        
        private Gtk.Label label2;
        
        private Gtk.Entry entryFilter;
        
        private Gtk.ToggleButton togglebuttonOk;
        
        private Gtk.ToggleButton togglebuttonMissing;
        
        private Gtk.ToggleButton togglebuttonFuzzy;
        
        private Gtk.VPaned vpaned2;
        
        private Gtk.ScrolledWindow scrolledwindow1;
        
        private Gtk.TreeView treeviewEntries;
        
        private Gtk.Table table1;
        
        private Gtk.VBox vbox3;
        
        private Gtk.Label label6;
        
        private Gtk.ScrolledWindow scrolledwindow3;
        
        private Gtk.TextView textviewComments;
        
        private Gtk.VBox vbox4;
        
        private Gtk.Label label7;
        
        private Gtk.Notebook notebookTranslated;
        
        private Gtk.Label label1;
        
        private Gtk.VBox vbox5;
        
        private Gtk.Label label8;
        
        private Gtk.ScrolledWindow scrolledwindow4;
        
        private Gtk.Label labelOriginal;
        
        private Gtk.VBox vbox8;
        
        private Gtk.Label label9;
        
        private Gtk.ScrolledWindow scrolledwindow5;
        
        private Gtk.Label labelPlural;
        
        private Gtk.VBox vbox6;
        
        private Gtk.Label label4;
        
        private Gtk.ScrolledWindow scrolledwindow2;
        
        private Gtk.TreeView treeviewFoundIn;
        
        private Gtk.Label label5;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Toolbar toolbarPages;
        
        private Gtk.ProgressBar progressbar1;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoDevelop.Gettext.POEditorWidget
            Stetic.BinContainer w1 = Stetic.BinContainer.Attach(this);
            Gtk.UIManager w2 = new Gtk.UIManager();
            Gtk.ActionGroup w3 = new Gtk.ActionGroup("Default");
            w2.InsertActionGroup(w3, 0);
            this.Name = "MonoDevelop.Gettext.POEditorWidget";
            // Container child MonoDevelop.Gettext.POEditorWidget.Gtk.Container+ContainerChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.notebookPages = new Gtk.Notebook();
            this.notebookPages.CanFocus = true;
            this.notebookPages.Name = "notebookPages";
            this.notebookPages.CurrentPage = 0;
            this.notebookPages.ShowBorder = false;
            this.notebookPages.ShowTabs = false;
            // Container child notebookPages.Gtk.Notebook+NotebookChild
            this.vbox7 = new Gtk.VBox();
            this.vbox7.Name = "vbox7";
            this.vbox7.Spacing = 6;
            // Container child vbox7.Gtk.Box+BoxChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 6;
            // Container child hbox2.Gtk.Box+BoxChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("_Filter:");
            this.label2.UseUnderline = true;
            this.hbox2.Add(this.label2);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.hbox2[this.label2]));
            w4.Position = 0;
            w4.Expand = false;
            w4.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.entryFilter = new Gtk.Entry();
            this.entryFilter.CanFocus = true;
            this.entryFilter.Name = "entryFilter";
            this.entryFilter.IsEditable = true;
            this.entryFilter.InvisibleChar = '●';
            this.hbox2.Add(this.entryFilter);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.hbox2[this.entryFilter]));
            w5.Position = 1;
            // Container child hbox2.Gtk.Box+BoxChild
            this.togglebuttonOk = new Gtk.ToggleButton();
            this.togglebuttonOk.CanFocus = true;
            this.togglebuttonOk.Name = "togglebuttonOk";
            this.togglebuttonOk.UseUnderline = true;
            // Container child togglebuttonOk.Gtk.Container+ContainerChild
            Gtk.Alignment w6 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w7 = new Gtk.HBox();
            w7.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Image w8 = new Gtk.Image();
            w8.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-apply", Gtk.IconSize.Menu, 16);
            w7.Add(w8);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Label w10 = new Gtk.Label();
            w10.LabelProp = "";
            w7.Add(w10);
            w6.Add(w7);
            this.togglebuttonOk.Add(w6);
            this.hbox2.Add(this.togglebuttonOk);
            Gtk.Box.BoxChild w14 = ((Gtk.Box.BoxChild)(this.hbox2[this.togglebuttonOk]));
            w14.Position = 2;
            w14.Expand = false;
            w14.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.togglebuttonMissing = new Gtk.ToggleButton();
            this.togglebuttonMissing.CanFocus = true;
            this.togglebuttonMissing.Name = "togglebuttonMissing";
            this.togglebuttonMissing.UseUnderline = true;
            // Container child togglebuttonMissing.Gtk.Container+ContainerChild
            Gtk.Alignment w15 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w16 = new Gtk.HBox();
            w16.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Image w17 = new Gtk.Image();
            w17.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-cancel", Gtk.IconSize.Menu, 16);
            w16.Add(w17);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Label w19 = new Gtk.Label();
            w19.LabelProp = "";
            w16.Add(w19);
            w15.Add(w16);
            this.togglebuttonMissing.Add(w15);
            this.hbox2.Add(this.togglebuttonMissing);
            Gtk.Box.BoxChild w23 = ((Gtk.Box.BoxChild)(this.hbox2[this.togglebuttonMissing]));
            w23.Position = 3;
            w23.Expand = false;
            w23.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.togglebuttonFuzzy = new Gtk.ToggleButton();
            this.togglebuttonFuzzy.CanFocus = true;
            this.togglebuttonFuzzy.Name = "togglebuttonFuzzy";
            this.togglebuttonFuzzy.UseUnderline = true;
            // Container child togglebuttonFuzzy.Gtk.Container+ContainerChild
            Gtk.Alignment w24 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w25 = new Gtk.HBox();
            w25.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Image w26 = new Gtk.Image();
            w26.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-about", Gtk.IconSize.Menu, 16);
            w25.Add(w26);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Label w28 = new Gtk.Label();
            w28.LabelProp = "";
            w25.Add(w28);
            w24.Add(w25);
            this.togglebuttonFuzzy.Add(w24);
            this.hbox2.Add(this.togglebuttonFuzzy);
            Gtk.Box.BoxChild w32 = ((Gtk.Box.BoxChild)(this.hbox2[this.togglebuttonFuzzy]));
            w32.Position = 4;
            w32.Expand = false;
            w32.Fill = false;
            this.vbox7.Add(this.hbox2);
            Gtk.Box.BoxChild w33 = ((Gtk.Box.BoxChild)(this.vbox7[this.hbox2]));
            w33.Position = 0;
            w33.Expand = false;
            w33.Fill = false;
            // Container child vbox7.Gtk.Box+BoxChild
            this.vpaned2 = new Gtk.VPaned();
            this.vpaned2.CanFocus = true;
            this.vpaned2.Name = "vpaned2";
            this.vpaned2.Position = 186;
            // Container child vpaned2.Gtk.Paned+PanedChild
            this.scrolledwindow1 = new Gtk.ScrolledWindow();
            this.scrolledwindow1.CanFocus = true;
            this.scrolledwindow1.Name = "scrolledwindow1";
            this.scrolledwindow1.ShadowType = ((Gtk.ShadowType)(1));
            // Container child scrolledwindow1.Gtk.Container+ContainerChild
            this.treeviewEntries = new Gtk.TreeView();
            this.treeviewEntries.CanFocus = true;
            this.treeviewEntries.Name = "treeviewEntries";
            this.treeviewEntries.HeadersClickable = true;
            this.scrolledwindow1.Add(this.treeviewEntries);
            this.vpaned2.Add(this.scrolledwindow1);
            Gtk.Paned.PanedChild w35 = ((Gtk.Paned.PanedChild)(this.vpaned2[this.scrolledwindow1]));
            w35.Resize = false;
            // Container child vpaned2.Gtk.Paned+PanedChild
            this.table1 = new Gtk.Table(((uint)(2)), ((uint)(2)), true);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            // Container child table1.Gtk.Table+TableChild
            this.vbox3 = new Gtk.VBox();
            this.vbox3.Name = "vbox3";
            this.vbox3.Spacing = 6;
            // Container child vbox3.Gtk.Box+BoxChild
            this.label6 = new Gtk.Label();
            this.label6.Name = "label6";
            this.label6.Xalign = 0F;
            this.label6.LabelProp = Mono.Unix.Catalog.GetString("_Comments:");
            this.label6.UseUnderline = true;
            this.vbox3.Add(this.label6);
            Gtk.Box.BoxChild w36 = ((Gtk.Box.BoxChild)(this.vbox3[this.label6]));
            w36.Position = 0;
            w36.Expand = false;
            w36.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.scrolledwindow3 = new Gtk.ScrolledWindow();
            this.scrolledwindow3.CanFocus = true;
            this.scrolledwindow3.Name = "scrolledwindow3";
            this.scrolledwindow3.ShadowType = ((Gtk.ShadowType)(1));
            // Container child scrolledwindow3.Gtk.Container+ContainerChild
            this.textviewComments = new Gtk.TextView();
            this.textviewComments.CanFocus = true;
            this.textviewComments.Name = "textviewComments";
            this.textviewComments.AcceptsTab = false;
            this.scrolledwindow3.Add(this.textviewComments);
            this.vbox3.Add(this.scrolledwindow3);
            Gtk.Box.BoxChild w38 = ((Gtk.Box.BoxChild)(this.vbox3[this.scrolledwindow3]));
            w38.Position = 1;
            this.table1.Add(this.vbox3);
            Gtk.Table.TableChild w39 = ((Gtk.Table.TableChild)(this.table1[this.vbox3]));
            w39.TopAttach = ((uint)(1));
            w39.BottomAttach = ((uint)(2));
            w39.LeftAttach = ((uint)(1));
            w39.RightAttach = ((uint)(2));
            w39.XOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.vbox4 = new Gtk.VBox();
            this.vbox4.Name = "vbox4";
            this.vbox4.Spacing = 6;
            // Container child vbox4.Gtk.Box+BoxChild
            this.label7 = new Gtk.Label();
            this.label7.Name = "label7";
            this.label7.Xalign = 0F;
            this.label7.LabelProp = Mono.Unix.Catalog.GetString("_Translated (msgstr):");
            this.label7.UseUnderline = true;
            this.vbox4.Add(this.label7);
            Gtk.Box.BoxChild w40 = ((Gtk.Box.BoxChild)(this.vbox4[this.label7]));
            w40.Position = 0;
            w40.Expand = false;
            w40.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.notebookTranslated = new Gtk.Notebook();
            this.notebookTranslated.CanFocus = true;
            this.notebookTranslated.Name = "notebookTranslated";
            this.notebookTranslated.CurrentPage = 0;
            // Notebook tab
            Gtk.Label w41 = new Gtk.Label();
            w41.Visible = true;
            this.notebookTranslated.Add(w41);
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("page1");
            this.notebookTranslated.SetTabLabel(w41, this.label1);
            this.label1.ShowAll();
            this.vbox4.Add(this.notebookTranslated);
            Gtk.Box.BoxChild w42 = ((Gtk.Box.BoxChild)(this.vbox4[this.notebookTranslated]));
            w42.Position = 1;
            this.table1.Add(this.vbox4);
            Gtk.Table.TableChild w43 = ((Gtk.Table.TableChild)(this.table1[this.vbox4]));
            w43.TopAttach = ((uint)(1));
            w43.BottomAttach = ((uint)(2));
            w43.XOptions = ((Gtk.AttachOptions)(4));
            w43.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.vbox5 = new Gtk.VBox();
            this.vbox5.Name = "vbox5";
            this.vbox5.Spacing = 6;
            // Container child vbox5.Gtk.Box+BoxChild
            this.label8 = new Gtk.Label();
            this.label8.Name = "label8";
            this.label8.Xalign = 0F;
            this.label8.LabelProp = Mono.Unix.Catalog.GetString("Original (msgid):");
            this.vbox5.Add(this.label8);
            Gtk.Box.BoxChild w44 = ((Gtk.Box.BoxChild)(this.vbox5[this.label8]));
            w44.Position = 0;
            w44.Expand = false;
            w44.Fill = false;
            // Container child vbox5.Gtk.Box+BoxChild
            this.scrolledwindow4 = new Gtk.ScrolledWindow();
            this.scrolledwindow4.CanFocus = true;
            this.scrolledwindow4.Name = "scrolledwindow4";
            this.scrolledwindow4.ShadowType = ((Gtk.ShadowType)(1));
            // Container child scrolledwindow4.Gtk.Container+ContainerChild
            Gtk.Viewport w45 = new Gtk.Viewport();
            w45.ShadowType = ((Gtk.ShadowType)(0));
            // Container child GtkViewport.Gtk.Container+ContainerChild
            this.labelOriginal = new Gtk.Label();
            this.labelOriginal.Name = "labelOriginal";
            this.labelOriginal.Xalign = 0F;
            this.labelOriginal.LabelProp = "";
            this.labelOriginal.Selectable = true;
            w45.Add(this.labelOriginal);
            this.scrolledwindow4.Add(w45);
            this.vbox5.Add(this.scrolledwindow4);
            Gtk.Box.BoxChild w48 = ((Gtk.Box.BoxChild)(this.vbox5[this.scrolledwindow4]));
            w48.Position = 1;
            // Container child vbox5.Gtk.Box+BoxChild
            this.vbox8 = new Gtk.VBox();
            this.vbox8.Name = "vbox8";
            this.vbox8.Spacing = 6;
            // Container child vbox8.Gtk.Box+BoxChild
            this.label9 = new Gtk.Label();
            this.label9.Name = "label9";
            this.label9.Xalign = 0F;
            this.label9.LabelProp = Mono.Unix.Catalog.GetString("Original plural (msgid_plural):");
            this.vbox8.Add(this.label9);
            Gtk.Box.BoxChild w49 = ((Gtk.Box.BoxChild)(this.vbox8[this.label9]));
            w49.Position = 0;
            w49.Expand = false;
            w49.Fill = false;
            // Container child vbox8.Gtk.Box+BoxChild
            this.scrolledwindow5 = new Gtk.ScrolledWindow();
            this.scrolledwindow5.CanFocus = true;
            this.scrolledwindow5.Name = "scrolledwindow5";
            this.scrolledwindow5.ShadowType = ((Gtk.ShadowType)(1));
            // Container child scrolledwindow5.Gtk.Container+ContainerChild
            Gtk.Viewport w50 = new Gtk.Viewport();
            w50.ShadowType = ((Gtk.ShadowType)(0));
            // Container child GtkViewport1.Gtk.Container+ContainerChild
            this.labelPlural = new Gtk.Label();
            this.labelPlural.Name = "labelPlural";
            this.labelPlural.Xalign = 0F;
            this.labelPlural.LabelProp = "";
            this.labelPlural.Selectable = true;
            w50.Add(this.labelPlural);
            this.scrolledwindow5.Add(w50);
            this.vbox8.Add(this.scrolledwindow5);
            Gtk.Box.BoxChild w53 = ((Gtk.Box.BoxChild)(this.vbox8[this.scrolledwindow5]));
            w53.Position = 1;
            this.vbox5.Add(this.vbox8);
            Gtk.Box.BoxChild w54 = ((Gtk.Box.BoxChild)(this.vbox5[this.vbox8]));
            w54.Position = 2;
            this.table1.Add(this.vbox5);
            // Container child table1.Gtk.Table+TableChild
            this.vbox6 = new Gtk.VBox();
            this.vbox6.Name = "vbox6";
            this.vbox6.Spacing = 6;
            // Container child vbox6.Gtk.Box+BoxChild
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.Xalign = 0F;
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("F_ound in:");
            this.label4.UseUnderline = true;
            this.vbox6.Add(this.label4);
            Gtk.Box.BoxChild w56 = ((Gtk.Box.BoxChild)(this.vbox6[this.label4]));
            w56.Position = 0;
            w56.Expand = false;
            w56.Fill = false;
            // Container child vbox6.Gtk.Box+BoxChild
            this.scrolledwindow2 = new Gtk.ScrolledWindow();
            this.scrolledwindow2.CanFocus = true;
            this.scrolledwindow2.Name = "scrolledwindow2";
            this.scrolledwindow2.ShadowType = ((Gtk.ShadowType)(1));
            // Container child scrolledwindow2.Gtk.Container+ContainerChild
            this.treeviewFoundIn = new Gtk.TreeView();
            this.treeviewFoundIn.CanFocus = true;
            this.treeviewFoundIn.Name = "treeviewFoundIn";
            this.treeviewFoundIn.HeadersClickable = true;
            this.scrolledwindow2.Add(this.treeviewFoundIn);
            this.vbox6.Add(this.scrolledwindow2);
            Gtk.Box.BoxChild w58 = ((Gtk.Box.BoxChild)(this.vbox6[this.scrolledwindow2]));
            w58.Position = 1;
            this.table1.Add(this.vbox6);
            Gtk.Table.TableChild w59 = ((Gtk.Table.TableChild)(this.table1[this.vbox6]));
            w59.LeftAttach = ((uint)(1));
            w59.RightAttach = ((uint)(2));
            w59.XOptions = ((Gtk.AttachOptions)(4));
            w59.YOptions = ((Gtk.AttachOptions)(4));
            this.vpaned2.Add(this.table1);
            Gtk.Paned.PanedChild w60 = ((Gtk.Paned.PanedChild)(this.vpaned2[this.table1]));
            w60.Resize = false;
            this.vbox7.Add(this.vpaned2);
            Gtk.Box.BoxChild w61 = ((Gtk.Box.BoxChild)(this.vbox7[this.vpaned2]));
            w61.Position = 1;
            this.notebookPages.Add(this.vbox7);
            // Notebook tab
            this.label5 = new Gtk.Label();
            this.label5.Name = "label5";
            this.label5.LabelProp = Mono.Unix.Catalog.GetString("page1");
            this.notebookPages.SetTabLabel(this.vbox7, this.label5);
            this.label5.ShowAll();
            this.vbox2.Add(this.notebookPages);
            Gtk.Box.BoxChild w63 = ((Gtk.Box.BoxChild)(this.vbox2[this.notebookPages]));
            w63.Position = 0;
            // Container child vbox2.Gtk.Box+BoxChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            w2.AddUiFromString("<ui><toolbar name='toolbarPages'/></ui>");
            this.toolbarPages = ((Gtk.Toolbar)(w2.GetWidget("/toolbarPages")));
            this.toolbarPages.Name = "toolbarPages";
            this.toolbarPages.ShowArrow = false;
            this.toolbarPages.ToolbarStyle = ((Gtk.ToolbarStyle)(0));
            this.hbox1.Add(this.toolbarPages);
            Gtk.Box.BoxChild w64 = ((Gtk.Box.BoxChild)(this.hbox1[this.toolbarPages]));
            w64.Position = 0;
            // Container child hbox1.Gtk.Box+BoxChild
            this.progressbar1 = new Gtk.ProgressBar();
            this.progressbar1.Name = "progressbar1";
            this.hbox1.Add(this.progressbar1);
            Gtk.Box.BoxChild w65 = ((Gtk.Box.BoxChild)(this.hbox1[this.progressbar1]));
            w65.Position = 1;
            this.vbox2.Add(this.hbox1);
            Gtk.Box.BoxChild w66 = ((Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
            w66.Position = 1;
            w66.Expand = false;
            w66.Fill = false;
            this.Add(this.vbox2);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            w1.SetUiManager(w2);
            this.label6.MnemonicWidget = this.textviewComments;
            this.label7.MnemonicWidget = this.notebookTranslated;
            this.label4.MnemonicWidget = this.treeviewFoundIn;
            this.Show();
        }
    }
}
