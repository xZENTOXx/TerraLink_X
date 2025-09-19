using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ut_presentacion_impl.Nucleo;
using ut_presentacion_impl.Repositorios;

namespace ut_presentacion_impl.Repositorios
{
    [TestClass]
    public class ReservaServiciosAplicacionPruebas : BasePruebas
    {
        private IFincasAplicacion fincas = null!;
        private IClientesAplicacion clientes = null!;
        private IReservasAplicacion reservas = null!;
        private IServiciosExtrasAplicacion servicios = null!;
        private IReservaServiciosAplicacion app = null!;

        [TestInitialize]
        public void Setup()
        {
            fincas = new FincasAplicacion(Cx); fincas.Configurar(SC);
            clientes = new ClientesAplicacion(Cx); clientes.Configurar(SC);
            reservas = new ReservasAplicacion(Cx); reservas.Configurar(SC);
            servicios = new ServiciosExtrasAplicacion(Cx); servicios.Configurar(SC);
            app = new ReservaServiciosAplicacion(Cx); app.Configurar(SC);
        }

        private (Fincas f, Clientes c, Reservas r, ServiciosExtras s) CrearFKs()
        {
            var f = fincas.Guardar(EntidadesNucleo.Fincas())!;
            var c = clientes.Guardar(EntidadesNucleo.Clientes())!;
            var r = reservas.Guardar(EntidadesNucleo.Reservas(f.Id, c.Id))!;
            var s = servicios.Guardar(EntidadesNucleo.ServiciosExtras())!;
            return (f, c, r, s);
        }
        private void LimpiarFKs((Fincas f, Clientes c, Reservas r, ServiciosExtras s) x)
        {
            servicios.Borrar(x.s); reservas.Borrar(x.r); clientes.Borrar(x.c); fincas.Borrar(x.f);
        }

        [TestMethod]
        public void ReservaServicios_Guardar_ok()
        {
            var x = CrearFKs();
            var e = app.Guardar(EntidadesNucleo.ReservaServicios(x.r.Id, x.s.Id));
            Assert.IsNotNull(e); Assert.IsTrue(e!.Id > 0);
            app.Borrar(e); LimpiarFKs(x);
        }

        [TestMethod]
        public void ReservaServicios_Listar_ok()
        {
            var x = CrearFKs();
            var temp = app.Guardar(EntidadesNucleo.ReservaServicios(x.r.Id, x.s.Id));
            var lista = app.Listar();
            Assert.IsTrue(lista.Count > 0);
            app.Borrar(temp); LimpiarFKs(x);
        }

        [TestMethod]
        public void ReservaServicios_Modificar_ok()
        {
            var x = CrearFKs();
            var e = app.Guardar(EntidadesNucleo.ReservaServicios(x.r.Id, x.s.Id))!;
            e.Cantidad = 2;
            var edit = app.Modificar(e);
            Assert.IsNotNull(edit); Assert.AreEqual(2, edit!.Cantidad);
            app.Borrar(edit); LimpiarFKs(x);
        }

        [TestMethod]
        public void ReservaServicios_Borrar_ok()
        {
            var x = CrearFKs();
            var e = app.Guardar(EntidadesNucleo.ReservaServicios(x.r.Id, x.s.Id))!;
            var borr = app.Borrar(e); Assert.IsNotNull(borr);
            LimpiarFKs(x);
        }
    }
}
