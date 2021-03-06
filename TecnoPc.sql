CREATE DATABASE [TECNOPC]
GO
USE [TECNOPC]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[ID Categoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre Categoria] [nvarchar](50) UNIQUE NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[ID Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ID Cliente] [int] IDENTITY(1,1) NOT NULL,
	[ID Depto] [int] NOT NULL,
	[Identidad] [nvarchar](15) UNIQUE,
	[Nombre] [nvarchar](30) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
	[Correo Electronico] [nvarchar](50),
	[Direccion] [nvarchar](max) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ID Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[ID Compra] [int] IDENTITY(1,1) NOT NULL,
	[ID Producto] [int] NOT NULL,
	[Fecha Compra] [date] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio Historico] [money] NOT NULL,
 CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
	[ID Compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contactos]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contactos](
	[ID Contacto] [int] IDENTITY(1,1) NOT NULL,
	[ID Proveedor] [int] NOT NULL,
	[ID Depto] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
	[Correo Electronico] [nvarchar](50) UNIQUE,
	[Direccion] [nvarchar](max) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Contactos] PRIMARY KEY CLUSTERED 
(
	[ID Contacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamentos](
	[ID Depto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre Depto] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Departamentos] PRIMARY KEY CLUSTERED 
(
	[ID Depto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[ID Factura] [int] NOT NULL,
	[ID Producto] [int] NOT NULL,
	[Precio Historico] [money] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_DetalleFactura] PRIMARY KEY CLUSTERED 
(
	[ID Factura] ASC,
	[ID Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[ID Empleado] [int] IDENTITY(1,1) NOT NULL,
	[ID Puesto] [int] NOT NULL,
	[ID Depto] [int] NOT NULL,
	[Identidad] [nvarchar](20) UNIQUE,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
	[Correo Electronico] [nvarchar](50) UNIQUE,
	[Direccion] [nvarchar](max) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[ID Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturas](
	[ID Factura] [int] IDENTITY(1,1) NOT NULL,
	[ID Cliente] [int] NOT NULL,
	[ID Empleado] [int] NOT NULL,
	[ID Transaccion] [int] NOT NULL,
	[Fecha Venta] [date] NOT NULL,
	[Fecha Vencimiento] [date] NOT NULL,
	[ISV] [float] NOT NULL,
 CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED 
(
	[ID Factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventarios]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventarios](
	[ID Producto] [int] NOT NULL,
	[Stock] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[ID Marca] [int] IDENTITY(1,1) NOT NULL,
	[Nombre Marca] [nvarchar](50) UNIQUE NOT NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[ID Marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notificacion Compra]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notificacion Compra](
	[ID NOTI] [int] IDENTITY(1,1) NOT NULL,
	[Producto] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Fecha] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Notificacion Compra] PRIMARY KEY CLUSTERED 
(
	[ID NOTI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[ID Producto] [int] IDENTITY(1,1) NOT NULL,
	[ID Categoria] [int] NOT NULL,
	[ID Marca] [int] NOT NULL,
	[ID Proveedor] [int] NOT NULL,
	[Nombre Producto] [nvarchar](50) NOT NULL,
	[Modelo] [nvarchar](50) NOT NULL,
	[Precio Unitario] [money] NOT NULL,
	[Estado] [bit] NOT NULL,
	[CodBarra] [nvarchar](12) UNIQUE NOT NULL,
 CONSTRAINT [PK_Productos_1] PRIMARY KEY CLUSTERED 
(
	[ID Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[ID Proveedor] [int] IDENTITY(1,1) NOT NULL,
	[ID Depto] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL UNIQUE,
	[Telefono] [nvarchar](20) NOT NULL,
	[Direccion] [nvarchar](max) NOT NULL,
	[Correo Electronico] [nvarchar](50) UNIQUE,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[ID Proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puestos]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puestos](
	[ID Puesto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre Puesto] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Puestos] PRIMARY KEY CLUSTERED 
(
	[ID Puesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IDRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre Rol] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[IDRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transacciones]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transacciones](
	[ID Transaccion] [int] IDENTITY(1,1) NOT NULL,
	[Tipo Transaccion] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Transacciones] PRIMARY KEY CLUSTERED 
(
	[ID Transaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[ID Usuario] [int] IDENTITY(1,1) NOT NULL,
	[ID Rol] [int] NOT NULL,
	[ID Empleado] [int] Unique NOT NULL,
	[Nombre Usuario] [nvarchar](50) UNIQUE not null,
	[Clave] [nvarchar](MAX) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[ID Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Departamentos] FOREIGN KEY([ID Depto])
REFERENCES [dbo].[Departamentos] ([ID Depto])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Departamentos]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Productos] FOREIGN KEY([ID Producto])
REFERENCES [dbo].[Productos] ([ID Producto])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Productos]
GO
ALTER TABLE [dbo].[Contactos]  WITH CHECK ADD  CONSTRAINT [FK_Contactos_Departamentos] FOREIGN KEY([ID Depto])
REFERENCES [dbo].[Departamentos] ([ID Depto])
GO
ALTER TABLE [dbo].[Contactos] CHECK CONSTRAINT [FK_Contactos_Departamentos]
GO
ALTER TABLE [dbo].[Contactos]  WITH CHECK ADD  CONSTRAINT [FK_Contactos_Proveedores] FOREIGN KEY([ID Proveedor])
REFERENCES [dbo].[Proveedores] ([ID Proveedor])
GO
ALTER TABLE [dbo].[Contactos] CHECK CONSTRAINT [FK_Contactos_Proveedores]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Facturas] FOREIGN KEY([ID Factura])
REFERENCES [dbo].[Facturas] ([ID Factura])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Facturas]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Productos] FOREIGN KEY([ID Producto])
REFERENCES [dbo].[Productos] ([ID Producto])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Productos]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Departamentos] FOREIGN KEY([ID Depto])
REFERENCES [dbo].[Departamentos] ([ID Depto])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Departamentos]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Puestos] FOREIGN KEY([ID Puesto])
REFERENCES [dbo].[Puestos] ([ID Puesto])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Puestos]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Clientes] FOREIGN KEY([ID Cliente])
REFERENCES [dbo].[Clientes] ([ID Cliente])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_Clientes]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Empleados] FOREIGN KEY([ID Empleado])
REFERENCES [dbo].[Empleados] ([ID Empleado])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_Empleados]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Transacciones] FOREIGN KEY([ID Transaccion])
REFERENCES [dbo].[Transacciones] ([ID Transaccion])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_Transacciones]
GO
ALTER TABLE [dbo].[Inventarios]  WITH CHECK ADD  CONSTRAINT [FK_Inventarios_Productos] FOREIGN KEY([ID Producto])
REFERENCES [dbo].[Productos] ([ID Producto])
GO
ALTER TABLE [dbo].[Inventarios] CHECK CONSTRAINT [FK_Inventarios_Productos]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Categorias] FOREIGN KEY([ID Categoria])
REFERENCES [dbo].[Categorias] ([ID Categoria])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Categorias]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Marcas] FOREIGN KEY([ID Marca])
REFERENCES [dbo].[Marcas] ([ID Marca])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Marcas]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Proveedores] FOREIGN KEY([ID Proveedor])
REFERENCES [dbo].[Proveedores] ([ID Proveedor])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Proveedores]
GO
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD  CONSTRAINT [FK_Proveedores_Departamentos] FOREIGN KEY([ID Depto])
REFERENCES [dbo].[Departamentos] ([ID Depto])
GO
ALTER TABLE [dbo].[Proveedores] CHECK CONSTRAINT [FK_Proveedores_Departamentos]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Empleados] FOREIGN KEY([ID Empleado])
REFERENCES [dbo].[Empleados] ([ID Empleado])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Empleados]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([ID Rol])
REFERENCES [dbo].[Roles] ([IDRol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
/****** Object:  Trigger [dbo].[UPInventario]    Script Date: 19/3/2022 09:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo
-- Create date: 20-02-2022
-- Description:	Actualizar el estado a 0
-- =============================================
CREATE TRIGGER [dbo].[UPInventario]
   ON  [dbo].[Compras]
   AFTER INSERT
AS 
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @cantidad int;
	DECLARE @id int;
	DECLARE @stock int;
	DECLARE @suma int;

SELECT @cantidad =  inserted .Cantidad
FROM     inserted  INNER JOIN
                  Inventarios ON inserted .[ID Producto] = Inventarios.[ID Producto]

SELECT @id =  inserted .[ID Producto]
FROM     inserted  INNER JOIN
                  Inventarios ON inserted .[ID Producto] = Inventarios.[ID Producto]

SELECT @stock = Inventarios.Stock
FROM     Compras INNER JOIN
                  Inventarios ON Compras.[ID Producto] = Inventarios.[ID Producto]
	
SET @suma = @stock + @cantidad 


	UPDATE Inventarios SET Stock = @suma  where Inventarios.[ID Producto] = @id 

SET @suma = 0
SET @cantidad = 0
SET @stock = 0

END
GO
ALTER TABLE [dbo].[Compras] ENABLE TRIGGER [UPInventario]
GO
/****** Object:  Trigger [dbo].[UPInventario_Restar]    Script Date: 19/3/2022 09:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo
-- Create date: 20-02-2022
-- Description:	Eliminara del stock la cantidad vendida
-- =============================================
CREATE TRIGGER [dbo].[UPInventario_Restar]
   ON  [dbo].[DetalleFactura]
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    	DECLARE @cantidad int;
	DECLARE @id int;
	DECLARE @stock int;
	DECLARE @suma int;

SELECT @cantidad =  inserted .Cantidad
FROM     inserted  

SELECT @id =  inserted .[ID Producto]
FROM     inserted  

SELECT @stock = Inventarios.Stock
FROM     inserted   INNER JOIN
                  Inventarios ON inserted  .[ID Producto] = Inventarios.[ID Producto]
	
SET @suma = @stock - @cantidad 


	UPDATE Inventarios SET Stock = @suma  where Inventarios.[ID Producto] = @id 

SET @suma = 0
SET @cantidad = 0
SET @stock = 0

END
GO
ALTER TABLE [dbo].[DetalleFactura] ENABLE TRIGGER [UPInventario_Restar]
GO
/****** Object:  Trigger [dbo].[InsNotificacionesCompra]    Script Date: 19/3/2022 09:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 20-02-2022
-- Description:	Insertar Datos en tabla notificacion
-- =============================================
CREATE TRIGGER [dbo].[InsNotificacionesCompra]
   ON  [dbo].[Inventarios]
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @Producto nvarchar(50);
	DECLARE @Cantidad int;

SELECT @Producto = Productos.[Nombre Producto]
FROM     Productos INNER JOIN
                  inserted  ON Productos.[ID Producto] = inserted .[ID Producto]

SELECT @Cantidad = Inventarios.Stock
FROM     Inventarios INNER JOIN
                  inserted  ON Inventarios.[ID Producto] = inserted .[ID Producto]


IF(@Cantidad <= 15)
BEGIN

INSERT INTO [dbo].[Notificacion Compra]
           ([Producto]
           ,[Descripcion]
           ,[Fecha]
           ,[Estado])
     VALUES
           (@Producto, 
           'Hay Poca Existencia del Siguiente Producto: '+@Producto +'. Es Requerido Reabastecer la Existencia del Producto.',
           GETDATE(),
           1)
END

END
GO
ALTER TABLE [dbo].[Inventarios] ENABLE TRIGGER [InsNotificacionesCompra]
GO
USE [master]
GO
ALTER DATABASE [TECNOPC] SET  READ_WRITE 
GO

USE [TECNOPC]
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([ID Categoria], [Nombre Categoria]) VALUES (1, N'Celulares')
INSERT [dbo].[Categorias] ([ID Categoria], [Nombre Categoria]) VALUES (2, N'Televisores')
INSERT [dbo].[Categorias] ([ID Categoria], [Nombre Categoria]) VALUES (3, N'Videojuegos')
INSERT [dbo].[Categorias] ([ID Categoria], [Nombre Categoria]) VALUES (4, N'Auriculares')
INSERT [dbo].[Categorias] ([ID Categoria], [Nombre Categoria]) VALUES (5, N'Computadoras')
INSERT [dbo].[Categorias] ([ID Categoria], [Nombre Categoria]) VALUES (6, N'Camaras')
INSERT [dbo].[Categorias] ([ID Categoria], [Nombre Categoria]) VALUES (7, N'Tablets')
INSERT [dbo].[Categorias] ([ID Categoria], [Nombre Categoria]) VALUES (8, N'Licencias')
INSERT [dbo].[Categorias] ([ID Categoria], [Nombre Categoria]) VALUES (9, N'Relojes Inteligentes')
INSERT [dbo].[Categorias] ([ID Categoria], [Nombre Categoria]) VALUES (10, N'Equipo de Audio')
INSERT [dbo].[Categorias] ([ID Categoria], [Nombre Categoria]) VALUES (11, N'Monitores')
INSERT [dbo].[Categorias] ([ID Categoria], [Nombre Categoria]) VALUES (12, N'Teclados')
INSERT [dbo].[Categorias] ([ID Categoria], [Nombre Categoria]) VALUES (13, N'Mouses')
INSERT [dbo].[Categorias] ([ID Categoria], [Nombre Categoria]) VALUES (14, N'Almacenamiento')
INSERT [dbo].[Categorias] ([ID Categoria], [Nombre Categoria]) VALUES (15, N'Cargadores')
INSERT [dbo].[Categorias] ([ID Categoria], [Nombre Categoria]) VALUES (16, N'Impresoras')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
SET IDENTITY_INSERT [dbo].[Marcas] ON 

INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (1, N'Dell')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (2, N'Lenovo')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (3, N'MSI')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (4, N'HP')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (5, N'EPSON')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (6, N'LG')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (7, N'BENQ')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (8, N'ASUS')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (9, N'Samsung')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (10, N'Sony')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (11, N'HTC')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (12, N'Canon')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (13, N'Xbox')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (14, N'Playstation')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (15, N'Huawei')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (16, N'Alcatel')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (17, N'Apple')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (18, N'Xiaomi')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (19, N'Motorola')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (20, N'Toshiba')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (21, N'Kingstone')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (22, N'RCA')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (23, N'Philips')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (24, N'Nintendo')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (25, N'Intel')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (26, N'AMD')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (27, N'SanDisk')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (28, N'Acer')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (29, N'Google')
INSERT [dbo].[Marcas] ([ID Marca], [Nombre Marca]) VALUES (30, N'Microsoft')
SET IDENTITY_INSERT [dbo].[Marcas] OFF
GO
SET IDENTITY_INSERT [dbo].[Departamentos] ON 

INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (1, N'Atlantida')
INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (2, N'Colon')
INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (3, N'Comayagua')
INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (4, N'Copan')
INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (5, N'Cortes')
INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (6, N'Choluteca')
INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (7, N'El Paraiso')
INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (8, N'Francisco Morazan')
INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (9, N'Gracias a Dios')
INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (10, N'Intibuca')
INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (11, N'Islas de la Bahia')
INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (12, N'La Paz')
INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (13, N'Lempira')
INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (14, N'Ocotepeque')
INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (15, N'Olancho')
INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (16, N'Santa Barbara')
INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (17, N'Valle')
INSERT [dbo].[Departamentos] ([ID Depto], [Nombre Depto]) VALUES (18, N'Yoro')
SET IDENTITY_INSERT [dbo].[Departamentos] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (1, 8, N'Accesorios para Computadoras y Oficinas, S.A', N'98176762', N'BARRIO GUADALUPE,
TEGUCIGALPA, M.D.C', N'oficosa@gmail.com', 1)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (2, 8, N'JABKABED INVERSIONES', N'22234746', N'RESIDENCIAL LOSPROCERES, CALLEPRINCIPAL, CASA 252,TEGUCIGALPA, M.D.C', N'jabkabed@outlook.com', 1)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (3, 8, N'DISTRIBUIDORA CHOROTEGA', N'22450009', N'BOULEVARD DELNORTE,COMAYAGUELA,M.D.C.', N'chorotegadis@gmail.com', 1)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (4, 8, N'CENTROMATIC', N'23220109', N'COLONIA LA ALAMEDA, EDIFICIO LISBOA, 1421, TEGUCIGALPA, M.D.C', N'maticetro_@yahoo.com', 1)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (5, 8, N'COMPUSER', N'98066466', N'COLONIA TEPEYAC, BOULEVARD JUAN PABLO II, CONTIGUO A LAVANDERIA MAYA, TEGUCIGALPA, M.D.C', N'compuser_@outlook.com', 1)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (6, 8, N'COMYSO', N'89065456', N'BARRIO MORAZAN, CALLE PRINCIPAL, SENDERO EL TRIUNFO, CASA 1109, TEGUCIGALPA, M.D.C', N'comyso@yahoo.com', 1)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (7, 8, N'HARD SYSTEMS', N'22236609', N'BARRIO CONCEPCION, 4 Y 5 CALLE, 4 AVENIDA, CENTRO COMERCIAL SUPER COLOR, COMAYAGUELA, M.D.C.', N'systems_hard_@gmail.com', 1)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (8, 8, N'EYS', N'22267876', N'COLONIA FLORENCIA NORTE, EDIFICIO CH INVERSIONES, CONTIGUO A BANPAIS, BLVD. SUYAPA, TEGUCIGALPA, M.D.C.', N'_eys_@yahoo.com', 1)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (9, 8, N'TECNICOM', N'22217476', N'COLONIA HATO DE EN MEDIO, SECTOR 7CALLE DEL COMERCIO, EDIFICIO DIMAFRE, 2 PISO, TEGUCIGALPA, M.D.', N'tecnicom@outlook.com', 1)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (10, 8, N'INFOTEC', N'99867473', N'CENTRO DE NEGOCIOS LAS LOMAS, LOMAS DEL GUIJARRO, 1ER PISO, TEGUICIGALPA, M.D.C.', N'_infotec01@outlook.com', 1)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (11, 8, N'SYSTEM MART', N'22267478', N'BOULEVARD SUYAPA, CONTIGUO A REPOSTERIA EL HOGAR, TEGUCIGALPA, M.D.C', N'martsystem@gmail.com', 1)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (12, 3, N'entero', N'786589', N'dsdkksd', N'jota', 0)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (13, 8, N'Técnologias Unidas', N'22267346', N'BARRIO EL CENTRO, ESQUINA OPUESTA AL CINE VARIEDADES, TEGUCIGALPA, M.D.C', N'info@tecnologias-unidas.com', 1)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (14, 1, N'macizo', N'232', N'kskd', N'ksd', 0)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (15, 1, N'a', N',', N'm', N'n', 0)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (16, 8, N'Jetstero', N'22334499', N'Tegucigalpa', N'streojjet@yahoo.com', 0)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (17, 1, N'sala', N'890', N'nnxc', N'jjsd', 0)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (18, 1, N'colac', N'78', N'mm', N'nna', 0)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (19, 1, N'casasa', N'243', N'kidfs', N'msd', 0)
INSERT [dbo].[Proveedores] ([ID Proveedor], [ID Depto], [Nombre], [Telefono], [Direccion], [Correo Electronico], [Estado]) VALUES (20, 2, N'Tepito', N'23232', N'por ahi', N'sds@g.com', 0)
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([ID Producto], [ID Categoria], [ID Marca], [ID Proveedor], [Nombre Producto], [Modelo], [Precio Unitario], [Estado], [CodBarra]) VALUES (1, 1, 15, 3, N'Huawei Y9 Prime 2019', N'Prime 2019', 7000.0000, 1, N'764608000000')
INSERT [dbo].[Productos] ([ID Producto], [ID Categoria], [ID Marca], [ID Proveedor], [Nombre Producto], [Modelo], [Precio Unitario], [Estado], [CodBarra]) VALUES (2, 5, 2, 5, N'Ideapad 3', N'SZX-9000', 15000.0000, 1, N'764608000001')
INSERT [dbo].[Productos] ([ID Producto], [ID Categoria], [ID Marca], [ID Proveedor], [Nombre Producto], [Modelo], [Precio Unitario], [Estado], [CodBarra]) VALUES (3, 1, 9, 5, N'iphone', N'10', 5000.0000, 1, N'764608000002')
INSERT [dbo].[Productos] ([ID Producto], [ID Categoria], [ID Marca], [ID Proveedor], [Nombre Producto], [Modelo], [Precio Unitario], [Estado], [CodBarra]) VALUES (4, 14, 28, 1, N'a', N'ks', 8.0000, 0, N'764608000003')
INSERT [dbo].[Productos] ([ID Producto], [ID Categoria], [ID Marca], [ID Proveedor], [Nombre Producto], [Modelo], [Precio Unitario], [Estado], [CodBarra]) VALUES (5, 1, 10, 5, N'Sony Ericson', N'Yz100', 800.0000, 1, N'764608000006')
INSERT [dbo].[Productos] ([ID Producto], [ID Categoria], [ID Marca], [ID Proveedor], [Nombre Producto], [Modelo], [Precio Unitario], [Estado], [CodBarra]) VALUES (9, 5, 28, 11, N'Portatil Acer', N'H2345', 15000.0000, 1, N'764608000020')
INSERT [dbo].[Productos] ([ID Producto], [ID Categoria], [ID Marca], [ID Proveedor], [Nombre Producto], [Modelo], [Precio Unitario], [Estado], [CodBarra]) VALUES (10, 13, 8, 1, N'Mouse gaming', N'45897', 500.0000, 1, N'764608000003')
INSERT [dbo].[Productos] ([ID Producto], [ID Categoria], [ID Marca], [ID Proveedor], [Nombre Producto], [Modelo], [Precio Unitario], [Estado], [CodBarra]) VALUES (11, 2, 9, 11, N'Plasma Samsung', N'32 pulgadas', 5800.0000, 1, N'764608000004')
INSERT [dbo].[Productos] ([ID Producto], [ID Categoria], [ID Marca], [ID Proveedor], [Nombre Producto], [Modelo], [Precio Unitario], [Estado], [CodBarra]) VALUES (12, 8, 30, 5, N'Licencia Office 2019', N'1 Mes', 500.0000, 1, N'764608000007')
INSERT [dbo].[Productos] ([ID Producto], [ID Categoria], [ID Marca], [ID Proveedor], [Nombre Producto], [Modelo], [Precio Unitario], [Estado], [CodBarra]) VALUES (1006, 1, 10, 7, N'Xperia', N'T100', 1500.0000, 1, N'700000000156')
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([ID Cliente], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (1, 1, N'90', N'as', N'hj', N'87', N'jsjsj', N'ksjsjsjsjjs', 0)
INSERT [dbo].[Clientes] ([ID Cliente], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (2, 6, N'121', N'jjjj', N'jjjsjd', N'9283', N'shdjs', N'ksdjsk', 0)
INSERT [dbo].[Clientes] ([ID Cliente], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (3, 1, N'80919900000', N'Jenn', N'Astora', N'99887766', N'jenn@yahooc.om', N'Ceiba', 0)
INSERT [dbo].[Clientes] ([ID Cliente], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (4, 1, N'78', N'ha', N'm', N'8', N'm', N'jkl', 0)
INSERT [dbo].[Clientes] ([ID Cliente], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (5, 8, N'7200315466', N'Adria', N'Jon Fierro', N'93590989', N'mateo83@hispavista.com', N'Calle Valeria, Apto 5', 1)
INSERT [dbo].[Clientes] ([ID Cliente], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (6, 14, N'225199632654', N'Berta ', N'Oliver Domingo', N'90457998', N'roberto67@latinmail.com', N'Av. Medrano, 023, Hab. 78', 1)
INSERT [dbo].[Clientes] ([ID Cliente], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (7, 16, N'325199612456', N'Gabriel Alejandro ', N'Valverde Solorio', N'51786005', N'vtellez@loya.org', N'Callejón Delagarza, Hab. 33', 1)
INSERT [dbo].[Clientes] ([ID Cliente], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (8, 18, N'234199023569', N'Miguel ', N'Sauceda', N'81684545', N'lola.ruelas@sarabia.com', N'Avenida Jesus, 3, Nro 0', 1)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Puestos] ON 

INSERT [dbo].[Puestos] ([ID Puesto], [Nombre Puesto]) VALUES (1, N'Administrador')
INSERT [dbo].[Puestos] ([ID Puesto], [Nombre Puesto]) VALUES (2, N'Director')
INSERT [dbo].[Puestos] ([ID Puesto], [Nombre Puesto]) VALUES (3, N'Vendedor')
INSERT [dbo].[Puestos] ([ID Puesto], [Nombre Puesto]) VALUES (4, N'Jefe de Compras')
INSERT [dbo].[Puestos] ([ID Puesto], [Nombre Puesto]) VALUES (5, N'Empleador')
SET IDENTITY_INSERT [dbo].[Puestos] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleados] ON 

INSERT [dbo].[Empleados] ([ID Empleado], [ID Puesto], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (1, 1, 8, N'0802199001516', N'Steven', N'Nolasco', N'99890979', N'nolasteven@gmail.com', N'Tegucigalpa', 1)
INSERT [dbo].[Empleados] ([ID Empleado], [ID Puesto], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (2, 2, 10, N'0708200090901', N'Jeferson', N'Estrada', N'95465326', N'estradajef@gmail.com', N'Colonia las Vermudas, calle #4 y casa #47', 1)
INSERT [dbo].[Empleados] ([ID Empleado], [ID Puesto], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (3, 1, 1, N'00000', N'casa', N'b', N'i', N'n', N'j', 0)
INSERT [dbo].[Empleados] ([ID Empleado], [ID Puesto], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (4, 1, 7, N'0703200200182', N'Yelson', N'Figueroa', N'89412723', N'Danli', N'Colonia El zarzal', 0)
INSERT [dbo].[Empleados] ([ID Empleado], [ID Puesto], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (5, 1, 4, N'maamas', N'sds', N'nams', N'mkad', N'a ', N' lla', 0)
INSERT [dbo].[Empleados] ([ID Empleado], [ID Puesto], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (6, 1, 1, N'mamalo', N'mm', N'sa', N'jk', N'jn', N'kk', 0)
INSERT [dbo].[Empleados] ([ID Empleado], [ID Puesto], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (7, 3, 7, N'0703200104218', N'Lorenzo', N'Lagos', N'98068075', N'lagosariasa343@gmail.com', N'Col. Bella vista, dos cuadras al norte de Fabrica tabacos de Danli', 1)
INSERT [dbo].[Empleados] ([ID Empleado], [ID Puesto], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (8, 3, 1, N'909883', N'loco', N'nnnn', N'12881', N'ksd', N'kkkss', 0)
INSERT [dbo].[Empleados] ([ID Empleado], [ID Puesto], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (9, 3, 8, N'0810200019999', N'Luis', N'Alexander', N'90098998', N'xanderluis@yahoo.com', N'Tegucigalpa', 0)
INSERT [dbo].[Empleados] ([ID Empleado], [ID Puesto], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (10, 1, 1, N'7778', N'hola', N'quetal', N'789', N'bbz', N'jjzx', 0)
INSERT [dbo].[Empleados] ([ID Empleado], [ID Puesto], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (11, 3, 7, N'0703200200182', N'Yelson', N'Figueroa', N'89412723', N'eduardoyelson@gmail.com', N'Col. El zarzal ', 1)
INSERT [dbo].[Empleados] ([ID Empleado], [ID Puesto], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (12, 4, 8, N'0703200000000', N'Alex', N'Figueroa', N'88776655', N'alex@yahoo.com', N'Colonia Los Robles', 1)
INSERT [dbo].[Empleados] ([ID Empleado], [ID Puesto], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (13, 3, 7, N'9099090909090', N'mama', N'papa', N'88997766', N'a@j.com', N'zarzal', 0)
INSERT [dbo].[Empleados] ([ID Empleado], [ID Puesto], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (14, 4, 7, N'0703200200182', N'yelson', N'canales', N'22334455', N'yelson@yahoo.com', N'colonia', 0)
INSERT [dbo].[Empleados] ([ID Empleado], [ID Puesto], [ID Depto], [Identidad], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (15, 5, 8, N'08090000111', N'Sebastian', N'Villalobos', N'12', N'as@g.com', N'12312', 0)
SET IDENTITY_INSERT [dbo].[Empleados] OFF
GO
SET IDENTITY_INSERT [dbo].[Transacciones] ON 

INSERT [dbo].[Transacciones] ([ID Transaccion], [Tipo Transaccion]) VALUES (1, N'Efectivo')
INSERT [dbo].[Transacciones] ([ID Transaccion], [Tipo Transaccion]) VALUES (2, N'Tarjeta')
SET IDENTITY_INSERT [dbo].[Transacciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Facturas] ON 

INSERT [dbo].[Facturas] ([ID Factura], [ID Cliente], [ID Empleado], [ID Transaccion], [Fecha Venta], [Fecha Vencimiento], [ISV]) VALUES (1, 1, 1, 1, CAST(N'2022-12-15' AS Date), CAST(N'2023-01-15' AS Date), 15)
INSERT [dbo].[Facturas] ([ID Factura], [ID Cliente], [ID Empleado], [ID Transaccion], [Fecha Venta], [Fecha Vencimiento], [ISV]) VALUES (2, 1, 1, 1, CAST(N'2022-01-01' AS Date), CAST(N'2022-02-01' AS Date), 15)
INSERT [dbo].[Facturas] ([ID Factura], [ID Cliente], [ID Empleado], [ID Transaccion], [Fecha Venta], [Fecha Vencimiento], [ISV]) VALUES (3, 1, 1, 1, CAST(N'2022-01-01' AS Date), CAST(N'2023-01-01' AS Date), 15)
INSERT [dbo].[Facturas] ([ID Factura], [ID Cliente], [ID Empleado], [ID Transaccion], [Fecha Venta], [Fecha Vencimiento], [ISV]) VALUES (4, 1, 1, 1, CAST(N'2022-01-01' AS Date), CAST(N'2022-01-01' AS Date), 25)
INSERT [dbo].[Facturas] ([ID Factura], [ID Cliente], [ID Empleado], [ID Transaccion], [Fecha Venta], [Fecha Vencimiento], [ISV]) VALUES (5, 1, 1, 1, CAST(N'2022-02-02' AS Date), CAST(N'2023-02-02' AS Date), 15)
INSERT [dbo].[Facturas] ([ID Factura], [ID Cliente], [ID Empleado], [ID Transaccion], [Fecha Venta], [Fecha Vencimiento], [ISV]) VALUES (6, 2, 1, 1, CAST(N'2022-02-25' AS Date), CAST(N'2022-03-25' AS Date), 0.15)
INSERT [dbo].[Facturas] ([ID Factura], [ID Cliente], [ID Empleado], [ID Transaccion], [Fecha Venta], [Fecha Vencimiento], [ISV]) VALUES (7, 8, 1, 1, CAST(N'2022-03-01' AS Date), CAST(N'2022-04-01' AS Date), 0.15)
INSERT [dbo].[Facturas] ([ID Factura], [ID Cliente], [ID Empleado], [ID Transaccion], [Fecha Venta], [Fecha Vencimiento], [ISV]) VALUES (8, 7, 1, 1, CAST(N'2022-03-01' AS Date), CAST(N'2022-04-01' AS Date), 0.2)
INSERT [dbo].[Facturas] ([ID Factura], [ID Cliente], [ID Empleado], [ID Transaccion], [Fecha Venta], [Fecha Vencimiento], [ISV]) VALUES (1007, 5, 1, 2, CAST(N'2022-03-02' AS Date), CAST(N'2022-04-02' AS Date), 0.15)
INSERT [dbo].[Facturas] ([ID Factura], [ID Cliente], [ID Empleado], [ID Transaccion], [Fecha Venta], [Fecha Vencimiento], [ISV]) VALUES (1008, 5, 1, 2, CAST(N'2022-03-05' AS Date), CAST(N'2022-04-05' AS Date), 0.15)
INSERT [dbo].[Facturas] ([ID Factura], [ID Cliente], [ID Empleado], [ID Transaccion], [Fecha Venta], [Fecha Vencimiento], [ISV]) VALUES (1009, 8, 1, 1, CAST(N'2022-03-05' AS Date), CAST(N'2022-04-05' AS Date), 0.15)
INSERT [dbo].[Facturas] ([ID Factura], [ID Cliente], [ID Empleado], [ID Transaccion], [Fecha Venta], [Fecha Vencimiento], [ISV]) VALUES (1010, 5, 1, 2, CAST(N'2022-03-18' AS Date), CAST(N'2022-04-18' AS Date), 0.15)
INSERT [dbo].[Facturas] ([ID Factura], [ID Cliente], [ID Empleado], [ID Transaccion], [Fecha Venta], [Fecha Vencimiento], [ISV]) VALUES (1011, 8, 1, 2, CAST(N'2022-03-19' AS Date), CAST(N'2022-04-19' AS Date), 0.2)
SET IDENTITY_INSERT [dbo].[Facturas] OFF
GO
SET IDENTITY_INSERT [dbo].[Contactos] ON 

INSERT [dbo].[Contactos] ([ID Contacto], [ID Proveedor], [ID Depto], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (1, 5, 1, N'Panfilo', N'Gomez', N'00000000', N'panfilo@gmail.com', N'Atlantida, calle #4 casa #6', 0)
INSERT [dbo].[Contactos] ([ID Contacto], [ID Proveedor], [ID Depto], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (2, 1, 1, N'Kilian ', N'Rodriguez', N'56487895', N'rodrguez@gmail.com', N'Carretera Nil, Casa 49', 1)
INSERT [dbo].[Contactos] ([ID Contacto], [ID Proveedor], [ID Depto], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (3, 4, 8, N'Rodrigo', N'Calvo', N'450-0634239', N'guillem.matias@gmail.com', N'Av. Laia, 66, Casa 0', 1)
INSERT [dbo].[Contactos] ([ID Contacto], [ID Proveedor], [ID Depto], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (4, 18, 7, N'Ariadna ', N'Macias', N'+628 9613', N'montez.lidia@hotmail.com', N'Avenida Roque, 03, Piso 7', 1)
INSERT [dbo].[Contactos] ([ID Contacto], [ID Proveedor], [ID Depto], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (5, 3, 15, N'Angel ', N'Méndez', N'25629583', N'guillem62@gmail.com', N'Cl. Ruben, 42, Nro 74', 1)
INSERT [dbo].[Contactos] ([ID Contacto], [ID Proveedor], [ID Depto], [Nombre], [Apellido], [Telefono], [Correo Electronico], [Direccion], [Estado]) VALUES (6, 16, 16, N'Luis Andres ', N'de Anda Rosa', N'90261924', N'eva99@rolon.net', N'Vereda Ian, Hab. 28', 1)
SET IDENTITY_INSERT [dbo].[Contactos] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([IDRol], [Nombre Rol]) VALUES (1, N'Administrador')
INSERT [dbo].[Roles] ([IDRol], [Nombre Rol]) VALUES (2, N'Vendedor')
INSERT [dbo].[Roles] ([IDRol], [Nombre Rol]) VALUES (3, N'Jefe de Compras')
INSERT [dbo].[Roles] ([IDRol], [Nombre Rol]) VALUES (4, N'Empleador')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([ID Usuario], [ID Rol], [ID Empleado], [Nombre Usuario], [Clave], [Estado]) VALUES (1, 1, 1, N'admin', ENCRYPTBYPASSPHRASE('TecnoPc', N'admonuser1'), 1)
INSERT [dbo].[Usuarios] ([ID Usuario], [ID Rol], [ID Empleado], [Nombre Usuario], [Clave], [Estado]) VALUES (3, 2, 7, N'lagos343', ENCRYPTBYPASSPHRASE('TecnoPc', N'Manino10'), 1)
INSERT [dbo].[Usuarios] ([ID Usuario], [ID Rol], [ID Empleado], [Nombre Usuario], [Clave], [Estado]) VALUES (5, 2, 12, N'vendedor', ENCRYPTBYPASSPHRASE('TecnoPc', N'1234'), 1)

SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (1, 1, 30.0000, 10)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (1, 2, 30.0000, 10)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (1, 3, 30.0000, 10)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (2, 1, 30.0000, 10)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (2, 2, 30.0000, 10)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (2, 3, 30.0000, 10)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (2, 4, 30.0000, 47)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (3, 1, 30.0000, 10)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (3, 2, 30.0000, 10)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (3, 3, 30.0000, 5)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (3, 4, 30.0000, 1)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (4, 1, 30.0000, 5)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (4, 2, 30.0000, 10)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (4, 3, 30.0000, 3)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (5, 1, 30.0000, 20)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (5, 3, 30.0000, 20)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (6, 1, 7000.0000, 2)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (6, 2, 15000.0000, 2)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (6, 4, 8.0000, 2)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (7, 3, 5000.0000, 4)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (7, 11, 5800.0000, 4)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (8, 1, 7000.0000, 4)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (8, 2, 15000.0000, 3)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (8, 3, 5000.0000, 3)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (1007, 9, 15000.0000, 2)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (1008, 1006, 1500.0000, 1)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (1009, 1, 7000.0000, 2)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (1009, 5, 800.0000, 1)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (1009, 1006, 1500.0000, 2)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (1010, 5, 800.0000, 1)
INSERT [dbo].[DetalleFactura] ([ID Factura], [ID Producto], [Precio Historico], [Cantidad]) VALUES (1011, 1, 7000.0000, 2)
GO
SET IDENTITY_INSERT [dbo].[Compras] ON 

INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (1, 2, CAST(N'2022-02-20' AS Date), 20, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (2, 2, CAST(N'2022-02-20' AS Date), 10, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (3, 2, CAST(N'2022-02-20' AS Date), 10, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (4, 1, CAST(N'2022-02-20' AS Date), 10, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (5, 4, CAST(N'2022-02-20' AS Date), 10, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (6, 3, CAST(N'2022-02-20' AS Date), 5, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (7, 3, CAST(N'2022-02-20' AS Date), 5, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (8, 1, CAST(N'2022-02-20' AS Date), 5, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (9, 2, CAST(N'2022-02-20' AS Date), 5, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (10, 4, CAST(N'2022-02-20' AS Date), 5, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (11, 1, CAST(N'2022-02-20' AS Date), 25, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (12, 3, CAST(N'2022-02-20' AS Date), 25, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (13, 1, CAST(N'2022-02-20' AS Date), 25, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (14, 1, CAST(N'2022-02-20' AS Date), 25, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (15, 1, CAST(N'2022-02-20' AS Date), 15, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (16, 2, CAST(N'2022-02-20' AS Date), 15, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (17, 2, CAST(N'2022-02-20' AS Date), 10, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (18, 2, CAST(N'2022-02-20' AS Date), 10, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (19, 2, CAST(N'2022-02-20' AS Date), 10, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (20, 2, CAST(N'2022-02-20' AS Date), 10, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (21, 2, CAST(N'2022-02-20' AS Date), 10, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (22, 2, CAST(N'2022-02-20' AS Date), 10, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (23, 1, CAST(N'2022-02-20' AS Date), 10, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (24, 3, CAST(N'2022-02-20' AS Date), 10, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (25, 1, CAST(N'2022-02-20' AS Date), 15, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (26, 1, CAST(N'2022-02-20' AS Date), 20, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (27, 2, CAST(N'2022-02-20' AS Date), 10, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (28, 2, CAST(N'2022-02-20' AS Date), 100, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (29, 3, CAST(N'2022-02-20' AS Date), 1, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (30, 4, CAST(N'2022-02-20' AS Date), 12, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (31, 1, CAST(N'2022-02-20' AS Date), 500, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (32, 3, CAST(N'2022-02-20' AS Date), 200, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (33, 4, CAST(N'2022-02-20' AS Date), 200, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (34, 4, CAST(N'2022-02-20' AS Date), 200, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (35, 4, CAST(N'2022-02-20' AS Date), 200, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (36, 4, CAST(N'2022-02-20' AS Date), 200, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (37, 4, CAST(N'2022-02-20' AS Date), 200, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (38, 1, CAST(N'2022-02-20' AS Date), 200, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (39, 1, CAST(N'2022-02-20' AS Date), 200, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (40, 1, CAST(N'2022-02-20' AS Date), 200, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (41, 2, CAST(N'2022-02-20' AS Date), 20, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (42, 1, CAST(N'2022-02-20' AS Date), 20, 30.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (43, 1, CAST(N'2022-02-20' AS Date), 10, 19.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (44, 1, CAST(N'2022-02-20' AS Date), 10, 19.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (45, 1, CAST(N'2022-02-20' AS Date), 10, 40.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (46, 2, CAST(N'2022-02-20' AS Date), 30, 40.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (47, 1, CAST(N'2022-02-21' AS Date), 10, 1.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (48, 1, CAST(N'2022-02-21' AS Date), 10, 1.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (49, 2, CAST(N'2022-02-21' AS Date), 10, 1.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (50, 2, CAST(N'2022-02-21' AS Date), 10, 1.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (51, 2, CAST(N'2022-02-21' AS Date), 10, 1.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (52, 2, CAST(N'2022-02-21' AS Date), 10, 1.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (53, 2, CAST(N'2022-02-21' AS Date), 10, 1.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (54, 2, CAST(N'2022-02-21' AS Date), 10, 1.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (55, 2, CAST(N'2022-02-21' AS Date), 10, 1.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (56, 2, CAST(N'2022-02-21' AS Date), 10, 1.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (57, 2, CAST(N'2022-02-21' AS Date), 10, 1.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (58, 1, CAST(N'2022-03-02' AS Date), 27, 7000.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (59, 3, CAST(N'2022-03-02' AS Date), 20, 5000.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (60, 2, CAST(N'2022-03-02' AS Date), 25, 15000.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (1058, 1, CAST(N'2022-03-02' AS Date), 47, 7000.0000)
INSERT [dbo].[Compras] ([ID Compra], [ID Producto], [Fecha Compra], [Cantidad], [Precio Historico]) VALUES (1059, 10, CAST(N'2022-03-12' AS Date), 10, 500.0000)
SET IDENTITY_INSERT [dbo].[Compras] OFF
GO
INSERT [dbo].[Inventarios] ([ID Producto], [Stock]) VALUES (1, 96)
INSERT [dbo].[Inventarios] ([ID Producto], [Stock]) VALUES (2, 50)
INSERT [dbo].[Inventarios] ([ID Producto], [Stock]) VALUES (3, 22)
INSERT [dbo].[Inventarios] ([ID Producto], [Stock]) VALUES (5, 98)
INSERT [dbo].[Inventarios] ([ID Producto], [Stock]) VALUES (9, 48)
INSERT [dbo].[Inventarios] ([ID Producto], [Stock]) VALUES (10, 25)
INSERT [dbo].[Inventarios] ([ID Producto], [Stock]) VALUES (1006, 17)
INSERT [dbo].[Inventarios] ([ID Producto], [Stock]) VALUES (11, 41)
INSERT [dbo].[Inventarios] ([ID Producto], [Stock]) VALUES (12, 80)
GO
SET IDENTITY_INSERT [dbo].[Notificacion Compra] ON 

INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (1, N'papas', N'comprar un par de unidad de papas', CAST(N'2022-02-20T17:39:10.110' AS DateTime), 0)
INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (2, N'pchorros', N'comprar un par de unidad de chorros', CAST(N'2022-02-20T17:39:23.110' AS DateTime), 0)
INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (3, N'Huawei Y9 Prime 2019', N'Hay Poca Existencia del Siguiente Producto: Huawei Y9 Prime 2019. Es Requerido Reabastecer la Existencia del Producto.', CAST(N'2022-02-20T20:26:55.793' AS DateTime), 0)
INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (4, N'Huawei Y9 Prime 2019', N'Hay Poca Existencia del Siguiente Producto: Huawei Y9 Prime 2019. Es Requerido Reabastecer la Existencia del Producto.', CAST(N'2022-02-20T20:28:33.837' AS DateTime), 0)
INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (5, N'a', N'Hay Poca Existencia del Siguiente Producto: a. Es Requerido Reabastecer la Existencia del Producto.', CAST(N'2022-02-20T20:32:40.867' AS DateTime), 0)
INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (6, N'Huawei Y9 Prime 2019', N'Hay Poca Existencia del Siguiente Producto: Huawei Y9 Prime 2019. Es Requerido Reabastecer la Existencia del Producto.', CAST(N'2022-02-20T20:32:55.503' AS DateTime), 0)
INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (7, N'Huawei Y9 Prime 2019', N'Hay Poca Existencia del Siguiente Producto: Huawei Y9 Prime 2019. Es Requerido Reabastecer la Existencia del Producto.', CAST(N'2022-02-20T20:35:12.417' AS DateTime), 0)
INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (8, N'Ideapad 3', N'Hay Poca Existencia del Siguiente Producto: Ideapad 3. Es Requerido Reabastecer la Existencia del Producto.', CAST(N'2022-02-20T20:36:22.327' AS DateTime), 0)
INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (14, N'Ideapad 3', N'Hay Poca Existencia del Siguiente Producto: Ideapad 3. Es Requerido Reabastecer la Existencia del Producto.', CAST(N'2022-02-20T22:13:37.183' AS DateTime), 0)
INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (15, N'Huawei Y9 Prime 2019', N'Hay Poca Existencia del Siguiente Producto: Huawei Y9 Prime 2019. Es Requerido Reabastecer la Existencia del Producto.', CAST(N'2022-02-20T22:16:40.970' AS DateTime), 0)
INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (16, N'Huawei Y9 Prime 2019', N'Hay Poca Existencia del Siguiente Producto: Huawei Y9 Prime 2019. Es Requerido Reabastecer la Existencia del Producto.', CAST(N'2022-02-20T22:39:11.327' AS DateTime), 0)
INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (17, N'Ideapad 3', N'Hay Poca Existencia del Siguiente Producto: Ideapad 3. Es Requerido Reabastecer la Existencia del Producto.', CAST(N'2022-02-20T22:39:21.373' AS DateTime), 0)
INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (18, N'iphone', N'Hay Poca Existencia del Siguiente Producto: iphone. Es Requerido Reabastecer la Existencia del Producto.', CAST(N'2022-02-20T22:46:32.963' AS DateTime), 0)
INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (19, N'Huawei Y9 Prime 2019', N'Hay Poca Existencia del Siguiente Producto: Huawei Y9 Prime 2019. Es Requerido Reabastecer la Existencia del Producto.', CAST(N'2022-02-21T12:10:09.047' AS DateTime), 0)
INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (20, N'Ideapad 3', N'Hay Poca Existencia del Siguiente Producto: Ideapad 3. Es Requerido Reabastecer la Existencia del Producto.', CAST(N'2022-02-21T12:10:18.353' AS DateTime), 0)
INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (21, N'Huawei Y9 Prime 2019', N'Hay Poca Existencia del Siguiente Producto: Huawei Y9 Prime 2019. Es Requerido Reabastecer la Existencia del Producto.', CAST(N'2022-02-21T12:11:00.450' AS DateTime), 0)
INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (22, N'iphone', N'Hay Poca Existencia del Siguiente Producto: iphone. Es Requerido Reabastecer la Existencia del Producto.', CAST(N'2022-03-02T00:00:50.357' AS DateTime), 0)
INSERT [dbo].[Notificacion Compra] ([ID NOTI], [Producto], [Descripcion], [Fecha], [Estado]) VALUES (23, N'Mouse gaming', N'Hay Poca Existencia del Siguiente Producto: Mouse gaming. Es Requerido Reabastecer la Existencia del Producto.', CAST(N'2022-03-02T00:16:37.293' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Notificacion Compra] OFF
GO