using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ut_presentacion_impl.Nucleo;
using ut_presentacion_impl.Repositorios;

namespace ut_presentacion_impl.Repositorios
{
    [TestClass]
    public class PagosAplicacionPruebas : BasePruebas
    {
        private IFincasAplicacion fincas = null!;
        private IClientesAplicacion clientes = null!;
        private IReservasAplicacion reservas = null!;
        private IPagosAplicacion app = null!;

        [TestInitialize]
        public void Setup()
        {
            fincas = new FincasAplicacion(Cx); fincas.Configurar(SC);
            clientes = new ClientesAplicacion(Cx); clientes.Configurar(SC);
            reservas = new ReservasAplicacion(Cx); reservas.Configurar(SC);
            app = new PagosAplicacion(Cx); app.Configurar(SC);
        }

        private (Fincas f, Clientes c, Reservas r) CrearReservaBase()
        {
            var f = fincas.Guardar(EntidadesNucleo.Fincas())!;
            var c = clientes.Guardar(EntidadesNucleo.Clientes())!;
            var r = reservas.Guardar(EntidadesNucleo.Reservas(f.Id, c.Id))!;
            return (f, c, r);
        }
        private void LimpiarReservaBase((Fincas f, Clientes c, Reservas r) x)
        {
            reservas.Borrar(x.r);
            clientes.Borrar(x.c);
            fincas.Borrar(x.f);
        }

        [TestMethod]
        public void Pagos_Guardar_ok()
        {
            var x = CrearReservaBase();
            var e = app.Guardar(EntidadesNucleo.Pagos(x.r.Id));
            Assert.IsNotNull(e); Assert.IsTrue(e!.Id > 0);
            app.Borrar(e); LimpiarReservaBase(x);
        }

        [TestMethod]
        public void Pagos_Listar_ok()
        {
            var x = CrearReservaBase();
            var temp = app.Guardar(EntidadesNucleo.Pagos(x.r.Id));
            var lista = app.Listar();
            Assert.IsTrue(lista.Count > 0);
            app.Borrar(temp); LimpiarReservaBase(x);
        }

        [TestMethod]
        public void Pagos_Modificar_ok()
        {
            var x = CrearReservaBase();
            var e = app.Guardar(EntidadesNucleo.Pagos(x.r.Id))!;
            e.Metodo = "Tarjeta"; e.Monto += 1;
            var edit = app.Modificar(e);
            Assert.IsNotNull(edit); Assert.AreEqual("Tarjeta", edit!.Metodo);
            app.Borrar(edit); LimpiarReservaBase(x);
        }

        [TestMethod]
        public void Pagos_Borrar_ok()
        {
            var x = CrearReservaBase();
            var e = app.Guardar(EntidadesNucleo.Pagos(x.r.Id))!;
            var borr = app.Borrar(e);
            Assert.IsNotNull(borr);
            LimpiarReservaBase(x);
        }
    }
}
