using API_D_D.Objetos;
using Microsoft.AspNetCore.Mvc;
using Modelo.Scripts;
using MySql.Data.MySqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Linq;
using API_D_D.Metodos;
using System.Security.Cryptography.X509Certificates;

namespace API_D_D.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CriaturaController : ControllerBase
    {
        //Traer todas las criaturas--------------------------------------------------------------------------------------------------------------------------------------------------
        [HttpGet(Name = "PostTodasLasCriaturas")]
        public IEnumerable<Criatura> Get()
        { 

            ConexionBD conexion = new ConexionBD();
            string query = "select * from criaturas order by nombre";
            MySqlCommand cmd = new MySqlCommand(query, conexion.AbrirConexion());
            

            List<Criatura> criaturas = new List<Criatura>();
            using (var Resultado = cmd.ExecuteReader()) { 
                if (Resultado.HasRows) {
                    
                    while (Resultado.Read())
                    {
                        int contador = 0;
                        Validaciones valido = new Validaciones(Resultado);
                        Criatura criatura = new Criatura();
                        criatura.ID = Convert.ToInt32(valido.ValidarValor("ID"));
                        criatura.SubID = Convert.ToInt32(valido.ValidarValor("SUBID"));
                        criatura.Nombre = valido.ValidarValor("Nombre");
                        criatura.Dificultad = valido.ValidarValor("Dificultad");
                        criatura.Vida = Convert.ToInt32(valido.ValidarValor("Vida"));
                        criatura.Velocidad = Convert.ToInt32(valido.ValidarValor("Velocidad"));
                        criatura.VelocidadNado = Convert.ToInt32(valido.ValidarValor("VelocidadNado"));
                        criatura.VelocidadVuelo = Convert.ToInt32(valido.ValidarValor("VelocidadVuelo"));
                        criatura.Armadura = Convert.ToInt32(valido.ValidarValor("Armadura"));
                        criatura.XP = Convert.ToInt32(valido.ValidarValor("XP"));
                        criatura.Fuerza = Convert.ToInt32(valido.ValidarValor("Fuerza"));
                        criatura.Destreza = Convert.ToInt32(valido.ValidarValor("Destreza"));
                        criatura.Constitucion = Convert.ToInt32(valido.ValidarValor("Constitucion"));
                        criatura.Inteligencia = Convert.ToInt32(valido.ValidarValor("Inteligencia"));
                        criatura.Sabiduria = Convert.ToInt32(valido.ValidarValor("Sabiduria"));
                        criatura.Carisma = Convert.ToInt32(valido.ValidarValor("Carisma"));
                        string[] ataques = ((string)valido.ValidarValor("IdAtaques")).Split(",");
                        criatura.IdAtaques = new List<int>();
                            foreach (string item in ataques)
                            {
                                if (item != "" && item != null)
                                {
                                    int Temporal = Convert.ToInt32(item);   
                                    criatura.IdAtaques.Add(Temporal);
                                    contador++;
                                }
                            }
                        criatura.Tipo = valido.ValidarValor("Tipo");
                        criatura.Tamaño = valido.ValidarValor("Tamaño");
                        criatura.Alineamiento = valido.ValidarValor("Alineamiento");
                        criaturas.Add(criatura);
                    }

                    
                }
            }
            conexion.CerrarConexion();
            return criaturas;

              
        }
       


        //Traer criaturas X especies EJ: Todos los goblins----------------------------------------------------------------------------------------------------------------------------
        public class ID { 
            public int id { get; set;  }
        }
        [HttpPost("PostCriaturaXEspecie")]
         public IEnumerable<Criatura> Post(ID id) 
        {
            ConexionBD conexion = new ConexionBD();
            string query = "select * from criaturas where ID = " + id.id + " order by nombre" ;
            MySqlCommand cmd = new MySqlCommand(query, conexion.AbrirConexion());
            

            List<Criatura> criaturas = new List<Criatura>();
            using (var Resultado = cmd.ExecuteReader()) { 
                if (Resultado.HasRows) {
                    
                    while (Resultado.Read())
                    {
                        int contador = 0;
                        Validaciones valido = new Validaciones(Resultado);
                        Criatura criatura = new Criatura();
                        criatura.ID = Convert.ToInt32(valido.ValidarValor("ID"));
                        criatura.SubID = Convert.ToInt32(valido.ValidarValor("SUBID"));
                        criatura.Nombre = valido.ValidarValor("Nombre");
                        criatura.Dificultad = valido.ValidarValor("Dificultad");
                        criatura.Vida = Convert.ToInt32(valido.ValidarValor("Vida"));
                        criatura.Velocidad = Convert.ToInt32(valido.ValidarValor("Velocidad"));
                        criatura.VelocidadNado = Convert.ToInt32(valido.ValidarValor("VelocidadNado"));
                        criatura.VelocidadVuelo = Convert.ToInt32(valido.ValidarValor("VelocidadVuelo"));
                        criatura.Armadura = Convert.ToInt32(valido.ValidarValor("Armadura"));
                        criatura.XP = Convert.ToInt32(valido.ValidarValor("XP"));
                        criatura.Fuerza = Convert.ToInt32(valido.ValidarValor("Fuerza"));
                        criatura.Destreza = Convert.ToInt32(valido.ValidarValor("Destreza"));
                        criatura.Constitucion = Convert.ToInt32(valido.ValidarValor("Constitucion"));
                        criatura.Inteligencia = Convert.ToInt32(valido.ValidarValor("Inteligencia"));
                        criatura.Sabiduria = Convert.ToInt32(valido.ValidarValor("Sabiduria"));
                        criatura.Carisma = Convert.ToInt32(valido.ValidarValor("Carisma"));
                        string[] ataques = ((string)valido.ValidarValor("IdAtaques")).Split(",");
                        criatura.IdAtaques = new List<int>();
                        foreach (string item in ataques)
                        {
                            if (item != "" && item != null)
                            {
                                int Temporal = Convert.ToInt32(item);
                                criatura.IdAtaques.Add(Temporal);
                                contador++;
                            }
                        }
                        criatura.Tipo = valido.ValidarValor("Tipo");
                        criatura.Tamaño = valido.ValidarValor("Tamaño");
                        criatura.Alineamiento = valido.ValidarValor("Alineamiento");
                        criaturas.Add(criatura);
                    }

                    
                }
            }
            conexion.CerrarConexion();
            return criaturas;

              
        }



        //Traer criatura en particular  EJ: El jefe goblin----------------------------------------------------------------------------------------------------------------------------
        public class IDySubID
        {
            public int ID { get; set; }
            public int SUBID { get; set; }
        }
        [HttpPost("PostCriaturaPuntual")]
        public IEnumerable<Criatura> Post(IDySubID IDySubID)
        {
            ConexionBD conexion = new ConexionBD();
            string query = "select * from criaturas where ID = " + IDySubID.ID + " and SUBID = "+ IDySubID.SUBID + " order by nombre";
            MySqlCommand cmd = new MySqlCommand(query, conexion.AbrirConexion());


            List<Criatura> criaturas = new List<Criatura>();
            using (var Resultado = cmd.ExecuteReader())
            {
                if (Resultado.HasRows)
                {

                    while (Resultado.Read())
                    {
                        int contador = 0;
                        Validaciones valido = new Validaciones(Resultado);
                        Criatura criatura = new Criatura();
                        criatura.ID = Convert.ToInt32(valido.ValidarValor("ID"));
                        criatura.SubID = Convert.ToInt32(valido.ValidarValor("SUBID"));
                        criatura.Nombre = valido.ValidarValor("Nombre");
                        criatura.Dificultad = valido.ValidarValor("Dificultad");
                        criatura.Vida = Convert.ToInt32(valido.ValidarValor("Vida"));
                        criatura.Velocidad = Convert.ToInt32(valido.ValidarValor("Velocidad"));
                        criatura.VelocidadNado = Convert.ToInt32(valido.ValidarValor("VelocidadNado"));
                        criatura.VelocidadVuelo = Convert.ToInt32(valido.ValidarValor("VelocidadVuelo"));
                        criatura.Armadura = Convert.ToInt32(valido.ValidarValor("Armadura"));
                        criatura.XP = Convert.ToInt32(valido.ValidarValor("XP"));
                        criatura.Fuerza = Convert.ToInt32(valido.ValidarValor("Fuerza"));
                        criatura.Destreza = Convert.ToInt32(valido.ValidarValor("Destreza"));
                        criatura.Constitucion = Convert.ToInt32(valido.ValidarValor("Constitucion"));
                        criatura.Inteligencia = Convert.ToInt32(valido.ValidarValor("Inteligencia"));
                        criatura.Sabiduria = Convert.ToInt32(valido.ValidarValor("Sabiduria"));
                        criatura.Carisma = Convert.ToInt32(valido.ValidarValor("Carisma"));
                        string[] ataques = ((string)valido.ValidarValor("IdAtaques")).Split(",");
                        criatura.IdAtaques = new List<int>();
                        foreach (string item in ataques)
                        {
                            if (item != "" && item != null)
                            {
                                int Temporal = Convert.ToInt32(item);
                                criatura.IdAtaques.Add(Temporal);
                                contador++;
                            }
                        }
                        criatura.Tipo = valido.ValidarValor("Tipo");
                        criatura.Tamaño = valido.ValidarValor("Tamaño");
                        criatura.Alineamiento = valido.ValidarValor("Alineamiento");
                        criaturas.Add(criatura);
                    }


                }
            }
            conexion.CerrarConexion();
            return criaturas;


        }



        //Traer criaturas X Nombre parcial EJ: Ingresas la Z y te trae todas las criaturas que tengan Z en el nombre------------------------------------------------------------------
        public class NombreCriatura
        {
            public string Letra { get; set; }
        }
        [HttpPost("PostCriaturaNombre")]
        public IEnumerable<Criatura> Post(NombreCriatura Nombre)
        {
            ConexionBD conexion = new ConexionBD();
            string query = "select * from criaturas where upper(Nombre) LIKE upper('%" + Nombre.Letra+ "%')" + " order by nombre";
            MySqlCommand cmd = new MySqlCommand(query, conexion.AbrirConexion());


            List<Criatura> criaturas = new List<Criatura>();
            using (var Resultado = cmd.ExecuteReader())
            {
                if (Resultado.HasRows)
                {

                    while (Resultado.Read())
                    {
                        int contador = 0;
                        Validaciones valido = new Validaciones(Resultado);
                        Criatura criatura = new Criatura();
                        criatura.ID = Convert.ToInt32(valido.ValidarValor("ID"));
                        criatura.SubID = Convert.ToInt32(valido.ValidarValor("SUBID"));
                        criatura.Nombre = valido.ValidarValor("Nombre");
                        criatura.Dificultad = valido.ValidarValor("Dificultad");
                        criatura.Vida = Convert.ToInt32(valido.ValidarValor("Vida"));
                        criatura.Velocidad = Convert.ToInt32(valido.ValidarValor("Velocidad"));
                        criatura.VelocidadNado = Convert.ToInt32(valido.ValidarValor("VelocidadNado"));
                        criatura.VelocidadVuelo = Convert.ToInt32(valido.ValidarValor("VelocidadVuelo"));
                        criatura.Armadura = Convert.ToInt32(valido.ValidarValor("Armadura"));
                        criatura.XP = Convert.ToInt32(valido.ValidarValor("XP"));
                        criatura.Fuerza = Convert.ToInt32(valido.ValidarValor("Fuerza"));
                        criatura.Destreza = Convert.ToInt32(valido.ValidarValor("Destreza"));
                        criatura.Constitucion = Convert.ToInt32(valido.ValidarValor("Constitucion"));
                        criatura.Inteligencia = Convert.ToInt32(valido.ValidarValor("Inteligencia"));
                        criatura.Sabiduria = Convert.ToInt32(valido.ValidarValor("Sabiduria"));
                        criatura.Carisma = Convert.ToInt32(valido.ValidarValor("Carisma"));
                        string[] ataques = ((string)valido.ValidarValor("IdAtaques")).Split(",");
                        criatura.IdAtaques = new List<int>();
                        foreach (string item in ataques)
                        {
                            if (item != "" && item != null)
                            {
                                int Temporal = Convert.ToInt32(item);
                                criatura.IdAtaques.Add(Temporal);
                                contador++;
                            }
                        }
                        criaturas.Add(criatura);
                    }


                }
            }
            conexion.CerrarConexion();
            return criaturas;


        }



        //Traer criaturas X pagina----------------------------------------------------------------------------------------------------------------------------
        
        [HttpGet("PostCriaturaXpagina/{pagina}")]
        public IEnumerable<Criatura> get(int pagina)
        {
            ConexionBD conexion = new ConexionBD();
            int cantidad = 10;
            int inicio ;
            int fin;
            if (pagina == 0)
            {
                inicio = 0;
                fin = cantidad;
            }
            else { 
                inicio = pagina * cantidad;
            }
            fin = inicio + cantidad;


            string query = "select * from criaturas order by NOMBRE asc LIMIT " + inicio +", " +fin;
            MySqlCommand cmd = new MySqlCommand(query, conexion.AbrirConexion());


            List<Criatura> criaturas = new List<Criatura>();
            using (var Resultado = cmd.ExecuteReader())
            {
                if (Resultado.HasRows)
                {

                    while (Resultado.Read())
                    {
                        int contador = 0;
                        Validaciones valido = new Validaciones(Resultado);
                        Criatura criatura = new Criatura();
                        criatura.ID = Convert.ToInt32(valido.ValidarValor("ID"));
                        criatura.SubID = Convert.ToInt32(valido.ValidarValor("SUBID"));
                        criatura.Nombre = valido.ValidarValor("Nombre");
                        criatura.Dificultad = valido.ValidarValor("Dificultad");
                        criatura.Vida = Convert.ToInt32(valido.ValidarValor("Vida"));
                        criatura.Velocidad = Convert.ToInt32(valido.ValidarValor("Velocidad"));
                        criatura.VelocidadNado = Convert.ToInt32(valido.ValidarValor("VelocidadNado"));
                        criatura.VelocidadVuelo = Convert.ToInt32(valido.ValidarValor("VelocidadVuelo"));
                        criatura.Armadura = Convert.ToInt32(valido.ValidarValor("Armadura"));
                        criatura.XP = Convert.ToInt32(valido.ValidarValor("XP"));
                        criatura.Fuerza = Convert.ToInt32(valido.ValidarValor("Fuerza"));
                        criatura.Destreza = Convert.ToInt32(valido.ValidarValor("Destreza"));
                        criatura.Constitucion = Convert.ToInt32(valido.ValidarValor("Constitucion"));
                        criatura.Inteligencia = Convert.ToInt32(valido.ValidarValor("Inteligencia"));
                        criatura.Sabiduria = Convert.ToInt32(valido.ValidarValor("Sabiduria"));
                        criatura.Carisma = Convert.ToInt32(valido.ValidarValor("Carisma"));
                        string[] ataques = ((string)valido.ValidarValor("IdAtaques")).Split(",");
                        criatura.IdAtaques = new List<int>();
                        foreach (string item in ataques)
                        {
                            if (item != "" && item != null)
                            {
                                int Temporal = Convert.ToInt32(item);
                                criatura.IdAtaques.Add(Temporal);
                                contador++;
                            }
                        }
                        criatura.Tipo = valido.ValidarValor("Tipo");
                        criatura.Tamaño = valido.ValidarValor("Tamaño");
                        criatura.Alineamiento = valido.ValidarValor("Alineamiento");
                        criaturas.Add(criatura);
                    }


                }
            }
            conexion.CerrarConexion();
            return criaturas;
        }



        //Contar todas las criaturas----------------------------------------------------------------------------------------------------------------------------

        [HttpGet("GetContarTotalCriaturas")]
        public IEnumerable<Criatura> get()
        {
            ConexionBD conexion = new ConexionBD();
            string query = "select count(ID) as contador from criaturas";
            MySqlCommand cmd = new MySqlCommand(query, conexion.AbrirConexion());


            List<Criatura> criaturas = new List<Criatura>();
            using (var Resultado = cmd.ExecuteReader())
            {
                if (Resultado.HasRows)
                {
                    while (Resultado.Read())
                    {
                        int contador = 0;
                        Validaciones valido = new Validaciones(Resultado);
                        Criatura criatura = new Criatura();
                        criatura.MAX = Convert.ToInt32(valido.ValidarValor("contador"));
                        criaturas.Add(criatura);
                    }
                }
            }
            conexion.CerrarConexion();
            return criaturas;
        }

    }
}
