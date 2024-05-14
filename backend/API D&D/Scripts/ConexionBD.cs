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
        private MySqlConnection conn;

        public ConexionBD() {
            conn = new MySqlConnection("Server=localhost;database=dnd;user=root;password=123456789");
        }
        
        

        public MySqlConnection AbrirConexion() {
            try
            {
                conn.Open();
                System.Diagnostics.Debug.WriteLine("Conexion exitosa");
                return conn;
            }catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public void CerrarConexion() {
            conn.Close();
        }
    }
}
