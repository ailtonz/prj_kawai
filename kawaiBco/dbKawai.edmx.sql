
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/05/2013 17:06:59
-- Generated from EDMX file: C:\Particular\prj_kawai\kawaiBco\dbKawai.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dbKawai];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Empresa_Empresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empresa] DROP CONSTRAINT [FK_Empresa_Empresa];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Empresa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empresa];
GO
IF OBJECT_ID(N'[dbKawaiModelStoreContainer].[Endereco]', 'U') IS NOT NULL
    DROP TABLE [dbKawaiModelStoreContainer].[Endereco];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Empresa'
CREATE TABLE [dbo].[Empresa] (
    [codigo] int IDENTITY(1,1) NOT NULL,
    [razaoSocial] varchar(255)  NULL,
    [nomeFantasia] varchar(255)  NULL,
    [CNPJ] varchar(14)  NULL,
    [inscricaoEstadual] varchar(8)  NULL,
    [site] varchar(255)  NULL,
    [codigoMatriz] int  NULL,
    [Endereco_codigo] int  NOT NULL
);
GO

-- Creating table 'Endereco'
CREATE TABLE [dbo].[Endereco] (
    [codigo] int IDENTITY(1,1) NOT NULL,
    [logradouro] varchar(500)  NULL,
    [numero] varchar(50)  NULL,
    [complemento] varchar(500)  NULL,
    [bairro] varchar(255)  NULL,
    [CEP] varchar(9)  NULL,
    [Cidade] varchar(255)  NULL,
    [codigoUF] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [codigo] in table 'Empresa'
ALTER TABLE [dbo].[Empresa]
ADD CONSTRAINT [PK_Empresa]
    PRIMARY KEY CLUSTERED ([codigo] ASC);
GO

-- Creating primary key on [codigo] in table 'Endereco'
ALTER TABLE [dbo].[Endereco]
ADD CONSTRAINT [PK_Endereco]
    PRIMARY KEY CLUSTERED ([codigo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [codigoMatriz] in table 'Empresa'
ALTER TABLE [dbo].[Empresa]
ADD CONSTRAINT [FK_Empresa_Empresa]
    FOREIGN KEY ([codigoMatriz])
    REFERENCES [dbo].[Empresa]
        ([codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Empresa_Empresa'
CREATE INDEX [IX_FK_Empresa_Empresa]
ON [dbo].[Empresa]
    ([codigoMatriz]);
GO

-- Creating foreign key on [Endereco_codigo] in table 'Empresa'
ALTER TABLE [dbo].[Empresa]
ADD CONSTRAINT [FK_EnderecoEmpresa]
    FOREIGN KEY ([Endereco_codigo])
    REFERENCES [dbo].[Endereco]
        ([codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EnderecoEmpresa'
CREATE INDEX [IX_FK_EnderecoEmpresa]
ON [dbo].[Empresa]
    ([Endereco_codigo]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------