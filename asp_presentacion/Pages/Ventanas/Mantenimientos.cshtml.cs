using asp_presentacion.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_presentacion.Pages.Ventanas
{
    public class MantenimientosModel : GenericoModel<Mantenimientos, IMantenimientosPresentacion>
    {
        [BindProperty]
        public List<Fincas>? ListaFincas { get; set; }

        public MantenimientosModel(IMantenimientosPresentacion presentacion)
            : base(presentacion)
        {
            Filtro = new Mantenimientos
            {
                Finca = 0,
                Fecha = DateTime.Today,
                Responsable = "",
                Descripcion = "",  
                Costo = 0           
            };

        }

        public override void OnGet()
        {
            LoadFincas();
            base.OnGet();
        }

        public override void OnPostBtRefrescar()
        {
            try
            {
                ValidarSesion();
                LoadFincas();
                Accion = Enumerables.Ventanas.Listas;

                // FILTRAR POR FECHA
                if (Filtro!.Fecha != default)
                {
                    Lista = Presentacion!.PorFecha(Filtro).Result;
                }
                // FILTRAR POR RESPONSABLE
                else if (!string.IsNullOrEmpty(Filtro!.Responsable))
                {
                    Lista = Presentacion!.PorResponsable(Filtro).Result;
                }
                // FILTRAR POR FINCA
                else if (Filtro.Finca != 0)
                {
                    var data = Presentacion!.Listar().Result;
                    Lista = data.Where(x => x.Finca == Filtro.Finca).ToList();
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
            LoadFincas();

            Actual = new Mantenimientos
            {
                Descripcion = "",
                Costo = 0,
                Fecha = DateTime.Today,
                Responsable = "",
                Finca = 0
            };
        }

        private void LoadFincas()
        {
            var t = Presentacion!.ListarFincas();
            t.Wait();
            ListaFincas = t.Result;
        }
    }
}
