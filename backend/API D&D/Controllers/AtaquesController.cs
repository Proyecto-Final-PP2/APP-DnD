using API_D_D.Objetos;
using API_D_D.Metodos;
using Microsoft.AspNetCore.Mvc;
using Modelo.Scripts;
using MySql.Data.MySqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Linq;
using System.Data;

namespace API_D_D.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtaqueController : ControllerBase
    {
        //Traer Todos los ataques----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        [HttpPost(Name = "PostTodosLosAtaques")]
        public IEnumerable<Ataque> Post()
        {   
            
            ConexionBD conexion = new ConexionBD();
            string query = "select * from ataques order by nombre";
            MySqlCommand cmd = new MySqlCommand(query, conexion.AbrirConexion());
            List<Ataque> Ataques = new List<Ataque>();
            using (var Resultado = cmd.ExecuteReader())
            {
                if (Resultado.HasRows)
                {
                    while (Resultado.Read())
                    {
                        Validaciones valido = new Validaciones(Resultado);
                        Ataque ataque = new Ataque();
                        ataque.ID = Convert.ToInt32(Resultado["ID"]);
                        ataque.Nombre = valido.ValidarValor("Nombre");
                        ataque.Nivel = Convert.ToInt32(valido.ValidarValor("NIVEL"));
                        ataque.Tipo = valido.ValidarValor("Tipo");
                        ataque.CDSalvacion = valido.ValidarValor("CDSalvacion");
                        ataque.Descripcion = valido.ValidarValor("Descripcion");
                        ataque.Vocal = valido.ValidarValorBool("Vocal");
                        ataque.Somatico = valido.ValidarValorBool("Somatico");
                        ataque.Material = valido.ValidarValorBool("Material");
                        ataque.Duracion = valido.ValidarValor("Duracion");
                        ataque.TiempoDeLanzamiento = valido.ValidarValor("TiempoDeLanzamiento");
                        ataque.Daño = valido.ValidarValor("Daño");
                        ataque.Daño2 = valido.ValidarValor("Daño2");
                        ataque.DañoXNivelSuperior = valido.ValidarValor("DañoXNivelSuperior");
                        ataque.Alcance = valido.ValidarValor("Alcance");
                        Ataques.Add(ataque);
                    }


                }
            }
            conexion.CerrarConexion();
            return Ataques;


        }

        //Traer ataques por ID----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public class IDAtaque
        {
            public int id { get; set; }
        }
        [HttpPost("PostAtaqueXID")]
        public IEnumerable<Ataque> Post(IDAtaque ID)
        {
            ConexionBD conexion = new ConexionBD();
            string query = "select * from ataques where ID = " + ID.id  + " order by nombre";
            MySqlCommand cmd = new MySqlCommand(query, conexion.AbrirConexion());
            List<Ataque> Ataques = new List<Ataque>();
            using (var Resultado = cmd.ExecuteReader())
            {
                if (Resultado.HasRows)
                {
                    while (Resultado.Read())
                    {
                        Validaciones valido = new Validaciones(Resultado);
                        Ataque ataque = new Ataque();
                        ataque.ID = Convert.ToInt32(Resultado["ID"]);
                        ataque.Nombre = valido.ValidarValor("Nombre");
                        ataque.Nivel = Convert.ToInt32(valido.ValidarValor("NIVEL"));
                        ataque.Tipo = valido.ValidarValor("Tipo");
                        ataque.CDSalvacion = valido.ValidarValor("CDSalvacion");
                        ataque.Descripcion = valido.ValidarValor("Descripcion");
                        ataque.Vocal = valido.ValidarValorBool("Vocal");
                        ataque.Somatico = valido.ValidarValorBool("Somatico");
                        ataque.Material = valido.ValidarValorBool("Material");
                        ataque.Duracion = valido.ValidarValor("Duracion");
                        ataque.TiempoDeLanzamiento = valido.ValidarValor("TiempoDeLanzamiento");
                        ataque.Daño = valido.ValidarValor("Daño");
                        ataque.Daño2 = valido.ValidarValor("Daño2");
                        ataque.DañoXNivelSuperior = valido.ValidarValor("DañoXNivelSuperior");
                        ataque.Alcance = valido.ValidarValor("Alcance");
                        Ataques.Add(ataque);
                    }


                }
            }
            conexion.CerrarConexion();
            return Ataques;


        }

        //Traer ataques por Nombre----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public class Nombre
        {
            public string Letra { get; set; }
        }
        [HttpPost("PostAtaqueXNombreParcial")]
        public IEnumerable<Ataque> Post(Nombre Letra)
        {
            ConexionBD conexion = new ConexionBD();
            string query = "select * from ataques where upper(Nombre) LIKE upper('%" + Letra.Letra + "%')" + " order by nombre";
            MySqlCommand cmd = new MySqlCommand(query, conexion.AbrirConexion());
            List<Ataque> Ataques = new List<Ataque>();
            using (var Resultado = cmd.ExecuteReader())
            {
                if (Resultado.HasRows)
                {
                    while (Resultado.Read())
                    {
                        Validaciones valido = new Validaciones(Resultado);
                        Ataque ataque = new Ataque();
                        ataque.ID = Convert.ToInt32(Resultado["ID"]);
                        ataque.Nombre = valido.ValidarValor("Nombre");
                        ataque.Nivel = Convert.ToInt32(valido.ValidarValor("NIVEL"));
                        ataque.Tipo = valido.ValidarValor("Tipo");
                        ataque.CDSalvacion = valido.ValidarValor("CDSalvacion");
                        ataque.Descripcion = valido.ValidarValor("Descripcion");
                        ataque.Vocal = valido.ValidarValorBool("Vocal");
                        ataque.Somatico = valido.ValidarValorBool("Somatico");
                        ataque.Material = valido.ValidarValorBool("Material");
                        ataque.Duracion = valido.ValidarValor("Duracion");
                        ataque.TiempoDeLanzamiento = valido.ValidarValor("TiempoDeLanzamiento");
                        ataque.Daño = valido.ValidarValor("Daño");
                        ataque.Daño2 = valido.ValidarValor("Daño2");
                        ataque.DañoXNivelSuperior = valido.ValidarValor("DañoXNivelSuperior");
                        ataque.Alcance = valido.ValidarValor("Alcance");
                        Ataques.Add(ataque);
                    }


                }
            }
            conexion.CerrarConexion();
            return Ataques;


        }
        //Contar todas las criaturas----------------------------------------------------------------------------------------------------------------------------

        [HttpGet("GetContarTotalAtaques")]
        public IEnumerable<Ataque> get()
        {
            ConexionBD conexion = new ConexionBD();
            string query = "select count(ID) as contador from ataques";
            MySqlCommand cmd = new MySqlCommand(query, conexion.AbrirConexion());


            List<Ataque> ataques= new List<Ataque>();
            using (var Resultado = cmd.ExecuteReader())
            {
                if (Resultado.HasRows)
                {

                    while (Resultado.Read())
                    {
                        int contador = 0;
                        Validaciones valido = new Validaciones(Resultado);
                        Ataque ataque = new Ataque();
                        ataque.MAX = Convert.ToInt32(valido.ValidarValor("contador"));
                        ataques.Add(ataque);
                    }
                }
            }
            conexion.CerrarConexion();
            return ataques;
        }
    }
}
