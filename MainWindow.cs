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

        private bool IsAC, IsCal, IsDot;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);
            DeleteEvent += Window_DeleteEvent;

            Cal = new();

            NumberA = 0;
            NumberB = null;

            IsAC = false;
            IsCal = false;
            IsDot = false;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a) => Application.Quit();

        public void OnNumClick (object sender, EventArgs e)
        {
            if (IsCal){
                NumberB = NumberA;
                NumberA = 0;
            }

            if (NumberA.ToString().Contains(","))
                IsDot = true;

            mainLabel.Text = StrFormat.AddEnd(
                ref NumberA,
                ((Button)sender).Label,
                IsDot
            );

            IsAC = false;
            IsCal = false;
        }

        public void OnBackspace (object sender, EventArgs e)
        {
            mainLabel.Text = StrFormat.RemoveEnd(
                ref NumberA
            );

            if (!NumberA.ToString().Contains(","))
                IsDot = false;
        }
        
        public void OnAC (object sender, EventArgs e)
        {
            if (IsAC) 
            {
                Cal.DelOperation();
                NumberB = null;
            }
            else
            {
                IsAC = true;
            }

            mainLabel.Text = "0";
            NumberA = 0;

            IsDot = false;
        }
        public void OnAction (object sender, EventArgs e)
        {
            if (NumberB is not null && Cal.IsOperation()) NumberB = Cal.CalRes(NumberB ?? 0, NumberA); 
            else NumberB = NumberA;

            NumberA = 0;
            mainLabel.Text = NumberB.ToString();

            IsAC = false;
            IsCal = false;
            IsDot = false;
        }
        
        public void OnCal (object sender, EventArgs e)
        {
            NumberA = NumberB ?? 0;
            NumberB = null;

            Cal.DelOperation();

            IsCal = true;
        }

        public void OnDot (object sender, EventArgs e)
        { 
            if (!IsDot)
            {
                mainLabel.Text += ",";
                IsDot = true;
            }
        }

        public void OnAdd (object sender, EventArgs e) => Cal.SetOperation(new Add());

        public void OnSub (object sender, EventArgs e) => Cal.SetOperation(new Sub());

        public void OnMul (object sender, EventArgs e) => Cal.SetOperation(new Mul());

        public void OnDiv (object sender, EventArgs e) => Cal.SetOperation(new Div());
    }
}