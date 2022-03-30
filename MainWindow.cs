using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace GMitC
{
    class MainWindow : Window
    {

        [UI]
        private Label mainLabel;

        private Calculator Cal;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) 
        : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);
            Cal = new();
            mainLabel.Text = Cal.GetNum();
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        public void OnNumClick (object sender, EventArgs e)
        {
            mainLabel.Text = Cal.AddNum(((Button)sender).Label);
        }
    }
}