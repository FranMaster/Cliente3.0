using ClaroNet3.Views;
using GalaSoft.MvvmLight.Command;
using System;
using Xamarin.Forms;

namespace ClaroNet3.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string _Email;
        private string _Password;
        #endregion
        #region Properties

        public string Email
        {
            get { return _Email; }
            set { _Email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; OnPropertyChanged(nameof(Password)); }
        }
        #endregion

        #region Commands
        public RelayCommand BtnLogIn => new RelayCommand(logIn);
        public RelayCommand BtnLogInNoConect => new RelayCommand(TrabajarSinConexion); 
        #endregion
        private void logIn()
        {
            throw new NotImplementedException();
        }

        private void TrabajarSinConexion()
        {
            MainVewModel.GetInstance.Recargas = new RecargasViewModel();
            MainVewModel.GetInstance.Recargas.ComponentesVisibles = true;

            Application.Current.MainPage = new NavigationPage(new MasterPage());
        }

        public LoginViewModel()
        {

        }
    }
}
