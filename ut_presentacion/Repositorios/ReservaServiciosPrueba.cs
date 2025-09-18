using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ReservaServiciosPrueba
    {
        private readonly IConexion iConexion;
        private List<ReservaServicios>? lista;
        private ReservaServicios? entidad;

        public ReservaServiciosPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.ReservaServicios!.Take(20).ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            // Reserva 1 y Servicio 1 existen por seeds
            this.entidad = EntidadesNucleo.ReservaServicios(1, 1);
            this.iConexion!.ReservaServicios!.Add(this.entidad!);
            this.iConexion!.SaveChanges();
            return this.entidad!.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Cantidad = 2;
            var entry = this.iConexion!.Entry<ReservaServicios>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.ReservaServicios!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
