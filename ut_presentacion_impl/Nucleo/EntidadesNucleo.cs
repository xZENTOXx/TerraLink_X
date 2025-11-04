using lib_dominio.Entidades;

namespace ut_presentacion_impl.Nucleo
{
    public class EntidadesNucleo
    {
        private static string NowStr() => DateTime.Now.ToString("yyyyMMddHHmmss");

        public static Fincas Fincas()
        {
            var ahora = NowStr();
            return new Fincas
            {
                Nombre = "Finca-" + ahora,
                Ubicacion = "Ubic-" + ahora,
                Capacidad = 10,
                Descripcion = "Desc-" + ahora,
                PrecioBase = 120000,
                Estado = true
            };
        }

        public static Clientes Clientes()
        {
            var ahora = NowStr();
            return new Clientes
            {
                Nombre = "Nombre-" + ahora,
                Apellido = "Apellido-" + ahora,
                Correo = $"c{ahora}@mail.com",
                Telefono = "300" + ahora[..7],
                Documento = "DOC-" + ahora
            };
        }

        public static Usuarios Usuarios()
        {
            var ahora = NowStr();
            return new Usuarios
            {
                NombreUsuario = "usr_" + ahora,
                Clave = "clave_" + ahora,
                Rol = "Tester"
            };
        }

        public static Empleados Empleados()
        {
            var ahora = NowStr();
            return new Empleados
            {
                Nombre = "Emp-" + ahora,
                Apellido = "Ape-" + ahora,
                Cargo = "Cargo",
                Telefono = "311" + ahora[..7],
                Correo = $"emp{ahora}@terralink.com"
            };
        }

        public static Reservas Reservas(int fincaId = 1, int clienteId = 1)
        {
            return new Reservas
            {
                FechaInicio = DateTime.Today.AddDays(1),
                FechaFin = DateTime.Today.AddDays(3),
                Estado = "Confirmada",
                Total = 200000,
                Finca = fincaId,
                Cliente = clienteId
            };
        }

        public static Pagos Pagos(int reservaId = 1)
        {
            return new Pagos
            {
                Reserva = reservaId,
                Monto = 100000,
                FechadePago = DateTime.Now,
                Metodo = "Transferencia"
            };
        }

        public static ServiciosExtras ServiciosExtras()
        {
            var ahora = NowStr();
            return new ServiciosExtras
            {
                Nombre = "Serv-" + ahora,
                Precio = 50000,
                Estado = true
            };
        }

        public static ReservaServicios ReservaServicios(int reservaId = 1, int servicioId = 1)
        {
            return new ReservaServicios
            {
                Reserva = reservaId,
                Servicio = servicioId,
                Cantidad = 1
            };
        }

        public static Promociones Promociones()
        {
            var hoy = DateTime.Today;
            return new Promociones
            {
                Nombre = "Promo-" + NowStr(),
                Descuento = 10,
                FechaInicio = hoy,
                FechaFin = hoy.AddDays(10),
                Estado = true
            };
        }

        public static ReservaPromociones ReservaPromociones(int reservaId = 1, int promocionId = 1)
        {
            return new ReservaPromociones
            {
                Reserva = reservaId,
                Promocion = promocionId
            };
        }

        public static Inventarios Inventarios(int fincaId = 1)
        {
            return new Inventarios
            {
                Finca = fincaId,
                Nombre = "Item-" + NowStr(),
                Cantidad = 5,
                Estado = "Bueno"
            };
        }

        public static Mantenimientos Mantenimientos(int fincaId = 1)
        {
            return new Mantenimientos
            {
                Finca = fincaId,
                Descripcion = "Manto-" + NowStr(),
                Costo = 75000,
                Fecha = DateTime.Today,
                Responsable = "Resp"
            };
        }

        public static Tareas Tareas(int empleadoId = 1, int fincaId = 1)
        {
            return new Tareas
            {
                Empleado = empleadoId,
                Finca = fincaId,
                Descripcion = "Tarea-" + NowStr(),
                FechaAsignacion = DateTime.Today,
                Estado = "Pendiente"
            };
        }

        public static Reseñas Reseñas(int fincaId = 1, int clienteId = 1)
        {
            return new Reseñas
            {
                Finca = fincaId,
                Cliente = clienteId,
                Calificacion = 5,
                Comentario = "Ok",
                Fecha = DateTime.Today
            };
        }

        public static Auditorias Auditorias(int usuarioId = 1)
        {
            return new Auditorias
            {
                Usuario = usuarioId,
                Accion = "TEST",
                Fecha = DateTime.Now,
                TablaAfectada = "Nada",
                IdRegistroAfectado = null
            };
        }
    }
}
