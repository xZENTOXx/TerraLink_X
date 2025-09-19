using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion_impl.Nucleo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ut_presentacion_impl.Repositorios
{
    public abstract class BasePruebas
    {
        protected IConexion Cx = new Conexion();
        protected string SC => Configuracion.ObtenerValor("StringConexion");

        [TestInitialize]
        public void BaseInit()
        {
            Cx.StringConexion = SC;
        }
    }
}