CREATE DATABASE Veterinaria1;-- tablas
GO
USE Veterinaria1;
GO
-- Tiene sedes en varias ciudades del país.
CREATE TABLE Sede ( --Samuel
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    ciudad NVARCHAR(100) NOT NULL,
    direccion NVARCHAR(MAX)
)
GO

CREATE TABLE Perfil ( --Laura
    id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    PaginaNavegar NVARCHAR(MAX),
);
GO

CREATE TABLE Usuario ( --Laura
    id INT IDENTITY(1,1) PRIMARY KEY,
    userName NVARCHAR(100),
    contraseña NVARCHAR(MAX),
    salt NVARCHAR(MAX),
    perfil_id INT FOREIGN KEY REFERENCES Perfil(id)
);
GO

CREATE TABLE Empleado ( --Samuel
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    correo NVARCHAR(100) NOT NULL,
	telefono INT,
    usuario_id INT FOREIGN KEY REFERENCES Usuario(id),
    sede_id INT FOREIGN KEY REFERENCES Sede(id)
)
GO

-- Maneja farmacia propia para la atención de los pacientes en el hospital.
CREATE TABLE Farmacia ( --Samuel
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    telefono NVARCHAR(20),
    direccion NVARCHAR(MAX),
    sede_id INT FOREIGN KEY REFERENCES Sede(id)
)
GO
-- - Compra productos a proveedores para cirugías, gestión de las camas, etc.
CREATE TABLE Proveedor ( --Samuel
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    contacto NVARCHAR(100),
    telefono NVARCHAR(20),
    email NVARCHAR(100)
);
GO

CREATE TABLE Herramienta ( --Laura
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    tipo NVARCHAR(50),
    proveedor_id INT FOREIGN KEY REFERENCES Proveedor(id),
);
GO

CREATE TABLE Medicamento ( --Laura
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    tipo NVARCHAR(50),
    precio DECIMAL(10,2),
    proveedor_id INT FOREIGN KEY REFERENCES Proveedor(id),
);
GO


CREATE TABLE Cliente ( --Laura
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    telefono NVARCHAR(20),
    email NVARCHAR(100),
    direccion NVARCHAR(MAX),
    documento NVARCHAR(50),
);
GO


-- Preguntar: Es necesario crear todas las tablas posibles?
CREATE TABLE Mascota ( --Sara
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    especie NVARCHAR(50),
    raza NVARCHAR(50),
    edad INT,
    sexo NVARCHAR(10),
    cliente_id INT FOREIGN KEY REFERENCES Cliente(id),
    sede_id INT FOREIGN KEY REFERENCES Sede(id)
);
GO

CREATE TABLE Consultorio ( --Sara
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    sede_id INT FOREIGN KEY REFERENCES Sede(id)
);
GO

-- Preguntar: Debe tener pagos?
-- Preguntar: citas aplica para hospitalizacion, cirugía y otros servicios?
CREATE TABLE Cita ( --Sara
    id INT IDENTITY(1,1) PRIMARY KEY,
    fecha DATETIME NOT NULL,
    motivo NVARCHAR(MAX),
    mascota_id INT FOREIGN KEY REFERENCES Mascota(id),
    empleado_id INT FOREIGN KEY REFERENCES Empleado(id),
    sede_id INT FOREIGN KEY REFERENCES Sede(id)
);
GO

CREATE TABLE TipoServicio ( --Sara
	id INT IDENTITY(1,1) PRIMARY KEY,
	nombre NVARCHAR(80),
	costo INT,
	descripcion NVARCHAR(MAX)
);
GO

CREATE TABLE Servicio ( --Harol
    id INT IDENTITY(1,1) PRIMARY KEY,
    fecha_ingreso DATE,
    fecha_salida DATE,
    mascota_id INT FOREIGN KEY REFERENCES Mascota(id),
    empleado_id INT FOREIGN KEY REFERENCES Empleado(id),
    consultorio_id INT FOREIGN KEY REFERENCES Consultorio(id),
	tipoServicio_id INT FOREIGN KEY REFERENCES TipoServicio(id)
);
GO

CREATE TABLE Pago ( --Harol
	id INT IDENTITY(1,1) PRIMARY KEY,
	costo_total INT,
	descripcion NVARCHAR(MAX),
	servicio_id INT FOREIGN KEY REFERENCES Servicio(id),
	medicamento_id INT FOREIGN KEY REFERENCES Medicamento(id)
);
GO

CREATE TABLE InventarioMedicamento ( --Harol
	id INT IDENTITY(1,1) PRIMARY KEY,
	cantidad INT,
	medicamento_id INT FOREIGN KEY REFERENCES Medicamento(id),
	farmacia_id INT FOREIGN KEY REFERENCES Farmacia(id)
);
GO

CREATE TABLE InventarioHerramienta ( --Harol
	id INT IDENTITY(1,1) PRIMARY KEY,
	cantidad INT,
	herramientas_id INT FOREIGN KEY REFERENCES Herramienta(id),
	farmacia_id INT FOREIGN KEY REFERENCES Farmacia(id)
);
