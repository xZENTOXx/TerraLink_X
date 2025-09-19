using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ut_presentacion_impl.Nucleo;
using ut_presentacion_impl.Repositorios;

namespace ut_presentacion_impl.Repositorios
{
    [TestClass]
    public class MantenimientosAplicacionPruebas : BasePruebas
    {
        private IFincasAplicacion fincas = null!;
        private IMantenimientosAplicacion app = null!;

        [TestInitialize]
        public void Setup()
        {
            fincas = new FincasAplicacion(Cx); fincas.Configurar(SC);
            app = new MantenimientosAplicacion(Cx); app.Configurar(SC);
        }

        [TestMethod]
        public void Mantenimientos_Guardar_ok()
        {
            var f = fincas.Guardar(EntidadesNucleo.Fincas())!;
            var e = app.Guardar(EntidadesNucleo.Mantenimientos(f.Id));
            Assert.IsNotNull(e); Assert.IsTrue(e!.Id > 0);
            app.Borrar(e); fincas.Borrar(f);
        }

        [TestMethod]
        public void Mantenimientos_Listar_ok()
        {
            var f = fincas.Guardar(EntidadesNucleo.Fincas())!;
            var temp = app.Guardar(EntidadesNucleo.Mantenimientos(f.Id));
            var lista = app.Listar(); Assert.IsTrue(lista.Count > 0);
            app.Borrar(temp); fincas.Borrar(f);
        }

        [TestMethod]
        public void Mantenimientos_Modificar_ok()
        {
            var f = fincas.Guardar(EntidadesNucleo.Fincas())!;
            var e = app.Guardar(EntidadesNucleo.Mantenimientos(f.Id))!;
            e.Costo += 1000; e.Responsable = "Resp-EDIT";
            var edit = app.Modificar(e);
            Assert.IsNotNull(edit); Assert.AreEqual("Resp-EDIT", edit!.Responsable);
            app.Borrar(edit); fincas.Borrar(f);
        }

        [TestMethod]
        public void Mantenimientos_Borrar_ok()
        {
            var f = fincas.Guardar(EntidadesNucleo.Fincas())!;
            var e = app.Guardar(EntidadesNucleo.Mantenimientos(f.Id))!;
            var borr = app.Borrar(e); Assert.IsNotNull(borr);
            fincas.Borrar(f);
        }
    }
}
