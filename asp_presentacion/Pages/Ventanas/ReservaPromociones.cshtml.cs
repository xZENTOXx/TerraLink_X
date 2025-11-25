using asp_presentacion.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace asp_presentacion.Pages.Ventanas
{
    public class ReservaPromocionesModel : GenericoModel<ReservaPromociones, IReservaPromocionesPresentacion>
    {
        public ReservaPromocionesModel(IReservaPromocionesPresentacion presentacion)
            : base(presentacion)
        {
            Filtro = new ReservaPromociones
            {
                Promocion = 0
            };
        }

        public override void OnPostBtRefrescar()
        {
            try
            {
                ValidarSesion();
                Accion = Enumerables.Ventanas.Listas;

                // FILTRO POR PROMOCIÓN
                if (Filtro!.Promocion > 0)
                {
                    Lista = Presentacion!.PorPromocion(Filtro).Result;
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

            Actual = new ReservaPromociones
            {
                Reserva = 0,
                Promocion = 0
            };
        }
    }
}
