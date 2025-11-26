using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //          RESERVAS   
            modelBuilder.Entity<Reservas>()
                .HasOne(r => r._Finca)
                .WithMany()
                .HasForeignKey(r => r.Finca)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservas>()
                .HasOne(r => r._Cliente)
                .WithMany()
                .HasForeignKey(r => r.Cliente)
                .OnDelete(DeleteBehavior.Cascade);

            //              PAGOS 
            modelBuilder.Entity<Pagos>()
                .HasOne(p => p._Reserva)
                .WithMany()
                .HasForeignKey(p => p.Reserva)
                .OnDelete(DeleteBehavior.Cascade);

            //          INVENTARIOS 
            modelBuilder.Entity<Inventarios>()
                .HasOne(i => i._Finca)
                .WithMany()
                .HasForeignKey(i => i.Finca)
                .OnDelete(DeleteBehavior.Cascade);

            //       MANTENIMIENTOS 
            modelBuilder.Entity<Mantenimientos>()
                .HasOne(m => m._Finca)
                .WithMany()
                .HasForeignKey(m => m.Finca)
                .OnDelete(DeleteBehavior.Cascade);

            //          RESEÑAS 
            modelBuilder.Entity<Reseñas>()
                .HasOne(r => r._Finca)
                .WithMany()
                .HasForeignKey(r => r.Finca)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reseñas>()
                .HasOne(r => r._Cliente)
                .WithMany()
                .HasForeignKey(r => r.Cliente)
                .OnDelete(DeleteBehavior.Cascade);

            //       RESERVA SERVICIOS 
            modelBuilder.Entity<ReservaServicios>()
                .HasOne(rs => rs._Reserva)
                .WithMany()
                .HasForeignKey(rs => rs.Reserva)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReservaServicios>()
                .HasOne(rs => rs._Servicio)
                .WithMany()
                .HasForeignKey(rs => rs.Servicio)
                .OnDelete(DeleteBehavior.Cascade);

            //      RESERVA PROMOCIONES 
            modelBuilder.Entity<ReservaPromociones>()
                .HasOne(rp => rp._Reserva)
                .WithMany()
                .HasForeignKey(rp => rp.Reserva)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReservaPromociones>()
                .HasOne(rp => rp._Promocion)
                .WithMany()
                .HasForeignKey(rp => rp.Promocion)
                .OnDelete(DeleteBehavior.Cascade);

            //          TAREAS 
            modelBuilder.Entity<Tareas>()
                .HasOne(t => t._Empleado)
                .WithMany()
                .HasForeignKey(t => t.Empleado)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tareas>()
                .HasOne(t => t._Finca)
                .WithMany()
                .HasForeignKey(t => t.Finca)
                .OnDelete(DeleteBehavior.Cascade);

            //        AUDITORIAS 
            modelBuilder.Entity<Auditorias>()
                .HasOne(a => a._Usuario)
                .WithMany()
                .HasForeignKey(a => a.Usuario)
                .OnDelete(DeleteBehavior.Restrict);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
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
