using asp_presentacion.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace asp_presentacion.Pages.Ventanas
{
    public class UsuariosModel : GenericoModel<Usuarios, IUsuariosPresentacion>
    {
        public UsuariosModel(IUsuariosPresentacion presentacion)
            : base(presentacion)
        {
            Filtro = new Usuarios
            {
                NombreUsuario = "",
                Clave = "",
                Rol = ""
            };
        }

        public override void OnPostBtRefrescar()
        {
            try
            {
                ValidarSesion();
                Accion = Enumerables.Ventanas.Listas;

                if (!string.IsNullOrEmpty(Filtro!.NombreUsuario))
                {
                    Lista = Presentacion!.PorNombre_Usuario(Filtro).Result;
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

            Actual = new Usuarios
            {
                NombreUsuario = "",
                Clave = "",
                Rol = "Empleado"
            };
        }
    }
}
