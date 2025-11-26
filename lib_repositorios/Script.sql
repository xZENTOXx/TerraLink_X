/* 
   - Creacion BD db_TerraLink
   - Creacion 15 tablas con menos de 10 campos cada una
   - Insertar 5 registros por tabla
 */

--  Descomentar si se desea eliminar la base de datos existente en prueba
-- IF DB_ID('db_TerraLink') IS NOT NULL DROP DATABASE db_TerraLink;
-- GO

-- 1) Base de datos y uso
IF DB_ID('db_TerraLink') IS NULL
    CREATE DATABASE db_TerraLink;
GO
USE db_TerraLink;
GO


/* 2) TABLAS (15) */

-- 1. Fincas
CREATE TABLE dbo.Fincas(
 [Id] INT IDENTITY(1,1) PRIMARY KEY,
 [Nombre] NVARCHAR(100) NOT NULL,
 [Ubicacion] NVARCHAR(100) NOT NULL,
 [Capacidad] INT NOT NULL,
 [Descripcion] NVARCHAR(150),
 [PrecioBase] DECIMAL(10, 4) NOT NULL,
 [Estado] BIT NOT NULL DEFAULT 1
);

-- 2. Clientes
CREATE TABLE dbo.Clientes(
 [Id] INT IDENTITY(1,1) PRIMARY KEY,
 [Nombre] NVARCHAR(50) NOT NULL,
 [Apellido] NVARCHAR(50) NOT NULL,
 [Correo] NVARCHAR(150) NOT NULL,
 [Telefono] NVARCHAR(20),
 [Documento] NVARCHAR(50) NOT NULL
);

-- 3. Usuarios
CREATE TABLE dbo.Usuarios(
 [Id] INT IDENTITY(1,1) PRIMARY KEY,
 [NombreUsuario] NVARCHAR(150) NOT NULL,
 [Clave] NVARCHAR(100) NOT NULL,
 [Rol] NVARCHAR(50) NOT NULL
);

-- 4. Empleados
CREATE TABLE dbo.Empleados(
 [Id] INT IDENTITY(1,1) PRIMARY KEY,
 [Nombre] NVARCHAR(100) NOT NULL,
 [Apellido] NVARCHAR(100) NOT NULL,
 [Cargo] NVARCHAR(50) NOT NULL,
 [Telefono] NVARCHAR(20),
 [Correo] NVARCHAR(100) UNIQUE
);

-- 5. Reservas
CREATE TABLE dbo.Reservas(
 [Id] INT IDENTITY(1,1) PRIMARY KEY,
 [FechaInicio] DATE NOT NULL,
 [FechaFin] DATE NOT NULL,
 [Estado] NVARCHAR(20) NOT NULL,
 [Total] DECIMAL(10,2) NOT NULL DEFAULT 0,
 [Finca] INT NOT NULL,
 [Cliente] INT NOT NULL,
 CONSTRAINT FK_Reservas_Fincas  FOREIGN KEY ([Finca])  REFERENCES dbo.Fincas([Id]),
 CONSTRAINT FK_Reservas_Clientes FOREIGN KEY ([Cliente]) REFERENCES dbo.Clientes([Id])
);

-- 6. Pagos
CREATE TABLE dbo.Pagos(
 [Id] INT IDENTITY(1,1) PRIMARY KEY,
 [Reserva] INT NOT NULL,
 [Monto] DECIMAL(10,2) NOT NULL,
 [FechadePago] DATETIME2 NOT NULL DEFAULT GETDATE(),
 [Metodo] NVARCHAR(50) NOT NULL,
 CONSTRAINT FK_Pagos_Reservas FOREIGN KEY ([Reserva]) REFERENCES dbo.Reservas([Id])
);

-- 7. ServiciosExtras
CREATE TABLE dbo.ServiciosExtras(
 [Id] INT IDENTITY(1,1) PRIMARY KEY,
 [Nombre] NVARCHAR(100) NOT NULL,
 [Precio] DECIMAL(10,2) NOT NULL,
 [Estado] BIT NOT NULL DEFAULT 1
);

-- 8. ReservaServicios
CREATE TABLE dbo.ReservaServicios(
 [Id] INT IDENTITY(1,1) PRIMARY KEY,
 [Reserva] INT NOT NULL,
 [Servicio] INT NOT NULL,
 [Cantidad] INT NOT NULL DEFAULT 1,
 CONSTRAINT FK_ReservaServicios_Reservas  FOREIGN KEY ([Reserva])  REFERENCES dbo.Reservas([Id]),
 CONSTRAINT FK_ReservaServicios_Servicios FOREIGN KEY ([Servicio]) REFERENCES dbo.ServiciosExtras([Id])
);

