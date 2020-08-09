using ClaroNet3.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ClaroNet3.Model
{
    public class ItemMenuModel
    {
        public string Title { get; set; }
        public string Icon { get; set; }

        public RelayCommand NavigateCommand => new RelayCommand(Navegar);

       public void Navegar()
       {
            try
            {
                if (Title.Equals("Login"))
                {

                    Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                }
            }
            catch (Exception e)
            {

                Application.Current.MainPage.DisplayAlert(e.Message, "AVISO", "volver");
            }
       }
    }
}

