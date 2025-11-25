using Microsoft.Data.SqlClient;
using Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaNegocio
{
    public class Deposito : IMetodo
    {
        private SqlCommand sqlhacer;
        public void Monto(string correo, string password, decimal monto)
        {
            try
            {
                Console.Clear();
                //Traer la conexion con la base de datos
                BD BaseDatos = BD.GetBD();

                //String con el comando para traer los datos y comprobar si es null o no
                string select = "SELECT monto FROM USUARIOS WHERE correo = @correo AND pass = @password";

                sqlhacer = new SqlCommand(select, BaseDatos.BDConectar());

                //comparar los datos segun los parametros
                sqlhacer.Parameters.AddWithValue("@correo", correo);
                sqlhacer.Parameters.AddWithValue("@password", password);

                //Trae un solo valor 
                object posiblenull = sqlhacer.ExecuteScalar();

                //Si monto es null inserta el monto
                if (posiblenull == DBNull.Value || posiblenull == null)
                {
                    Console.WriteLine("[Insertar cantidad a depositar]");

                    string insert = "UPDATE USUARIOS SET monto = @monto WHERE correo = @correo AND pass = @password";

                    sqlhacer = new SqlCommand(insert, BaseDatos.BDConectar());
                    //Insertar los datos
                    sqlhacer.Parameters.AddWithValue("@monto", monto);
                    sqlhacer.Parameters.AddWithValue("@correo", correo);
                    sqlhacer.Parameters.AddWithValue("@password", password);
                    
                    sqlhacer.ExecuteNonQuery();
                    Console.Clear();
                    Console.WriteLine(">Deposito realizado\nPresina enter para volver al menu");
                    Console.ReadKey();
                }
                // Si monto no es null, suma el monto actual con el ingresado
                else
                {
                    Console.WriteLine("[Insertar cantidad a depositar]");

                    string update = "UPDATE USUARIOS SET monto = monto + @monto " +
                        "WHERE correo = @correo AND pass = @password";

                    sqlhacer = new SqlCommand(update, BaseDatos.BDConectar());

                    //Insertar los datos
                    sqlhacer.Parameters.AddWithValue("@monto", monto);
                    sqlhacer.Parameters.AddWithValue("@correo", correo);
                    sqlhacer.Parameters.AddWithValue("@password", password);

                    sqlhacer.ExecuteNonQuery();
                    Console.Clear();
                    Console.WriteLine(">Deposito realizado\nPresina enter para volver al menu");
                    Console.ReadKey();
                }
                BaseDatos.BDCerrar();
            }
            catch (SqlException ex) 
            {
                Console.WriteLine("Error de deposito: " + ex.Message);
            }

            Console.WriteLine("Deposito realizado");
        } 

    }
}