-- 9. Promociones
CREATE TABLE dbo.Promociones(
 [Id] INT IDENTITY(1,1) PRIMARY KEY,
 [Nombre] NVARCHAR(100) NOT NULL,
 [Descuento] DECIMAL(5,2) NOT NULL, 
 [FechaInicio] DATE NOT NULL,
 [FechaFin] DATE NOT NULL,
 [Estado] BIT NOT NULL DEFAULT 1
);

-- 10. ReservaPromociones
CREATE TABLE dbo.ReservaPromociones(
 [Id] INT IDENTITY(1,1) PRIMARY KEY,
 [Reserva] INT NOT NULL,
 [Promocion] INT NOT NULL,
 CONSTRAINT FK_ReservaPromociones_Reservas    FOREIGN KEY ([Reserva])   REFERENCES dbo.Reservas([Id]),
 CONSTRAINT FK_ReservaPromociones_Promociones FOREIGN KEY ([Promocion]) REFERENCES dbo.Promociones([Id])
);

-- 11. Inventarios
CREATE TABLE dbo.Inventarios(
 [Id] INT IDENTITY(1,1) PRIMARY KEY,
 [Finca] INT NOT NULL,
 [Nombre] NVARCHAR(100) NOT NULL,
 [Cantidad] INT NOT NULL,
 [Estado] NVARCHAR(50) NOT NULL DEFAULT 'Bueno',
 CONSTRAINT FK_Inventarios_Fincas FOREIGN KEY ([Finca]) REFERENCES dbo.Fincas([Id])
);

-- 12. Mantenimientos
CREATE TABLE dbo.Mantenimientos(
 [Id] INT IDENTITY(1,1) PRIMARY KEY,
 [Finca] INT NOT NULL,
 [Descripcion] NVARCHAR(200) NOT NULL,
 [Costo] DECIMAL(10,2) NOT NULL,
 [Fecha] DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
 [Responsable] NVARCHAR(100),
 CONSTRAINT FK_Mantenimientos_Fincas FOREIGN KEY ([Finca]) REFERENCES dbo.Fincas([Id])
);

-- 13. Tareas
CREATE TABLE dbo.Tareas(
 [Id] INT IDENTITY(1,1) PRIMARY KEY,
 [Empleado] INT NOT NULL,
 [Finca] INT NOT NULL,
 [Descripcion] NVARCHAR(200),
 [FechaAsignacion] DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
 [Estado] NVARCHAR(50) NOT NULL DEFAULT 'Pendiente',
 CONSTRAINT FK_Tareas_Empleados FOREIGN KEY ([Empleado]) REFERENCES dbo.Empleados([Id]),
 CONSTRAINT FK_Tareas_Fincas    FOREIGN KEY ([Finca])    REFERENCES dbo.Fincas([Id])
);

-- 14. Reseñas
CREATE TABLE dbo.[Reseñas](
 [Id] INT IDENTITY(1,1) PRIMARY KEY,
 [Finca] INT NOT NULL,
 [Cliente] INT NOT NULL,
 [Calificacion] INT NOT NULL CHECK (Calificacion BETWEEN 1 AND 5),
 [Comentario] NVARCHAR(300),
 [Fecha] DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
 CONSTRAINT FK_Reseñas_Fincas   FOREIGN KEY ([Finca])  REFERENCES dbo.Fincas([Id]),
 CONSTRAINT FK_Reseñas_Clientes FOREIGN KEY ([Cliente]) REFERENCES dbo.Clientes([Id])
);

-- 15. Auditoria
CREATE TABLE dbo.Auditorias(
 [Id] INT IDENTITY(1,1) PRIMARY KEY,
 [Usuario] INT NOT NULL,
 [Accion] NVARCHAR(200) NOT NULL,
 [Fecha] DATETIME2 NOT NULL DEFAULT GETDATE(),
 [TablaAfectada] NVARCHAR(50),
 [IdRegistroAfectado] INT,
 CONSTRAINT FK_Auditoria_Usuarios FOREIGN KEY ([Usuario]) REFERENCES dbo.Usuarios([Id])
);

