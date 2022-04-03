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

        private double NumberA, NumberB;
        public double Num
        {
            get => NumberA;  
            set
            {
                NumberA = value;
                mainLabel.Text = StrFormat.GetNum(
                    NumberA.ToString()
                );
            }
        }

        private bool Opr = false;
        private bool OprStart 
        {
            get => Opr;
            set
            {
                if (!Opr)
                {
                    NumberB = Num;
                    Num = 0;
                }

                Opr = value;
            }
        }

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) 
        : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);
            DeleteEvent += Window_DeleteEvent;
            Cal = new();
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        public void OnNumClick (object sender, EventArgs e)
        {
            Num = StrFormat.AddEnd(
                Num,
                ((Button)sender).Label
            );
        }

        public void OnBackspace (object sender, EventArgs e)
        {
            if (OprStart) OprStart = false;

            Num = StrFormat.RemoveEnd(
                Num.ToString()
            );
        }
        
        public void OnAC (object sender, EventArgs e)
        {
            Num = 0;
        }

        public void OnCal (object sender, EventArgs e) 
        {
            if (OprStart) OprStart = false;
            Num = Cal.CalRes(NumberB, NumberA);
        }

        public void OnAdd (object sender, EventArgs e) 
        {
            OprStart = true;
            Cal.SetOperation(new Add());
        }

        public void OnSub (object sender, EventArgs e) 
        {
            OprStart = true;
            Cal.SetOperation(new Sub());
        }

        public void OnMul (object sender, EventArgs e) 
        {
            OprStart = true;
            Cal.SetOperation(new Mul());
        }

        public void OnDiv (object sender, EventArgs e) 
        {
            OprStart = true;
            Cal.SetOperation(new Div());
        }
    }
}