using ClaroNet3.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClaroNet3.Insfrastructure
{
    public class InstanceLocator
    {
        public MainVewModel Main { get; set; }

        public InstanceLocator()
        {
            Main = MainVewModel.GetInstance;
        }
    }
}
