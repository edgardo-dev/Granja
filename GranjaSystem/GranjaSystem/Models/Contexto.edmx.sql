
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/07/2020 10:28:24
-- Generated from EDMX file: C:\Users\PC\Desktop\Granja\GranjaSystem\GranjaSystem\Models\Contexto.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB_A460EB_PruebasNGS2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_tblCerdas_dbo_tblGeneticas_IdGenetica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCerdas] DROP CONSTRAINT [FK_dbo_tblCerdas_dbo_tblGeneticas_IdGenetica];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_tblControlLechones_dbo_tblCerdas_IdCerda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblControlLechones] DROP CONSTRAINT [FK_dbo_tblControlLechones_dbo_tblCerdas_IdCerda];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_tblControlLechones_dbo_tblLotes_Lotes_IdLote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblControlLechones] DROP CONSTRAINT [FK_dbo_tblControlLechones_dbo_tblLotes_Lotes_IdLote];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_tblDetalleLotes_dbo_tblCerdas_IdCerda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDetalleLotes] DROP CONSTRAINT [FK_dbo_tblDetalleLotes_dbo_tblCerdas_IdCerda];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_tblDetalleLotes_dbo_tblLotes_IdLote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDetalleLotes] DROP CONSTRAINT [FK_dbo_tblDetalleLotes_dbo_tblLotes_IdLote];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_tblDetalleLotes_dbo_tblVarracos_IdVarraco]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDetalleLotes] DROP CONSTRAINT [FK_dbo_tblDetalleLotes_dbo_tblVarracos_IdVarraco];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_tblFichas_dbo_tblCerdas_IdCerda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblFichas] DROP CONSTRAINT [FK_dbo_tblFichas_dbo_tblCerdas_IdCerda];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_tblFichas_dbo_tblEmpleados_IdEmpleado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblFichas] DROP CONSTRAINT [FK_dbo_tblFichas_dbo_tblEmpleados_IdEmpleado];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_tblFichas_dbo_tblVarracos_IdVarraco]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblFichas] DROP CONSTRAINT [FK_dbo_tblFichas_dbo_tblVarracos_IdVarraco];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_tblUsuarios_dbo_tblEmpleados_IdEmpleado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblUsuarios] DROP CONSTRAINT [FK_dbo_tblUsuarios_dbo_tblEmpleados_IdEmpleado];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_tblUsuarios_dbo_tblRoles_IdRol]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblUsuarios] DROP CONSTRAINT [FK_dbo_tblUsuarios_dbo_tblRoles_IdRol];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_tblVacunas_dbo_tblCerdas_IdCerda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblVacunas] DROP CONSTRAINT [FK_dbo_tblVacunas_dbo_tblCerdas_IdCerda];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_tblVacunasLotes_dbo_tblLotes_IdLote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblVacunasLotes] DROP CONSTRAINT [FK_dbo_tblVacunasLotes_dbo_tblLotes_IdLote];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_tblVarracos_dbo_tblGeneticas_IdGenetica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblVarracos] DROP CONSTRAINT [FK_dbo_tblVarracos_dbo_tblGeneticas_IdGenetica];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[tblCerdas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCerdas];
GO
IF OBJECT_ID(N'[dbo].[tblControlLechones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblControlLechones];
GO
IF OBJECT_ID(N'[dbo].[tblDetalleLotes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblDetalleLotes];
GO
IF OBJECT_ID(N'[dbo].[tblEmpleados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblEmpleados];
GO
IF OBJECT_ID(N'[dbo].[tblFichas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblFichas];
GO
IF OBJECT_ID(N'[dbo].[tblGeneticas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblGeneticas];
GO
IF OBJECT_ID(N'[dbo].[tblLechones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblLechones];
GO
IF OBJECT_ID(N'[dbo].[tblLotes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblLotes];
GO
IF OBJECT_ID(N'[dbo].[tblRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblRoles];
GO
IF OBJECT_ID(N'[dbo].[tblUsuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblUsuarios];
GO
IF OBJECT_ID(N'[dbo].[tblVacunas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblVacunas];
GO
IF OBJECT_ID(N'[dbo].[tblVacunasLotes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblVacunasLotes];
GO
IF OBJECT_ID(N'[dbo].[tblVarracos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblVarracos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tblCerdas'
CREATE TABLE [dbo].[tblCerdas] (
    [IdCerda] int IDENTITY(1,1) NOT NULL,
    [NumCerda] int  NOT NULL,
    [Procedencia] nvarchar(max)  NULL,
    [Observaciones] nvarchar(max)  NULL,
    [NumParto] int  NOT NULL,
    [FechaRegistro] datetime  NOT NULL,
    [Estado] nvarchar(max)  NULL,
    [IdGenetica] int  NOT NULL
);
GO

-- Creating table 'tblControlLechones'
CREATE TABLE [dbo].[tblControlLechones] (
    [IdControlL] int IDENTITY(1,1) NOT NULL,
    [IdLotes] int  NOT NULL,
    [FechaDestete] nvarchar(max)  NULL,
    [IdCerda] int  NOT NULL,
    [TotalLechones] int  NOT NULL,
    [PesoPromedioL] float  NOT NULL,
    [Lotes_IdLote] int  NULL
);
GO

-- Creating table 'tblDetalleLotes'
CREATE TABLE [dbo].[tblDetalleLotes] (
    [IdDLote] int IDENTITY(1,1) NOT NULL,
    [IdCerda] int  NOT NULL,
    [FechaInseminacion] datetime  NOT NULL,
    [FechaParto] datetime  NOT NULL,
    [IdVarraco] int  NOT NULL,
    [Fvacuna1] datetime  NOT NULL,
    [Fvacuna2] datetime  NOT NULL,
    [Observaciones] nvarchar(max)  NULL,
    [FechaRegistro] datetime  NOT NULL,
    [IdLote] int  NOT NULL,
    [Estado] nvarchar(max)  NULL,
    [Fvacuna15] datetime  NULL
);
GO

-- Creating table 'tblEmpleados'
CREATE TABLE [dbo].[tblEmpleados] (
    [IdEmpleado] int IDENTITY(1,1) NOT NULL,
    [NombreEmpleado] nvarchar(max)  NULL,
    [ApellidoEmpleado] nvarchar(max)  NULL,
    [Telefono] int  NULL,
    [DUI] nvarchar(max)  NULL,
    [NIT] nvarchar(max)  NULL,
    [FechaRegistro] datetime  NOT NULL,
    [FechaNacimiento] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL
);
GO

-- Creating table 'tblFichas'
CREATE TABLE [dbo].[tblFichas] (
    [IdFicha] int IDENTITY(1,1) NOT NULL,
    [IdCerda] int  NOT NULL,
    [NumParto] int  NOT NULL,
    [FechaServio] nvarchar(max)  NULL,
    [IdVarraco] int  NOT NULL,
    [FechaParto] nvarchar(max)  NULL,
    [NacidosVivos] int  NULL,
    [NacidosMuertos] int  NULL,
    [NacidosMomias] int  NULL,
    [TotalNacidos] int  NULL,
    [PesoPromedio1D] decimal(18,2)  NULL,
    [NumDestetado] int  NULL,
    [PesoPromedio28D] decimal(18,2)  NULL,
    [FechaDestete] nvarchar(max)  NULL,
    [IdEmpleado] int  NOT NULL,
    [Lote] int  NULL
);
GO

-- Creating table 'tblGeneticas'
CREATE TABLE [dbo].[tblGeneticas] (
    [IdGenetica] int IDENTITY(1,1) NOT NULL,
    [Genetica] nvarchar(max)  NULL,
    [Observacion] nvarchar(max)  NULL
);
GO

-- Creating table 'tblLechones'
CREATE TABLE [dbo].[tblLechones] (
    [IdLechones] int IDENTITY(1,1) NOT NULL,
    [NumLote] int  NOT NULL,
    [Edad] int  NOT NULL,
    [NCerdos] int  NOT NULL,
    [NCerdas] int  NOT NULL,
    [NVarracos] int  NOT NULL,
    [Fases] nvarchar(max)  NULL,
    [FechaInicio] datetime  NULL,
    [FechaRegistro] datetime  NOT NULL,
    [Estado] nvarchar(max)  NULL,
    [qqDiarios] decimal(18,2)  NOT NULL,
    [qqSemanal] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'tblLotes'
CREATE TABLE [dbo].[tblLotes] (
    [IdLote] int IDENTITY(1,1) NOT NULL,
    [NumLote] int  NOT NULL,
    [FechaRegistro] datetime  NOT NULL,
    [Estado] nvarchar(max)  NULL
);
GO

-- Creating table 'tblRoles'
CREATE TABLE [dbo].[tblRoles] (
    [IdRol] int IDENTITY(1,1) NOT NULL,
    [Rol] nvarchar(max)  NULL,
    [Descripcion] nvarchar(max)  NULL
);
GO

-- Creating table 'tblUsuarios'
CREATE TABLE [dbo].[tblUsuarios] (
    [IdUsuario] int IDENTITY(1,1) NOT NULL,
    [Usuario] nvarchar(max)  NULL,
    [Clave] nvarchar(max)  NULL,
    [IdEmpleado] int  NOT NULL,
    [IdRol] int  NOT NULL
);
GO

-- Creating table 'tblVacunas'
CREATE TABLE [dbo].[tblVacunas] (
    [IdVacuna] int IDENTITY(1,1) NOT NULL,
    [IdCerda] int  NOT NULL,
    [FechaRegistro] datetime  NOT NULL,
    [FechaInyeccion] nvarchar(max)  NULL,
    [Vacuna] nvarchar(max)  NULL,
    [Descripcion] nvarchar(max)  NULL
);
GO

-- Creating table 'tblVacunasLotes'
CREATE TABLE [dbo].[tblVacunasLotes] (
    [IdVacunaLote] int IDENTITY(1,1) NOT NULL,
    [IdLote] int  NOT NULL,
    [FechaVacuna] datetime  NOT NULL,
    [Vacuna] nvarchar(max)  NULL,
    [Descripcion] nvarchar(max)  NULL
);
GO

-- Creating table 'tblVarracos'
CREATE TABLE [dbo].[tblVarracos] (
    [IdVarraco] int IDENTITY(1,1) NOT NULL,
    [NumVarraco] int  NOT NULL,
    [Procedencia] nvarchar(max)  NULL,
    [Observaciones] nvarchar(max)  NULL,
    [FechaRegistro] datetime  NOT NULL,
    [Estado] nvarchar(max)  NULL,
    [IdGenetica] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdCerda] in table 'tblCerdas'
ALTER TABLE [dbo].[tblCerdas]
ADD CONSTRAINT [PK_tblCerdas]
    PRIMARY KEY CLUSTERED ([IdCerda] ASC);
GO

-- Creating primary key on [IdControlL] in table 'tblControlLechones'
ALTER TABLE [dbo].[tblControlLechones]
ADD CONSTRAINT [PK_tblControlLechones]
    PRIMARY KEY CLUSTERED ([IdControlL] ASC);
GO

-- Creating primary key on [IdDLote] in table 'tblDetalleLotes'
ALTER TABLE [dbo].[tblDetalleLotes]
ADD CONSTRAINT [PK_tblDetalleLotes]
    PRIMARY KEY CLUSTERED ([IdDLote] ASC);
GO

-- Creating primary key on [IdEmpleado] in table 'tblEmpleados'
ALTER TABLE [dbo].[tblEmpleados]
ADD CONSTRAINT [PK_tblEmpleados]
    PRIMARY KEY CLUSTERED ([IdEmpleado] ASC);
GO

-- Creating primary key on [IdFicha] in table 'tblFichas'
ALTER TABLE [dbo].[tblFichas]
ADD CONSTRAINT [PK_tblFichas]
    PRIMARY KEY CLUSTERED ([IdFicha] ASC);
GO

-- Creating primary key on [IdGenetica] in table 'tblGeneticas'
ALTER TABLE [dbo].[tblGeneticas]
ADD CONSTRAINT [PK_tblGeneticas]
    PRIMARY KEY CLUSTERED ([IdGenetica] ASC);
GO

-- Creating primary key on [IdLechones] in table 'tblLechones'
ALTER TABLE [dbo].[tblLechones]
ADD CONSTRAINT [PK_tblLechones]
    PRIMARY KEY CLUSTERED ([IdLechones] ASC);
GO

-- Creating primary key on [IdLote] in table 'tblLotes'
ALTER TABLE [dbo].[tblLotes]
ADD CONSTRAINT [PK_tblLotes]
    PRIMARY KEY CLUSTERED ([IdLote] ASC);
GO

-- Creating primary key on [IdRol] in table 'tblRoles'
ALTER TABLE [dbo].[tblRoles]
ADD CONSTRAINT [PK_tblRoles]
    PRIMARY KEY CLUSTERED ([IdRol] ASC);
GO

-- Creating primary key on [IdUsuario] in table 'tblUsuarios'
ALTER TABLE [dbo].[tblUsuarios]
ADD CONSTRAINT [PK_tblUsuarios]
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC);
GO

-- Creating primary key on [IdVacuna] in table 'tblVacunas'
ALTER TABLE [dbo].[tblVacunas]
ADD CONSTRAINT [PK_tblVacunas]
    PRIMARY KEY CLUSTERED ([IdVacuna] ASC);
GO

-- Creating primary key on [IdVacunaLote] in table 'tblVacunasLotes'
ALTER TABLE [dbo].[tblVacunasLotes]
ADD CONSTRAINT [PK_tblVacunasLotes]
    PRIMARY KEY CLUSTERED ([IdVacunaLote] ASC);
GO

-- Creating primary key on [IdVarraco] in table 'tblVarracos'
ALTER TABLE [dbo].[tblVarracos]
ADD CONSTRAINT [PK_tblVarracos]
    PRIMARY KEY CLUSTERED ([IdVarraco] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdGenetica] in table 'tblCerdas'
ALTER TABLE [dbo].[tblCerdas]
ADD CONSTRAINT [FK_dbo_tblCerdas_dbo_tblGeneticas_IdGenetica]
    FOREIGN KEY ([IdGenetica])
    REFERENCES [dbo].[tblGeneticas]
        ([IdGenetica])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_tblCerdas_dbo_tblGeneticas_IdGenetica'
CREATE INDEX [IX_FK_dbo_tblCerdas_dbo_tblGeneticas_IdGenetica]
ON [dbo].[tblCerdas]
    ([IdGenetica]);
GO

-- Creating foreign key on [IdCerda] in table 'tblControlLechones'
ALTER TABLE [dbo].[tblControlLechones]
ADD CONSTRAINT [FK_dbo_tblControlLechones_dbo_tblCerdas_IdCerda]
    FOREIGN KEY ([IdCerda])
    REFERENCES [dbo].[tblCerdas]
        ([IdCerda])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_tblControlLechones_dbo_tblCerdas_IdCerda'
CREATE INDEX [IX_FK_dbo_tblControlLechones_dbo_tblCerdas_IdCerda]
ON [dbo].[tblControlLechones]
    ([IdCerda]);
GO

-- Creating foreign key on [IdCerda] in table 'tblDetalleLotes'
ALTER TABLE [dbo].[tblDetalleLotes]
ADD CONSTRAINT [FK_dbo_tblDetalleLotes_dbo_tblCerdas_IdCerda]
    FOREIGN KEY ([IdCerda])
    REFERENCES [dbo].[tblCerdas]
        ([IdCerda])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_tblDetalleLotes_dbo_tblCerdas_IdCerda'
CREATE INDEX [IX_FK_dbo_tblDetalleLotes_dbo_tblCerdas_IdCerda]
ON [dbo].[tblDetalleLotes]
    ([IdCerda]);
GO

-- Creating foreign key on [IdCerda] in table 'tblFichas'
ALTER TABLE [dbo].[tblFichas]
ADD CONSTRAINT [FK_dbo_tblFichas_dbo_tblCerdas_IdCerda]
    FOREIGN KEY ([IdCerda])
    REFERENCES [dbo].[tblCerdas]
        ([IdCerda])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_tblFichas_dbo_tblCerdas_IdCerda'
CREATE INDEX [IX_FK_dbo_tblFichas_dbo_tblCerdas_IdCerda]
ON [dbo].[tblFichas]
    ([IdCerda]);
GO

-- Creating foreign key on [IdCerda] in table 'tblVacunas'
ALTER TABLE [dbo].[tblVacunas]
ADD CONSTRAINT [FK_dbo_tblVacunas_dbo_tblCerdas_IdCerda]
    FOREIGN KEY ([IdCerda])
    REFERENCES [dbo].[tblCerdas]
        ([IdCerda])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_tblVacunas_dbo_tblCerdas_IdCerda'
CREATE INDEX [IX_FK_dbo_tblVacunas_dbo_tblCerdas_IdCerda]
ON [dbo].[tblVacunas]
    ([IdCerda]);
GO

-- Creating foreign key on [Lotes_IdLote] in table 'tblControlLechones'
ALTER TABLE [dbo].[tblControlLechones]
ADD CONSTRAINT [FK_dbo_tblControlLechones_dbo_tblLotes_Lotes_IdLote]
    FOREIGN KEY ([Lotes_IdLote])
    REFERENCES [dbo].[tblLotes]
        ([IdLote])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_tblControlLechones_dbo_tblLotes_Lotes_IdLote'
CREATE INDEX [IX_FK_dbo_tblControlLechones_dbo_tblLotes_Lotes_IdLote]
ON [dbo].[tblControlLechones]
    ([Lotes_IdLote]);
GO

-- Creating foreign key on [IdLote] in table 'tblDetalleLotes'
ALTER TABLE [dbo].[tblDetalleLotes]
ADD CONSTRAINT [FK_dbo_tblDetalleLotes_dbo_tblLotes_IdLote]
    FOREIGN KEY ([IdLote])
    REFERENCES [dbo].[tblLotes]
        ([IdLote])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_tblDetalleLotes_dbo_tblLotes_IdLote'
CREATE INDEX [IX_FK_dbo_tblDetalleLotes_dbo_tblLotes_IdLote]
ON [dbo].[tblDetalleLotes]
    ([IdLote]);
GO

-- Creating foreign key on [IdVarraco] in table 'tblDetalleLotes'
ALTER TABLE [dbo].[tblDetalleLotes]
ADD CONSTRAINT [FK_dbo_tblDetalleLotes_dbo_tblVarracos_IdVarraco]
    FOREIGN KEY ([IdVarraco])
    REFERENCES [dbo].[tblVarracos]
        ([IdVarraco])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_tblDetalleLotes_dbo_tblVarracos_IdVarraco'
CREATE INDEX [IX_FK_dbo_tblDetalleLotes_dbo_tblVarracos_IdVarraco]
ON [dbo].[tblDetalleLotes]
    ([IdVarraco]);
GO

-- Creating foreign key on [IdEmpleado] in table 'tblFichas'
ALTER TABLE [dbo].[tblFichas]
ADD CONSTRAINT [FK_dbo_tblFichas_dbo_tblEmpleados_IdEmpleado]
    FOREIGN KEY ([IdEmpleado])
    REFERENCES [dbo].[tblEmpleados]
        ([IdEmpleado])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_tblFichas_dbo_tblEmpleados_IdEmpleado'
CREATE INDEX [IX_FK_dbo_tblFichas_dbo_tblEmpleados_IdEmpleado]
ON [dbo].[tblFichas]
    ([IdEmpleado]);
GO

-- Creating foreign key on [IdEmpleado] in table 'tblUsuarios'
ALTER TABLE [dbo].[tblUsuarios]
ADD CONSTRAINT [FK_dbo_tblUsuarios_dbo_tblEmpleados_IdEmpleado]
    FOREIGN KEY ([IdEmpleado])
    REFERENCES [dbo].[tblEmpleados]
        ([IdEmpleado])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_tblUsuarios_dbo_tblEmpleados_IdEmpleado'
CREATE INDEX [IX_FK_dbo_tblUsuarios_dbo_tblEmpleados_IdEmpleado]
ON [dbo].[tblUsuarios]
    ([IdEmpleado]);
GO

-- Creating foreign key on [IdVarraco] in table 'tblFichas'
ALTER TABLE [dbo].[tblFichas]
ADD CONSTRAINT [FK_dbo_tblFichas_dbo_tblVarracos_IdVarraco]
    FOREIGN KEY ([IdVarraco])
    REFERENCES [dbo].[tblVarracos]
        ([IdVarraco])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_tblFichas_dbo_tblVarracos_IdVarraco'
CREATE INDEX [IX_FK_dbo_tblFichas_dbo_tblVarracos_IdVarraco]
ON [dbo].[tblFichas]
    ([IdVarraco]);
GO

-- Creating foreign key on [IdGenetica] in table 'tblVarracos'
ALTER TABLE [dbo].[tblVarracos]
ADD CONSTRAINT [FK_dbo_tblVarracos_dbo_tblGeneticas_IdGenetica]
    FOREIGN KEY ([IdGenetica])
    REFERENCES [dbo].[tblGeneticas]
        ([IdGenetica])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_tblVarracos_dbo_tblGeneticas_IdGenetica'
CREATE INDEX [IX_FK_dbo_tblVarracos_dbo_tblGeneticas_IdGenetica]
ON [dbo].[tblVarracos]
    ([IdGenetica]);
GO

-- Creating foreign key on [IdLote] in table 'tblVacunasLotes'
ALTER TABLE [dbo].[tblVacunasLotes]
ADD CONSTRAINT [FK_dbo_tblVacunasLotes_dbo_tblLotes_IdLote]
    FOREIGN KEY ([IdLote])
    REFERENCES [dbo].[tblLotes]
        ([IdLote])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_tblVacunasLotes_dbo_tblLotes_IdLote'
CREATE INDEX [IX_FK_dbo_tblVacunasLotes_dbo_tblLotes_IdLote]
ON [dbo].[tblVacunasLotes]
    ([IdLote]);
GO

-- Creating foreign key on [IdRol] in table 'tblUsuarios'
ALTER TABLE [dbo].[tblUsuarios]
ADD CONSTRAINT [FK_dbo_tblUsuarios_dbo_tblRoles_IdRol]
    FOREIGN KEY ([IdRol])
    REFERENCES [dbo].[tblRoles]
        ([IdRol])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_tblUsuarios_dbo_tblRoles_IdRol'
CREATE INDEX [IX_FK_dbo_tblUsuarios_dbo_tblRoles_IdRol]
ON [dbo].[tblUsuarios]
    ([IdRol]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------