using asp_presentacion.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace asp_presentacion.Pages.Ventanas
{
    public class TareasModel : GenericoModel<Tareas, ITareasPresentacion>
    {
        public TareasModel(ITareasPresentacion presentacion)
            : base(presentacion)
        {
            Filtro = new Tareas
            {
                Empleado = 0
            };
        }

        public override void OnPostBtRefrescar()
        {
            try
            {
                ValidarSesion();
                Accion = Enumerables.Ventanas.Listas;

                if (Filtro!.Empleado > 0)
                {
                    Lista = Presentacion!.PorEmpleado(Filtro).Result;
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

            Actual = new Tareas
            {
                Empleado = 0,
                Finca = 0,
                Descripcion = "",
                FechaAsignacion = DateTime.Today,
                Estado = "Pendiente"
            };
        }
    }
}
