// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace MonoDevelop.Ide {
    
    
    public partial class DocumentSwitcher {
        
        private Gtk.VBox vbox1;
        
        private Gtk.HBox hbox2;
        
        private Gtk.Image imageType;
        
        private Gtk.VBox vbox4;
        
        private Gtk.Label labelTitel;
        
        private Gtk.Label labelType;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Table table1;
        
        private Gtk.VBox vbox2;
        
        private Gtk.Alignment alignment1;
        
        private Gtk.Label label8;
        
        private Gtk.ScrolledWindow scrolledwindow1;
        
        private Gtk.VBox vbox3;
        
        private Gtk.Label label10;
        
        private Gtk.ScrolledWindow scrolledwindow2;
        
        private Gtk.Image imagePreview;
        
        private Gtk.Label labelFileName;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoDevelop.Ide.DocumentSwitcher
            this.Name = "MonoDevelop.Ide.DocumentSwitcher";
            this.Title = "";
            this.TypeHint = ((Gdk.WindowTypeHint)(4));
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.BorderWidth = ((uint)(6));
            // Container child MonoDevelop.Ide.DocumentSwitcher.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 6;
            // Container child hbox2.Gtk.Box+BoxChild
            this.imageType = new Gtk.Image();
            this.imageType.Name = "imageType";
            this.hbox2.Add(this.imageType);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.hbox2[this.imageType]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.vbox4 = new Gtk.VBox();
            this.vbox4.Name = "vbox4";
            this.vbox4.Spacing = 6;
            // Container child vbox4.Gtk.Box+BoxChild
            this.labelTitel = new Gtk.Label();
            this.labelTitel.Name = "labelTitel";
            this.labelTitel.LabelProp = "";
            this.vbox4.Add(this.labelTitel);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox4[this.labelTitel]));
            w2.Position = 0;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.labelType = new Gtk.Label();
            this.labelType.Name = "labelType";
            this.labelType.Xalign = 0F;
            this.labelType.LabelProp = "";
            this.vbox4.Add(this.labelType);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox4[this.labelType]));
            w3.Position = 1;
            w3.Expand = false;
            w3.Fill = false;
            this.hbox2.Add(this.vbox4);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.hbox2[this.vbox4]));
            w4.Position = 1;
            this.vbox1.Add(this.hbox2);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
            w5.Position = 0;
            w5.Expand = false;
            w5.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.table1 = new Gtk.Table(((uint)(1)), ((uint)(2)), true);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            // Container child table1.Gtk.Table+TableChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            // Container child alignment1.Gtk.Container+ContainerChild
            this.label8 = new Gtk.Label();
            this.label8.Name = "label8";
            this.label8.Xalign = 0F;
            this.label8.LabelProp = Mono.Unix.Catalog.GetString("Pads");
            this.alignment1.Add(this.label8);
            this.vbox2.Add(this.alignment1);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment1]));
            w7.Position = 0;
            w7.Expand = false;
            w7.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.scrolledwindow1 = new Gtk.ScrolledWindow();
            this.scrolledwindow1.CanFocus = true;
            this.scrolledwindow1.Name = "scrolledwindow1";
            this.scrolledwindow1.VscrollbarPolicy = ((Gtk.PolicyType)(2));
            this.scrolledwindow1.HscrollbarPolicy = ((Gtk.PolicyType)(2));
            this.scrolledwindow1.ShadowType = ((Gtk.ShadowType)(1));
            this.vbox2.Add(this.scrolledwindow1);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox2[this.scrolledwindow1]));
            w8.Position = 1;
            this.table1.Add(this.vbox2);
            Gtk.Table.TableChild w9 = ((Gtk.Table.TableChild)(this.table1[this.vbox2]));
            w9.XOptions = ((Gtk.AttachOptions)(4));
            w9.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.vbox3 = new Gtk.VBox();
            this.vbox3.Name = "vbox3";
            this.vbox3.Spacing = 6;
            // Container child vbox3.Gtk.Box+BoxChild
            this.label10 = new Gtk.Label();
            this.label10.Name = "label10";
            this.label10.Xalign = 0F;
            this.label10.LabelProp = Mono.Unix.Catalog.GetString("Documents");
            this.vbox3.Add(this.label10);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox3[this.label10]));
            w10.Position = 0;
            w10.Expand = false;
            w10.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.scrolledwindow2 = new Gtk.ScrolledWindow();
            this.scrolledwindow2.CanFocus = true;
            this.scrolledwindow2.Name = "scrolledwindow2";
            this.scrolledwindow2.VscrollbarPolicy = ((Gtk.PolicyType)(2));
            this.scrolledwindow2.HscrollbarPolicy = ((Gtk.PolicyType)(2));
            this.scrolledwindow2.ShadowType = ((Gtk.ShadowType)(1));
            this.vbox3.Add(this.scrolledwindow2);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.vbox3[this.scrolledwindow2]));
            w11.Position = 1;
            this.table1.Add(this.vbox3);
            Gtk.Table.TableChild w12 = ((Gtk.Table.TableChild)(this.table1[this.vbox3]));
            w12.LeftAttach = ((uint)(1));
            w12.RightAttach = ((uint)(2));
            this.hbox1.Add(this.table1);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.hbox1[this.table1]));
            w13.Position = 0;
            // Container child hbox1.Gtk.Box+BoxChild
            this.imagePreview = new Gtk.Image();
            this.imagePreview.Name = "imagePreview";
            this.hbox1.Add(this.imagePreview);
            Gtk.Box.BoxChild w14 = ((Gtk.Box.BoxChild)(this.hbox1[this.imagePreview]));
            w14.PackType = ((Gtk.PackType)(1));
            w14.Position = 1;
            w14.Expand = false;
            w14.Fill = false;
            this.vbox1.Add(this.hbox1);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
            w15.Position = 1;
            // Container child vbox1.Gtk.Box+BoxChild
            this.labelFileName = new Gtk.Label();
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.LabelProp = "";
            this.vbox1.Add(this.labelFileName);
            Gtk.Box.BoxChild w16 = ((Gtk.Box.BoxChild)(this.vbox1[this.labelFileName]));
            w16.PackType = ((Gtk.PackType)(1));
            w16.Position = 2;
            w16.Expand = false;
            w16.Fill = false;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 400;
            this.DefaultHeight = 300;
            this.Show();
        }
    }
}
