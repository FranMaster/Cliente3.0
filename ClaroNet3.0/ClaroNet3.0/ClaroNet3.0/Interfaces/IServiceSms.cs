using System;
using System.Collections.Generic;
using System.Text;

namespace ClaroNet3.Interfaces
{
    public interface IServiceSms
    {
        event EventHandler Mensajes;
        List<string> GetAllSms();
    }
}
