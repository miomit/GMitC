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
            DeleteEvent += Window_DeleteEvent;
            Cal = new();
            UpdateText();
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void UpdateText() {
            mainLabel.Text = Cal.GetNum();
        }

        public void OnNumClick (object sender, EventArgs e)
        {
            Cal.AddNum(((Button)sender).Label);
            UpdateText();
        }

        public void OnBackspace (object sender, EventArgs e)
        {
            Cal.Backspace();
            UpdateText();
        }
        
        public void OnAC (object sender, EventArgs e)
        {
            Cal.Clean();
            UpdateText();
        }
    }
}