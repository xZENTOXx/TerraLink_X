namespace lib_dominio.Entidades
{
    public class ReservaServicios : IEntidad
    {
        public int Id { get; set; }
        public int Reserva { get; set; }
        public int Servicio { get; set; }
        public int Cantidad { get; set; } = 1;
        public Reservas? _Reserva { get; set; }
        public ServiciosExtras? _Servicio { get; set; }

    }
}
