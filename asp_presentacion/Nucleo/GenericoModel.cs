using lib_dominio.Nucleo;
using lib_dominio.Entidades;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace asp_presentacion.Nucleo
{
    public class GenericoModel<T, TP> : PageModel
        where T : class, IEntidad
        where TP : IGenericoPresentacion<T>
    {
        protected TP? Presentacion;

        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public T? Actual { get; set; }
        [BindProperty] public T? Filtro { get; set; }
        [BindProperty] public List<T>? Lista { get; set; }

        public GenericoModel(TP presentacion)
        {
            Presentacion = presentacion;
        }

        public virtual void OnGet() => OnPostBtRefrescar();


        // REFRESCAR — puede ser sobreescrito por módulos con filtros especiales
        public virtual void OnPostBtRefrescar()
        {
            try
            {
                ValidarSesion();

                Accion = Enumerables.Ventanas.Listas;

                var task = Presentacion!.Listar();
                task.Wait();
                Lista = task.Result;

                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }


        // NUEVO
        public virtual void OnPostBtNuevo()
        {
            Accion = Enumerables.Ventanas.Editar;

            // No crear new T() aquí si la entidad tiene required.
            // Cada PageModel deberá sobrescribir este método.
        }

        // MODIFICAR
        public virtual void OnPostBtModificar(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }


        // GUARDAR
        public virtual void OnPostBtGuardar()
        {
            try
            {
                Task<T>? task = null;

                if (Actual!.Id == 0)
                    task = Presentacion!.Guardar(Actual);
                else
                    task = Presentacion!.Modificar(Actual);

                task!.Wait();
                Actual = task.Result;

                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }


        // BORRAR — abre popup
        public virtual void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }


        // CONFIRMAR BORRADO
        public virtual void OnPostBtBorrar()
        {
            try
            {
                var task = Presentacion!.Borrar(Actual!);
                task.Wait();
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }


        // CANCELAR
        public virtual void OnPostBtCancelar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }


        // VALIDACIÓN DE SESIÓN
        protected void ValidarSesion()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");

            if (string.IsNullOrEmpty(variable_session))
            {
                HttpContext.Response.Redirect("/");
            }
        }
    }
}
