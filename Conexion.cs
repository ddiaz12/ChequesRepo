using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProyectoBanco
{
    internal class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection conectar = new SqlConnection("SERVER=MSI;DATABASE=Banco;Integrated security = true");
            conectar.Open();
            return conectar;

        }

        public static void Cerrar()
        {
            SqlConnection cerrar = new SqlConnection();
            cerrar.Close();
        }
    }
}
