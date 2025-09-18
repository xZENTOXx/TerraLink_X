namespace lib_dominio.Entidades
{
    public class ReservaServicios
    {
        public int Id { get; set; }
        public int Reserva { get; set; }
        public int Servicio { get; set; }
        public int Cantidad { get; set; } = 1;

    }
}