-- 3) CHECKS e ÍNDICES simples (nivel básico)
ALTER TABLE dbo.Reservas ADD CONSTRAINT CK_Reservas_Fechas CHECK (FechaFin > FechaInicio);
ALTER TABLE dbo.Reservas ADD CONSTRAINT CK_Reservas_Total  CHECK (Total >= 0);
ALTER TABLE dbo.Pagos    ADD CONSTRAINT CK_Pagos_Monto     CHECK (Monto > 0);

CREATE UNIQUE INDEX UX_Clientes_Correo    ON dbo.Clientes(Correo);
CREATE UNIQUE INDEX UX_Clientes_Documento ON dbo.Clientes(Documento);

ALTER TABLE dbo.Reservas
DROP CONSTRAINT FK_Reservas_Fincas;
ALTER TABLE dbo.Reservas
ADD CONSTRAINT FK_Reservas_Fincas 
FOREIGN KEY (Finca) REFERENCES dbo.Fincas(Id) ON DELETE CASCADE;

ALTER TABLE dbo.Reservas
DROP CONSTRAINT FK_Reservas_Clientes;
ALTER TABLE dbo.Reservas
ADD CONSTRAINT FK_Reservas_Clientes
FOREIGN KEY (Cliente) REFERENCES dbo.Clientes(Id) ON DELETE CASCADE;

-- PAGOS → RESERVAS
ALTER TABLE dbo.Pagos
DROP CONSTRAINT FK_Pagos_Reservas;
ALTER TABLE dbo.Pagos
ADD CONSTRAINT FK_Pagos_Reservas
FOREIGN KEY (Reserva) REFERENCES dbo.Reservas(Id) ON DELETE CASCADE;

-- RESERVASERVICIOS → RESERVAS / SERVICIOSEXTRAS
ALTER TABLE dbo.ReservaServicios
DROP CONSTRAINT FK_ReservaServicios_Reservas;
ALTER TABLE dbo.ReservaServicios
ADD CONSTRAINT FK_ReservaServicios_Reservas
FOREIGN KEY (Reserva) REFERENCES dbo.Reservas(Id) ON DELETE CASCADE;

ALTER TABLE dbo.ReservaServicios
DROP CONSTRAINT FK_ReservaServicios_Servicios;
ALTER TABLE dbo.ReservaServicios
ADD CONSTRAINT FK_ReservaServicios_Servicios
FOREIGN KEY (Servicio) REFERENCES dbo.ServiciosExtras(Id) ON DELETE CASCADE;

-- RESERVAPROMOCIONES → RESERVAS / PROMOCIONES
ALTER TABLE dbo.ReservaPromociones
DROP CONSTRAINT FK_ReservaPromociones_Reservas;
ALTER TABLE dbo.ReservaPromociones
ADD CONSTRAINT FK_ReservaPromociones_Reservas
FOREIGN KEY (Reserva) REFERENCES dbo.Reservas(Id) ON DELETE CASCADE;

ALTER TABLE dbo.ReservaPromociones
DROP CONSTRAINT FK_ReservaPromociones_Promociones;
ALTER TABLE dbo.ReservaPromociones
ADD CONSTRAINT FK_ReservaPromociones_Promociones
FOREIGN KEY (Promocion) REFERENCES dbo.Promociones(Id) ON DELETE CASCADE;

-- INVENTARIOS → FINCAS
ALTER TABLE dbo.Inventarios
DROP CONSTRAINT FK_Inventarios_Fincas;
ALTER TABLE dbo.Inventarios
ADD CONSTRAINT FK_Inventarios_Fincas
FOREIGN KEY (Finca) REFERENCES dbo.Fincas(Id) ON DELETE CASCADE;

-- MANTENIMIENTOS → FINCAS
ALTER TABLE dbo.Mantenimientos
DROP CONSTRAINT FK_Mantenimientos_Fincas;
ALTER TABLE dbo.Mantenimientos
ADD CONSTRAINT FK_Mantenimientos_Fincas
FOREIGN KEY (Finca) REFERENCES dbo.Fincas(Id) ON DELETE CASCADE;

-- TAREAS → EMPLEADOS / FINCAS
ALTER TABLE dbo.Tareas
DROP CONSTRAINT FK_Tareas_Empleados;
ALTER TABLE dbo.Tareas
ADD CONSTRAINT FK_Tareas_Empleados
FOREIGN KEY (Empleado) REFERENCES dbo.Empleados(Id) ON DELETE CASCADE;

