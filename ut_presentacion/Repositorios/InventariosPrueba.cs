using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class InventariosPrueba
    {
        private readonly IConexion iConexion;
        private List<Inventarios>? lista;
        private Inventarios? entidad;

        public InventariosPrueba()
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
            this.lista = this.iConexion!.Inventarios!.Take(20).ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Inventarios(1);
            this.iConexion!.Inventarios!.Add(this.entidad!);
            this.iConexion!.SaveChanges();
            return this.entidad!.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Cantidad = 9;
            var entry = this.iConexion!.Entry<Inventarios>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Inventarios!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
