using asp_presentacion.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace asp_presentacion.Pages.Ventanas
{
    public class ReseñasModel : GenericoModel<Reseñas, IReseñasPresentacion>
    {
        public ReseñasModel(IReseñasPresentacion presentacion)
            : base(presentacion)
        {
            Filtro = new Reseñas
            {
                Calificacion = 0,
                Fecha = DateTime.Today
            };
        }

        public override void OnPostBtRefrescar()
        {
            try
            {
                ValidarSesion();
                Accion = Enumerables.Ventanas.Listas;

                if (Filtro!.Calificacion > 0)
                {
                    Lista = Presentacion!.PorCalificacion(Filtro).Result;
                }
                else if (Filtro.Fecha != default)
                {
                    Lista = Presentacion!.PorFecha(Filtro).Result;
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

            Actual = new Reseñas
            {
                Finca = 0,
                Cliente = 0,
                Calificacion = 1,
                Comentario = "",
                Fecha = DateTime.Today
            };
        }
    }
}
