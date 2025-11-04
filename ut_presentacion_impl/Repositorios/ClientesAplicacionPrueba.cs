using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ut_presentacion_impl.Nucleo;

namespace ut_presentacion_impl.Repositorios
{
    [TestClass]
    public class ClientesAplicacionPruebas : BasePruebas
    {
        private IClientesAplicacion app = null!;

        [TestInitialize]
        public void Setup()
        {
            app = new ClientesAplicacion(Cx);
            app.Configurar(SC);
        }

        [TestMethod]
        public void Clientes_Guardar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.Clientes());
            Assert.IsNotNull(e); Assert.IsTrue(e!.Id > 0);
            app.Borrar(e);
        }

        [TestMethod]
        public void Clientes_Listar_ok()
        {
            var temp = app.Guardar(EntidadesNucleo.Clientes());
            var lista = app.Listar();
            Assert.IsTrue(lista.Count > 0);
            app.Borrar(temp);
        }

        [TestMethod]
        public void Clientes_Modificar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.Clientes());
            e!.Telefono = "3000000000";
            var edit = app.Modificar(e);
            Assert.IsNotNull(edit); Assert.AreEqual("3000000000", edit!.Telefono);
            app.Borrar(edit);
        }

        [TestMethod]
        public void Clientes_Borrar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.Clientes());
            var borr = app.Borrar(e);
            Assert.IsNotNull(borr);
        }
    }
}
