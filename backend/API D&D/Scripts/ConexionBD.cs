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
            /*
            conn = new MySqlConnection("Server=localhost;" +
                                       "database=dnd;" +
                                       "user=root;" +
                                       "password=123456789");

            */
            conn = new MySqlConnection("Server=bsaosyt8x9cqc68z63bc-mysql.services.clever-cloud.com;" +
                                       "Port=3306;"+     
                                       "database=bsaosyt8x9cqc68z63bc;" +
                                       "user=ubhcshgbi1nfolq2;" +
                                       "password=Sph0v23HTvo7g9KsXC0C");

       
        
        
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
