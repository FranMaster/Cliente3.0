using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ClaroNet3.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string Prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Prop));
        }
    }
}
