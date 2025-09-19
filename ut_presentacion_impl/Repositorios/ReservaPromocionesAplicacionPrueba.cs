using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ut_presentacion_impl.Nucleo;

namespace ut_presentacion_impl.Repositorios
{
    [TestClass]
    public class ReservaPromocionesAplicacionPruebas : BasePruebas
    {
        private IFincasAplicacion fincas = null!;
        private IClientesAplicacion clientes = null!;
        private IReservasAplicacion reservas = null!;
        private IPromocionesAplicacion promos = null!;
        private IReservaPromocionesAplicacion app = null!;

        [TestInitialize]
        public void Setup()
        {
            fincas = new FincasAplicacion(Cx); fincas.Configurar(SC);
            clientes = new ClientesAplicacion(Cx); clientes.Configurar(SC);
            reservas = new ReservasAplicacion(Cx); reservas.Configurar(SC);
            promos = new PromocionesAplicacion(Cx); promos.Configurar(SC);
            app = new ReservaPromocionesAplicacion(Cx); app.Configurar(SC);
        }

        private (Fincas f, Clientes c, Reservas r, Promociones p) CrearFKs()
        {
            var f = fincas.Guardar(EntidadesNucleo.Fincas())!;
            var c = clientes.Guardar(EntidadesNucleo.Clientes())!;
            var r = reservas.Guardar(EntidadesNucleo.Reservas(f.Id, c.Id))!;
            var p = promos.Guardar(EntidadesNucleo.Promociones())!;
            return (f, c, r, p);
        }
        private void LimpiarFKs((Fincas f, Clientes c, Reservas r, Promociones p) x)
        {
            app.Listar(); // no hace daño; a veces ayuda a “tocar” la tabla
            promos.Borrar(x.p); reservas.Borrar(x.r); clientes.Borrar(x.c); fincas.Borrar(x.f);
        }

        [TestMethod]
        public void ReservaPromociones_Guardar_ok()
        {
            var x = CrearFKs();
            var e = app.Guardar(EntidadesNucleo.ReservaPromociones(x.r.Id, x.p.Id));
            Assert.IsNotNull(e); Assert.IsTrue(e!.Id > 0);
            app.Borrar(e); LimpiarFKs(x);
        }

        [TestMethod]
        public void ReservaPromociones_Listar_ok()
        {
            var x = CrearFKs();
            var temp = app.Guardar(EntidadesNucleo.ReservaPromociones(x.r.Id, x.p.Id));
            var lista = app.Listar();
            Assert.IsTrue(lista.Count > 0);
            app.Borrar(temp); LimpiarFKs(x);
        }

        [TestMethod]
        public void ReservaPromociones_Borrar_ok()
        {
            var x = CrearFKs();
            var e = app.Guardar(EntidadesNucleo.ReservaPromociones(x.r.Id, x.p.Id))!;
            var borr = app.Borrar(e); Assert.IsNotNull(borr);
            LimpiarFKs(x);
        }

        // Sin Modificar porque el modelo tiene 2 FKs + 1 Id (poco que editar básico)
    }
}
