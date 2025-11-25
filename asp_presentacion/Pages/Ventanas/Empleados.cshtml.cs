using asp_presentacion.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace asp_presentacion.Pages.Ventanas
{
    public class EmpleadosModel : GenericoModel<Empleados, IEmpleadosPresentacion>
    {
        public EmpleadosModel(IEmpleadosPresentacion presentacion)
            : base(presentacion)
        {
            // Filtro inicial
            Filtro = new Empleados
            {
                Nombre = "",
                Apellido = "",
                Cargo = "",
                Telefono = ""
            };
        }

        // NUEVO
        public override void OnPostBtNuevo()
        {
            Accion = Enumerables.Ventanas.Editar;

            Actual = new Empleados
            {
                Nombre = "",
                Apellido = "",
                Cargo = "",
                Telefono = "",
                Correo = ""
            };
        }

        // REFRESCAR CON FILTROS
        public override void OnPostBtRefrescar()
        {
            try
            {
                ValidarSesion();
                Accion = Enumerables.Ventanas.Listas;

                // Filtro por Teléfono
                if (!string.IsNullOrEmpty(Filtro!.Telefono))
                {
                    var task = Presentacion!.PorTelefono(Filtro!);
                    task.Wait();
                    Lista = task.Result;
                }
                // Filtro por Cargo
                else if (!string.IsNullOrEmpty(Filtro!.Cargo))
                {
                    var task = Presentacion!.PorCargo(Filtro!);
                    task.Wait();
                    Lista = task.Result;
                }
                else
                {
                    // Listar todo
                    base.OnPostBtRefrescar();
                }

                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