ALTER TABLE dbo.Tareas
DROP CONSTRAINT FK_Tareas_Fincas;
ALTER TABLE dbo.Tareas
ADD CONSTRAINT FK_Tareas_Fincas
FOREIGN KEY (Finca) REFERENCES dbo.Fincas(Id) ON DELETE CASCADE;

-- RESEÑAS → FINCAS / CLIENTES
ALTER TABLE dbo.[Reseñas]
DROP CONSTRAINT FK_Reseñas_Fincas;
ALTER TABLE dbo.[Reseñas]
ADD CONSTRAINT FK_Reseñas_Fincas
FOREIGN KEY (Finca) REFERENCES dbo.Fincas(Id) ON DELETE CASCADE;

ALTER TABLE dbo.[Reseñas]
DROP CONSTRAINT FK_Reseñas_Clientes;
ALTER TABLE dbo.[Reseñas]
ADD CONSTRAINT FK_Reseñas_Clientes
FOREIGN KEY (Cliente) REFERENCES dbo.Clientes(Id) ON DELETE CASCADE;

/* ============ INSERT INTO ============ */

-- USUARIOS 
INSERT INTO [Usuarios] ([NombreUsuario], [Clave], [Rol]) VALUES
('admin',  'admin123',   'Admin'),
('recep1', 'recep123',   'Recepcion'),
('ventas', 'ventas123',  'Comercial'),
('mnto',   'mnto123',    'Mantenimiento'),
('audit',  'audit123',   'Auditor');

-- CLIENTES
INSERT INTO [Clientes] ([Nombre], [Apellido], [Correo], [Telefono], [Documento]) VALUES
('Laura','Gomez','laura@example.com','3001112233','1032456789'),
('Carlos','Restrepo','carlos@example.com','3012223344','1019988776'),
('Ana','Martinez','ana@example.com','3023334455','CE-P987654'),
('Julian','Arango','julian@example.com','3034445566','1005678901'),
('Mariana','Lopez','mariana@example.com','3045556677','99012345');

-- FINCAS
INSERT INTO [Fincas] ([Nombre], [Ubicacion], [Capacidad], [Descripcion], [PrecioBase], [Estado]) VALUES
('Finca El Retiro','El Retiro - Antioquia',60,'Finca campestre con lago',180000.0000,1),
('Finca La Ceja','La Ceja - Antioquia',40,'Cabañas familiares',150000.0000,1),
('Finca Guatapé Vista','Guatapé - Antioquia',80,'Vista al embalse',250000.0000,1),
('Finca Jardín Café','Jardín - Antioquia',35,'Ambiente cafetero',130000.0000,1),
('Finca Santa Elena','Santa Elena - Medellín',50,'Bosque de niebla',170000.0000,1);

-- EMPLEADOS
INSERT INTO [Empleados] ([Nombre], [Apellido], [Cargo], [Telefono], [Correo]) VALUES
('Sofia','Perez','Recepcion','3110000001','sofia.recep@terralink.com'),
('Mateo','Ramirez','Mantenimiento','3110000002','mateo.mnto@terralink.com'),
('Valeria','Londoño','Ventas','3110000003','valeria.ventas@terralink.com'),
('Andres','Guerra','Aseo','3110000004','andres.aseo@terralink.com'),
('Camila','Aristizabal','Guia','3110000005','camila.guia@terralink.com');

-- SERVICIOSEXTRAS
INSERT INTO [ServiciosExtras] ([Nombre], [Precio], [Estado]) VALUES
('Asado + Parrilla',120000,1),
('Piscina Climatizada',80000,1),
('Kayak 1h',40000,1),
('Fogata Nocturna',30000,1),
('Decoracion Romántica',150000,1);

-- PROMOCIONES
INSERT INTO [Promociones] ([Nombre], [Descuento], [FechaInicio], [FechaFin], [Estado]) VALUES
('Semana Amor y Amistad',10.00,'2025-09-01','2025-09-30',1),
('Puente Festivo',12.50,'2025-10-12','2025-10-15',1),
('Black Weekend',15.00,'2025-11-28','2025-12-01',1),
('Navidad',20.00,'2025-12-20','2025-12-27',1),
('Año Nuevo',18.00,'2025-12-28','2026-01-05',1);

/* ============ OPERACIoN ============ */

