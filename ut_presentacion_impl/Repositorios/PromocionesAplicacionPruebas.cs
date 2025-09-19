using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ut_presentacion_impl.Nucleo;

namespace ut_presentacion_impl.Repositorios
{
    [TestClass]
    public class PromocionesAplicacionPruebas : BasePruebas
    {
        private IPromocionesAplicacion app = null!;

        [TestInitialize]
        public void Setup()
        {
            app = new PromocionesAplicacion(Cx);
            app.Configurar(SC);
        }

        [TestMethod]
        public void Promociones_Guardar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.Promociones());
            Assert.IsNotNull(e); Assert.IsTrue(e!.Id > 0);
            app.Borrar(e);
        }

        [TestMethod]
        public void Promociones_Listar_ok()
        {
            var temp = app.Guardar(EntidadesNucleo.Promociones());
            var lista = app.Listar();
            Assert.IsTrue(lista.Count > 0);
            app.Borrar(temp);
        }

        [TestMethod]
        public void Promociones_Modificar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.Promociones())!;
            e.Descuento += 1;
            var edit = app.Modificar(e);
            Assert.IsNotNull(edit); Assert.IsTrue(edit!.Descuento >= e.Descuento);
            app.Borrar(edit);
        }

        [TestMethod]
        public void Promociones_Borrar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.Promociones())!;
            var borr = app.Borrar(e);
            Assert.IsNotNull(borr);
        }
    }
}
