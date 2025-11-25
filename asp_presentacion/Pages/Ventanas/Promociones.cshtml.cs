using asp_presentacion.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace asp_presentacion.Pages.Ventanas
{
    public class PromocionesModel : GenericoModel<Promociones, IPromocionesPresentacion>
    {
        public PromocionesModel(IPromocionesPresentacion presentacion)
            : base(presentacion)
        {
            Filtro = new Promociones
            {
                Nombre = ""
            };
        }

        public override void OnPostBtRefrescar()
        {
            try
            {
                ValidarSesion();
                Accion = Enumerables.Ventanas.Listas;

                // FILTRO POR NOMBRE
                if (!string.IsNullOrEmpty(Filtro!.Nombre))
                {
                    Lista = Presentacion!.PorNombre(Filtro).Result;
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

            Actual = new Promociones
            {
                Nombre = "",
                Descuento = 0,
                FechaInicio = DateTime.Today,
                FechaFin = DateTime.Today,
                Estado = true
            };
        }
    }
}
