using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class AuditoriasPrueba
    {
        private readonly IConexion iConexion;
        private List<Auditorias>? lista;
        private Auditorias? entidad;

        public AuditoriasPrueba()
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
            this.lista = this.iConexion!.Auditorias!.Take(20).ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Auditorias(1);
            this.iConexion!.Auditorias!.Add(this.entidad!);
            this.iConexion!.SaveChanges();
            return this.entidad!.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.TablaAfectada = "TEST_TABLA";
            var entry = this.iConexion!.Entry<Auditorias>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Auditorias!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
