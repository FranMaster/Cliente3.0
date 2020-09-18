using ClaroNet3.Interfaces;
using ClaroNet3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static ClaroNet3.Model.EventsUtilities;

namespace ClaroNet3.ViewModels
{
    public class MainVewModel
    {
        #region Properties
        public LoginViewModel Login { get; set; }
        public RecargasViewModel Recargas { get; set; }
        public ObservableCollection<ItemMenuModel> Menu { get; set; }
        #endregion

        #region Constructor
        private  MainVewModel()
        {
            Login = new LoginViewModel();
            LoadMenu();
            this.Subscribe<List<string>>(Events.SmsRecieved, NuevoMensaje =>
            {
                Notificacion(NuevoMensaje);
            });
        }

        private void Notificacion(List<string> Inbox)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Singleton
        private static MainVewModel instance;

        public static MainVewModel GetInstance
        {
            get
            {

                if (instance == null)
                    instance = new MainVewModel();
                return instance;
            }

        } 
        #endregion


        public void LoadMenu()
        {
            Menu = new ObservableCollection<ItemMenuModel>
            {
                new ItemMenuModel{Icon="logIn",Title="Login"},
                new ItemMenuModel{Icon="moneda",Title="Consultar Saldo"},
                new ItemMenuModel{Icon="listado",Title="listar"}
            };
        }


        public async Task ConsultaSaldo()
        {                                
            await Task.Run(() =>
            DependencyService.Get<IServiceCaller>()
                       .RealizarLLamadaSaldo("2232"));
        }



        public   List<string> ListarDatos()
        {            
            var Respuesta=  DependencyService.Get<IServiceSms>()
                     .GetAllSms();
            return Respuesta;
               
        }


        private void MainVewModel_Mensajes(object sender, EventArgs e)
        {
            Application.Current.MainPage
                .DisplayAlert("Aviso de mensaje recibido", "e", "volver");
        }
    }
}
