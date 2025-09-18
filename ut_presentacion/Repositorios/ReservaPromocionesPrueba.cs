using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ReservaPromocionesPrueba
    {
        private readonly IConexion iConexion;
        private List<ReservaPromociones>? lista;
        private ReservaPromociones? entidad;

        public ReservaPromocionesPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.ReservaPromociones!.Take(20).ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.ReservaPromociones(1, 1);
            this.iConexion!.ReservaPromociones!.Add(this.entidad!);
            this.iConexion!.SaveChanges();
            return this.entidad!.Id > 0;
        }

        public bool Borrar()
        {
            this.iConexion!.ReservaPromociones!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
