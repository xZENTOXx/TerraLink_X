using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ut_presentacion_impl.Nucleo;

namespace ut_presentacion_impl.Repositorios
{
    [TestClass]
    public class ReservasAplicacionPruebas : BasePruebas
    {
        private IFincasAplicacion fincas = null!;
        private IClientesAplicacion clientes = null!;
        private IReservasAplicacion app = null!;

        [TestInitialize]
        public void Setup()
        {
            fincas = new FincasAplicacion(Cx); fincas.Configurar(SC);
            clientes = new ClientesAplicacion(Cx); clientes.Configurar(SC);
            app = new ReservasAplicacion(Cx); app.Configurar(SC);
        }

        private (Fincas finca, Clientes cliente) CrearFKs()
        {
            var f = fincas.Guardar(EntidadesNucleo.Fincas())!;
            var c = clientes.Guardar(EntidadesNucleo.Clientes())!;
            return (f, c);
        }
        private void LimpiarFKs(Fincas f, Clientes c)
        {
            clientes.Borrar(c);
            fincas.Borrar(f);
        }

        [TestMethod]
        public void Reservas_Guardar_ok()
        {
            var (f, c) = CrearFKs();
            var e = app.Guardar(EntidadesNucleo.Reservas(f.Id, c.Id));
            Assert.IsNotNull(e); Assert.IsTrue(e!.Id > 0);
            app.Borrar(e); LimpiarFKs(f, c);
        }

        [TestMethod]
        public void Reservas_Listar_ok()
        {
            var (f, c) = CrearFKs();
            var temp = app.Guardar(EntidadesNucleo.Reservas(f.Id, c.Id));
            var lista = app.Listar();
            Assert.IsTrue(lista.Count > 0);
            app.Borrar(temp); LimpiarFKs(f, c);
        }

        [TestMethod]
        public void Reservas_Modificar_ok()
        {
            var (f, c) = CrearFKs();
            var e = app.Guardar(EntidadesNucleo.Reservas(f.Id, c.Id))!;
            e.Estado = "Pendiente"; e.Total += 5000;
            var edit = app.Modificar(e);
            Assert.IsNotNull(edit); Assert.AreEqual("Pendiente", edit!.Estado);
            app.Borrar(edit); LimpiarFKs(f, c);
        }

        [TestMethod]
        public void Reservas_Borrar_ok()
        {
            var (f, c) = CrearFKs();
            var e = app.Guardar(EntidadesNucleo.Reservas(f.Id, c.Id))!;
            var borr = app.Borrar(e);
            Assert.IsNotNull(borr);
            LimpiarFKs(f, c);
        }
    }
}
