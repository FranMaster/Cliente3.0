using System;
using System.Collections.Generic;
using System.Text;

namespace ClaroNet3.Interfaces
{
    public interface IServiceCaller
    {
        void RealizarLLamadaRecarga(string phone, string monto, string pin);
        void RealizarLLamadaSaldo(string pin);
    }
}
