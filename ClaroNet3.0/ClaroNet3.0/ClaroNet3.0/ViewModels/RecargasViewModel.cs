using System;
using System.Collections.Generic;
using System.Text;

namespace ClaroNet3.ViewModels
{
    public class RecargasViewModel:BaseViewModel
    {
        private bool _componentesVisibles=false;

        public bool ComponentesVisibles
        {
            get { return _componentesVisibles; }
            set { _componentesVisibles = value; OnPropertyChanged(nameof(ComponentesVisibles)); }
        }

    }
}
