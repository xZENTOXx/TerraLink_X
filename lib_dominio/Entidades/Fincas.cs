namespace lib_dominio.Entidades
{
    public class Fincas
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Ubicacion { get; set; }
        public int Capacidad { get; set; }
        public string? Descripcion { get; set; }
        public decimal PrecioBase { get; set; }
        public bool Estado { get; set; } = true;
    }

}
