using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ut_presentacion_impl.Nucleo;
using ut_presentacion_impl.Repositorios;

namespace ut_presentacion_impl.Repositorios
{
    [TestClass]
    public class FincasAplicacionPruebas : BasePruebas
    {
        private IFincasAplicacion app = null!;

        [TestInitialize]
        public void Setup()
        {
            app = new FincasAplicacion(Cx);
            app.Configurar(SC);
        }

        [TestMethod]
        public void Fincas_Guardar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.Fincas());
            Assert.IsNotNull(e); Assert.IsTrue(e!.Id > 0);
            app.Borrar(e);
        }

        [TestMethod]
        public void Fincas_Listar_ok()
        {
            var temp = app.Guardar(EntidadesNucleo.Fincas());
            var lista = app.Listar();
            Assert.IsTrue(lista.Count > 0);
            app.Borrar(temp);
        }

        [TestMethod]
        public void Fincas_Modificar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.Fincas());
            e!.Descripcion = "Desc-EDIT"; e.PrecioBase += 1000;
            var edit = app.Modificar(e);
            Assert.IsNotNull(edit); Assert.AreEqual("Desc-EDIT", edit!.Descripcion);
            app.Borrar(edit);
        }

        [TestMethod]
        public void Fincas_Borrar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.Fincas());
            var borr = app.Borrar(e);
            Assert.IsNotNull(borr);
        }
    }
}
