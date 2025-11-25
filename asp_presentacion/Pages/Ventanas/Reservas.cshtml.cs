using asp_presentacion.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace asp_presentacion.Pages.Ventanas
{
    public class ReservasModel : GenericoModel<Reservas, IReservasPresentacion>
    {
        public ReservasModel(IReservasPresentacion presentacion)
            : base(presentacion)
        {
            Filtro = new Reservas
            {
                Cliente = 0,
                FechaInicio = DateTime.Today,
                FechaFin = DateTime.Today,
                Estado = ""
            };

        }

        public override void OnPostBtRefrescar()
        {
            try
            {
                ValidarSesion();
                Accion = Enumerables.Ventanas.Listas;

                // FILTRO POR CLIENTE
                if (Filtro!.Cliente > 0)
                {
                    Lista = Presentacion!.PorCliente(Filtro).Result;
                }
                else
                {
                    base.OnPostBtRefrescar();
                }

                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public override void OnPostBtNuevo()
        {
            Accion = Enumerables.Ventanas.Editar;

            Actual = new Reservas
            {
                FechaInicio = DateTime.Today,
                FechaFin = DateTime.Today,
                Estado = "Pendiente",
                Total = 0,
                Cliente = 0,
                Finca = 0
            };
        }
    }
}
