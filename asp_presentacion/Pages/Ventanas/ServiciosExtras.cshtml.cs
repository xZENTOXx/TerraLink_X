using asp_presentacion.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace asp_presentacion.Pages.Ventanas
{
    public class ServiciosExtrasModel : GenericoModel<ServiciosExtras, IServiciosExtrasPresentacion>
    {
        public ServiciosExtrasModel(IServiciosExtrasPresentacion presentacion)
            : base(presentacion)
        {
            Filtro = new ServiciosExtras
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

            Actual = new ServiciosExtras
            {
                Nombre = "",
                Precio = 0,
                Estado = true
            };
        }
    }
}
