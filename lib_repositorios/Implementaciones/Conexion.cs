using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrWhiteSpace(this.StringConexion))
                throw new InvalidOperationException("Cadena de conexión no configurada.");

            optionsBuilder.UseSqlServer(this.StringConexion!);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Fincas>? Fincas { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Reservas>? Reservas { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Mantenimientos>? Mantenimientos { get; set; }
        public DbSet<ServiciosExtras>? ServiciosExtras { get; set; }
        public DbSet<ReservaServicios>? ReservaServicios { get; set; }
        public DbSet<Inventarios>? Inventarios { get; set; }
        public DbSet<Promociones>? Promociones { get; set; }
        public DbSet<ReservaPromociones>? ReservaPromociones { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Tareas>? Tareas { get; set; }
        public DbSet<Reseñas>? Reseñas { get; set; }
        public DbSet<Auditorias>? Auditorias { get; set; }
    }
}
