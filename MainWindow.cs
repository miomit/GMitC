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

        private double NumberA;
        private double? NumberB;

        private bool isAC;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);
            DeleteEvent += Window_DeleteEvent;

            Cal = new();

            NumberA = 0;
            NumberB = null;

            isAC = false;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a) => Application.Quit();

        public void OnNumClick (object sender, EventArgs e)
        {
            mainLabel.Text = StrFormat.AddEnd(
                ref NumberA,
                ((Button)sender).Label
            );

            isAC = false;
        }

        public void OnBackspace (object sender, EventArgs e)
        {
            mainLabel.Text = StrFormat.RemoveEnd(
                ref NumberA
            );
        }
        
        public void OnAC (object sender, EventArgs e)
        {
            if (isAC) 
            {
                Cal.DelOperation();
                NumberB = null;
            }
            else
            {
                isAC = true;
            }

            mainLabel.Text = "0";
            NumberA = 0;
        }

        public void OnAction (object sender, EventArgs e)
        {
            if (NumberB is not null && Cal.IsOperation()) NumberB = Cal.CalRes(NumberB ?? 0, NumberA); 
            else NumberB = NumberA;

            NumberA = 0;
            mainLabel.Text = NumberB.ToString();

            isAC = false;
        }
        
        public void OnAdd (object sender, EventArgs e) => Cal.SetOperation(new Add());

        public void OnSub (object sender, EventArgs e) => Cal.SetOperation(new Sub());

        public void OnMul (object sender, EventArgs e) => Cal.SetOperation(new Mul());

        public void OnDiv (object sender, EventArgs e) => Cal.SetOperation(new Div());
    }
}