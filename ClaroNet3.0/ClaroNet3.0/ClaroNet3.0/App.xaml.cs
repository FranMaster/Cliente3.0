using ClaroNet3.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClaroNet3._0
{
    public partial class App : Application
    {
        public NavigationPage Navigation { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MasterPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
