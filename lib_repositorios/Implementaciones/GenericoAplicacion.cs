using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    // Clase genérica de aplicación para cualquier entidad T.
    // Esta capa se encarga de la lógica de acceso a datos usando Entity Framework,
    // pero de forma reutilizable para todas las tablas.
    public class GenericoAplicacion<T> : IGenericoAplicacion<T> where T : class, IEntidad
    {
        // Conexión hacia la base de datos (DbContext)

        public readonly IConexion IConexion;

        // Constructor: recibe el DbContext por inyección
        // El constructor recibe una implementación de IConexion (nuestro DbContext)
        // y la guarda para usarla en los métodos CRUD.
        public GenericoAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        // Cambia la string de conexión en tiempo de ejecución
        // Configura la cadena de conexión que usará Entity Framework.
        // El valor viene desde el secrets.json y se inyecta en tiempo de ejecución.
        public void Configurar(string StringConexion)
        {
            this.IConexion.StringConexion = StringConexion;
        }

        // ============================================================
        // LISTAR
        // Método genérico para listar registros de cualquier entidad T.
        // Aquí está la "magia" que carga automáticamente las relaciones de navegación.
        public List<T> Listar()
        {
            // Convertir la conexión a DbContext
            // Convertimos la conexión genérica a DbContext para poder usar Set<T>() e Include().
            var db = (this.IConexion as DbContext)!;

            // Obtener el DbSet correspondiente a la entidad T
            // Empezamos el query base sobre el DbSet de la entidad T (por ejemplo: Reservas, Fincas, etc.).
            IQueryable<T> query = db.Set<T>();


            // Usamos reflexión para buscar TODAS las propiedades de la entidad T
            // que empiecen por "_" (por convención: _Finca, _Cliente, _Empleado, etc.).
            // Esas propiedades representan las relaciones de navegación.
            var propsNavegacion = typeof(T)
                .GetProperties()
                .Where(p => p.Name.StartsWith("_"))
                .ToList();

            // Por cada propiedad de navegación encontrada, agregamos un Include dinámico.
            // Esto le dice a Entity Framework: "cuando traigas T, también trae esta relación".
            foreach (var prop in propsNavegacion)
            {
                // Include recibe el nombre de la propiedad de navegación como string.
                // Ejemplo: Include("_Finca"), Include("_Cliente").
                query = query.Include(prop.Name);
            }

            // Devolver máximo 200 registros
            return query.Take(200).ToList();
        }

        // ============================================================
        // GUARDAR
        // ============================================================
        public T? Guardar(T? entidad)
        {
            // Si la entidad viene nula, no hacemos nada.
            if (entidad == null) return null;

            // Insertar en la BD
            // Agregamos la entidad al contexto para marcarla como "pendiente de insert".
            (this.IConexion as DbContext)!.Add(entidad);
            this.IConexion.SaveChanges();

            // Registrar auditoría
            RegistrarAuditoria("INSERTAR", typeof(T).Name, entidad.Id);
            // Devolvemos la entidad que se acaba de guardar (ya con Id si es identity).
            return entidad;
        }

        // ============================================================
        // MODIFICAR
        // ============================================================
        public T? Modificar(T? entidad)
        {
            // Si la entidad viene nula, salimos.
            if (entidad == null) return null;

            // Obtenemos la entrada de seguimiento de EF para esa entidad.
            // Marcar como modificada
            var entry = (this.IConexion as DbContext)!.Entry(entidad);
            // Marcamos la entidad como "Modified" para que EF genere un UPDATE.
            entry.State = EntityState.Modified;

            // Guardar cambios
            this.IConexion.SaveChanges();

            // Registrar auditoría
            RegistrarAuditoria("MODIFICAR", typeof(T).Name, entidad.Id);
            // Devolvemos la entidad modificada.
            return entidad;
        }

        // ============================================================
        // BORRAR
        // ============================================================
        public T? Borrar(T? entidad)
        {
            // Si la entidad viene nula, no hacemos nada.
            if (entidad == null) return null;

            // Eliminar de la BD
            // Marcamos la entidad para eliminación.
            (this.IConexion as DbContext)!.Remove(entidad);
            // Aplicamos los cambios en la base de datos (DELETE).
            this.IConexion.SaveChanges();

            // Registrar auditoría
            RegistrarAuditoria("BORRAR", typeof(T).Name, entidad.Id);

            return entidad;
        }

        // ============================================================
        // AUDITORÍA
        // ============================================================
        protected void RegistrarAuditoria(string accion, string tabla, int idRegistro)
        {
            try
            {
                // Crear registro de auditoría
                var auditoria = new Auditorias
                {
                    Usuario = "admin",                // Usuario fijo (no hay login con BD, en un futuro la habrá)
                    Accion = accion,            // Acción realizada
                    TablaAfectada = tabla,      // Nombre de la tabla
                    IdRegistroAfectado = idRegistro,
                    Fecha = DateTime.Now
                };

                // Guardar en la tabla Auditorias
                IConexion!.Auditorias!.Add(auditoria);
                IConexion.SaveChanges();
            }
            catch
            {
                // Nunca lanzar excepción para no romper operaciones CRUD
            }
        }
    }
}
