using asp_presentacion.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_presentacion.Pages.Ventanas
{
    public class InventariosModel : GenericoModel<Inventarios, IInventariosPresentacion>
    {
        [BindProperty]
        public List<Fincas>? ListaFincas { get; set; }

        public InventariosModel(IInventariosPresentacion presentacion)
            : base(presentacion)
        {
            Filtro = new Inventarios
            {
                Nombre = "",
                Finca = 0
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

                // FILTRAR POR FINCA
                if (Filtro!.Finca != 0)
                {
                    var lista = Presentacion!.Listar().Result;
                    Lista = lista.Where(x => x.Finca == Filtro.Finca).ToList();
                }
                // FILTRAR POR NOMBRE
                else if (!string.IsNullOrEmpty(Filtro!.Nombre))
                {
                    var lista = Presentacion!.PorNombre(Filtro!).Result;
                    Lista = lista;
                }
                else
                {
                    base.OnPostBtRefrescar();
                }
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

            Actual = new Inventarios
            {
                Nombre = "",
                Cantidad = 0,
                Estado = "Bueno",
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
