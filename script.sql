USE [master]
GO
/****** Object:  Database [ProductosProveedores]    Script Date: 17/2/2019 9:47:51 p. m. ******/
CREATE DATABASE [ProductosProveedores]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'sosbelleza', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\sosbelleza.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'sosbelleza_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\sosbelleza_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProductosProveedores] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductosProveedores].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductosProveedores] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductosProveedores] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductosProveedores] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductosProveedores] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductosProveedores] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductosProveedores] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProductosProveedores] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ProductosProveedores] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductosProveedores] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductosProveedores] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductosProveedores] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductosProveedores] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductosProveedores] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductosProveedores] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductosProveedores] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductosProveedores] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProductosProveedores] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductosProveedores] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductosProveedores] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductosProveedores] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductosProveedores] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductosProveedores] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProductosProveedores] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductosProveedores] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProductosProveedores] SET  MULTI_USER 
GO
ALTER DATABASE [ProductosProveedores] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductosProveedores] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductosProveedores] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductosProveedores] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ProductosProveedores]
GO
/****** Object:  StoredProcedure [dbo].[AltaPedido]    Script Date: 17/2/2019 9:47:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[AltaPedido] (@FechaPedido as date, @Proveedor as varchar(50), @Area as varchar(50), @Importe as decimal(18,0), @dvh as varchar(50))
AS
BEGIN
INSERT INTO Pedido (FechaPedido, NombreProveedor, Area,  Importe,  dvh) VALUES (@FechaPedido, @Proveedor, @Area, @Importe, @dvh)
END
GO
/****** Object:  StoredProcedure [dbo].[Cargar]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Cargar]
AS
BEGIN
	select 
	diccionario.clave,
	idioma_diccionario.
	valor 
	FROM diccionario inner join idioma_diccionario
	on diccionario.id_diccionario = idioma_diccionario.id_diccionario
END

GO
/****** Object:  StoredProcedure [dbo].[ModificarProducto]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarProducto] (@id as int, @nombre as varchar(50), @categoria as varchar(50), @frecuencia as int)
	
AS
BEGIN
	update producto
	set
	Nombre = @nombre ,
	Categoria = @categoria ,
	FrecuenciaDias = @frecuencia

	where Id_Producto = @id
END

GO
/****** Object:  Table [dbo].[Area]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Area](
	[Id_Area] [int] IDENTITY(1,1) NOT NULL,
	[NombreArea] [varchar](50) NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[Id_Area] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bitacora2]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bitacora2](
	[Id_bitacora] [int] IDENTITY(1,1) NOT NULL,
	[Accion] [varchar](50) NULL,
	[Fecha] [varchar](50) NULL,
	[Usuario] [varchar](50) NULL,
	[Id_Usuario] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id_Categoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ciudad](
	[Id_Ciudad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[CP] [varchar](50) NULL,
	[Provincia] [int] NULL,
	[NombreProvincia] [varchar](50) NULL,
 CONSTRAINT [PK_cK] PRIMARY KEY CLUSTERED 
(
	[Id_Ciudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[diccionario]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[diccionario](
	[id_diccionario] [int] IDENTITY(1,1) NOT NULL,
	[clave] [varchar](500) NOT NULL,
 CONSTRAINT [PK_diccionario] PRIMARY KEY CLUSTERED 
(
	[id_diccionario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[digitovertical]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[digitovertical](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NombreTabla] [varchar](50) NULL,
	[Digito] [varchar](50) NULL,
	[Fecha] [date] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleado](
	[Id_Empleado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Id_Area] [int] NULL,
	[NombreArea] [varchar](50) NULL,
	[Cargo] [varchar](50) NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[Id_Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Evaluacion]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Evaluacion](
	[Id_evaluacion] [int] IDENTITY(1,1) NOT NULL,
	[Proveedor] [int] NULL,
	[NombreProveedor] [varchar](50) NULL,
	[Tiempo] [int] NULL,
	[Atencion] [int] NULL,
	[Comunicacion] [int] NULL,
	[Calidad] [int] NULL,
	[Promedio] [decimal](18, 0) NULL,
	[Fecha] [varchar](50) NULL,
 CONSTRAINT [PK_Evaluacion] PRIMARY KEY CLUSTERED 
(
	[Id_evaluacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[idioma]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[idioma](
	[id_idioma] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](50) NOT NULL,
 CONSTRAINT [PK_idioma] PRIMARY KEY CLUSTERED 
(
	[id_idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[idioma_diccionario]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[idioma_diccionario](
	[id_idioma] [int] NOT NULL,
	[id_diccionario] [int] NOT NULL,
	[valor] [varchar](500) NOT NULL,
 CONSTRAINT [PK_idioma_diccionario] PRIMARY KEY CLUSTERED 
(
	[id_idioma] ASC,
	[id_diccionario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrdenCompra]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrdenCompra](
	[Id_OC] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [varchar](50) NULL,
	[Proveedor] [varchar](50) NULL,
	[Area] [varchar](50) NULL,
	[Importe] [varchar](50) NULL,
	[dvh] [varchar](50) NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id_OC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pais](
	[Id_Pais] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[Id_Pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Patente]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patente](
	[Patente_id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Formulario] [varchar](50) NULL,
	[Tipo] [varchar](10) NOT NULL,
	[Menu] [varchar](10) NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[Patente_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatentePatente]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatentePatente](
	[patente_id_padre] [int] NOT NULL,
	[patente_id_hijo] [int] NOT NULL,
 CONSTRAINT [PK_PatentePatente] PRIMARY KEY CLUSTERED 
(
	[patente_id_padre] ASC,
	[patente_id_hijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[producto]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[producto](
	[Id_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Producto] [varchar](50) NULL,
	[Id_Categoria] [int] NULL,
	[Categoria] [varchar](50) NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[Id_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[proveedor](
	[Id_Proveedor] [int] IDENTITY(1,1) NOT NULL,
	[NombreProveedor] [varchar](50) NOT NULL,
	[CUIT] [varchar](50) NOT NULL,
	[Direccion] [varchar](50) NULL,
	[Ciudad] [varchar](50) NULL,
	[CodigoPostal] [varchar](50) NULL,
	[Provincia] [varchar](50) NULL,
	[Pais] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Celular] [varchar](50) NULL,
	[CorreoElectronico] [varchar](50) NULL,
 CONSTRAINT [PK_proveedor] PRIMARY KEY CLUSTERED 
(
	[Id_Proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[proveedor_producto]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[proveedor_producto](
	[Id_Registro] [int] IDENTITY(1,1) NOT NULL,
	[Id_Producto] [int] NULL,
	[Producto] [varchar](50) NULL,
	[Id_Proveedor] [int] NULL,
	[Proveedor] [varchar](50) NULL,
	[Precio] [decimal](18, 0) NULL,
	[DescuentoCantidad] [int] NULL,
	[CantidadDescuento] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Provincia](
	[Id_Provincia] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Pais] [int] NULL,
	[NombrePais] [varchar](50) NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[Id_Provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RegistroCompra]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RegistroCompra](
	[Id_Registro] [int] IDENTITY(1,1) NOT NULL,
	[Producto] [varchar](50) NULL,
	[Precio] [decimal](18, 0) NULL,
	[Cantidad] [int] NULL,
	[Descuento] [decimal](18, 0) NULL,
	[Total] [decimal](18, 0) NULL,
	[OrdenCompra] [int] NULL,
 CONSTRAINT [PK_RegistroCompras] PRIMARY KEY CLUSTERED 
(
	[Id_Registro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Usuario_id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioPatente]    Script Date: 17/2/2019 9:47:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPatente](
	[usuario_id] [int] NOT NULL,
	[patente_id] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioPatente] PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC,
	[patente_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Area] ON 

INSERT [dbo].[Area] ([Id_Area], [NombreArea]) VALUES (3, N'OyP')
INSERT [dbo].[Area] ([Id_Area], [NombreArea]) VALUES (6, N'Legales')
INSERT [dbo].[Area] ([Id_Area], [NombreArea]) VALUES (7, N'Tecnologia e Innovacion')
INSERT [dbo].[Area] ([Id_Area], [NombreArea]) VALUES (8, N'Riesgo')
INSERT [dbo].[Area] ([Id_Area], [NombreArea]) VALUES (10, N'Recursos Humanos')
INSERT [dbo].[Area] ([Id_Area], [NombreArea]) VALUES (11, N'Compras y Cont.')
INSERT [dbo].[Area] ([Id_Area], [NombreArea]) VALUES (12, N'Operaciones')
INSERT [dbo].[Area] ([Id_Area], [NombreArea]) VALUES (13, N'PLD')
INSERT [dbo].[Area] ([Id_Area], [NombreArea]) VALUES (16, N'Contabilidad')
INSERT [dbo].[Area] ([Id_Area], [NombreArea]) VALUES (18, N'Administración')
SET IDENTITY_INSERT [dbo].[Area] OFF
SET IDENTITY_INSERT [dbo].[bitacora2] ON 

INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9665, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9666, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9667, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9673, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9674, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9681, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9682, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9683, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9684, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9685, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9686, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9687, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9696, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9713, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9714, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9730, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9731, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9668, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9669, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9710, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9719, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9720, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9721, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9688, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9689, N'Ingreso al sistema', N'17/2/2019', N'Marcos', 2049)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9690, N'Ingreso al sistema', N'17/2/2019', N'Juan', 27)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9691, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9692, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9693, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9694, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9695, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9697, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9698, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9699, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9700, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9701, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9702, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9706, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9707, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9708, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9732, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9715, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9716, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9726, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9727, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9728, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9729, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9703, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9704, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9705, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9670, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9671, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9672, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9675, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9676, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9677, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9678, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9679, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9680, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9733, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9709, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9711, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9712, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9717, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9718, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9722, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9723, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9724, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9725, N'Ingreso al sistema', N'17/2/2019', N'Ana', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9617, N'Ingreso al sistema', N'12/2/2019', N'adipietro', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9618, N'Ingreso al sistema', N'12/2/2019', N'adipietro', 2)
INSERT [dbo].[bitacora2] ([Id_bitacora], [Accion], [Fecha], [Usuario], [Id_Usuario]) VALUES (9619, N'Ingreso al sistema', N'12/2/2019', N'adipietro', 2)
SET IDENTITY_INSERT [dbo].[bitacora2] OFF
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([Id_Categoria], [Nombre]) VALUES (4, N'Hoteles')
INSERT [dbo].[Categoria] ([Id_Categoria], [Nombre]) VALUES (38, N'Iluminación')
INSERT [dbo].[Categoria] ([Id_Categoria], [Nombre]) VALUES (39, N'Librería')
INSERT [dbo].[Categoria] ([Id_Categoria], [Nombre]) VALUES (46, N'Alimento')
INSERT [dbo].[Categoria] ([Id_Categoria], [Nombre]) VALUES (49, N'Eventos')
INSERT [dbo].[Categoria] ([Id_Categoria], [Nombre]) VALUES (71, N'Blancos')
INSERT [dbo].[Categoria] ([Id_Categoria], [Nombre]) VALUES (72, N'Limpieza')
INSERT [dbo].[Categoria] ([Id_Categoria], [Nombre]) VALUES (74, N'Servicios')
INSERT [dbo].[Categoria] ([Id_Categoria], [Nombre]) VALUES (75, N'Maquinas')
INSERT [dbo].[Categoria] ([Id_Categoria], [Nombre]) VALUES (78, N'Mobiliario')
INSERT [dbo].[Categoria] ([Id_Categoria], [Nombre]) VALUES (80, N'Tecnologia')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
SET IDENTITY_INSERT [dbo].[Ciudad] ON 

INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (2, N'Ciudad Autónoma de Bs As', N'1900', 1, N'Ciudad Autónoma de Bs As')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (3, N'Adolfo Gonzales Chaves', N'1901', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (4, N'Adrogué', N'1902', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (5, N'Alberti', N'1903', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (6, N'Alejandro Korn', N'1904', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (7, N'América', N'1905', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (8, N'Arrecifes', N'1906', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (9, N'Avellaneda', N'1907', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (10, N'Ayacucho', N'1908', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (11, N'Azul', N'1909', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (12, N'Bahía Blanca', N'1910', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (13, N'Balcarce', N'1911', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (14, N'Banfield', N'1912', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (15, N'Baradero', N'1913', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (16, N'Batán', N'1914', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (17, N'Béccar', N'1915', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (18, N'Bella Vista', N'1916', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (19, N'Benavídez', N'1917', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (20, N'Benito Juárez', N'1918', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (21, N'Berazategui', N'1919', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (22, N'Bernal', N'1920', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (23, N'Bolívar', N'1921', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (24, N'Bosques', N'1922', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (25, N'Boulogne Sur Mer', N'1923', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (26, N'Bragado', N'1924', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (27, N'Brandsen', N'1925', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (28, N'Burzaco', N'1926', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (29, N'Campana', N'1927', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (30, N'Cañuelas', N'1928', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (31, N'Capilla del Señor', N'1929', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (32, N'Capitán Sarmiento', N'1930', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (33, N'Carhué3?', N'1931', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (34, N'Carlos Casares', N'1932', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (35, N'Carlos Spegazzini', N'1933', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (36, N'Carlos Tejedor', N'1934', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (37, N'Carmen de Areco', N'1935', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (38, N'Carmen de Patagones', N'1936', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (39, N'Casbas', N'1937', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (40, N'Caseros', N'1938', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (41, N'Castelar', N'1939', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (42, N'Castelli', N'1940', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (43, N'Chacabuco', N'1941', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (44, N'Claypole', N'1942', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (45, N'Colón', N'1943', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (46, N'Comandante Nicanor Otamendi', N'1944', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (47, N'Coronel Dorrego', N'1945', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (48, N'Coronel Pringles', N'1946', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (49, N'Coronel Suárez', N'1947', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (50, N'Coronel Vidal', N'1948', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (51, N'Daireaux', N'1949', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (52, N'Dock Sud', N'1950', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (53, N'Dolores', N'1951', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (54, N'Don Torcuato', N'1952', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (55, N'Eduardo OBrien', N'1953', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (56, N'El Jagüel', N'1954', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (57, N'El Palomar', N'1955', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (58, N'El Talar', N'1956', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (59, N'Ezeiza', N'1957', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (60, N'Ezpeleta', N'1958', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (61, N'Francisco Álvarez', N'1959', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (62, N'Florentino Ameghino', N'1960', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (63, N'Garín', N'1961', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (64, N'General Alvear', N'1962', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (65, N'General Arenales', N'1963', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (66, N'General Belgrano', N'1964', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (67, N'General Conesa', N'1965', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (68, N'General Daniel Cerri', N'1966', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (69, N'General Guido', N'1967', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (70, N'General Juan Madariaga', N'1968', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (71, N'General Las Heras', N'1969', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (72, N'General Lavalle', N'1970', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (73, N'General Pacheco', N'1971', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (74, N'General Pinto', N'1972', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (75, N'General Rodríguez', N'1973', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (76, N'General Villegas', N'1974', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (77, N'Gerli', N'1975', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (78, N'Glew', N'1976', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (79, N'González Catán', N'1977', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (80, N'Gregorio de Laferrere', N'1978', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (81, N'Guaminí', N'1979', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (82, N'Guernica', N'1980', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (83, N'Haedo', N'1981', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (84, N'Henderson', N'1982', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (85, N'Hudson', N'1983', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (86, N'Hurlingham', N'1984', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (87, N'Ingeniero Budge', N'1985', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (88, N'Ingeniero Maschwitz', N'1986', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (89, N'Isidro Casanova', N'1987', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (90, N'Ituzaingó', N'1988', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (91, N'José C. Paz', N'1989', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (92, N'Junín', N'1990', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (93, N'La Emilia', N'1991', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (94, N'La Plata', N'1992', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (95, N'La Tablada', N'1993', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (96, N'La Unión', N'1994', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (97, N'Lanús', N'1995', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (98, N'Laprida', N'1996', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (99, N'Las Flores', N'1997', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (100, N'Lezama', N'1998', 2, N'Buenos Aires')
GO
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (101, N'Llavallol', N'1999', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (102, N'Libertad', N'2000', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (103, N'Lincoln', N'2001', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (104, N'Lobería', N'2002', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (105, N'Lobos', N'2003', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (106, N'Lomas de Zamora', N'2004', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (107, N'Lomas del Mirador', N'2005', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (108, N'Longchamps', N'2006', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (109, N'Los Polvorines', N'2007', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (110, N'Los Toldos', N'2008', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (111, N'Luis Guillón', N'2009', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (112, N'Magdalena', N'2010', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (113, N'Maipú', N'2011', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (114, N'Mar de Ajó', N'2012', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (115, N'Mar del Plata', N'2013', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (116, N'Mar del Tuyú', N'2014', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (117, N'Marcos Paz', N'2015', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (118, N'Mariano Acosta', N'2016', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (119, N'Martínez', N'2017', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (120, N'Médanos', N'2018', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (121, N'Merlo', N'2019', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (122, N'Miramar', N'2020', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (123, N'Monte', N'2021', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (124, N'Monte Chingolo', N'2022', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (125, N'Monte Grande', N'2023', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (126, N'Monte Hermoso', N'2024', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (127, N'Navarro', N'2025', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (128, N'Necochea', N'2026', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (129, N'Nueve de Julio', N'2027', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (130, N'Olavarría', N'2028', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (131, N'Paso del Rey', N'2029', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (132, N'Pehuajó', N'2030', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (133, N'Pellegrini', N'2031', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (134, N'Pergamino', N'2032', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (135, N'Pila', N'2033', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (136, N'Pilar', N'2034', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (137, N'Pinamar', N'2035', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (138, N'Pontevedra', N'2036', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (139, N'Presidente Derqui', N'2037', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (140, N'Puan', N'2038', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (141, N'Punta Alta', N'2039', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (142, N'Quilmes10?', N'2040', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (143, N'Rafael Calzada', N'2041', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (144, N'Rafael Castillo', N'2042', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (145, N'Ramallo', N'2043', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (146, N'Ramos Mejía', N'2044', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (147, N'Ranchos', N'2045', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (148, N'Rauch', N'2046', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (149, N'Rawson', N'2047', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (150, N'Remedios de Escalada', N'2048', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (151, N'Rojas', N'2049', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (152, N'Roque Pérez', N'2050', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (153, N'Saavedra', N'2051', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (154, N'Saladillo', N'2052', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (155, N'Salto', N'2053', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (156, N'San Andrés de Giles', N'2054', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (157, N'San Antonio de Areco', N'2055', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (158, N'San Antonio de Padua', N'2056', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (159, N'San Cayetano', N'2057', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (160, N'San Fernando', N'2058', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (161, N'San Francisco Solano', N'2059', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (162, N'San Isidro', N'2060', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (163, N'San Juan Bautista (ex Florencio Varela)', N'2061', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (164, N'San Justo', N'2062', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (165, N'San Martín', N'2063', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (166, N'San Pedro', N'2064', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (167, N'San Nicolás de los Arroyos', N'2065', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (168, N'San Vicente', N'2066', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (169, N'Santa María', N'2067', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (170, N'Sarandí', N'2068', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (171, N'Suipacha', N'2069', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (172, N'Tandil', N'2070', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (173, N'Tapalqué', N'2071', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (174, N'Temperley', N'2072', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (175, N'Tigre', N'2073', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (176, N'Tornquist', N'2074', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (177, N'Treinta de Agosto', N'2075', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (178, N'Trenque Lauquen', N'2076', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (179, N'Tres Arroyos', N'2077', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (180, N'Tres Lomas', N'2078', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (181, N'Tristán Suárez', N'2079', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (182, N'Turdera5?', N'2080', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (183, N'Valentín Alsina', N'2081', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (184, N'Vedia', N'2082', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (185, N'Veinticinco de Mayo', N'2083', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (186, N'Vicente López', N'2084', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (187, N'Villa Ballester', N'2085', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (188, N'Villa Elisa', N'2086', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (189, N'Villa Fiorito', N'2087', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (190, N'Villa Luzuriaga', N'2088', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (191, N'Villa Madero', N'2089', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (192, N'Villa Ramallo', N'2090', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (193, N'Villa Tesei', N'2091', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (194, N'Wilde', N'2092', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (195, N'Zárate', N'2093', 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (196, N'Santa Cruz de La Sierra', N'111', 25, N'Potosi')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (197, N'El Alto Cochabamba ', N'112', 25, N'Potosi')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (198, N'Sucre ', N'113', 25, N'Potosi')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (199, N'Oruro', N'114', 25, N'Potosi')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (200, N'Tarija', N'114', 25, N'Potosi')
GO
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (201, N'Potosí', N'115', 25, N'Potosi')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (203, N'Sacaba', N'116', 26, N'Santa Cruz')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (204, N'Quillacollo', N'117', 26, N'Santa Cruz')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (205, N'Montero', N'118', 26, N'Santa Cruz')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (206, N'Trinidad', N'118', 26, N'Santa Cruz')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (207, N'Riberalta', N'120', 27, N'Pando')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (208, N'Colcapirhua', N'121', 27, N'Pando')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (209, N'Tiquipaya', N'122', 27, N'Pando')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (210, N'Viacha', N'123', 27, N'Pando')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (211, N'Guayaramerín', N'124', 28, N'La Paz')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (212, N'La Paz', N'125', 28, N'La Paz')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (213, N'Cobija ', N'126', 28, N'La Paz')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (214, N'Villazón', N'127', 28, N'La Paz')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (215, N'San Ignacio de Velasco', N'128', 28, N'La Paz')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (216, N'Tupiza ', N'129', 28, N'La Paz')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (217, N'Villamontes', N'130', 28, N'La Paz')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (218, N'Acheral', N'1001', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (219, N'Aconquija', N'1002', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (220, N'Acostilla', N'1003', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (221, N'Adolfo E Carranza', N'1004', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (222, N'Agua Amarilla La Hoyada', N'1005', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (223, N'Agua Amarilla Pta de Balasto', N'1006', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (224, N'Barranquitas', N'1007', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (225, N'Barro Negro', N'1008', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (226, N'Chañaritos', N'1009', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (227, N'Chañaryaco', N'1010', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (228, N'Chanero', N'1011', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (229, N'Cordobita', N'1012', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (230, N'Corral de Piedra', N'1013', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (231, N'Dos Pocitos', N'1014', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (232, N'Dos Troncos', N'1015', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (233, N'Duraznillo', N'1016', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (234, N'El Potrero', N'1017', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (235, N'El Potrero de Los Cordoba', N'1018', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (236, N'El Pozo', N'1019', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (237, N'El Pucar', N'1020', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (238, N'Fiambalá', N'1021', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (239, N'Fuerte Quemado', N'1022', 3, N'Catamarca')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (240, N'Presidencia Roque Sáenz Peña', N'3001', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (241, N'Fontana', N'3002', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (242, N'Juan José Castelli', N'3003', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (243, N'Pampa del Indio', N'3004', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (244, N'Corzuela', N'3005', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (245, N'La Leonesa', N'3006', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (246, N'Santa Sylvina', N'3007', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (247, N'Los Frentones', N'3008', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (248, N'Margarita Belén', N'3009', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (249, N'Colonia Elisa', N'3010', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (250, N'Barranqueras', N'3011', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (251, N'General José de San Martín', N'3012', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (252, N'Las Breñas', N'3013', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (253, N'Villa Río Bermejito', N'3014', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (254, N'Campo Largo', N'3015', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (255, N'Pampa del Infierno', N'3016', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (256, N'Puerto Vilelas', N'3017', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (257, N'Hermoso Campo', N'3018', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (258, N'Concepción del Bermejo', N'3019', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (259, N'Las Garcitas', N'3020', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (260, N'Villa Ángela', N'3021', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (261, N'Charata', N'3022', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (262, N'Tres Isletas', N'3023', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (263, N'Villa Berthet', N'3024', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (264, N'San Bernardo', N'3025', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (265, N'Taco Pozo', N'3026', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (266, N'Miraflores', N'3027', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (267, N'El Sauzalito', N'3028', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (268, N'Makallé', N'3029', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (269, N'Gancedo', N'3030', 4, N'Chaco')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (270, N'Biedma', N'4001', 5, N'Chubut')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (271, N'Cushamen', N'4002', 5, N'Chubut')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (272, N'Escalante', N'4003', 5, N'Chubut')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (273, N'Florentino Ameghino', N'4004', 5, N'Chubut')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (274, N'Futaleufú', N'4005', 5, N'Chubut')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (275, N'Gaiman', N'4006', 5, N'Chubut')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (276, N'Gastre', N'4007', 5, N'Chubut')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (277, N'Languiñeo', N'4008', 5, N'Chubut')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (278, N'Mártires', N'4009', 5, N'Chubut')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (279, N'Paso de Indios', N'4010', 5, N'Chubut')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (280, N'Rawson', N'4011', 5, N'Chubut')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (281, N'Río Senguer', N'4012', 5, N'Chubut')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (282, N'Sarmiento', N'4013', 5, N'Chubut')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (283, N'Tehuelches', N'4014', 5, N'Chubut')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (284, N'Telsen', N'4015', 5, N'Chubut')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (391, N'Achiras', N'5001', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (392, N'Agua de Oro', N'5002', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (393, N'Alcira Gigena', N'5003', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (394, N'Almafuerte', N'5004', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (395, N'Alpa Corral', N'5005', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (396, N'Alta Gracia', N'5006', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (397, N'Amboy', N'5007', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (398, N'Anisacate', N'5008', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (399, N'Arias', N'5009', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (400, N'Arroyito', N'5010', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (401, N'Arroyo de los Patos', N'5011', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (402, N'Ascochinga', N'5012', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (403, N'Athos Pampa', N'5013', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (404, N'Ballesteros', N'5014', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (405, N'Balnearia', N'5015', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (406, N'Bell Ville', N'5016', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (407, N'Berrotarán', N'5017', 6, N'Córdoba')
GO
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (408, N'Bialet Masse', N'5018', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (409, N'Brinkmann', N'5019', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (410, N'Cabalango', N'5020', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (411, N'Calmayo', N'5021', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (412, N'Caminiaga', N'5022', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (413, N'Canals', N'5023', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (414, N'Cañada del Sauce', N'5024', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (415, N'Capilla del Monte', N'5025', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (416, N'Casa Grande', N'5026', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (417, N'Cavanagh', N'5027', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (418, N'Cerro Champaqui', N'5028', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (419, N'Cerro Colorado', N'5029', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (420, N'Charbonier', N'5030', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (421, N'Ciudad de Córdoba', N'5031', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (422, N'Colonia Caroya', N'5032', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (423, N'Copacabana', N'5033', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (424, N'Coronel Moldes', N'5034', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (425, N'Corral de Bustos', N'5035', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (426, N'Cosquín', N'5036', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (427, N'Cruz Alta', N'5037', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (428, N'Cruz Chica', N'5038', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (429, N'Cruz del Eje', N'5039', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (430, N'Cruz Grande', N'5040', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (431, N'Cuesta Blanca', N'5041', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (432, N'D. Velez Sarsfield', N'5042', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (433, N'Dean Funes', N'5043', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (434, N'Del Campillo', N'5044', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (435, N'Despeñaderos', N'5045', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (436, N'Devoto', N'5046', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (437, N'El Durazno', N'5047', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (438, N'El Manzano', N'5048', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (439, N'El Tío', N'5049', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (440, N'Embalse', N'5050', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (441, N'Estancia Vieja', N'5051', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (442, N'Falda del Carmen', N'5052', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (443, N'General Baldissera', N'5053', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (444, N'General Cabrera', N'5054', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (445, N'General Deheza', N'5055', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (446, N'General Levalle', N'5056', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (447, N'Hernando', N'5057', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (448, N'Huerta Grande', N'5058', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (449, N'Huinca Renanco', N'5059', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (450, N'Icho Cruz', N'5060', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (451, N'Ifflinger', N'5061', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (452, N'Intiyaco', N'5062', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (453, N'Ischilín', N'5063', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (454, N'James Craik', N'5064', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (455, N'Jesús María', N'5065', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (456, N'José de la Quintana', N'5066', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (457, N'Jovita', N'5067', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (458, N'Juárez Celman', N'5068', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (459, N'Justiniano Posse', N'5069', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (460, N'La Bolsa', N'5070', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (461, N'Laboulaye', N'5071', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (462, N'La Calera', N'5072', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (463, N'La Carlota', N'5073', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (464, N'La Cesira', N'5074', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (465, N'La Cruz', N'5075', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (466, N'La Cumbre', N'5076', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (467, N'La Cumbrecita', N'5077', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (468, N'La Falda', N'5078', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (469, N'La Francia', N'5079', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (470, N'La Granja', N'5080', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (471, N'La Higuera', N'5081', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (472, N'La Paisanita', N'5082', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (473, N'La Para', N'5083', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (474, N'La Paz', N'5084', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (475, N'La Población', N'5085', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (476, N'La Rancherita', N'5086', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (477, N'Las Albahacas', N'5087', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (478, N'Las Caleras', N'5088', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (479, N'Las Calles', N'5089', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (480, N'Las Chacras', N'5090', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (481, N'La Serranita', N'5091', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (482, N'Las Jarillas', N'5092', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (483, N'Las Peñas', N'5093', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (484, N'Las Perdices', N'5094', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (485, N'Las Rabonas', N'5095', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (486, N'Las Tapias', N'5096', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (487, N'Las Varillas', N'5097', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (488, N'Leones', N'5098', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (489, N'Loma Bola', N'5099', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (490, N'Los Cerrillos', N'5100', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (491, N'Los Cocos', N'5101', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (492, N'Los Cóndores', N'5102', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (493, N'Los Gigantes', N'5103', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (494, N'Los Hornillos', N'5104', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (495, N'Los Molinos', N'5105', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (496, N'Los Pozos', N'5106', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (497, N'Los Reartes', N'5107', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (498, N'Los Surgentes', N'5108', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (499, N'Loza Corral', N'5109', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (500, N'Luque', N'5110', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (501, N'Lutti', N'5111', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (502, N'Luyaba', N'5112', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (503, N'Marcos Juárez', N'5113', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (504, N'Marull', N'5114', 6, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (505, N'BELLA VISTA', N'6001', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (529, N'BELLA VISTA', N'6001', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (530, N'BERON DE ASTRADA', N'6002', 7, N'Corrientes')
GO
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (531, N'CAA CATI', N'6003', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (532, N'CARLOS PELLEGRINI', N'6004', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (533, N'CORRIENTES CAPITAL', N'6005', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (534, N'CURUZU CUATIA', N'6006', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (535, N'EMPEDRADO', N'6007', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (536, N'ESQUINA', N'6008', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (537, N'GOYA', N'6009', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (538, N'ITA IBATE', N'6010', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (539, N'ITATI', N'6011', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (540, N'ITUZAINGO', N'6012', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (541, N'LA CRUZ', N'6013', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (542, N'MBURUCUYA', N'6014', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (543, N'MERCEDES', N'6015', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (544, N'MONTE CASEROS', N'6016', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (545, N'PASO DE LA PATRIA', N'6017', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (546, N'PASO DE LOS LIBRES', N'6018', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (547, N'SANTA ANA', N'6019', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (548, N'SANTO TOME', N'6020', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (549, N'SAUCE', N'6021', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (550, N'VIRASORO', N'6022', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (551, N'YAHAPE', N'6023', 7, N'Corrientes')
INSERT [dbo].[Ciudad] ([Id_Ciudad], [Nombre], [CP], [Provincia], [NombreProvincia]) VALUES (552, N'YAPEYU', N'6024', 7, N'Corrientes')
SET IDENTITY_INSERT [dbo].[Ciudad] OFF
SET IDENTITY_INSERT [dbo].[diccionario] ON 

INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1, N'Crear Idioma')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (2, N'Palabra')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (3, N'Traducción')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (4, N'Guardar')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (5, N'Nuevo')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (6, N'Nombre')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (7, N'Apellido')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (8, N'Usuario')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (9, N'Contraseña')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (10, N'Repetir Contraseña')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (11, N'Alta')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (12, N'Alta de Usuarios')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (13, N'Alta de nuevos Usuarios')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (14, N'Definir Usuario - Familia - Patentes')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (15, N'Ingresar')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (16, N'Registrarse')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (17, N'Ingreso')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (18, N'Dialogo Patentes')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (19, N'Nombre Patente')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (20, N'Formulario')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (21, N'Familia')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (22, N'Nombre Familia')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (23, N'Patentes')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (24, N'Aceptar')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (25, N'Ingresar Patentes')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (26, N'Ingresar Grupo Patente')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (27, N'Modificar')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (28, N'Seleccionar Usuario')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (29, N'Definir Idioma')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (30, N'Salir')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (31, N'Principal')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (32, N'Seleccionar Usuarios')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (33, N'Alta Familia')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (34, N'Alta Patentes')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (48, N'Cantidad')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (49, N'Productos')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (50, N'Proveedores')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (51, N'Nombre Proveedor')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (71, N'Alta Producto')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (72, N'Alta Proveedor')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (73, N'Realizar Pedido')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (74, N'Nombre Producto')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (75, N'Precio')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (76, N'Categoria')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (77, N'Frecuencia dias')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (78, N'Guardar Producto')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (79, N'Eliminar Producto')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (80, N'Modificar Producto')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (81, N'Nombre Categoria')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (82, N'Guardar Nueva')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (83, N'Modificar Categoria')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (84, N'Eliminar Categoria')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (85, N'Modificar Proveedor')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (86, N'Eliminar Proveedor')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (87, N'Evaluacion Proveedor')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (88, N'Nueva Evaluacion')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (89, N'Eliminar')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (90, N'Idioma')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1014, N'Usuarios')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1015, N'Roles')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1016, N'Categorias')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1017, N'Proveedor-Producto')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1018, N'Orden Compra')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1019, N'Idiomas')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1021, N'Compras y Proveedores')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1022, N'Seleccionar')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1024, N'Analisis de Contingencia')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1025, N'Evaluacion de Proveedores')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1026, N'Agregar Producto-Proveedor')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1027, N'Eliminar Producto-Proveedor')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1028, N'Seleccione Producto')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1029, N'Precio Unitario')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1030, N'Descuento por cantidad')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1031, N'Cantidad Minima descuento')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1032, N'Frecuencia (dias)')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1033, N'Cargar Nueva')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1034, N'Direccion')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1035, N'Ciudad')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1036, N'Provincia')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1037, N'Pais')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1038, N'Telefono')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1039, N'Celular (sin 15)')
INSERT [dbo].[diccionario] ([id_diccionario], [clave]) VALUES (1040, N'Correo Electronico')
SET IDENTITY_INSERT [dbo].[diccionario] OFF
SET IDENTITY_INSERT [dbo].[digitovertical] ON 

INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (1, N'pedido', N'D41D8CD98F00B204E9800998ECF8427E', CAST(0xFE3E0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (2, N'pedido', N'F523A5441603F8CDAAAC93CD45394AEC', CAST(0xFE3E0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (3, N'pedido', N'D41D8CD98F00B204E9800998ECF8427E', CAST(0x023F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (4, N'pedido', N'F1FDAD477F2DFAC8DC9514834845B33D', CAST(0x023F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (5, N'pedido', N'FDC29B289EC5D816B57717D2645AEC90', CAST(0x023F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (6, N'pedido', N'44F9A14E61D0DD2D65C719878796D55D', CAST(0x033F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (7, N'pedido', N'7409F6A73BB7233F4C2720F28D92884F', CAST(0x033F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (8, N'pedido', N'4DDCDBE3209EB19EA620032C50C08CD1', CAST(0x033F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (9, N'pedido', N'EBB7BD8F630EC7303DE8F228C4766420', CAST(0x033F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (10, N'pedido', N'E53DA560E644BE8AC682B59EC079142B', CAST(0x043F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (11, N'pedido', N'3B28C3B93E24624CF1EDE96B7E21A82B', CAST(0x4D3F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (12, N'pedido', N'789B678E327492A73B5EC57710D7EA46', CAST(0x4D3F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (13, N'pedido', N'841FBA97E9465F01B7DF866589D3A072', CAST(0x4D3F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (14, N'OrdenCompra', N'18FC53CF2A931DABC141F8B81C4942C9', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (15, N'OrdenCompra', N'6643C2883CBB431F5A37CF23463DD7F5', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (16, N'OrdenCompra', N'AB9C891D69449DEF7C5AF061A8BC9BA4', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (17, N'OrdenCompra', N'937BD53F0709DFF68076305D80E4DF1C', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (19, N'OrdenCompra', N'67898BF771B4E6430AA3F8AC5404576C', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (20, N'OrdenCompra', N'31B0EDA3EFC4AB0223508BC007FC2202', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (22, N'OrdenCompra', N'0F52D28946BD744101E5EA80F29EFF22', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (27, N'OrdenCompra', N'12A2E12B64955900AC72FB0F70136249', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (28, N'OrdenCompra', N'84A13775FE26E656D1247AB4348500D4', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (30, N'OrdenCompra', N'038FECD96DF9BCDF4CB32BA5CD5452FD', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (31, N'OrdenCompra', N'050ACAAB11BBE4542B0D111CCF763964', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (33, N'OrdenCompra', N'7DE010D50692CC4FD9E84043F63E485C', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (41, N'OrdenCompra', N'A13C95179982ACA54999829D4C4D44F0', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (45, N'OrdenCompra', N'19DC0DE792C19FBD2C9F790D433290C3', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (48, N'OrdenCompra', N'37B09662C3FE908E89C8A47DE983919A', CAST(0x523F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (49, N'OrdenCompra', N'C979A38CA4F7ED4A66AC235A4222988E', CAST(0x523F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (18, N'OrdenCompra', N'D3F9E24FC3576075A32DB1473DF34AA7', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (21, N'OrdenCompra', N'2A35C5570BCA1151BD6760807F3050E7', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (29, N'OrdenCompra', N'B1E81076C0D18C167223D7D4E6351990', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (32, N'OrdenCompra', N'7181742C4BA6ED1F639BEDDFFE28A187', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (23, N'OrdenCompra', N'ED61CE518CE72D967C865F6E1F521131', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (24, N'OrdenCompra', N'33FA8614AB9CD575ED20EC1996641E0E', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (25, N'OrdenCompra', N'D7BF4041295BC9E92BFCBB7AD38E9C86', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (26, N'OrdenCompra', N'8EB6FF1121FDA3D7D089927E239EEE4B', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (34, N'OrdenCompra', N'B54D456387A53FE33AB9ED1962D4B7C5', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (38, N'OrdenCompra', N'8885DF02678A8F84E43C203506F75235', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (39, N'OrdenCompra', N'796E25AE842774E24DA7434C277FA9E2', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (40, N'OrdenCompra', N'61FA3306B12848795E54BE01D0B79C4F', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (42, N'OrdenCompra', N'0FA40DDFE323451E2B6F412BEC0EA658', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (44, N'OrdenCompra', N'A2E76C2617FF8309F129ECBFCD4F52A7', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (46, N'OrdenCompra', N'4B40E747C7975463EF74E822AEA826A3', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (47, N'OrdenCompra', N'14225194A5CCE13CCB16511970931B7D', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (35, N'OrdenCompra', N'5E9C3766CD871D080E5F5DFADCED8676', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (36, N'OrdenCompra', N'4E9348A88EECCDC43C86E669600147B7', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (37, N'OrdenCompra', N'DEC21A1708209C6CDE9E7B3E3369940D', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (43, N'OrdenCompra', N'721FC06AA801A7E1104F3CC2B7C3894A', CAST(0x513F0B00 AS Date))
INSERT [dbo].[digitovertical] ([id], [NombreTabla], [Digito], [Fecha]) VALUES (50, N'OrdenCompra', N'D634C5ABC173361FF62FCE0BF734BEB5', CAST(0x523F0B00 AS Date))
SET IDENTITY_INSERT [dbo].[digitovertical] OFF
SET IDENTITY_INSERT [dbo].[Empleado] ON 

INSERT [dbo].[Empleado] ([Id_Empleado], [Nombre], [Apellido], [Id_Area], [NombreArea], [Cargo]) VALUES (2, N'Martin ', N'Fernandez', 3, N'OyP', N'Analista')
INSERT [dbo].[Empleado] ([Id_Empleado], [Nombre], [Apellido], [Id_Area], [NombreArea], [Cargo]) VALUES (3, N'Pablo', N'Garcia', 11, N'Compras y Cont.', N'Gerente')
INSERT [dbo].[Empleado] ([Id_Empleado], [Nombre], [Apellido], [Id_Area], [NombreArea], [Cargo]) VALUES (4, N'Emiliano', N'Lopez', 7, N'Tecnologia e Innovacion', N'DBA')
INSERT [dbo].[Empleado] ([Id_Empleado], [Nombre], [Apellido], [Id_Area], [NombreArea], [Cargo]) VALUES (5, N'Sebastian', N'Perez', 7, N'Tecnologia e Innovacion', N'Desarrollador')
INSERT [dbo].[Empleado] ([Id_Empleado], [Nombre], [Apellido], [Id_Area], [NombreArea], [Cargo]) VALUES (7, N'Ana', N'Montiel', 3, N'OyP', N'Analista')
INSERT [dbo].[Empleado] ([Id_Empleado], [Nombre], [Apellido], [Id_Area], [NombreArea], [Cargo]) VALUES (8, N'Milena', N'Diaz', 11, N'Compras y Cont.', N'Analista')
INSERT [dbo].[Empleado] ([Id_Empleado], [Nombre], [Apellido], [Id_Area], [NombreArea], [Cargo]) VALUES (9, N'Juan Cruz', N'Iglesias', 11, N'Compras y Cont.', N'Analista')
INSERT [dbo].[Empleado] ([Id_Empleado], [Nombre], [Apellido], [Id_Area], [NombreArea], [Cargo]) VALUES (10, N'Ariel', N'Martinez', 11, N'Compras y Cont.', N'Jefe')
INSERT [dbo].[Empleado] ([Id_Empleado], [Nombre], [Apellido], [Id_Area], [NombreArea], [Cargo]) VALUES (11, N'Luis', N'Perez', 3, N'OyP', N'Jefe')
INSERT [dbo].[Empleado] ([Id_Empleado], [Nombre], [Apellido], [Id_Area], [NombreArea], [Cargo]) VALUES (12, N'Maximiliano', N'Salgado', 3, N'OyP', N'Gerente')
SET IDENTITY_INSERT [dbo].[Empleado] OFF
SET IDENTITY_INSERT [dbo].[Evaluacion] ON 

INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2020, 24, N'Arcor SA', 4, 5, 5, 5, CAST(4 AS Decimal(18, 0)), N'Oct 11 2017 12:00AM')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2049, 23, N'Amsa SA', 5, 5, 5, 5, CAST(5 AS Decimal(18, 0)), N'Dec 11 2017 12:00AM')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2055, 23, N'Amsa SA', 5, 5, 5, 5, CAST(5 AS Decimal(18, 0)), N'Jan 12 2018 12:00AM')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2056, 2, N'Ana Dipietro', 5, 5, 5, 5, CAST(5 AS Decimal(18, 0)), N'Jan 12 2018 12:00AM')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2057, 2, N'Ana Dipietro', 5, 5, 5, 5, CAST(5 AS Decimal(18, 0)), N'Jan 12 2018 12:00AM')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2058, 2, N'Ana Dipietro', 5, 5, 5, 5, CAST(5 AS Decimal(18, 0)), N'Jan 12 2018 12:00AM')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2059, 2, N'Ana Dipietro', 4, 4, 4, 4, CAST(4 AS Decimal(18, 0)), N'Jan 12 2018 12:00AM')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2061, 2, N'Ana Dipietro', 2, 2, 2, 2, CAST(2 AS Decimal(18, 0)), N'Jan 12 2018 12:00AM')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2062, 2, N'Ana Dipietro', 2, 5, 3, 4, CAST(3 AS Decimal(18, 0)), N'Jan 12 2018 12:00AM')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2065, 1037, N'Libreria Macarena', 2, 5, 3, 4, CAST(3 AS Decimal(18, 0)), N'Jan 12 2018 12:00AM')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2072, 1036, N'Casa Gomez', 1, 4, 5, 2, CAST(3 AS Decimal(18, 0)), N'Jan 12 2018 12:00AM')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2073, 1039, N'Amanda Reyes', 5, 5, 5, 5, CAST(5 AS Decimal(18, 0)), N'Jan 12 2018 12:00AM')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2074, 1037, N'Libreria Macarena', 2, 2, 2, 2, CAST(2 AS Decimal(18, 0)), N'Jan 12 2018 12:00AM')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2076, 1037, N'Libreria Macarena', 2, 2, 2, 2, CAST(2 AS Decimal(18, 0)), N'2018-01-12')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2077, 1042, N'Los Mirasoles', 3, 4, 3, 2, CAST(3 AS Decimal(18, 0)), N'12/2/2019 10:04:31 a. m.')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2081, 1042, N'Los Mirasoles', 4, 4, 4, 4, CAST(4 AS Decimal(18, 0)), N'12/2/2019 10:39:24 a. m.')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2083, 1042, N'Los Mirasoles', 3, 3, 3, 3, CAST(3 AS Decimal(18, 0)), N'12/2/2019 10:53:24 a. m.')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2087, 27, N'Nicasio Rodriguez', 1, 2, 3, 2, CAST(2 AS Decimal(18, 0)), N'12/2/2019 12:38:11 p. m.')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2092, 24, N'Arcor SA', 5, 5, 5, 5, CAST(5 AS Decimal(18, 0)), N'16/2/2019 9:03:51 p. m.')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2096, 2, N'Ana Dipietro', 2, 2, 2, 2, NULL, N'17/2/2019 8:01:07 p. m.')
INSERT [dbo].[Evaluacion] ([Id_evaluacion], [Proveedor], [NombreProveedor], [Tiempo], [Atencion], [Comunicacion], [Calidad], [Promedio], [Fecha]) VALUES (2097, 2, N'Ana Dipietro', 2, 3, 4, 5, NULL, N'17/2/2019 8:01:15 p. m.')
SET IDENTITY_INSERT [dbo].[Evaluacion] OFF
SET IDENTITY_INSERT [dbo].[idioma] ON 

INSERT [dbo].[idioma] ([id_idioma], [nombre]) VALUES (5, N'Español                                           ')
INSERT [dbo].[idioma] ([id_idioma], [nombre]) VALUES (15, N'Ingles                                            ')
INSERT [dbo].[idioma] ([id_idioma], [nombre]) VALUES (17, N'Afgano                                            ')
INSERT [dbo].[idioma] ([id_idioma], [nombre]) VALUES (18, N'Aleman                                            ')
INSERT [dbo].[idioma] ([id_idioma], [nombre]) VALUES (1019, N'Coreano                                           ')
INSERT [dbo].[idioma] ([id_idioma], [nombre]) VALUES (1020, N'Catalan                                           ')
INSERT [dbo].[idioma] ([id_idioma], [nombre]) VALUES (1021, N'Chino                                             ')
INSERT [dbo].[idioma] ([id_idioma], [nombre]) VALUES (1022, N'Aleman                                            ')
INSERT [dbo].[idioma] ([id_idioma], [nombre]) VALUES (1023, N'Ruso                                              ')
INSERT [dbo].[idioma] ([id_idioma], [nombre]) VALUES (1024, N'Frances                                           ')
INSERT [dbo].[idioma] ([id_idioma], [nombre]) VALUES (1025, N'Aaaaaa                                            ')
SET IDENTITY_INSERT [dbo].[idioma] OFF
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 1, N'Crear Idioma')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 2, N'Palabra')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 3, N'Traducción')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 4, N'Guardar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 5, N'Nuevo')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 6, N'Nombre')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 7, N'Apellido')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 8, N'Usuario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 9, N'Constraseña')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 10, N'Repetir Constraseña')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 11, N'Alta')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 12, N'Alta de Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 13, N'Alta de nuevos Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 14, N'Definir Usuario - Familia - Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 15, N'Ingresar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 16, N'Registrarse')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 17, N'Ingreso')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 18, N'Dialogo Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 19, N'Nombre Patente')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 20, N'Formulario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 21, N'Familia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 22, N'Nombre Familia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 23, N'Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 24, N'Aceptar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 25, N'Ingresar Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 26, N'Ingresar Grupo Patente')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 27, N'Modificar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 28, N'Seleccionar Usuario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 29, N'Definir Idioma')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 30, N'Salir')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 31, N'Principal')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 32, N'Seleccionar Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 33, N'Alta Familia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 34, N'Alta Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 48, N'Cantidad')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 49, N'Productos')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 50, N'Proveedores')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 51, N'Nombre Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 71, N'Alta Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 72, N'Alta Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 73, N'Realizar Pedido')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 74, N'Nombre Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 75, N'Precio')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 76, N'Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 77, N'Frecuencia dias')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 78, N'Guardar Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 79, N'Eliminar Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 80, N'Modificar Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 81, N'Nombre Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 82, N'Guardar Nueva')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 83, N'Modificar Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 84, N'Eliminar Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 85, N'Modificar Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 86, N'Eliminar Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 87, N'Evaluacion Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 88, N'Nueva Evaluacion')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 89, N'Eliminar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 90, N'Idioma')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 1014, N'Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 1015, N'Roles')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 1016, N'Categorias')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 1017, N'Proveedor-Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 1018, N'Orden Compra')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 1019, N'Compras y Proveedores')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 1021, N'Seleccionar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 1024, N'Analisis de contingencia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 1025, N'Evaluacion de Proveedores')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 1026, N'Agregar Producto-Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 1027, N'Eliminar Producto-Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 1028, N'Seleccione Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 1029, N'Precio Unitario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 1030, N'Descuento por cantidad')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (5, 1031, N'Cantidad Minima descuento')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 1, N'Create language')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 2, N'Word')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 3, N'Traslate')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 4, N'Save')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 5, N'New')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 6, N'Name')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 7, N'LastName')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 8, N'Uss')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 9, N'Password')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 10, N'Repeat Password')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 11, N'Register')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 12, N'Register Uss')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 13, N'Register New ussers')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 14, N'Define user-family-patent')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 15, N'Sign In')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 16, N'Registers')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 17, N'Entry')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 18, N'Dialog Patents')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 19, N'Patent Name')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 20, N'Form')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 21, N'Family')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 22, N'Family Name')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 23, N'Patents')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 24, N'To Accept')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 25, N'Enter Patents')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 26, N'Enterr Grups Patents')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 27, N'Modify')
GO
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 28, N'Select Usser')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 29, N'set Leanguage')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 30, N'Get Out')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 31, N'Principal')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 32, N'Select Ussers')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 33, N'Register Family')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 34, N'Register Patents')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 48, N'Quantity')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 49, N'Products')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 50, N'Providers')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 51, N'Name Provider')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 71, N'Register Product')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 72, N'Register Provider')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 73, N'Make an Order')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 74, N'Name Product')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 75, N'Price')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 76, N'Category')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 77, N'Frecuency days')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 78, N'Save Product')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 79, N'Delete Product')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 80, N'Modifyr Product')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 81, N'Name Category')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 82, N'Save New')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 83, N'Modify Category')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 84, N'Delete Category')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 85, N'Modify Provider')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 86, N'Delete Provider')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 87, N'Evaluation Provider')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 88, N'New Evaluation')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 89, N'Delete')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 90, N'Lenguage')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 1014, N'Ussers')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 1015, N'Roles')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 1016, N'Categorys')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 1017, N'Suppliers-Products')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 1018, N'purchase order')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 1019, N'Sales and Suppliers')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 1021, N'Selected')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 1024, N'Contingency analysis')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 1025, N'
Supplier Evaluation')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 1026, N'Add product supplier')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 1027, N'Delete product supplier')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 1028, N'
Select Product')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 1029, N'
Unit price')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 1030, N'Quantity Discount')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (15, 1031, N'
Minimum Order Quantity')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 1, N'Crear Idioma')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 2, N'swqsa')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 3, N'hahjka')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 4, N'Guardar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 5, N'Nuevo')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 6, N'Nombre')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 7, N'Apellido')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 8, N'Usuario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 9, N'Constraseña')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 10, N'Repetir Constraseña')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 11, N'Alta')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 12, N'Alta de Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 13, N'Alta de nuevos Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 14, N'Definir Usuario - Familia - Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 15, N'Ingresar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 16, N'Registrarse')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 17, N'Ingreso')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 18, N'Dialogo Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 19, N'Nombre Patente')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 20, N'Formulario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 21, N'Familia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 22, N'Nombre Familia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 23, N'Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 24, N'Aceptar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 25, N'Ingresar Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 26, N'Ingresar Grupo Patente')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 27, N'Modificar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 28, N'Seleccionar Usuario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 29, N'Definir Idioma')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 30, N'Salir')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 31, N'Principal')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 32, N'Seleccionar Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 33, N'Alta Familia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 34, N'Alta Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 48, N'Cantidad')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 49, N'Productos')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 50, N'Proveedores')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 51, N'Nombre Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 71, N'Alta Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 72, N'Alta Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 73, N'Realizar Pedido')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 74, N'Nombre Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 75, N'Precio')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 76, N'Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 77, N'Frecuencia dias')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 78, N'Guardar Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 79, N'Eliminar Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 80, N'Modificar Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 81, N'Nombre Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 82, N'Guardar Nueva')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 83, N'Modificar Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 84, N'Eliminar Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 85, N'Modificar Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 86, N'Eliminar Proveedor')
GO
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 87, N'Evaluacion Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 88, N'Nueva Evaluacion')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 89, N'Eliminar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 90, N'Idioma')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 1014, N'Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 1015, N'Roles')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 1016, N'Categorias')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 1017, N'Proveedor-Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 1018, N'Orden Compra')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 1019, N'Compras y Proveedores')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 1021, N'Seleccionar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 1024, N'Analisis de contingencia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 1025, N'Evaluacion de Proveedores')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 1026, N'Agregar Producto-Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 1027, N'Eliminar Producto-Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 1028, N'Seleccione Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 1029, N'Precio Unitario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 1030, N'Descuento por cantidad')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (17, 1031, N'Cantidad Minima descuento')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 1, N'Crear Idioma')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 2, N'Palabra')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 3, N'Traducción')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 4, N'Guardar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 5, N'Nuevo')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 6, N'Nombre')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 7, N'Apellido')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 8, N'Usuario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 9, N'Constraseña')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 10, N'Repetir Constraseña')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 11, N'Alta')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 12, N'Alta de Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 13, N'Alta de nuevos Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 14, N'Definir Usuario - Familia - Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 15, N'Ingresar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 16, N'Registrarse')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 17, N'Ingreso')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 18, N'Dialogo Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 19, N'Nombre Patente')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 20, N'Formulario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 21, N'Familia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 22, N'Nombre Familia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 23, N'Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 24, N'Aceptar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 25, N'Ingresar Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 26, N'Ingresar Grupo Patente')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 27, N'Modificar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 28, N'Seleccionar Usuario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 29, N'Definir Idioma')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 30, N'Salir')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 31, N'Principal')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 32, N'Seleccionar Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 33, N'Alta Familia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 34, N'Alta Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 48, N'Cantidad')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 49, N'Productos')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 50, N'Proveedores')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 51, N'Nombre Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 71, N'Alta Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 72, N'Alta Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 73, N'Realizar Pedido')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 74, N'Nombre Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 75, N'Precio')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 76, N'Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 77, N'Frecuencia dias')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 78, N'Guardar Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 79, N'Eliminar Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 80, N'Modificar Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 81, N'Nombre Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 82, N'Guardar Nueva')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 83, N'Modificar Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 84, N'Eliminar Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 85, N'Modificar Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 86, N'Eliminar Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 87, N'Evaluacion Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 88, N'Nueva Evaluacion')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 89, N'Eliminar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 90, N'Idioma')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 1014, N'Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 1015, N'Roles')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 1016, N'Categorias')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 1017, N'Proveedor-Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 1018, N'Orden Compra')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 1019, N'Compras y Proveedores')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 1021, N'Seleccionar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 1024, N'Analisis de contingencia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 1025, N'Evaluacion de Proveedores')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 1026, N'Agregar Producto-Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 1027, N'Eliminar Producto-Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 1028, N'Seleccione Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 1029, N'Precio Unitario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 1030, N'Descuento por cantidad')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (18, 1031, N'Cantidad Minima descuento')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 1, N'Crear Idioma')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 2, N'ppp')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 3, N'Traducción')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 4, N'Guardar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 5, N'Nuevo')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 6, N'Nombre')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 7, N'Apellido')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 8, N'Usuario')
GO
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 9, N'Constraseña')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 10, N'Repetir Constraseña')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 11, N'Alta')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 12, N'Alta de Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 13, N'Alta de nuevos Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 14, N'Definir Usuario - Familia - Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 15, N'Ingresar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 16, N'Registrarse')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 17, N'Ingreso')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 18, N'Dialogo Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 19, N'Nombre Patente')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 20, N'Formulario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 21, N'Familia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 22, N'Nombre Familia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 23, N'Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 24, N'Aceptar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 25, N'Ingresar Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 26, N'Ingresar Grupo Patente')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 27, N'Modificar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 28, N'Seleccionar Usuario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 29, N'Definir Idioma')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 30, N'Salir')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 31, N'Principal')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 32, N'Seleccionar Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 33, N'Alta Familia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 34, N'Alta Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 48, N'Cantidad')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 49, N'Productos')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 50, N'Proveedores')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 51, N'Nombre Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 71, N'Alta Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 72, N'Alta Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 73, N'Realizar Pedido')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 74, N'Nombre Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 75, N'Precio')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 76, N'Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 77, N'Frecuencia dias')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 78, N'Guardar Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 79, N'Eliminar Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 80, N'Modificar Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 81, N'Nombre Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 82, N'Guardar Nueva')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 83, N'Modificar Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 84, N'Eliminar Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 85, N'Modificar Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 86, N'Eliminar Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 87, N'Evaluacion Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 88, N'Nueva Evaluacion')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 89, N'Eliminar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 90, N'Idioma')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 1014, N'Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 1015, N'Roles')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 1016, N'Categorias')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 1017, N'Proveedor-Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 1018, N'Orden Compra')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 1019, N'Compras y Proveedores')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 1021, N'Seleccionar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 1024, N'Analisis de contingencia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 1025, N'Evaluacion de Proveedores')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 1026, N'Agregar Producto-Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 1027, N'Eliminar Producto-Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 1028, N'Seleccione Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 1029, N'Precio Unitario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 1030, N'Descuento por cantidad')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1020, 1031, N'Cantidad Minima descuento')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1021, 1, N'Crear Idioma')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1021, 2, N'Palabra')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1021, 3, N'Traducción')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 1, N'Crear Idioma')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 2, N'Palabra')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 3, N'Traducción')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 4, N'Guardar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 5, N'Nuevo')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 6, N'Nombre')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 7, N'Apellido')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 8, N'Usuario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 9, N'Constraseña')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 10, N'Repetir Constraseña')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 11, N'Alta')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 12, N'Alta de Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 13, N'Alta de nuevos Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 14, N'Definir Usuario - Familia - Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 15, N'Ingresar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 16, N'Registrarse')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 17, N'Ingreso')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 18, N'Dialogo Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 19, N'Nombre Patente')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 20, N'Formulario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 21, N'Familia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 22, N'Nombre Familia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 23, N'Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 24, N'Aceptar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 25, N'Ingresar Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 26, N'Ingresar Grupo Patente')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 27, N'Modificar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 28, N'Seleccionar Usuario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 29, N'Definir Idioma')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 30, N'Salir')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 31, N'Principal')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 32, N'Seleccionar Usuarios')
GO
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 33, N'Alta Familia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 34, N'Alta Patentes')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 48, N'Cantidad')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 49, N'Productos')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 50, N'Proveedores')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 51, N'Nombre Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 71, N'Alta Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 72, N'Alta Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 73, N'Realizar Pedido')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 74, N'Nombre Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 75, N'Precio')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 76, N'Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 77, N'Frecuencia dias')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 78, N'Guardar Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 79, N'Eliminar Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 80, N'Modificar Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 81, N'Nombre Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 82, N'Guardar Nueva')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 83, N'Modificar Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 84, N'Eliminar Categoria')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 85, N'Modificar Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 86, N'Eliminar Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 87, N'Evaluacion Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 88, N'Nueva Evaluacion')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 89, N'Eliminar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 90, N'Idioma')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 1014, N'Usuarios')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 1015, N'Roles')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 1016, N'Categorias')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 1017, N'Proveedor-Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 1018, N'Orden Compra')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 1019, N'Compras y Proveedores')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 1021, N'Seleccionar')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 1024, N'Analisis de contingencia')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 1025, N'Evaluacion de Proveedores')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 1026, N'Agregar Producto-Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 1027, N'Eliminar Producto-Proveedor')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 1028, N'Seleccione Producto')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 1029, N'Precio Unitario')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 1030, N'Descuento por cantidad')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1023, 1031, N'Cantidad Minima descuento')
INSERT [dbo].[idioma_diccionario] ([id_idioma], [id_diccionario], [valor]) VALUES (1024, 1, N'Crear Idioma')
SET IDENTITY_INSERT [dbo].[OrdenCompra] ON 

INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2033, N'12/2/2019', N'Ana Dipietro', N'OyP', N'102', N'9DF4FFD9405440197844B52E1748593F')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2034, N'12/2/2019', N'Nicasio Rodriguez', N'Tecnologia e Innovacion', N'4800', N'21909FB8F5702816B2281E80444E02A1')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2035, N'12/2/2019', N'Ana Dipietro', N'Compras y Cont.', N'3950', N'DA1A20C54939B42240A276FE8C24388C')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2044, N'16/2/2019', N'Libreria Macarena', N'OyP', N'835', N'53069B24679852A82C4991F5BC36B92D')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2045, N'16/2/2019', N'Nicasio Rodriguez', N'OyP', N'840', N'FF9833249EDB87F80C964F0C8F6ED53E')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2046, N'16/2/2019', N'Nicasio Rodriguez', N'OyP', N'840', N'FF9833249EDB87F80C964F0C8F6ED53E')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2047, N'16/2/2019', N'Libreria Macarena', N'OyP', N'1002', N'78F7A08AE6F2769311BC277CAF53DE7F')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2048, N'16/2/2019', N'Libreria Macarena', N'OyP', N'1002', N'78F7A08AE6F2769311BC277CAF53DE7F')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2049, N'16/2/2019', N'Ana Dipietro', N'OyP', N'385', N'0536B735B7507C1F3DD5C02E104B829A')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2050, N'16/2/2019', N'Libreria Macarena', N'OyP', N'8350', N'3CE4CFE245ACCBA0BDF1B956A2ABE6CE')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2051, N'16/2/2019', N'Ana Dipietro', N'OyP', N'4502', N'97C3AB02C90EB042AB706DA0701595F4')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2052, N'16/2/2019', N'Ana Dipietro', N'Tecnologia e Innovacion', N'4740', N'F9BCDF98556993C78ED54764D988874F')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2053, N'16/2/2019', N'Ana Dipietro', N'OyP', N'3902', N'71E2550D6EF9EF1B9479742DC4D73347')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2054, N'16/2/2019', N'Ana Dipietro', N'OyP', N'123', N'A23E268FE77F53CB7D908D2F96686128')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2055, N'16/2/2019', N'Ana Dipietro', N'OyP', N'589', N'797118825A71D4293588AEE9DB7C2C2B')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2056, N'16/2/2019', N'Ana Dipietro', N'OyP', N'479', N'F4F035CE1FD22B03DCAD354588662990')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2057, N'16/2/2019', N'Ana Dipietro', N'OyP', N'44248', N'2DC0B6C8F652056500AA80F9D79FFC51')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2058, N'16/2/2019', N'Libreria Macarena', N'OyP', N'34200', N'4DCA9D40CE189441F02D33F7CB890F5E')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2059, N'16/2/2019', N'Libreria Macarena', N'Tecnologia e Innovacion', N'6490', N'B00FB797CE8654D4F5B78EBF6D53275D')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2060, N'16/2/2019', N'Ana Dipietro', N'OyP', N'330', N'F96913AE23DEF0DEF10A3881A55D6BCB')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2061, N'16/2/2019', N'Ana Dipietro', N'OyP', N'110', N'2E9609637B8DA97EE068EED0DB0C24C0')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2062, N'16/2/2019', N'Ana Dipietro', N'OyP', N'1904', N'FE31B96E15167A44AB844339EC0B5D20')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2063, N'16/2/2019', N'Ana Dipietro', N'OyP', N'1442', N'A386FC957D7774E578514CEB9ABE03C8')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2064, N'16/2/2019', N'Libreria Macarena', N'OyP', N'17736', N'81A9D2C1F202BAC651795BE2F7BC239A')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2065, N'16/2/2019', N'Amanda Reyes', N'OyP', N'345', N'E6E83634B8426A7DCCF9B32F296B1CF5')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2066, N'16/2/2019', N'Ana Dipietro', N'OyP', N'3740', N'D5D505E37AED9896E78FD9867A831E1E')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2067, N'16/2/2019', N'Ana Dipietro', N'OyP', N'275', N'D0066310CC3EABABBF975734EE685623')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2068, N'16/2/2019', N'Ana Dipietro', N'OyP', N'246', N'7102942B4105090E4CD5C5FA3E4B1AA0')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2069, N'16/2/2019', N'Ana Dipietro', N'OyP', N'301', N'6E2D65010A36BF3D20822F09D9B78856')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2070, N'17/2/2019', N'Ana Dipietro', N'OyP', N'275', N'8A8A54D52312AB3EE346DFB7FB323198')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2071, N'17/2/2019', N'Ana Dipietro', N'OyP', N'136', N'C8CBFE427305BEA6338E056A06F076CF')
INSERT [dbo].[OrdenCompra] ([Id_OC], [Fecha], [Proveedor], [Area], [Importe], [dvh]) VALUES (2072, N'17/2/2019', N'Ana Dipietro', N'OyP', N'728', N'2A2BBAFEC1C6FCC04D71A227105C96CA')
SET IDENTITY_INSERT [dbo].[OrdenCompra] OFF
SET IDENTITY_INSERT [dbo].[Pais] ON 

INSERT [dbo].[Pais] ([Id_Pais], [Nombre]) VALUES (1, N'Argentina')
INSERT [dbo].[Pais] ([Id_Pais], [Nombre]) VALUES (2, N'Bolivia')
INSERT [dbo].[Pais] ([Id_Pais], [Nombre]) VALUES (3, N'Brasil')
INSERT [dbo].[Pais] ([Id_Pais], [Nombre]) VALUES (4, N'Chile')
SET IDENTITY_INSERT [dbo].[Pais] OFF
SET IDENTITY_INSERT [dbo].[Patente] ON 

INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (1046, N'Roles', N'WindowsApplication1.DeclararFamilias', N'P', N'Seguridad')
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (1048, N'Alta Patentes', N'WindowsApplication1.DialogoPatentes', N'P', N'Seguridad')
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (1049, N'Proveedores', N'WindowsApplication1.frmProveedor', N'P', N'General')
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (1050, N'Productos', N'WindowsApplication1.frmProducto', N'P', N'General')
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (1051, N'Categorias', N'WindowsApplication1.frmCategoria', N'P', N'General')
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (1053, N'Orden Compra', N'WindowsApplication1.frmRealizarPedido', N'P', N'Ordenes')
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (1054, N'Idiomas', N'WindowsApplication1.frmIdioma', N'P', N'General')
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (1059, N'Familia-Usuario', N'WindowsApplication1.Usuarios', N'P', N'Seguridad')
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (1060, N'ABM Usuario', N'WindowsApplication1.frmAltaUsuarios', N'P', N'Seguridad')
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (1062, N'Gestiónar Bitacora', N'WindowsApplication1.frmBitacora', N'P', N'General')
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (1063, N'Backup', N'WindowsApplication1.Backup', N'P', N'Seguridad')
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (1064, N'Asociar Producto a Proveedor', N'WindowsApplication1.frmProdProv', N'P', N'Ordenes')
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (2080, N'Evaluar Proveedor', N'WindowsApplication1.frmABMevaluacion', N'P', N'Ordenes')
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (2081, N'Administrador', NULL, N'F', NULL)
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (2083, N'Novato', NULL, N'F', NULL)
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (2084, N'Avanzado', NULL, N'F', NULL)
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (2085, N'Gordo Patasucia', N'WindowsApplication1.frmBitacora', N'P', N'Tavo')
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (2086, N'Alta de Familia', N'WindowsApplication1.frmAltaFamilia', N'P', N'Seguridad')
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (2087, N'Externos', NULL, N'F', NULL)
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Tipo], [Menu]) VALUES (2090, N'Atencion al cliente', NULL, N'F', NULL)
SET IDENTITY_INSERT [dbo].[Patente] OFF
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2081, 1046)
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2081, 1048)
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2083, 1049)
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2084, 1049)
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2081, 1050)
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2083, 1050)
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2084, 1050)
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2081, 1051)
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2081, 1053)
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2084, 1054)
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2081, 1059)
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2081, 1060)
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2084, 1060)
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2081, 1062)
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2081, 1063)
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2081, 1064)
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2081, 2080)
INSERT [dbo].[PatentePatente] ([patente_id_padre], [patente_id_hijo]) VALUES (2081, 2086)
SET IDENTITY_INSERT [dbo].[producto] ON 

INSERT [dbo].[producto] ([Id_Producto], [Producto], [Id_Categoria], [Categoria]) VALUES (6, N'Lamparita', 38, N'Iluminación')
INSERT [dbo].[producto] ([Id_Producto], [Producto], [Id_Categoria], [Categoria]) VALUES (35, N'Hotel dos reyes', 4, N'Hoteles')
INSERT [dbo].[producto] ([Id_Producto], [Producto], [Id_Categoria], [Categoria]) VALUES (36, N'Carpeta Oficio', 39, N'Librería')
INSERT [dbo].[producto] ([Id_Producto], [Producto], [Id_Categoria], [Categoria]) VALUES (37, N'Plomero', 74, N'Servicio')
INSERT [dbo].[producto] ([Id_Producto], [Producto], [Id_Categoria], [Categoria]) VALUES (1040, N'Apliques Paredes', 38, N'Iluminación')
INSERT [dbo].[producto] ([Id_Producto], [Producto], [Id_Categoria], [Categoria]) VALUES (3039, N'Lapices', 39, N'Librería')
INSERT [dbo].[producto] ([Id_Producto], [Producto], [Id_Categoria], [Categoria]) VALUES (3045, N'Blem Autobrilo', 72, N'Limpieza')
INSERT [dbo].[producto] ([Id_Producto], [Producto], [Id_Categoria], [Categoria]) VALUES (3046, N'Poet', 72, N'Limpieza')
INSERT [dbo].[producto] ([Id_Producto], [Producto], [Id_Categoria], [Categoria]) VALUES (3047, N'Resma Hojas', 39, N'Librería')
INSERT [dbo].[producto] ([Id_Producto], [Producto], [Id_Categoria], [Categoria]) VALUES (3048, N'Lamparas', 38, N'Iluminación')
INSERT [dbo].[producto] ([Id_Producto], [Producto], [Id_Categoria], [Categoria]) VALUES (3049, N'Mouse Inalambrico', 80, N'Tecnologia')
INSERT [dbo].[producto] ([Id_Producto], [Producto], [Id_Categoria], [Categoria]) VALUES (3050, N'Lamparas', 38, N'Iluminación')
SET IDENTITY_INSERT [dbo].[producto] OFF
SET IDENTITY_INSERT [dbo].[proveedor] ON 

INSERT [dbo].[proveedor] ([Id_Proveedor], [NombreProveedor], [CUIT], [Direccion], [Ciudad], [CodigoPostal], [Provincia], [Pais], [Telefono], [Celular], [CorreoElectronico]) VALUES (2, N'Ana Dipietro', N'23212345777', N'Moreno 3456', N'CABA', N'2334', N'Ciudad Autonoma de Buenos Aires', N'Argentina', N'(011)2334-5645', N'(011)22233444', N'adiaz@hotmail.com')
INSERT [dbo].[proveedor] ([Id_Proveedor], [NombreProveedor], [CUIT], [Direccion], [Ciudad], [CodigoPostal], [Provincia], [Pais], [Telefono], [Celular], [CorreoElectronico]) VALUES (23, N'Amsa SA', N'3322233338', N'Colombres 222', N'Ciudad Autónoma de Bs As', N'1900', N'Ciudad Autónoma de Bs As', N'Argentina', N'(011)2333-3333', N'(344)34444444', N'amsa@gmail.com')
INSERT [dbo].[proveedor] ([Id_Proveedor], [NombreProveedor], [CUIT], [Direccion], [Ciudad], [CodigoPostal], [Provincia], [Pais], [Telefono], [Celular], [CorreoElectronico]) VALUES (24, N'Arcor SA', N'322223456', N'Monte Grande 1232', N'Lomas de Zamora', N'2323', N'Buenos Aires', N'Argentina', N'(576)5776-57', N'(765)765765', N'compras@arcor.com')
INSERT [dbo].[proveedor] ([Id_Proveedor], [NombreProveedor], [CUIT], [Direccion], [Ciudad], [CodigoPostal], [Provincia], [Pais], [Telefono], [Celular], [CorreoElectronico]) VALUES (27, N'Nicasio Rodriguez', N'232444565', N'Matienzo 444', N'Alberti', N'1903', N'Buenos Aires', N'Argentina', N'(022)2929-2929', N'(929)29292929', N'nicasio.rodriguez@gmail.net')
INSERT [dbo].[proveedor] ([Id_Proveedor], [NombreProveedor], [CUIT], [Direccion], [Ciudad], [CodigoPostal], [Provincia], [Pais], [Telefono], [Celular], [CorreoElectronico]) VALUES (1029, N'Juan Cruz Morales', N'1233223232', N'Juana Manzo 345', N'Alejandro Korn (CP: 1904)', N'1904', N'Buenos Aires', N'Argentina', N'(011)2323-4444', N'(011)34234343', N'jmorales@gmail.com')
INSERT [dbo].[proveedor] ([Id_Proveedor], [NombreProveedor], [CUIT], [Direccion], [Ciudad], [CodigoPostal], [Provincia], [Pais], [Telefono], [Celular], [CorreoElectronico]) VALUES (1036, N'Casa Gomez', N'3422234345', N'Mariano Moreno 4356', N'Treinta de Agosto', N'2075', N'Buenos Aires', N'Argentina', N'(233)9384-9933', N'(011)34231122', N'presupuesto@casagomez.com.ar')
INSERT [dbo].[proveedor] ([Id_Proveedor], [NombreProveedor], [CUIT], [Direccion], [Ciudad], [CodigoPostal], [Provincia], [Pais], [Telefono], [Celular], [CorreoElectronico]) VALUES (1037, N'Libreria Macarena', N'3348737781', N'Luis Vernet 342', N'Monte Grande', N'1842', N'Buenos Aires', N'Argentina', N'(011)2343-6677', N'(011)34532233', N'pedidos@libreriasmacarena.com.ar')
INSERT [dbo].[proveedor] ([Id_Proveedor], [NombreProveedor], [CUIT], [Direccion], [Ciudad], [CodigoPostal], [Provincia], [Pais], [Telefono], [Celular], [CorreoElectronico]) VALUES (1039, N'Amanda Reyes', N'33409856780', N'Av Siempre Viva 232', N'Monte Grande', N'1898', N'Buenos Aires', N'Argentina', N'(011)4281-9898', N'(011)46768787', N'areyes@yahoo.com.ar')
INSERT [dbo].[proveedor] ([Id_Proveedor], [NombreProveedor], [CUIT], [Direccion], [Ciudad], [CodigoPostal], [Provincia], [Pais], [Telefono], [Celular], [CorreoElectronico]) VALUES (1041, N'Arcor SA', N'322223456', N'Monte Grande 1232', N'Adrogué', N'1902', N'Buenos Aires', N'Argentina', N'(576)5776-57', N'(765)765765', N'compras@arcor.com')
INSERT [dbo].[proveedor] ([Id_Proveedor], [NombreProveedor], [CUIT], [Direccion], [Ciudad], [CodigoPostal], [Provincia], [Pais], [Telefono], [Celular], [CorreoElectronico]) VALUES (1042, N'Los Mirasoles', N'3398703498', N'Los Mirasoles 9878', N'Acostilla', N'1003', N'Catamarca', N'Argentina', N'(099)3433-5566', N'(099)78789966', N'losmirasolessa@yahoo.com.ar')
SET IDENTITY_INSERT [dbo].[proveedor] OFF
SET IDENTITY_INSERT [dbo].[proveedor_producto] ON 

INSERT [dbo].[proveedor_producto] ([Id_Registro], [Id_Producto], [Producto], [Id_Proveedor], [Proveedor], [Precio], [DescuentoCantidad], [CantidadDescuento]) VALUES (10, 37, N'Plomero', 1042, N'Los Mirasoles', CAST(478 AS Decimal(18, 0)), 10, 10)
INSERT [dbo].[proveedor_producto] ([Id_Registro], [Id_Producto], [Producto], [Id_Proveedor], [Proveedor], [Precio], [DescuentoCantidad], [CantidadDescuento]) VALUES (2, 6, N'Lamparitas', 23, N'Amsa SA', CAST(45 AS Decimal(18, 0)), 10, 50)
INSERT [dbo].[proveedor_producto] ([Id_Registro], [Id_Producto], [Producto], [Id_Proveedor], [Proveedor], [Precio], [DescuentoCantidad], [CantidadDescuento]) VALUES (4, 36, N'Carpeta Oficio', 2, N'Ana Dipietro', CAST(55 AS Decimal(18, 0)), 0, 0)
INSERT [dbo].[proveedor_producto] ([Id_Registro], [Id_Producto], [Producto], [Id_Proveedor], [Proveedor], [Precio], [DescuentoCantidad], [CantidadDescuento]) VALUES (5, 6, N'Lamparitas', 2, N'Ana Dipietro', CAST(34 AS Decimal(18, 0)), 10, 50)
INSERT [dbo].[proveedor_producto] ([Id_Registro], [Id_Producto], [Producto], [Id_Proveedor], [Proveedor], [Precio], [DescuentoCantidad], [CantidadDescuento]) VALUES (6, 3047, N'Resma Hojas', 1037, N'Libreria Macarena', CAST(167 AS Decimal(18, 0)), 15, 500)
INSERT [dbo].[proveedor_producto] ([Id_Registro], [Id_Producto], [Producto], [Id_Proveedor], [Proveedor], [Precio], [DescuentoCantidad], [CantidadDescuento]) VALUES (11, 3049, N'Mouse Inalambrico', 1037, N'Libreria Macarena', CAST(280 AS Decimal(18, 0)), 10, 50)
INSERT [dbo].[proveedor_producto] ([Id_Registro], [Id_Producto], [Producto], [Id_Proveedor], [Proveedor], [Precio], [DescuentoCantidad], [CantidadDescuento]) VALUES (8, 1040, N'Apliques Pared', 27, N'Nicasio Rodriguez', CAST(120 AS Decimal(18, 0)), 10, 10)
INSERT [dbo].[proveedor_producto] ([Id_Registro], [Id_Producto], [Producto], [Id_Proveedor], [Proveedor], [Precio], [DescuentoCantidad], [CantidadDescuento]) VALUES (12, 36, N'Carpeta Oficio', 1037, N'Libreria Macarena', CAST(35 AS Decimal(18, 0)), 0, 0)
INSERT [dbo].[proveedor_producto] ([Id_Registro], [Id_Producto], [Producto], [Id_Proveedor], [Proveedor], [Precio], [DescuentoCantidad], [CantidadDescuento]) VALUES (13, 3039, N'Lapices', 1037, N'Libreria Macarena', CAST(34 AS Decimal(18, 0)), 0, 0)
SET IDENTITY_INSERT [dbo].[proveedor_producto] OFF
INSERT [dbo].[Provincia] ([Id_Provincia], [Nombre], [Pais], [NombrePais]) VALUES (1, N'Ciudad Autónoma de Bs As', 1, N'Argentina')
INSERT [dbo].[Provincia] ([Id_Provincia], [Nombre], [Pais], [NombrePais]) VALUES (2, N'Buenos Aires', 1, N'Argentina')
INSERT [dbo].[Provincia] ([Id_Provincia], [Nombre], [Pais], [NombrePais]) VALUES (3, N'Catamarca', 1, N'Argentina')
INSERT [dbo].[Provincia] ([Id_Provincia], [Nombre], [Pais], [NombrePais]) VALUES (4, N'Chaco', 1, N'Argentina')
INSERT [dbo].[Provincia] ([Id_Provincia], [Nombre], [Pais], [NombrePais]) VALUES (5, N'Chubut', 1, N'Argentina')
INSERT [dbo].[Provincia] ([Id_Provincia], [Nombre], [Pais], [NombrePais]) VALUES (6, N'Córdoba', 1, N'Argentina')
INSERT [dbo].[Provincia] ([Id_Provincia], [Nombre], [Pais], [NombrePais]) VALUES (7, N'Corrientes', 1, N'Argentina')
INSERT [dbo].[Provincia] ([Id_Provincia], [Nombre], [Pais], [NombrePais]) VALUES (25, N'Potosi', 2, N'Bolivia')
INSERT [dbo].[Provincia] ([Id_Provincia], [Nombre], [Pais], [NombrePais]) VALUES (26, N'Santa Cruz', 2, N'Bolivia')
INSERT [dbo].[Provincia] ([Id_Provincia], [Nombre], [Pais], [NombrePais]) VALUES (27, N'Pando', 2, N'Bolivia')
INSERT [dbo].[Provincia] ([Id_Provincia], [Nombre], [Pais], [NombrePais]) VALUES (28, N'La Paz', 2, N'Bolivia')
SET IDENTITY_INSERT [dbo].[RegistroCompra] ON 

INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3068, N'Lamparitas', CAST(45 AS Decimal(18, 0)), 6, CAST(0 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)), 2033)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3070, N'Carpeta Oficio', CAST(38 AS Decimal(18, 0)), 8, CAST(0 AS Decimal(18, 0)), CAST(304 AS Decimal(18, 0)), 2034)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3071, N'Carpeta Oficio', CAST(38 AS Decimal(18, 0)), 7, CAST(0 AS Decimal(18, 0)), CAST(266 AS Decimal(18, 0)), 2035)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3076, N'Veladores', CAST(70 AS Decimal(18, 0)), 8, CAST(0 AS Decimal(18, 0)), CAST(560 AS Decimal(18, 0)), 2035)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3077, N'Apliques Pared', CAST(120 AS Decimal(18, 0)), 67, CAST(804 AS Decimal(18, 0)), CAST(8040 AS Decimal(18, 0)), 2035)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3099, N'Resma Hojas', CAST(167 AS Decimal(18, 0)), 5, CAST(0 AS Decimal(18, 0)), CAST(835 AS Decimal(18, 0)), 2044)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3100, N'Apliques Pared', CAST(120 AS Decimal(18, 0)), 7, CAST(0 AS Decimal(18, 0)), CAST(840 AS Decimal(18, 0)), 2045)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3101, N'Apliques Pared', CAST(120 AS Decimal(18, 0)), 7, CAST(0 AS Decimal(18, 0)), CAST(840 AS Decimal(18, 0)), 2046)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3102, N'Resma Hojas', CAST(167 AS Decimal(18, 0)), 6, CAST(0 AS Decimal(18, 0)), CAST(1002 AS Decimal(18, 0)), 2047)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3103, N'Resma Hojas', CAST(167 AS Decimal(18, 0)), 6, CAST(0 AS Decimal(18, 0)), CAST(1002 AS Decimal(18, 0)), 2048)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3104, N'Carpeta Oficio', CAST(55 AS Decimal(18, 0)), 7, CAST(0 AS Decimal(18, 0)), CAST(385 AS Decimal(18, 0)), 2049)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3105, N'Resma Hojas', CAST(167 AS Decimal(18, 0)), 50, CAST(41750 AS Decimal(18, 0)), CAST(8350 AS Decimal(18, 0)), 2050)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3106, N'Lamparitas', CAST(34 AS Decimal(18, 0)), 3, CAST(0 AS Decimal(18, 0)), CAST(102 AS Decimal(18, 0)), 2051)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3107, N'Carpeta Oficio', CAST(55 AS Decimal(18, 0)), 80, CAST(0 AS Decimal(18, 0)), CAST(4400 AS Decimal(18, 0)), 2051)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3108, N'Carpeta Oficio', CAST(55 AS Decimal(18, 0)), 80, CAST(0 AS Decimal(18, 0)), CAST(4400 AS Decimal(18, 0)), 2052)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3109, N'Lamparitas', CAST(34 AS Decimal(18, 0)), 10, CAST(170 AS Decimal(18, 0)), CAST(340 AS Decimal(18, 0)), 2052)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3110, N'Carpeta Oficio', CAST(55 AS Decimal(18, 0)), 66, CAST(0 AS Decimal(18, 0)), CAST(3630 AS Decimal(18, 0)), 2053)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3111, N'Lamparitas', CAST(34 AS Decimal(18, 0)), 8, CAST(0 AS Decimal(18, 0)), CAST(272 AS Decimal(18, 0)), 2053)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3112, N'Carpeta Oficio', CAST(55 AS Decimal(18, 0)), 1, CAST(0 AS Decimal(18, 0)), CAST(55 AS Decimal(18, 0)), 2054)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3113, N'Lamparitas', CAST(34 AS Decimal(18, 0)), 2, CAST(0 AS Decimal(18, 0)), CAST(68 AS Decimal(18, 0)), 2054)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3114, N'Lamparitas', CAST(34 AS Decimal(18, 0)), 6, CAST(0 AS Decimal(18, 0)), CAST(204 AS Decimal(18, 0)), 2055)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3115, N'Carpeta Oficio', CAST(55 AS Decimal(18, 0)), 7, CAST(0 AS Decimal(18, 0)), CAST(385 AS Decimal(18, 0)), 2055)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3116, N'Carpeta Oficio', CAST(55 AS Decimal(18, 0)), 5, CAST(0 AS Decimal(18, 0)), CAST(275 AS Decimal(18, 0)), 2056)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3117, N'Lamparitas', CAST(34 AS Decimal(18, 0)), 6, CAST(0 AS Decimal(18, 0)), CAST(204 AS Decimal(18, 0)), 2056)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3118, N'Carpeta Oficio', CAST(55 AS Decimal(18, 0)), 250, CAST(0 AS Decimal(18, 0)), CAST(13750 AS Decimal(18, 0)), 2057)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3119, N'Lamparitas', CAST(34 AS Decimal(18, 0)), 897, CAST(15249 AS Decimal(18, 0)), CAST(30498 AS Decimal(18, 0)), 2057)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3120, N'Resma Hojas', CAST(167 AS Decimal(18, 0)), 100, CAST(83500 AS Decimal(18, 0)), CAST(16700 AS Decimal(18, 0)), 2058)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3121, N'Mouse Inalambrico', CAST(280 AS Decimal(18, 0)), 50, CAST(7000 AS Decimal(18, 0)), CAST(14000 AS Decimal(18, 0)), 2058)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3122, N'Carpeta Oficio', CAST(35 AS Decimal(18, 0)), 100, CAST(0 AS Decimal(18, 0)), CAST(3500 AS Decimal(18, 0)), 2058)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3123, N'Resma Hojas', CAST(167 AS Decimal(18, 0)), 20, CAST(16700 AS Decimal(18, 0)), CAST(3340 AS Decimal(18, 0)), 2059)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3124, N'Mouse Inalambrico', CAST(280 AS Decimal(18, 0)), 10, CAST(1400 AS Decimal(18, 0)), CAST(2800 AS Decimal(18, 0)), 2059)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3125, N'Carpeta Oficio', CAST(35 AS Decimal(18, 0)), 10, CAST(0 AS Decimal(18, 0)), CAST(350 AS Decimal(18, 0)), 2059)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3126, N'Carpeta Oficio', CAST(55 AS Decimal(18, 0)), 6, CAST(0 AS Decimal(18, 0)), CAST(330 AS Decimal(18, 0)), 2060)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3127, N'Carpeta Oficio', CAST(55 AS Decimal(18, 0)), 2, CAST(0 AS Decimal(18, 0)), CAST(110 AS Decimal(18, 0)), 2061)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3128, N'Lamparitas', CAST(34 AS Decimal(18, 0)), 56, CAST(952 AS Decimal(18, 0)), CAST(1904 AS Decimal(18, 0)), 2062)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3129, N'Carpeta Oficio', CAST(55 AS Decimal(18, 0)), 12, CAST(0 AS Decimal(18, 0)), CAST(660 AS Decimal(18, 0)), 2063)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3130, N'Lamparitas', CAST(34 AS Decimal(18, 0)), 23, CAST(391 AS Decimal(18, 0)), CAST(782 AS Decimal(18, 0)), 2063)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3131, N'Resma Hojas', CAST(167 AS Decimal(18, 0)), 23, CAST(19205 AS Decimal(18, 0)), CAST(3841 AS Decimal(18, 0)), 2064)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3132, N'Mouse Inalambrico', CAST(280 AS Decimal(18, 0)), 44, CAST(6160 AS Decimal(18, 0)), CAST(12320 AS Decimal(18, 0)), 2064)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3133, N'Carpeta Oficio', CAST(35 AS Decimal(18, 0)), 45, CAST(0 AS Decimal(18, 0)), CAST(1575 AS Decimal(18, 0)), 2064)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3134, N'Mouse Inalambrico', CAST(115 AS Decimal(18, 0)), 3, CAST(0 AS Decimal(18, 0)), CAST(345 AS Decimal(18, 0)), 2065)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3135, N'Carpeta Oficio', CAST(55 AS Decimal(18, 0)), 34, CAST(0 AS Decimal(18, 0)), CAST(1870 AS Decimal(18, 0)), 2066)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3136, N'Lamparitas', CAST(34 AS Decimal(18, 0)), 55, CAST(935 AS Decimal(18, 0)), CAST(1870 AS Decimal(18, 0)), 2066)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3137, N'Carpeta Oficio', CAST(55 AS Decimal(18, 0)), 5, CAST(0 AS Decimal(18, 0)), CAST(275 AS Decimal(18, 0)), 2067)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3138, N'Carpeta Oficio', CAST(55 AS Decimal(18, 0)), 2, CAST(0 AS Decimal(18, 0)), CAST(110 AS Decimal(18, 0)), 2068)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3139, N'Lamparitas', CAST(34 AS Decimal(18, 0)), 4, CAST(0 AS Decimal(18, 0)), CAST(136 AS Decimal(18, 0)), 2068)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3140, N'Carpeta Oficio', CAST(55 AS Decimal(18, 0)), 3, CAST(0 AS Decimal(18, 0)), CAST(165 AS Decimal(18, 0)), 2069)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3141, N'Lamparitas', CAST(34 AS Decimal(18, 0)), 4, CAST(0 AS Decimal(18, 0)), CAST(136 AS Decimal(18, 0)), 2069)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3142, N'Carpeta Oficio', CAST(55 AS Decimal(18, 0)), 5, CAST(0 AS Decimal(18, 0)), CAST(275 AS Decimal(18, 0)), 2070)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3143, N'Lamparitas', CAST(34 AS Decimal(18, 0)), 4, CAST(0 AS Decimal(18, 0)), CAST(136 AS Decimal(18, 0)), 2071)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3144, N'Carpeta Oficio', CAST(55 AS Decimal(18, 0)), 12, CAST(0 AS Decimal(18, 0)), CAST(660 AS Decimal(18, 0)), 2072)
INSERT [dbo].[RegistroCompra] ([Id_Registro], [Producto], [Precio], [Cantidad], [Descuento], [Total], [OrdenCompra]) VALUES (3145, N'Lamparitas', CAST(34 AS Decimal(18, 0)), 2, CAST(0 AS Decimal(18, 0)), CAST(68 AS Decimal(18, 0)), 2072)
SET IDENTITY_INSERT [dbo].[RegistroCompra] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Usuario_id], [Nombre], [Apellido], [Usuario], [Contraseña]) VALUES (2, N'Ana', N'Dipietro', N'adipietro', N'123')
INSERT [dbo].[Usuario] ([Usuario_id], [Nombre], [Apellido], [Usuario], [Contraseña]) VALUES (13, N'Mariaela', N'Antonia', N'mantonia', N'444')
INSERT [dbo].[Usuario] ([Usuario_id], [Nombre], [Apellido], [Usuario], [Contraseña]) VALUES (27, N'Juan', N'Lopez', N'jlopez', N'444')
INSERT [dbo].[Usuario] ([Usuario_id], [Nombre], [Apellido], [Usuario], [Contraseña]) VALUES (2047, N'Gustavo', N'Gouiric', N'ggouiric', N'1234')
INSERT [dbo].[Usuario] ([Usuario_id], [Nombre], [Apellido], [Usuario], [Contraseña]) VALUES (2049, N'Marcos', N'Perez', N'mperez', N'3456')
INSERT [dbo].[Usuario] ([Usuario_id], [Nombre], [Apellido], [Usuario], [Contraseña]) VALUES (2052, N'Tony', N'Stark', N'tstark', N'9900')
INSERT [dbo].[Usuario] ([Usuario_id], [Nombre], [Apellido], [Usuario], [Contraseña]) VALUES (2053, N'bb', N'bb', N'bbb', N'222')
INSERT [dbo].[Usuario] ([Usuario_id], [Nombre], [Apellido], [Usuario], [Contraseña]) VALUES (2054, N'Dario', N'Simonassi', N'dsimonassi', N'dario123')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
INSERT [dbo].[UsuarioPatente] ([usuario_id], [patente_id]) VALUES (2, 1048)
INSERT [dbo].[UsuarioPatente] ([usuario_id], [patente_id]) VALUES (2, 1050)
INSERT [dbo].[UsuarioPatente] ([usuario_id], [patente_id]) VALUES (2, 1053)
INSERT [dbo].[UsuarioPatente] ([usuario_id], [patente_id]) VALUES (2, 1064)
INSERT [dbo].[UsuarioPatente] ([usuario_id], [patente_id]) VALUES (2, 2081)
INSERT [dbo].[UsuarioPatente] ([usuario_id], [patente_id]) VALUES (2, 2085)
INSERT [dbo].[UsuarioPatente] ([usuario_id], [patente_id]) VALUES (27, 1064)
INSERT [dbo].[UsuarioPatente] ([usuario_id], [patente_id]) VALUES (27, 2083)
INSERT [dbo].[UsuarioPatente] ([usuario_id], [patente_id]) VALUES (2047, 1048)
INSERT [dbo].[UsuarioPatente] ([usuario_id], [patente_id]) VALUES (2047, 2081)
INSERT [dbo].[UsuarioPatente] ([usuario_id], [patente_id]) VALUES (2047, 2084)
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Patente]    Script Date: 17/2/2019 9:47:52 p. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Patente] ON [dbo].[Patente]
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PatentePatente]    Script Date: 17/2/2019 9:47:52 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_PatentePatente] ON [dbo].[PatentePatente]
(
	[patente_id_padre] ASC,
	[patente_id_hijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PatentePatente_1]    Script Date: 17/2/2019 9:47:52 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_PatentePatente_1] ON [dbo].[PatentePatente]
(
	[patente_id_hijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[bitacora2]  WITH CHECK ADD  CONSTRAINT [FK_bitacora2_Usuario] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuario] ([Usuario_id])
GO
ALTER TABLE [dbo].[bitacora2] CHECK CONSTRAINT [FK_bitacora2_Usuario]
GO
ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad_Provincia] FOREIGN KEY([Provincia])
REFERENCES [dbo].[Provincia] ([Id_Provincia])
GO
ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [FK_Ciudad_Provincia]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Area] FOREIGN KEY([Id_Area])
REFERENCES [dbo].[Area] ([Id_Area])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Area]
GO
ALTER TABLE [dbo].[Evaluacion]  WITH CHECK ADD  CONSTRAINT [FK_Evaluacion_proveedor] FOREIGN KEY([Proveedor])
REFERENCES [dbo].[proveedor] ([Id_Proveedor])
GO
ALTER TABLE [dbo].[Evaluacion] CHECK CONSTRAINT [FK_Evaluacion_proveedor]
GO
ALTER TABLE [dbo].[idioma_diccionario]  WITH CHECK ADD  CONSTRAINT [FK_idioma_diccionario_diccionario] FOREIGN KEY([id_diccionario])
REFERENCES [dbo].[diccionario] ([id_diccionario])
GO
ALTER TABLE [dbo].[idioma_diccionario] CHECK CONSTRAINT [FK_idioma_diccionario_diccionario]
GO
ALTER TABLE [dbo].[idioma_diccionario]  WITH CHECK ADD  CONSTRAINT [FK_idioma_diccionario_idioma] FOREIGN KEY([id_idioma])
REFERENCES [dbo].[idioma] ([id_idioma])
GO
ALTER TABLE [dbo].[idioma_diccionario] CHECK CONSTRAINT [FK_idioma_diccionario_idioma]
GO
ALTER TABLE [dbo].[PatentePatente]  WITH CHECK ADD  CONSTRAINT [FK_PatentePatente_Patente] FOREIGN KEY([patente_id_padre])
REFERENCES [dbo].[Patente] ([Patente_id])
GO
ALTER TABLE [dbo].[PatentePatente] CHECK CONSTRAINT [FK_PatentePatente_Patente]
GO
ALTER TABLE [dbo].[PatentePatente]  WITH CHECK ADD  CONSTRAINT [FK_PatentePatente_Patente1] FOREIGN KEY([patente_id_hijo])
REFERENCES [dbo].[Patente] ([Patente_id])
GO
ALTER TABLE [dbo].[PatentePatente] CHECK CONSTRAINT [FK_PatentePatente_Patente1]
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_Categoria] FOREIGN KEY([Id_Categoria])
REFERENCES [dbo].[Categoria] ([Id_Categoria])
GO
ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [FK_producto_Categoria]
GO
ALTER TABLE [dbo].[proveedor_producto]  WITH CHECK ADD  CONSTRAINT [FK_proveedor_producto_producto1] FOREIGN KEY([Id_Producto])
REFERENCES [dbo].[producto] ([Id_Producto])
GO
ALTER TABLE [dbo].[proveedor_producto] CHECK CONSTRAINT [FK_proveedor_producto_producto1]
GO
ALTER TABLE [dbo].[proveedor_producto]  WITH CHECK ADD  CONSTRAINT [FK_proveedor_producto_proveedor1] FOREIGN KEY([Id_Proveedor])
REFERENCES [dbo].[proveedor] ([Id_Proveedor])
GO
ALTER TABLE [dbo].[proveedor_producto] CHECK CONSTRAINT [FK_proveedor_producto_proveedor1]
GO
ALTER TABLE [dbo].[Provincia]  WITH CHECK ADD  CONSTRAINT [FK_Provincia_Pais] FOREIGN KEY([Pais])
REFERENCES [dbo].[Pais] ([Id_Pais])
GO
ALTER TABLE [dbo].[Provincia] CHECK CONSTRAINT [FK_Provincia_Pais]
GO
ALTER TABLE [dbo].[RegistroCompra]  WITH CHECK ADD  CONSTRAINT [FK_RegistroCompras_OrdenCompra1] FOREIGN KEY([OrdenCompra])
REFERENCES [dbo].[OrdenCompra] ([Id_OC])
GO
ALTER TABLE [dbo].[RegistroCompra] CHECK CONSTRAINT [FK_RegistroCompras_OrdenCompra1]
GO
USE [master]
GO
ALTER DATABASE [ProductosProveedores] SET  READ_WRITE 
GO
