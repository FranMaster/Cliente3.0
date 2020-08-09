using ClaroNet3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
                new ItemMenuModel{Icon="userImg",Title="Login"}
            };
        }
    }
}
