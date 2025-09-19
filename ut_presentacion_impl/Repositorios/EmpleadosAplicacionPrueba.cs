using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ut_presentacion_impl.Nucleo;
using ut_presentacion_impl.Repositorios;

namespace ut_presentacion_impl.Repositorios
{
    [TestClass]
    public class EmpleadosAplicacionPruebas : BasePruebas
    {
        private IEmpleadosAplicacion app = null!;

        [TestInitialize]
        public void Setup()
        {
            app = new EmpleadosAplicacion(Cx);
            app.Configurar(SC);
        }

        [TestMethod]
        public void Empleados_Guardar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.Empleados());
            Assert.IsNotNull(e); Assert.IsTrue(e!.Id > 0);
            app.Borrar(e);
        }

        [TestMethod]
        public void Empleados_Listar_ok()
        {
            var temp = app.Guardar(EntidadesNucleo.Empleados());
            var lista = app.Listar();
            Assert.IsTrue(lista.Count > 0);
            app.Borrar(temp);
        }

        [TestMethod]
        public void Empleados_Modificar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.Empleados());
            e!.Cargo = "Soporte";
            var edit = app.Modificar(e);
            Assert.IsNotNull(edit); Assert.AreEqual("Soporte", edit!.Cargo);
            app.Borrar(edit);
        }

        [TestMethod]
        public void Empleados_Borrar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.Empleados());
            var borr = app.Borrar(e);
            Assert.IsNotNull(borr);
        }
    }
}
