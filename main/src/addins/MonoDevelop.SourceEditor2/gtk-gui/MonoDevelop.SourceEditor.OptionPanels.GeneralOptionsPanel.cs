// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace MonoDevelop.SourceEditor.OptionPanels {
    
    
    internal partial class GeneralOptionsPanel {
        
        private Gtk.VBox vbox1;
        
        private Gtk.Label GtkLabel13;
        
        private Gtk.Alignment alignment2;
        
        private Gtk.VBox vbox4;
        
        private Gtk.CheckButton codeCompletioncheckbutton;
        
        private Gtk.HBox hbox2;
        
        private Gtk.Fixed fixed1;
        
        private Gtk.CheckButton autoCodeCompletionCheckbutton;
        
        private Gtk.HBox hbox3;
        
        private Gtk.Fixed fixed2;
        
        private Gtk.CheckButton spaceOrPunctiuationCheckbutton;
        
        private Gtk.CheckButton quickFinderCheckbutton;
        
        private Gtk.Label GtkLabel14;
        
        private Gtk.Alignment alignment3;
        
        private Gtk.VBox vbox5;
        
        private Gtk.CheckButton foldingCheckbutton;
        
        private Gtk.CheckButton foldregionsCheckbutton;
        
        private Gtk.CheckButton foldCommentsCheckbutton;
        
        private Gtk.Label GtkLabel15;
        
        private Gtk.Alignment GtkAlignment1;
        
        private Gtk.VBox vbox3;
        
        private Gtk.RadioButton radiobutton1;
        
        private Gtk.HBox hbox1;
        
        private Gtk.RadioButton radiobutton2;
        
        private Gtk.FontButton fontselection;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoDevelop.SourceEditor.OptionPanels.GeneralOptionsPanel
            Stetic.BinContainer.Attach(this);
            this.Name = "MonoDevelop.SourceEditor.OptionPanels.GeneralOptionsPanel";
            // Container child MonoDevelop.SourceEditor.OptionPanels.GeneralOptionsPanel.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.GtkLabel13 = new Gtk.Label();
            this.GtkLabel13.Name = "GtkLabel13";
            this.GtkLabel13.Xalign = 0F;
            this.GtkLabel13.LabelProp = Mono.Unix.Catalog.GetString("<b>Coding</b>");
            this.GtkLabel13.UseMarkup = true;
            this.vbox1.Add(this.GtkLabel13);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox1[this.GtkLabel13]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.alignment2 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment2.Name = "alignment2";
            this.alignment2.LeftPadding = ((uint)(12));
            // Container child alignment2.Gtk.Container+ContainerChild
            this.vbox4 = new Gtk.VBox();
            this.vbox4.Name = "vbox4";
            this.vbox4.Spacing = 6;
            // Container child vbox4.Gtk.Box+BoxChild
            this.codeCompletioncheckbutton = new Gtk.CheckButton();
            this.codeCompletioncheckbutton.CanFocus = true;
            this.codeCompletioncheckbutton.Name = "codeCompletioncheckbutton";
            this.codeCompletioncheckbutton.Label = Mono.Unix.Catalog.GetString("Enable _code completion");
            this.codeCompletioncheckbutton.DrawIndicator = true;
            this.codeCompletioncheckbutton.UseUnderline = true;
            this.vbox4.Add(this.codeCompletioncheckbutton);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox4[this.codeCompletioncheckbutton]));
            w2.Position = 0;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 6;
            // Container child hbox2.Gtk.Box+BoxChild
            this.fixed1 = new Gtk.Fixed();
            this.fixed1.Name = "fixed1";
            this.fixed1.HasWindow = false;
            this.hbox2.Add(this.fixed1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox2[this.fixed1]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Padding = ((uint)(6));
            // Container child hbox2.Gtk.Box+BoxChild
            this.autoCodeCompletionCheckbutton = new Gtk.CheckButton();
            this.autoCodeCompletionCheckbutton.CanFocus = true;
            this.autoCodeCompletionCheckbutton.Name = "autoCodeCompletionCheckbutton";
            this.autoCodeCompletionCheckbutton.Label = Mono.Unix.Catalog.GetString("_Aggressively trigger code completion list");
            this.autoCodeCompletionCheckbutton.DrawIndicator = true;
            this.autoCodeCompletionCheckbutton.UseUnderline = true;
            this.hbox2.Add(this.autoCodeCompletionCheckbutton);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.hbox2[this.autoCodeCompletionCheckbutton]));
            w4.Position = 1;
            this.vbox4.Add(this.hbox2);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox4[this.hbox2]));
            w5.Position = 1;
            w5.Expand = false;
            w5.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.hbox3 = new Gtk.HBox();
            this.hbox3.Name = "hbox3";
            this.hbox3.Spacing = 6;
            // Container child hbox3.Gtk.Box+BoxChild
            this.fixed2 = new Gtk.Fixed();
            this.fixed2.Name = "fixed2";
            this.fixed2.HasWindow = false;
            this.hbox3.Add(this.fixed2);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.hbox3[this.fixed2]));
            w6.Position = 0;
            w6.Expand = false;
            w6.Padding = ((uint)(6));
            // Container child hbox3.Gtk.Box+BoxChild
            this.spaceOrPunctiuationCheckbutton = new Gtk.CheckButton();
            this.spaceOrPunctiuationCheckbutton.CanFocus = true;
            this.spaceOrPunctiuationCheckbutton.Name = "spaceOrPunctiuationCheckbutton";
            this.spaceOrPunctiuationCheckbutton.Label = Mono.Unix.Catalog.GetString("_Commit completion list selection with space or punctuation.");
            this.spaceOrPunctiuationCheckbutton.DrawIndicator = true;
            this.spaceOrPunctiuationCheckbutton.UseUnderline = true;
            this.hbox3.Add(this.spaceOrPunctiuationCheckbutton);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.hbox3[this.spaceOrPunctiuationCheckbutton]));
            w7.Position = 1;
            this.vbox4.Add(this.hbox3);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox4[this.hbox3]));
            w8.Position = 2;
            w8.Expand = false;
            w8.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.quickFinderCheckbutton = new Gtk.CheckButton();
            this.quickFinderCheckbutton.CanFocus = true;
            this.quickFinderCheckbutton.Name = "quickFinderCheckbutton";
            this.quickFinderCheckbutton.Label = Mono.Unix.Catalog.GetString("Show c_lass and method navigation bar");
            this.quickFinderCheckbutton.DrawIndicator = true;
            this.quickFinderCheckbutton.UseUnderline = true;
            this.vbox4.Add(this.quickFinderCheckbutton);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.vbox4[this.quickFinderCheckbutton]));
            w9.Position = 3;
            w9.Expand = false;
            w9.Fill = false;
            this.alignment2.Add(this.vbox4);
            this.vbox1.Add(this.alignment2);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment2]));
            w11.Position = 1;
            w11.Expand = false;
            w11.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.GtkLabel14 = new Gtk.Label();
            this.GtkLabel14.Name = "GtkLabel14";
            this.GtkLabel14.Xalign = 0F;
            this.GtkLabel14.LabelProp = Mono.Unix.Catalog.GetString("<b>Code Folding</b>");
            this.GtkLabel14.UseMarkup = true;
            this.vbox1.Add(this.GtkLabel14);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.vbox1[this.GtkLabel14]));
            w12.Position = 2;
            w12.Expand = false;
            w12.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment3.Name = "alignment3";
            this.alignment3.LeftPadding = ((uint)(12));
            // Container child alignment3.Gtk.Container+ContainerChild
            this.vbox5 = new Gtk.VBox();
            this.vbox5.Name = "vbox5";
            this.vbox5.Spacing = 6;
            // Container child vbox5.Gtk.Box+BoxChild
            this.foldingCheckbutton = new Gtk.CheckButton();
            this.foldingCheckbutton.CanFocus = true;
            this.foldingCheckbutton.Name = "foldingCheckbutton";
            this.foldingCheckbutton.Label = Mono.Unix.Catalog.GetString("Enable code _folding");
            this.foldingCheckbutton.DrawIndicator = true;
            this.foldingCheckbutton.UseUnderline = true;
            this.vbox5.Add(this.foldingCheckbutton);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox5[this.foldingCheckbutton]));
            w13.Position = 0;
            w13.Expand = false;
            w13.Fill = false;
            // Container child vbox5.Gtk.Box+BoxChild
            this.foldregionsCheckbutton = new Gtk.CheckButton();
            this.foldregionsCheckbutton.CanFocus = true;
            this.foldregionsCheckbutton.Name = "foldregionsCheckbutton";
            this.foldregionsCheckbutton.Label = Mono.Unix.Catalog.GetString("Fold #_regions by default");
            this.foldregionsCheckbutton.DrawIndicator = true;
            this.foldregionsCheckbutton.UseUnderline = true;
            this.vbox5.Add(this.foldregionsCheckbutton);
            Gtk.Box.BoxChild w14 = ((Gtk.Box.BoxChild)(this.vbox5[this.foldregionsCheckbutton]));
            w14.Position = 1;
            w14.Expand = false;
            w14.Fill = false;
            // Container child vbox5.Gtk.Box+BoxChild
            this.foldCommentsCheckbutton = new Gtk.CheckButton();
            this.foldCommentsCheckbutton.CanFocus = true;
            this.foldCommentsCheckbutton.Name = "foldCommentsCheckbutton";
            this.foldCommentsCheckbutton.Label = Mono.Unix.Catalog.GetString("Fold _comments by default");
            this.foldCommentsCheckbutton.DrawIndicator = true;
            this.foldCommentsCheckbutton.UseUnderline = true;
            this.vbox5.Add(this.foldCommentsCheckbutton);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.vbox5[this.foldCommentsCheckbutton]));
            w15.Position = 2;
            w15.Expand = false;
            w15.Fill = false;
            this.alignment3.Add(this.vbox5);
            this.vbox1.Add(this.alignment3);
            Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment3]));
            w17.Position = 3;
            w17.Expand = false;
            w17.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.GtkLabel15 = new Gtk.Label();
            this.GtkLabel15.Name = "GtkLabel15";
            this.GtkLabel15.Xalign = 0F;
            this.GtkLabel15.LabelProp = Mono.Unix.Catalog.GetString("<b>Font</b>");
            this.GtkLabel15.UseMarkup = true;
            this.vbox1.Add(this.GtkLabel15);
            Gtk.Box.BoxChild w18 = ((Gtk.Box.BoxChild)(this.vbox1[this.GtkLabel15]));
            w18.Position = 4;
            w18.Expand = false;
            w18.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.GtkAlignment1 = new Gtk.Alignment(0F, 0F, 1F, 1F);
            this.GtkAlignment1.Name = "GtkAlignment1";
            this.GtkAlignment1.LeftPadding = ((uint)(12));
            // Container child GtkAlignment1.Gtk.Container+ContainerChild
            this.vbox3 = new Gtk.VBox();
            this.vbox3.Name = "vbox3";
            this.vbox3.Spacing = 6;
            // Container child vbox3.Gtk.Box+BoxChild
            this.radiobutton1 = new Gtk.RadioButton(Mono.Unix.Catalog.GetString("_Default monospace"));
            this.radiobutton1.CanFocus = true;
            this.radiobutton1.Name = "radiobutton1";
            this.radiobutton1.DrawIndicator = true;
            this.radiobutton1.UseUnderline = true;
            this.radiobutton1.Group = new GLib.SList(System.IntPtr.Zero);
            this.vbox3.Add(this.radiobutton1);
            Gtk.Box.BoxChild w19 = ((Gtk.Box.BoxChild)(this.vbox3[this.radiobutton1]));
            w19.Position = 0;
            w19.Expand = false;
            w19.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 12;
            // Container child hbox1.Gtk.Box+BoxChild
            this.radiobutton2 = new Gtk.RadioButton(Mono.Unix.Catalog.GetString("_Custom"));
            this.radiobutton2.CanFocus = true;
            this.radiobutton2.Name = "radiobutton2";
            this.radiobutton2.DrawIndicator = true;
            this.radiobutton2.UseUnderline = true;
            this.radiobutton2.Group = this.radiobutton1.Group;
            this.hbox1.Add(this.radiobutton2);
            Gtk.Box.BoxChild w20 = ((Gtk.Box.BoxChild)(this.hbox1[this.radiobutton2]));
            w20.Position = 0;
            w20.Expand = false;
            w20.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.fontselection = new Gtk.FontButton();
            this.fontselection.CanFocus = true;
            this.fontselection.Name = "fontselection";
            this.hbox1.Add(this.fontselection);
            Gtk.Box.BoxChild w21 = ((Gtk.Box.BoxChild)(this.hbox1[this.fontselection]));
            w21.Position = 1;
            this.vbox3.Add(this.hbox1);
            Gtk.Box.BoxChild w22 = ((Gtk.Box.BoxChild)(this.vbox3[this.hbox1]));
            w22.Position = 1;
            w22.Expand = false;
            w22.Fill = false;
            this.GtkAlignment1.Add(this.vbox3);
            this.vbox1.Add(this.GtkAlignment1);
            Gtk.Box.BoxChild w24 = ((Gtk.Box.BoxChild)(this.vbox1[this.GtkAlignment1]));
            w24.Position = 5;
            w24.Expand = false;
            w24.Fill = false;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
        }
    }
}
