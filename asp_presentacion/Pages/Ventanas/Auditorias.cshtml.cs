using asp_presentacion.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_presentacion.Pages.Ventanas
{
    public class AuditoriasModel : GenericoModel<Auditorias, IAuditoriasPresentacion>
    {
        // Filtro ÚNICO: fecha
        [BindProperty]
        public DateTime FiltroFecha { get; set; } = DateTime.Today;

        public AuditoriasModel(IAuditoriasPresentacion presentacion)
            : base(presentacion)
        {
            // Filtro base — solo usamos fecha
            Filtro = new Auditorias
            {
                Fecha = DateTime.Today
            };
        }

        public override void OnPostBtRefrescar()
        {
            try
            {
                ValidarSesion();
                Accion = Enumerables.Ventanas.Listas;

                // FILTRO ÚNICO
                if (FiltroFecha != default)
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

        // Auditorías no permite crear, modificar, ni borrar desde la UI
        public override void OnPostBtNuevo() { }
        public override void OnPostBtModificar(string data) { }
        public override void OnPostBtGuardar() { }
        public override void OnPostBtBorrarVal(string data) { }
        public override void OnPostBtBorrar() { }
    }
}
