using Microsoft.EntityFrameworkCore;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    // Clase genérica de aplicación para cualquier entidad T.
    // Esta capa se encarga de la lógica de acceso a datos usando Entity Framework,
    // pero de forma reutilizable para todas las tablas.
    public class GenericoAplicacion<T> : IGenericoAplicacion<T> where T : class
    {
        // Referencia a la conexión (DbContext) que usamos para hablar con la base de datos.
        public readonly IConexion IConexion;

        // El constructor recibe una implementación de IConexion (nuestro DbContext)
        // y la guarda para usarla en los métodos CRUD.
        public GenericoAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        // Configura la cadena de conexión que usará Entity Framework.
        // El valor viene desde el secrets.json y se inyecta en tiempo de ejecución.
        public void Configurar(string StringConexion)
        {
            this.IConexion.StringConexion = StringConexion;
        }

        // Método genérico para listar registros de cualquier entidad T.
        // Aquí está la "magia" que carga automáticamente las relaciones de navegación.
        public List<T> Listar()
        {
            // Convertimos la conexión genérica a DbContext para poder usar Set<T>() e Include().
            var db = (this.IConexion as DbContext)!;

            // Empezamos el query base sobre el DbSet de la entidad T (por ejemplo: Reservas, Fincas, etc.).
            IQueryable<T> query = db.Set<T>();

            // Usamos reflexión para buscar TODAS las propiedades de la entidad T
            // que empiecen por "_" (por convención: _Finca, _Cliente, _Empleado, etc.).
            // Esas propiedades representan las relaciones de navegación.
            var propiedadesNavegacion = typeof(T)
                .GetProperties()
                .Where(p => p.Name.StartsWith("_"))
                .ToList();

            // Por cada propiedad de navegación encontrada, agregamos un Include dinámico.
            // Esto le dice a Entity Framework: "cuando traigas T, también trae esta relación".
            foreach (var prop in propiedadesNavegacion)
            {
                // Include recibe el nombre de la propiedad de navegación como string.
                // Ejemplo: Include("_Finca"), Include("_Cliente").
                query = query.Include(prop.Name);
            }

            // Ejecutamos el query, limitando a 200 registros para no traer datos infinitos.
            // Al devolver la lista, todas las relaciones (_Finca, _Cliente, etc.) ya vienen cargadas.
            return query.Take(200).ToList();
        }

        // Guarda una nueva entidad en la base de datos.
        // Aplica para cualquier T (Reservas, Clientes, Fincas, etc.).
        public T? Guardar(T? entidad)
        {
            // Si la entidad viene nula, no hacemos nada.
            if (entidad == null) return null;

            // Agregamos la entidad al contexto para marcarla como "pendiente de insert".
            (this.IConexion as DbContext)!.Add(entidad);

            // Guardamos los cambios en la base de datos.
            this.IConexion.SaveChanges();

            // Devolvemos la entidad que se acaba de guardar (ya con Id si es identity).
            return entidad;
        }

        // Modifica una entidad existente en la base de datos.
        public T? Modificar(T? entidad)
        {
            // Si la entidad viene nula, salimos.
            if (entidad == null) return null;

            // Obtenemos la entrada de seguimiento de EF para esa entidad.
            var entry = (this.IConexion as DbContext)!.Entry(entidad);

            // Marcamos la entidad como "Modified" para que EF genere un UPDATE.
            entry.State = EntityState.Modified;

            // Guardamos cambios en la base de datos.
            this.IConexion.SaveChanges();

            // Devolvemos la entidad modificada.
            return entidad;
        }

        // Borra una entidad de la base de datos.
        public T? Borrar(T? entidad)
        {
            // Si la entidad viene nula, no hacemos nada.
            if (entidad == null) return null;

            // Marcamos la entidad para eliminación.
            (this.IConexion as DbContext)!.Remove(entidad);

            // Aplicamos los cambios en la base de datos (DELETE).
            this.IConexion.SaveChanges();

            // Devolvemos la entidad que acabamos de borrar (por si se quiere mostrar algo en pantalla).
            return entidad;
        }
    }
}
