using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ut_presentacion_impl.Nucleo;
using ut_presentacion_impl.Repositorios;

namespace ut_presentacion_impl.Repositorios
{
    [TestClass]
    public class AuditoriasAplicacionPruebas : BasePruebas
    {
        private IUsuariosAplicacion usuarios = null!;
        private IAuditoriasAplicacion app = null!;

        [TestInitialize]
        public void Setup()
        {
            usuarios = new UsuariosAplicacion(Cx); usuarios.Configurar(SC);
            app = new AuditoriasAplicacion(Cx); app.Configurar(SC);
        }

        [TestMethod]
        public void Auditorias_Guardar_ok()
        {
            var u = usuarios.Guardar(EntidadesNucleo.Usuarios())!;
            var e = app.Guardar(EntidadesNucleo.Auditorias(u.Id));
            Assert.IsNotNull(e); Assert.IsTrue(e!.Id > 0);
            app.Borrar(e); usuarios.Borrar(u);
        }

        [TestMethod]
        public void Auditorias_Listar_ok()
        {
            var u = usuarios.Guardar(EntidadesNucleo.Usuarios())!;
            var temp = app.Guardar(EntidadesNucleo.Auditorias(u.Id));
            var lista = app.Listar(); Assert.IsTrue(lista.Count > 0);
            app.Borrar(temp); usuarios.Borrar(u);
        }

        [TestMethod]
        public void Auditorias_Modificar_ok()
        {
            var u = usuarios.Guardar(EntidadesNucleo.Usuarios())!;
            var e = app.Guardar(EntidadesNucleo.Auditorias(u.Id))!;
            e.Accion = "EDIT"; e.TablaAfectada = "T";
            var edit = app.Modificar(e);
            Assert.IsNotNull(edit); Assert.AreEqual("EDIT", edit!.Accion);
            app.Borrar(edit); usuarios.Borrar(u);
        }

        [TestMethod]
        public void Auditorias_Borrar_ok()
        {
            var u = usuarios.Guardar(EntidadesNucleo.Usuarios())!;
            var e = app.Guardar(EntidadesNucleo.Auditorias(u.Id))!;
            var borr = app.Borrar(e); Assert.IsNotNull(borr);
            usuarios.Borrar(u);
        }
    }
}
