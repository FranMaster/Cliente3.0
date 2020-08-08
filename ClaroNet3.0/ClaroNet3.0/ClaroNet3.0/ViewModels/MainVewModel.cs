using System;
using System.Collections.Generic;
using System.Text;

namespace ClaroNet3.ViewModels
{
    public class MainVewModel
    {
        #region Properties
        public LoginViewModel Login { get; set; } 
        #endregion

        #region Constructor
        public MainVewModel()
        {
            Login = new LoginViewModel();
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

    }
}
