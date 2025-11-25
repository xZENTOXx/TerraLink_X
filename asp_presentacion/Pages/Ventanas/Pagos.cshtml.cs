using asp_presentacion.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace asp_presentacion.Pages.Ventanas
{
    public class PagosModel : GenericoModel<Pagos, IPagosPresentacion>
    {
        public PagosModel(IPagosPresentacion presentacion)
            : base(presentacion)
        {
            Filtro = new Pagos
            {
                FechadePago = DateTime.Today,
                Metodo = ""
            };
        }

        public override void OnPostBtRefrescar()
        {
            try
            {
                ValidarSesion();
                Accion = Enumerables.Ventanas.Listas;

                // FILTRAR POR FECHA
                if (Filtro!.FechadePago != default)
                {
                    Lista = Presentacion!.PorFechadePago(Filtro).Result;
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

            Actual = new Pagos
            {
                Reserva = 0,
                Monto = 0,
                FechadePago = DateTime.Today,
                Metodo = ""
            };
        }
    }
}
