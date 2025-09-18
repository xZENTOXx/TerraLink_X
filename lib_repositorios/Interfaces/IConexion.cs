using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Fincas>? Fincas { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Reservas>? Reservas { get; set; }
        DbSet<Pagos>? Pagos { get; set; }
        DbSet<Usuarios>? Usuarios { get; set; }
        DbSet<Mantenimientos>? Mantenimientos { get; set; }
        DbSet<ServiciosExtras>? ServiciosExtras { get; set; }
        DbSet<ReservaServicios>? ReservaServicios { get; set; }
        DbSet<Inventarios>? Inventarios { get; set; }
        DbSet<Promociones>? Promociones { get; set; }
        DbSet<ReservaPromociones>? ReservaPromociones { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Tareas>? Tareas { get; set; }
        DbSet<Reseñas>? Reseñas { get; set; }
        DbSet<Auditorias>? Auditorias { get; set; }
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
