using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRegistro
    {
        public void Gestion(string nombre, string correo, string carrera, string password);
    } 
}
