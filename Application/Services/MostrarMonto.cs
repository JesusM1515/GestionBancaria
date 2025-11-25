using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Infraestructure.Context;
using Microsoft.Data.SqlClient;

namespace CapaNegocio
{
    public class MostrarMonto : IMetodo
    {
        private SqlCommand sqlhacer;
        public void Monto(string correo, string password, decimal monto)
        {
            try
            {
                Console.Clear();
                BD BaseDatos = BD.GetBD();

                string select = "SELECT monto, nombre FROM USUARIOS WHERE correo = @correo AND pass = @password";
                sqlhacer = new SqlCommand(select, BaseDatos.BDConectar());

                sqlhacer.Parameters.AddWithValue("@correo", correo);
                sqlhacer.Parameters.AddWithValue("@password", password);

                //Trae el valor de lectura de la consulta para las comparaciones
                SqlDataReader reader = sqlhacer.ExecuteReader();

                if (reader.Read()) 
                {
                    //Get ordinal sirve para traer el numero de la columna, despues de pasa a getstring para traer el nombre del usuario
                   int nombreIndex = reader.GetOrdinal("nombre");
                   string nombre = reader.GetString(nombreIndex);

                    //Lo mismo pero para balance
                    int balanceIndex = reader.GetOrdinal("monto");
                    decimal balance = reader.GetDecimal(balanceIndex);
                    
                    Console.WriteLine($"Bienvenido {nombre}\nBalance actual: {balance} RD$");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al mostrar balance: " + ex.Message);
            }
        }
    }
}
