using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ut_presentacion_impl.Nucleo;

namespace ut_presentacion_impl.Repositorios
{
    [TestClass]
    public class TareasAplicacionPruebas : BasePruebas
    {
        private IEmpleadosAplicacion empleados = null!;
        private IFincasAplicacion fincas = null!;
        private ITareasAplicacion app = null!;

        [TestInitialize]
        public void Setup()
        {
            empleados = new EmpleadosAplicacion(Cx); empleados.Configurar(SC);
            fincas = new FincasAplicacion(Cx); fincas.Configurar(SC);
            app = new TareasAplicacion(Cx); app.Configurar(SC);
        }

        private (Empleados emp, Fincas fin) CrearFKs()
        {
            var emp = empleados.Guardar(EntidadesNucleo.Empleados())!;
            var fin = fincas.Guardar(EntidadesNucleo.Fincas())!;
            return (emp, fin);
        }
        private void LimpiarFKs((Empleados emp, Fincas fin) x)
        {
            empleados.Borrar(x.emp); fincas.Borrar(x.fin);
        }

        [TestMethod]
        public void Tareas_Guardar_ok()
        {
            var x = CrearFKs();
            var e = app.Guardar(EntidadesNucleo.Tareas(x.emp.Id, x.fin.Id));
            Assert.IsNotNull(e); Assert.IsTrue(e!.Id > 0);
            app.Borrar(e); LimpiarFKs(x);
        }

        [TestMethod]
        public void Tareas_Listar_ok()
        {
            var x = CrearFKs();
            var temp = app.Guardar(EntidadesNucleo.Tareas(x.emp.Id, x.fin.Id));
            var lista = app.Listar(); Assert.IsTrue(lista.Count > 0);
            app.Borrar(temp); LimpiarFKs(x);
        }

        [TestMethod]
        public void Tareas_Modificar_ok()
        {
            var x = CrearFKs();
            var e = app.Guardar(EntidadesNucleo.Tareas(x.emp.Id, x.fin.Id))!;
            e.Estado = "Asignada";
            var edit = app.Modificar(e);
            Assert.IsNotNull(edit); Assert.AreEqual("Asignada", edit!.Estado);
            app.Borrar(edit); LimpiarFKs(x);
        }

        [TestMethod]
        public void Tareas_Borrar_ok()
        {
            var x = CrearFKs();
            var e = app.Guardar(EntidadesNucleo.Tareas(x.emp.Id, x.fin.Id))!;
            var borr = app.Borrar(e); Assert.IsNotNull(borr);
            LimpiarFKs(x);
        }
    }
}
