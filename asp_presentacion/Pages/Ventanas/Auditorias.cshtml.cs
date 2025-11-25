using asp_presentacion.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_presentacion.Pages.Ventanas
{
    public class AuditoriasModel : GenericoModel<Auditorias, IAuditoriasPresentacion>
    {
        public AuditoriasModel(IAuditoriasPresentacion presentacion)
            : base(presentacion)
        {
            Filtro = new Auditorias
            {
                Accion = ""
            };
        }

        [BindProperty] public int FiltroUsuario { get; set; }
        [BindProperty] public DateTime FiltroFecha { get; set; } = DateTime.Today;

        public override void OnPostBtRefrescar()
        {
            try
            {
                ValidarSesion();
                Accion = Enumerables.Ventanas.Listas;

                // PRIORIDAD DE FILTROS
                if (!string.IsNullOrEmpty(Filtro!.Accion))
                {
                    Lista = Presentacion!.PorAccion(Filtro).Result;
                }
                else if (FiltroUsuario > 0)
                {
                    Lista = Presentacion!.PorUsuario(FiltroUsuario).Result;
                }
                else if (FiltroFecha != default)
                {
                    Lista = Presentacion!.PorFecha(FiltroFecha).Result;
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

        public override void OnPostBtNuevo() { }
        public override void OnPostBtModificar(string data) { }
        public override void OnPostBtGuardar() { }
        public override void OnPostBtBorrarVal(string data) { }
        public override void OnPostBtBorrar() { }
    }
}
