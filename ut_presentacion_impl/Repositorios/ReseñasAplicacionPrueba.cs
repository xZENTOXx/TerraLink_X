using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ut_presentacion_impl.Nucleo;
using ut_presentacion_impl.Repositorios;

namespace ut_presentacion_impl.Repositorios
{
    [TestClass]
    public class ReseñasAplicacionPruebas : BasePruebas
    {
        private IFincasAplicacion fincas = null!;
        private IClientesAplicacion clientes = null!;
        private IReseñasAplicacion app = null!;

        [TestInitialize]
        public void Setup()
        {
            fincas = new FincasAplicacion(Cx); fincas.Configurar(SC);
            clientes = new ClientesAplicacion(Cx); clientes.Configurar(SC);
            app = new ReseñasAplicacion(Cx); app.Configurar(SC);
        }

        private (Fincas f, Clientes c) CrearFKs()
        {
            var f = fincas.Guardar(EntidadesNucleo.Fincas())!;
            var c = clientes.Guardar(EntidadesNucleo.Clientes())!;
            return (f, c);
        }
        private void LimpiarFKs(Fincas f, Clientes c)
        {
            clientes.Borrar(c); fincas.Borrar(f);
        }

        [TestMethod]
        public void Reseñas_Guardar_ok()
        {
            var (f, c) = CrearFKs();
            var e = app.Guardar(EntidadesNucleo.Reseñas(f.Id, c.Id));
            Assert.IsNotNull(e); Assert.IsTrue(e!.Id > 0);
            app.Borrar(e); LimpiarFKs(f, c);
        }

        [TestMethod]
        public void Reseñas_Listar_ok()
        {
            var (f, c) = CrearFKs();
            var temp = app.Guardar(EntidadesNucleo.Reseñas(f.Id, c.Id));
            var lista = app.Listar(); Assert.IsTrue(lista.Count > 0);
            app.Borrar(temp); LimpiarFKs(f, c);
        }

        [TestMethod]
        public void Reseñas_Modificar_ok()
        {
            var (f, c) = CrearFKs();
            var e = app.Guardar(EntidadesNucleo.Reseñas(f.Id, c.Id))!;
            e.Calificacion = 4; e.Comentario = "EDIT";
            var edit = app.Modificar(e);
            Assert.IsNotNull(edit); Assert.AreEqual(4, edit!.Calificacion);
            app.Borrar(edit); LimpiarFKs(f, c);
        }

        [TestMethod]
        public void Reseñas_Borrar_ok()
        {
            var (f, c) = CrearFKs();
            var e = app.Guardar(EntidadesNucleo.Reseñas(f.Id, c.Id))!;
            var borr = app.Borrar(e); Assert.IsNotNull(borr);
            LimpiarFKs(f, c);
        }
    }
}
