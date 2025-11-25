using asp_presentacion.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace asp_presentacion.Pages.Ventanas
{
    public class ReservaServiciosModel : GenericoModel<ReservaServicios, IReservaServiciosPresentacion>
    {
        public ReservaServiciosModel(IReservaServiciosPresentacion presentacion)
            : base(presentacion)
        {
            Filtro = new ReservaServicios
            {
                Servicio = 0
            };
        }

        public override void OnPostBtRefrescar()
        {
            try
            {
                ValidarSesion();
                Accion = Enumerables.Ventanas.Listas;

                if (Filtro!.Servicio > 0)
                {
                    Lista = Presentacion!.PorServicio(Filtro).Result;
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

            Actual = new ReservaServicios
            {
                Reserva = 0,
                Servicio = 0,
                Cantidad = 1
            };
        }
    }
}
