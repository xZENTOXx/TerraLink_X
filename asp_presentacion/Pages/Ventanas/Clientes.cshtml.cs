using asp_presentacion.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace asp_presentacion.Pages.Ventanas
{
    public class ClientesModel : GenericoModel<Clientes, IClientesPresentacion>
    {
        public ClientesModel(IClientesPresentacion presentacion)
            : base(presentacion)
        {
            // INICIALIZACIÓN DEL FILTRO ? necesario por los required
            Filtro = new Clientes
            {
                Nombre = "",
                Apellido = "",
                Correo = "",
                Documento = ""
            };
        }

        // NUEVO — Sobrescribe el método porque la entidad tiene required
        public override void OnPostBtNuevo()
        {
            Accion = Enumerables.Ventanas.Editar;

            Actual = new Clientes
            {
                Nombre = "",
                Apellido = "",
                Correo = "",
                Documento = ""
            };
        }

        // REFRESCAR — Aplica prioridad Documento ? Correo ? Listar todos
        public override void OnPostBtRefrescar()
        {
            try
            {
                ValidarSesion();
                Accion = Enumerables.Ventanas.Listas;

                // Filtro por Documento
                if (!string.IsNullOrEmpty(Filtro!.Documento))
                {
                    var task = Presentacion!.PorDocumento(Filtro!);
                    task.Wait();
                    Lista = task.Result;
                }
                // Filtro por Correo
                else if (!string.IsNullOrEmpty(Filtro!.Correo))
                {
                    var task = Presentacion!.PorCorreo(Filtro!);
                    task.Wait();
                    Lista = task.Result;
                }
                else
                {
                    // Usa el refrescar genérico (Listar)
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
