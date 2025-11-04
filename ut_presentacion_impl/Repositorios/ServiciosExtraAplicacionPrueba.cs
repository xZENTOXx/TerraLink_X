using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ut_presentacion_impl.Nucleo;
using ut_presentacion_impl.Repositorios;

namespace ut_presentacion_impl.Repositorios
{
    [TestClass]
    public class ServiciosExtrasAplicacionPruebas : BasePruebas
    {
        private IServiciosExtrasAplicacion app = null!;

        [TestInitialize]
        public void Setup()
        {
            app = new ServiciosExtrasAplicacion(Cx);
            app.Configurar(SC);
        }

        [TestMethod]
        public void ServiciosExtras_Guardar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.ServiciosExtras());
            Assert.IsNotNull(e); Assert.IsTrue(e!.Id > 0);
            app.Borrar(e);
        }

        [TestMethod]
        public void ServiciosExtras_Listar_ok()
        {
            var temp = app.Guardar(EntidadesNucleo.ServiciosExtras());
            var lista = app.Listar();
            Assert.IsTrue(lista.Count > 0);
            app.Borrar(temp);
        }

        [TestMethod]
        public void ServiciosExtras_Modificar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.ServiciosExtras())!;
            e.Precio += 1000;
            var edit = app.Modificar(e);
            Assert.IsNotNull(edit); Assert.IsTrue(edit!.Precio >= e.Precio);
            app.Borrar(edit);
        }

        [TestMethod]
        public void ServiciosExtras_Borrar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.ServiciosExtras())!;
            var borr = app.Borrar(e);
            Assert.IsNotNull(borr);
        }
    }
}
