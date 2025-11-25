using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    internal interface IMetodo
    {
        void Monto(string correo, string password, decimal monto);
    }
}
