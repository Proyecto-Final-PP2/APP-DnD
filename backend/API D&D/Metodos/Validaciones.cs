using API_D_D.Objetos;
using Google.Protobuf.WellKnownTypes;
using Modelo.Scripts;
using MySql.Data.MySqlClient;
namespace API_D_D.Metodos
{
    public class Validaciones
    {
        public MySqlDataReader resultado;
        public Validaciones(MySqlDataReader resultadoread) {
            resultado = resultadoread;
        }
        public string ValidarValor(string campo)
        {
            if (!resultado.IsDBNull(resultado.GetOrdinal(campo)))
            {
                return resultado[campo].ToString();
            }

            return null;
        }
        public bool ValidarValorBool(string campo)
        {
            if (!resultado.IsDBNull(resultado.GetOrdinal(campo)))
            {
                return true;
            }

            return false;
        }
    }
}
