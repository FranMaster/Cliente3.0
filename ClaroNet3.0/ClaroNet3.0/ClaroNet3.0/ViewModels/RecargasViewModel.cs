using ClaroNet3.Interfaces;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClaroNet3.ViewModels
{
    public class RecargasViewModel:BaseViewModel
    {
        #region Attributes
        private bool _componentesVisibles;
        private string _Telefono;
        private string _Monto;
        private string _Pin;
        private string _dni; 
        #endregion

        #region Properties
        public bool ComponentesVisibles
        {
            get { return _componentesVisibles; }
            set { _componentesVisibles = value; OnPropertyChanged(nameof(ComponentesVisibles)); }
        }

        public string Monto
        {
            get { return _Monto; }
            set { _Monto = value; OnPropertyChanged(nameof(Monto)); }
        }

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; OnPropertyChanged(nameof(Telefono)); }
        }
        public string Pin
        {
            get { return _Pin; }
            set { _Pin = value; OnPropertyChanged(nameof(Pin)); }
        }
        public string Dni
        {
            get { return _dni; }
            set { _dni = value; OnPropertyChanged(nameof(Dni)); }
        }
        #endregion

        #region Commands
          public RelayCommand BtnRecarga => new RelayCommand(Recargar);
        #endregion  

        #region Methods

        public async void Recargar()
        {
            try
            {
                if (string.IsNullOrEmpty(Telefono)
                    || (string.IsNullOrEmpty(Monto))
                    || (string.IsNullOrEmpty(Pin))
                    || (string.IsNullOrEmpty(Dni)))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", $"LLene todos los campos", "Accept");
                    return;
                }

                DependencyService.Get<IServiceCaller>()
                        .RealizarLLamadaRecarga(Telefono, Monto, Pin);


            }
            catch (Exception ed)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"{ed.Message}.", "Accept");

            }
        }

        #endregion

        public RecargasViewModel()
        {
            DependencyService.Get<IServiceSms>().Mensajes += RecargasViewModel_Mensajes;
        }

        private void RecargasViewModel_Mensajes(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
