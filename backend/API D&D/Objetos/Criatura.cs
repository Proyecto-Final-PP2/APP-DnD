namespace API_D_D.Objetos
{
    public class Criatura
    {
        public int? ID { get; set; }
        public int? SubID { get; set; }
        public string? Nombre { get; set; }
        public string? Dificultad { get; set; }
        public int? Vida { get; set; }
        public int? Velocidad { get; set; }
        public int? VelocidadNado { get; set; }
        public int? VelocidadVuelo { get; set; }
        public int? Armadura { get; set; }
        public int? Fuerza { get; set; }
        public int? FuerzaCompetencia =>Fuerza/2 -5;
        public int? Destreza { get; set; }
        public int? DestrezaCompetencia => Destreza / 2 - 5;
        public int? Constitucion { get; set; }
        public int? ConstitucionCompetencia => Constitucion / 2 - 5;
        public int? Inteligencia { get; set; }
        public int? InteligenciaCompetencia => Inteligencia / 2 - 5;
        public int? Sabiduria { get; set; }
        public int? SabiduriaCompetencia => Sabiduria / 2 - 5;
        public int? Carisma { get; set; }
        public int? CarismaCompetencia => Carisma / 2 - 5;
        public int? XP { get; set; }
        public List<int>? IdAtaques { get; set; }
        public string? Tipo { get; set; }
        public string? Tamaño { get; set; }
        public string? Alineamiento { get; set; }
        public int? MAX { get; set; }



    }
}
