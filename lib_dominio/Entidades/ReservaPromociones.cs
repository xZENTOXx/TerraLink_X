namespace lib_dominio.Entidades
{
    public class ReservaPromociones
    {
        public int Id { get; set; }
        public int Reserva { get; set; }
        public int Promocion { get; set; }
        public Reservas? _Reserva { get; set; }
        public Promociones? _Promocion { get; set; }
    }
}
