using Application.Interfaces;
using Infraestructure.Context;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Registro : IRegistro
    {
       private SqlCommand sqlhacer;
        public void Gestion(string nombre, string correo, string carrera, string password)
        {
            try
            {
                Console.Clear();
                //Traer la conexion con la base de datos
                BD BaseDatos = BD.GetBD();

                //IF
                //String con el comando para insertar los datos
                string insert = "INSERT INTO USUARIOS(nombre,correo,carrera,pass) " +
                    "VALUES (@nombre, @correo, @carrera, @pass)";
               

                sqlhacer = new SqlCommand(insert, BaseDatos.BDConectar());

                //Insertar los datos
                sqlhacer.Parameters.AddWithValue("@nombre", nombre);

                sqlhacer.Parameters.AddWithValue("@correo", correo);

                sqlhacer.Parameters.AddWithValue("@carrera", carrera);

                sqlhacer.Parameters.AddWithValue("@pass", password);

                sqlhacer.ExecuteNonQuery();
                BaseDatos.BDCerrar();
            }
            catch (SqlException ex) 
            {
                Console.WriteLine("Error al insertar datos: " + ex.Message);
            }
            
            Console.WriteLine("\nUsuario registrado");
        }
    }
}
