using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Aplikacja_Wpf.Commands;

namespace Aplikacja_Wpf.ModelViews
{
    public class MainWindowModelView : INotifyPropertyChanged
    {
        public MainWindowModelView()
        {
            NWDCommand = new RelayCommand(NWD);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string arg1;
        public string Arg1
        {
            get { return arg1; }
            set
            {
                arg1 = value;
                OnPropertyChanged(nameof(Arg1));
            }
        }

        private string arg2;
        public string Arg2
        {
            get { return arg2; }
            set
            {
                arg2 = value;
                OnPropertyChanged(nameof(Arg2));
            }
        }
        private string output;

        public string Output
        {
            get { return output; }
            set
            {
                output = value;
                OnPropertyChanged(nameof(output));
            }
        }
        public ICommand NWDCommand { get; set; }
        public void NWD(Object obj)
        {
            try
            {
                double x = Convert.ToDouble(Arg1);
                double y = Convert.ToDouble(Arg2);

                while(x != y) 
                {
                    if(x > y)
                        x -= y;
                    else
                        y -= x;
                }

                output = x.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
