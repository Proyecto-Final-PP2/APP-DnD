using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Modelo.Scripts
{
    public class ConexionBD
    {
        private String cadena = "Server=localhost;database=sakila; user=root; password=";
        public MySqlConnection conectar;

        public void AbrirConexion() {
            try
            {
                conectar = new MySqlConnection();
                conectar.ConnectionString = cadena;
                conectar.Open();
                System.Diagnostics.Debug.WriteLine("Conexion exitosa");
            }catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
