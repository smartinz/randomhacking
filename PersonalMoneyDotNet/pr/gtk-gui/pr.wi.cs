// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace pr {
    
    
    public partial class wi {
        
        private Gtk.HBox hbox1;
        
        private Gtk.Calendar calendar1;
        
        private Gtk.Button button1;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget pr.wi
            Stetic.BinContainer.Attach(this);
            this.Name = "pr.wi";
            // Container child pr.wi.Gtk.Container+ContainerChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.calendar1 = new Gtk.Calendar();
            this.calendar1.CanFocus = true;
            this.calendar1.Name = "calendar1";
            this.calendar1.DisplayOptions = ((Gtk.CalendarDisplayOptions)(35));
            this.hbox1.Add(this.calendar1);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.hbox1[this.calendar1]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.button1 = new Gtk.Button();
            this.button1.CanFocus = true;
            this.button1.Name = "button1";
            this.button1.UseUnderline = true;
            this.button1.Label = Mono.Unix.Catalog.GetString("button1");
            this.hbox1.Add(this.button1);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.hbox1[this.button1]));
            w2.Position = 1;
            w2.Expand = false;
            w2.Fill = false;
            this.Add(this.hbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Hide();
        }
    }
}
