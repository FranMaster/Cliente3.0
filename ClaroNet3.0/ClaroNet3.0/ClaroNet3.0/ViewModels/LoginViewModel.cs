using System;
using System.Collections.Generic;
using System.Text;

namespace ClaroNet3.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        private string _saludo;

        public string Saludo
        {
            get { return _saludo; }
            set { _saludo = value; OnPropertyChanged(nameof(Saludo)); }
        }

        public LoginViewModel()
        {
            Saludo = "Hola Enoc";
        }
    }
}