-- INVENTARIOS  (usa Id de fincas 1..5)
INSERT INTO [Inventarios] ([Finca], [Nombre], [Cantidad], [Estado]) VALUES
(1,'Sabanas',100,'Bueno'),
(1,'Toallas',80,'Bueno'),
(2,'Parrilla',5,'Bueno'),
(3,'Kayaks',6,'Bueno'),
(4,'Sillas Jardín',20,'Regular');

-- MANTENIMIENTOS
INSERT INTO [Mantenimientos] ([Finca], [Descripcion], [Costo], [Fecha], [Responsable]) VALUES
(1,'Mantenimiento piscina',500000,'2025-09-01','Mateo Ramirez'),
(2,'Pintura cabañas',800000,'2025-08-15','Andres Guerra'),
(3,'Revision kayaks',200000,'2025-09-10','Mateo Ramirez'),
(4,'Podado jardines',150000,'2025-09-05','Andres Guerra'),
(5,'Revision paneles solares',300000,'2025-09-12','Proveedor Solar');

-- RESERVAS (Finca y Cliente deben existir)
INSERT INTO [Reservas] ([FechaInicio], [FechaFin], [Estado], [Total], [Finca], [Cliente]) VALUES
('2025-09-20','2025-09-22','Confirmada',360000,1,1),
('2025-10-10','2025-10-13','Confirmada',900000,3,2),
('2025-12-28','2026-01-02','Pendiente',1400000,3,3),
('2025-09-25','2025-09-26','Confirmada',180000,1,4),
('2025-04-15','2025-04-17','Confirmada',440000,2,5);

-- PAGOS (Reserva debe existir)
INSERT INTO [Pagos] ([Reserva], [Monto], [FechadePago], [Metodo]) VALUES
(1,360000,'2025-09-18 10:00:00','Transferencia'),
(2,450000,'2025-10-05 09:30:00','Tarjeta Crédito'),
(2,450000,'2025-10-09 14:15:00','Efectivo'),
(4,180000,'2025-09-24 16:45:00','Nequi'),
(5,440000,'2025-04-10 12:00:00','Tarjeta Débito');

-- RESERVASERVICIOS (Reserva y Servicio deben existir)
INSERT INTO [ReservaServicios] ([Reserva], [Servicio], [Cantidad]) VALUES
(1,4,1),  -- Fogata
(2,1,1),  -- Asado
(2,2,1),  -- Piscina
(3,2,2),  -- Piscina x2
(5,5,1);  -- Decoracion

-- RESERVAPROMOCIONES (Reserva y Promocion deben existir)
INSERT INTO [ReservaPromociones] ([Reserva], [Promocion]) VALUES
(1,1),
(2,2),
(3,4),
(4,1),
(5,5);

-- TAREAS (Empleado y Finca deben existir)
INSERT INTO [Tareas] ([Empleado], [Finca], [Descripcion], [FechaAsignacion], [Estado]) VALUES
(1,1,'Check-in grupo familiar','2025-09-20','Pendiente'),
(2,1,'Revisar filtros piscina','2025-09-19','En Progreso'),
(3,3,'Cotizar plan fin de año','2025-10-01','Pendiente'),
(4,2,'Limpieza cabañas','2025-09-25','Pendiente'),
(5,4,'Tour caficultor','2025-09-22','Asignada');

-- RESEÑAS (Finca y Cliente deben existir)
INSERT INTO [Reseñas] ([Finca], [Cliente], [Calificacion], [Comentario], [Fecha]) VALUES
(1,1,5,'Excelente servicio y paisaje','2025-09-23'),
(3,2,4,'Muy buena vista, algo de ruido','2025-10-14'),
(2,5,5,'Perfecto para familias','2025-04-20'),
(4,4,4,'Tranquilo y bonito','2025-09-27'),
(3,3,3,'Esperaba más actividades','2026-01-03');

-- AUDITORIAS (Usuario debe existir)
INSERT INTO [Auditorias] ([Usuario], [Accion], [Fecha], [TablaAfectada], [IdRegistroAfectado]) VALUES
(1,'CREAR_RESERVA','2025-09-18 10:05:00','Reservas',1),
(2,'CONFIRMAR_PAGO','2025-09-18 10:10:00','Pagos',1),
(3,'APLICAR_PROMO','2025-10-10 08:00:00','ReservaPromociones',2),
(4,'CREAR_TAREA','2025-09-19 11:00:00','Tareas',2),
(5,'CARGA_MANTENIMIENTO','2025-09-12 15:30:00','Mantenimientos',5);

