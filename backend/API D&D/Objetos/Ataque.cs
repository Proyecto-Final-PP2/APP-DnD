using Google.Protobuf.WellKnownTypes;
using Mysqlx.Crud;
using static Mysqlx.Notice.Warning.Types;

namespace API_D_D.Objetos
{
    public class Ataque
    {
        public int? ID { get; set; }
        public string? Nombre { get; set; }
        public int? Nivel { get; set; }
        public string? Tipo { get; set; }
        public string? CDSalvacion { get; set; }
        public string? Descripcion { get; set; }
        public bool? Vocal { get; set; }
        public bool? Somatico { get; set; }
        public bool? Material { get; set; }
        public string? Duracion { get; set; }
        public string? TiempoDeLanzamiento { get; set; }
        public string? Daño { get; set; }
        public string? Daño2 { get; set; }
        public string? DañoXNivelSuperior { get; set; }
        public string? Alcance { get; set; }
    }
}
