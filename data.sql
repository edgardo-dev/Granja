USE [GranjaSystem.Models.Contexto]
GO
/****** Object:  Table [dbo].[tblCerdas]    Script Date: 23/04/2020 23:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCerdas](
	[IdCerda] [int] IDENTITY(1,1) NOT NULL,
	[NumCerda] [int] NOT NULL,
	[Procedencia] [nvarchar](max) NULL,
	[Observaciones] [nvarchar](max) NULL,
	[NumParto] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[Estado] [nvarchar](max) NULL,
	[IdGenetica] [int] NOT NULL,
 CONSTRAINT [PK_dbo.tblCerdas] PRIMARY KEY CLUSTERED 
(
	[IdCerda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblControlLechones]    Script Date: 23/04/2020 23:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblControlLechones](
	[IdControlL] [int] IDENTITY(1,1) NOT NULL,
	[IdLotes] [int] NOT NULL,
	[FechaDestete] [nvarchar](max) NULL,
	[IdCerda] [int] NOT NULL,
	[TotalLechones] [int] NOT NULL,
	[PesoPromedioL] [float] NOT NULL,
	[Lotes_IdLote] [int] NULL,
 CONSTRAINT [PK_dbo.tblControlLechones] PRIMARY KEY CLUSTERED 
(
	[IdControlL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDetalleLotes]    Script Date: 23/04/2020 23:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDetalleLotes](
	[IdDLote] [int] IDENTITY(1,1) NOT NULL,
	[IdCerda] [int] NOT NULL,
	[FechaInseminacion] [datetime] NOT NULL,
	[FechaParto] [datetime] NOT NULL,
	[IdVarraco] [int] NOT NULL,
	[Fvacuna1] [datetime] NOT NULL,
	[Fvacuna2] [datetime] NOT NULL,
	[Observaciones] [nvarchar](max) NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[IdLote] [int] NOT NULL,
	[Estado] [nvarchar](max) NULL,
	[Fvacuna15] [datetime] NULL,
 CONSTRAINT [PK_dbo.tblDetalleLotes] PRIMARY KEY CLUSTERED 
(
	[IdDLote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEmpleados]    Script Date: 23/04/2020 23:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmpleados](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[NombreEmpleado] [nvarchar](max) NULL,
	[ApellidoEmpleado] [nvarchar](max) NULL,
	[Telefono] [int] NOT NULL,
	[DUI] [nvarchar](max) NULL,
	[NIT] [nvarchar](max) NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[FechaNacimiento] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tblEmpleados] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblFichas]    Script Date: 23/04/2020 23:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFichas](
	[IdFicha] [int] IDENTITY(1,1) NOT NULL,
	[IdCerda] [int] NOT NULL,
	[NumParto] [int] NOT NULL,
	[FechaServio] [nvarchar](max) NULL,
	[IdVarraco] [int] NOT NULL,
	[FechaParto] [nvarchar](max) NULL,
	[NacidosVivos] [int] NULL,
	[NacidosMuertos] [int] NULL,
	[NacidosMomias] [int] NULL,
	[TotalNacidos] [int] NULL,
	[PesoPromedio1D] [decimal](18, 2) NULL,
	[NumDestetado] [int] NULL,
	[PesoPromedio28D] [decimal](18, 2) NULL,
	[FechaDestete] [nvarchar](max) NULL,
	[IdEmpleado] [int] NOT NULL,
	[Lote] [int] NULL,
 CONSTRAINT [PK_dbo.tblFichas] PRIMARY KEY CLUSTERED 
(
	[IdFicha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblGeneticas]    Script Date: 23/04/2020 23:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGeneticas](
	[IdGenetica] [int] IDENTITY(1,1) NOT NULL,
	[Genetica] [nvarchar](max) NULL,
	[Observacion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tblGeneticas] PRIMARY KEY CLUSTERED 
(
	[IdGenetica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLechones]    Script Date: 23/04/2020 23:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLechones](
	[IdLechones] [int] IDENTITY(1,1) NOT NULL,
	[NumLote] [int] NOT NULL,
	[Edad] [int] NOT NULL,
	[NCerdos] [int] NOT NULL,
	[NCerdas] [int] NOT NULL,
	[NVarracos] [int] NOT NULL,
	[Fases] [nvarchar](max) NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[Estado] [nvarchar](max) NULL,
	[qqDiarios] [decimal](18, 2) NOT NULL,
	[qqSemanal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.tblLechones] PRIMARY KEY CLUSTERED 
(
	[IdLechones] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLotes]    Script Date: 23/04/2020 23:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLotes](
	[IdLote] [int] IDENTITY(1,1) NOT NULL,
	[NumLote] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[Estado] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tblLotes] PRIMARY KEY CLUSTERED 
(
	[IdLote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRoles]    Script Date: 23/04/2020 23:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRoles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tblRoles] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsuarios]    Script Date: 23/04/2020 23:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](max) NULL,
	[Clave] [nvarchar](max) NULL,
	[IdEmpleado] [int] NOT NULL,
	[IdRol] [int] NOT NULL,
 CONSTRAINT [PK_dbo.tblUsuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVacunas]    Script Date: 23/04/2020 23:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVacunas](
	[IdVacuna] [int] IDENTITY(1,1) NOT NULL,
	[IdCerda] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[FechaInyeccion] [nvarchar](max) NULL,
	[Vacuna] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tblVacunas] PRIMARY KEY CLUSTERED 
(
	[IdVacuna] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVacunasLotes]    Script Date: 23/04/2020 23:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVacunasLotes](
	[IdVacunaLote] [int] IDENTITY(1,1) NOT NULL,
	[IdLote] [int] NOT NULL,
	[FechaVacuna] [datetime] NOT NULL,
	[Vacuna] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tblVacunasLotes] PRIMARY KEY CLUSTERED 
(
	[IdVacunaLote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVarracos]    Script Date: 23/04/2020 23:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVarracos](
	[IdVarraco] [int] IDENTITY(1,1) NOT NULL,
	[NumVarraco] [int] NOT NULL,
	[Procedencia] [nvarchar](max) NULL,
	[Observaciones] [nvarchar](max) NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[Estado] [nvarchar](max) NULL,
	[IdGenetica] [int] NOT NULL,
 CONSTRAINT [PK_dbo.tblVarracos] PRIMARY KEY CLUSTERED 
(
	[IdVarraco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblLechones] ADD  DEFAULT ((0)) FOR [qqDiarios]
GO
ALTER TABLE [dbo].[tblLechones] ADD  DEFAULT ((0)) FOR [qqSemanal]
GO
ALTER TABLE [dbo].[tblCerdas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblCerdas_dbo.tblGeneticas_IdGenetica] FOREIGN KEY([IdGenetica])
REFERENCES [dbo].[tblGeneticas] ([IdGenetica])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblCerdas] CHECK CONSTRAINT [FK_dbo.tblCerdas_dbo.tblGeneticas_IdGenetica]
GO
ALTER TABLE [dbo].[tblControlLechones]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblControlLechones_dbo.tblCerdas_IdCerda] FOREIGN KEY([IdCerda])
REFERENCES [dbo].[tblCerdas] ([IdCerda])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblControlLechones] CHECK CONSTRAINT [FK_dbo.tblControlLechones_dbo.tblCerdas_IdCerda]
GO
ALTER TABLE [dbo].[tblControlLechones]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblControlLechones_dbo.tblLotes_Lotes_IdLote] FOREIGN KEY([Lotes_IdLote])
REFERENCES [dbo].[tblLotes] ([IdLote])
GO
ALTER TABLE [dbo].[tblControlLechones] CHECK CONSTRAINT [FK_dbo.tblControlLechones_dbo.tblLotes_Lotes_IdLote]
GO
ALTER TABLE [dbo].[tblDetalleLotes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblDetalleLotes_dbo.tblCerdas_IdCerda] FOREIGN KEY([IdCerda])
REFERENCES [dbo].[tblCerdas] ([IdCerda])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblDetalleLotes] CHECK CONSTRAINT [FK_dbo.tblDetalleLotes_dbo.tblCerdas_IdCerda]
GO
ALTER TABLE [dbo].[tblDetalleLotes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblDetalleLotes_dbo.tblLotes_IdLote] FOREIGN KEY([IdLote])
REFERENCES [dbo].[tblLotes] ([IdLote])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblDetalleLotes] CHECK CONSTRAINT [FK_dbo.tblDetalleLotes_dbo.tblLotes_IdLote]
GO
ALTER TABLE [dbo].[tblDetalleLotes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblDetalleLotes_dbo.tblVarracos_IdVarraco] FOREIGN KEY([IdVarraco])
REFERENCES [dbo].[tblVarracos] ([IdVarraco])
GO
ALTER TABLE [dbo].[tblDetalleLotes] CHECK CONSTRAINT [FK_dbo.tblDetalleLotes_dbo.tblVarracos_IdVarraco]
GO
ALTER TABLE [dbo].[tblFichas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblFichas_dbo.tblCerdas_IdCerda] FOREIGN KEY([IdCerda])
REFERENCES [dbo].[tblCerdas] ([IdCerda])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblFichas] CHECK CONSTRAINT [FK_dbo.tblFichas_dbo.tblCerdas_IdCerda]
GO
ALTER TABLE [dbo].[tblFichas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblFichas_dbo.tblEmpleados_IdEmpleado] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[tblEmpleados] ([IdEmpleado])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblFichas] CHECK CONSTRAINT [FK_dbo.tblFichas_dbo.tblEmpleados_IdEmpleado]
GO
ALTER TABLE [dbo].[tblFichas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblFichas_dbo.tblVarracos_IdVarraco] FOREIGN KEY([IdVarraco])
REFERENCES [dbo].[tblVarracos] ([IdVarraco])
GO
ALTER TABLE [dbo].[tblFichas] CHECK CONSTRAINT [FK_dbo.tblFichas_dbo.tblVarracos_IdVarraco]
GO
ALTER TABLE [dbo].[tblUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblUsuarios_dbo.tblEmpleados_IdEmpleado] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[tblEmpleados] ([IdEmpleado])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblUsuarios] CHECK CONSTRAINT [FK_dbo.tblUsuarios_dbo.tblEmpleados_IdEmpleado]
GO
ALTER TABLE [dbo].[tblUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblUsuarios_dbo.tblRoles_IdRol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[tblRoles] ([IdRol])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblUsuarios] CHECK CONSTRAINT [FK_dbo.tblUsuarios_dbo.tblRoles_IdRol]
GO
ALTER TABLE [dbo].[tblVacunas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblVacunas_dbo.tblCerdas_IdCerda] FOREIGN KEY([IdCerda])
REFERENCES [dbo].[tblCerdas] ([IdCerda])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblVacunas] CHECK CONSTRAINT [FK_dbo.tblVacunas_dbo.tblCerdas_IdCerda]
GO
ALTER TABLE [dbo].[tblVacunasLotes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblVacunasLotes_dbo.tblLotes_IdLote] FOREIGN KEY([IdLote])
REFERENCES [dbo].[tblLotes] ([IdLote])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblVacunasLotes] CHECK CONSTRAINT [FK_dbo.tblVacunasLotes_dbo.tblLotes_IdLote]
GO
ALTER TABLE [dbo].[tblVarracos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblVarracos_dbo.tblGeneticas_IdGenetica] FOREIGN KEY([IdGenetica])
REFERENCES [dbo].[tblGeneticas] ([IdGenetica])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblVarracos] CHECK CONSTRAINT [FK_dbo.tblVarracos_dbo.tblGeneticas_IdGenetica]
GO
