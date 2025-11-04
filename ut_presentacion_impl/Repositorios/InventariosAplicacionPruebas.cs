using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ut_presentacion_impl.Nucleo;
using ut_presentacion_impl.Repositorios;

namespace ut_presentacion_impl.Repositorios
{
    [TestClass]
    public class InventariosAplicacionPruebas : BasePruebas
    {
        private IFincasAplicacion fincas = null!;
        private IInventariosAplicacion app = null!;

        [TestInitialize]
        public void Setup()
        {
            fincas = new FincasAplicacion(Cx); fincas.Configurar(SC);
            app = new InventariosAplicacion(Cx); app.Configurar(SC);
        }

        [TestMethod]
        public void Inventarios_Guardar_ok()
        {
            var f = fincas.Guardar(EntidadesNucleo.Fincas())!;
            var e = app.Guardar(EntidadesNucleo.Inventarios(f.Id));
            Assert.IsNotNull(e); Assert.IsTrue(e!.Id > 0);
            app.Borrar(e); fincas.Borrar(f);
        }

        [TestMethod]
        public void Inventarios_Listar_ok()
        {
            var f = fincas.Guardar(EntidadesNucleo.Fincas())!;
            var temp = app.Guardar(EntidadesNucleo.Inventarios(f.Id));
            var lista = app.Listar();
            Assert.IsTrue(lista.Count > 0);
            app.Borrar(temp); fincas.Borrar(f);
        }

        [TestMethod]
        public void Inventarios_Modificar_ok()
        {
            var f = fincas.Guardar(EntidadesNucleo.Fincas())!;
            var e = app.Guardar(EntidadesNucleo.Inventarios(f.Id))!;
            e.Cantidad += 1; e.Estado = "Regular";
            var edit = app.Modificar(e);
            Assert.IsNotNull(edit); Assert.AreEqual("Regular", edit!.Estado);
            app.Borrar(edit); fincas.Borrar(f);
        }

        [TestMethod]
        public void Inventarios_Borrar_ok()
        {
            var f = fincas.Guardar(EntidadesNucleo.Fincas())!;
            var e = app.Guardar(EntidadesNucleo.Inventarios(f.Id))!;
            var borr = app.Borrar(e); Assert.IsNotNull(borr);
            fincas.Borrar(f);
        }
    }
}
