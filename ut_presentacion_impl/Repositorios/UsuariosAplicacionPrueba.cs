using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ut_presentacion_impl.Nucleo;
using ut_presentacion_impl.Repositorios;

namespace ut_presentacion_impl.Repositorios
{
    [TestClass]
    public class UsuariosAplicacionPruebas : BasePruebas
    {
        private IUsuariosAplicacion app = null!;

        [TestInitialize]
        public void Setup()
        {
            app = new UsuariosAplicacion(Cx);
            app.Configurar(SC);
        }

        [TestMethod]
        public void Usuarios_Guardar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.Usuarios());
            Assert.IsNotNull(e); Assert.IsTrue(e!.Id > 0);
            app.Borrar(e);
        }

        [TestMethod]
        public void Usuarios_Listar_ok()
        {
            var temp = app.Guardar(EntidadesNucleo.Usuarios());
            var lista = app.Listar();
            Assert.IsTrue(lista.Count > 0);
            app.Borrar(temp);
        }

        [TestMethod]
        public void Usuarios_Modificar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.Usuarios());
            e!.Rol = "Admin";
            var edit = app.Modificar(e);
            Assert.IsNotNull(edit); Assert.AreEqual("Admin", edit!.Rol);
            app.Borrar(edit);
        }

        [TestMethod]
        public void Usuarios_Borrar_ok()
        {
            var e = app.Guardar(EntidadesNucleo.Usuarios());
            var borr = app.Borrar(e);
            Assert.IsNotNull(borr);
        }
    }
}
