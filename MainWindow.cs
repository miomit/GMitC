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
            Num = Cal.CalRes(NumberA, NumberB);
        }

        public void OnAdd (object sender, EventArgs e) 
        {
            NumberB = Num;
            Num = 10;
            Cal.SetOperation(new Add());
        }
    }
}