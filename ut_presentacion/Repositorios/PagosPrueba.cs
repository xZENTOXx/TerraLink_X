﻿using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class PagosPrueba
    {
        private readonly IConexion iConexion;
        private List<Pagos>? lista;
        private Pagos? entidad;

        public PagosPrueba()
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
            this.lista = this.iConexion!.Pagos!.Take(20).ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            // Reserva 1 existe por seeds
            this.entidad = EntidadesNucleo.Pagos(1);
            this.iConexion!.Pagos!.Add(this.entidad!);
            this.iConexion!.SaveChanges();
            return this.entidad!.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Metodo = "Efectivo";
            var entry = this.iConexion!.Entry<Pagos>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Pagos!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
