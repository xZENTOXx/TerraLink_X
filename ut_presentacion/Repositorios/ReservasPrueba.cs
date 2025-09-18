using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ReservasPrueba
    {
        private readonly IConexion iConexion;
        private List<Reservas>? lista;
        private Reservas? entidad;

        public ReservasPrueba()
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
            this.lista = this.iConexion!.Reservas!.Take(20).ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            // Usa FKs existentes (1..)
            this.entidad = EntidadesNucleo.Reservas(1, 1);
            this.iConexion!.Reservas!.Add(this.entidad!);
            this.iConexion!.SaveChanges();
            return this.entidad!.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Estado = "Pendiente";
            var entry = this.iConexion!.Entry<Reservas>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Reservas!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
