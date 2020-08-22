CREATE DATABASE [SiReMu]
GO 
USE [SiReMu]
GO
/****** Object:  Table [dbo].[album_sets]    Script Date: 13/08/2020 03:30:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[album_sets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[companiaDisco] [nvarchar](50) NOT NULL,
	[fechaLanzamiento] [date] NOT NULL,
	[ilustracion] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[esPublico] [bit] NOT NULL,
	[usuario_set_id] [int] NOT NULL,
 CONSTRAINT [PK_AlbumSet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cancion_sets]    Script Date: 13/08/2020 03:30:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cancion_sets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[archivo] [nvarchar](max) NOT NULL,
	[artista] [nvarchar](100) NOT NULL,
	[duracion] [time](7) NOT NULL,
	[genero] [nvarchar](50) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[esPromocion] [bit] NOT NULL,
	[likes] [int] NOT NULL,
	[esPublica] [bit] NOT NULL,
	[album_set_id] [int] NOT NULL,
 CONSTRAINT [PK_CancionSet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cancion_sets_lista_reproduccion_sets]    Script Date: 13/08/2020 03:30:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cancion_sets_lista_reproduccion_sets](
	[lista_reproduccion_set_id] [int] NOT NULL,
	[cancion_set_id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lista_reproduccion_sets]    Script Date: 13/08/2020 03:30:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lista_reproduccion_sets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[esDefault] [bit] NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[esPublica] [bit] NOT NULL,
	[ilustracion] [nvarchar](max) NULL,
	[likes] [int] NULL,
	[descripcion] [nvarchar](300) NULL,
 CONSTRAINT [PK_ListaReproduccionSet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lista_usuarios]    Script Date: 13/08/2020 03:30:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lista_usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[usuario_set_id] [int] NOT NULL,
	[lista_reproduccion_set_id] [int] NOT NULL,
	[esPropietario] [bit] NOT NULL,
 CONSTRAINT [PK_UsuarioListaReproduccion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario_sets]    Script Date: 13/08/2020 03:30:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario_sets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[contrasena] [nvarchar](100) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[correo] [nvarchar](70) NOT NULL,
	[esCreadorContenido] [bit] NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[genero] [nvarchar](50) NOT NULL,
	[usuario] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[calidadStream] [nvarchar](50) NULL,
 CONSTRAINT [PK_UsuarioSet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[album_sets]  WITH CHECK ADD  CONSTRAINT [FK_AlbumSet_UsuarioSet] FOREIGN KEY([usuario_set_id])
REFERENCES [dbo].[usuario_sets] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[album_sets] CHECK CONSTRAINT [FK_AlbumSet_UsuarioSet]
GO
ALTER TABLE [dbo].[cancion_sets]  WITH CHECK ADD  CONSTRAINT [FK_CancionAlbum] FOREIGN KEY([album_set_id])
REFERENCES [dbo].[album_sets] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[cancion_sets] CHECK CONSTRAINT [FK_CancionAlbum]
GO
ALTER TABLE [dbo].[cancion_sets_lista_reproduccion_sets]  WITH CHECK ADD  CONSTRAINT [FK_ListaReproduccionCancion_Cancion] FOREIGN KEY([cancion_set_id])
REFERENCES [dbo].[cancion_sets] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[cancion_sets_lista_reproduccion_sets] CHECK CONSTRAINT [FK_ListaReproduccionCancion_Cancion]
GO
ALTER TABLE [dbo].[cancion_sets_lista_reproduccion_sets]  WITH CHECK ADD  CONSTRAINT [FK_ListaReproduccionCancion_ListaReproduccion] FOREIGN KEY([lista_reproduccion_set_id])
REFERENCES [dbo].[lista_reproduccion_sets] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[cancion_sets_lista_reproduccion_sets] CHECK CONSTRAINT [FK_ListaReproduccionCancion_ListaReproduccion]
GO
ALTER TABLE [dbo].[lista_usuarios]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioListaReproduccion_ListaReproduccion] FOREIGN KEY([lista_reproduccion_set_id])
REFERENCES [dbo].[lista_reproduccion_sets] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[lista_usuarios] CHECK CONSTRAINT [FK_UsuarioListaReproduccion_ListaReproduccion]
GO
ALTER TABLE [dbo].[lista_usuarios]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioListaReproduccion_Usuario] FOREIGN KEY([usuario_set_id])
REFERENCES [dbo].[usuario_sets] ([id])
GO
ALTER TABLE [dbo].[lista_usuarios] CHECK CONSTRAINT [FK_UsuarioListaReproduccion_Usuario]
GO
