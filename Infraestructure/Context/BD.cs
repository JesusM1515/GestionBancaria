using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class BD
    {
        private static string BDPath = "Data Source=Gin;Initial Catalog=USUARIOS;Integrated Security=True;Trust Server Certificate=True";

        //Singleton para la conexion
        private static BD BDinstance;
        private BD()
        {

        }
        public static BD GetBD()
        {
            if (BDinstance == null)
                BDinstance = new BD();
            return BDinstance;
        }

        //Metodo par establecer la coneccion
        public SqlConnection BDConectar() 
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(BDPath);

                //Evitar errores, abriendo la base de datos solo si esta cerrada
                if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
                /*Console.WriteLine("Conexion establecida\n");

                Console.WriteLine("Estado de la conexion: " + sqlConnection.State);*/

                return sqlConnection;
            }
            //Atrapar cualquier error que pase
            catch (SqlException ex) 
            {
                Console.WriteLine("Error de conexion: " + ex.Message);

                return null;
            } 
        }

        //Metodo par cerrar la coneccion
        public SqlConnection BDCerrar()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(BDPath);

                //Evitar errores, cerrando la base solo si esta abierta
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
               /* Console.WriteLine("\nBase de datos cerrada");

                Console.WriteLine("Estado de la conexion: " + sqlConnection.State);*/

                return sqlConnection;
            }
            //Atrapar cualquier error que pase
            catch (SqlException ex)
            {
                Console.WriteLine("Error al cerrar base: " + ex.Message);

                return null;
            }
        }
    }
}
