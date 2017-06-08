
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/08/2017 20:22:14
-- Generated from EDMX file: D:\Onedrive\studiejaar 2\DNET\Opdrachten\Practicums\P5&6dotnet_Jeroen_de_Kruijf_V2B\Service2.0\WinkelService\WinkelService\WinkelDbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WinkelDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'GebruikerSet'
CREATE TABLE [dbo].[GebruikerSet] (
    [GebruikerID] int IDENTITY(1,1) NOT NULL,
    [Gebruikersnaam] nvarchar(max)  NOT NULL,
    [Wachtwoord] nvarchar(max)  NOT NULL,
    [Saldo] float  NOT NULL
);
GO

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [ProductID] int IDENTITY(1,1) NOT NULL,
    [Prijs] float  NOT NULL,
    [Naam] nvarchar(max)  NOT NULL,
    [Hoeveelheid] int  NOT NULL
);
GO

-- Creating table 'BestellingSet'
CREATE TABLE [dbo].[BestellingSet] (
    [BestellingID] int IDENTITY(1,1) NOT NULL,
    [Besteldatum] datetime  NOT NULL,
    [GebruikerID] int  NOT NULL
);
GO

-- Creating table 'BestelregelSet'
CREATE TABLE [dbo].[BestelregelSet] (
    [BestelRegelID] int IDENTITY(1,1) NOT NULL,
    [Hoeveelheid] int  NOT NULL,
    [BestellingID] int  NOT NULL,
    [ProductID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [GebruikerID] in table 'GebruikerSet'
ALTER TABLE [dbo].[GebruikerSet]
ADD CONSTRAINT [PK_GebruikerSet]
    PRIMARY KEY CLUSTERED ([GebruikerID] ASC);
GO

-- Creating primary key on [ProductID] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- Creating primary key on [BestellingID] in table 'BestellingSet'
ALTER TABLE [dbo].[BestellingSet]
ADD CONSTRAINT [PK_BestellingSet]
    PRIMARY KEY CLUSTERED ([BestellingID] ASC);
GO

-- Creating primary key on [BestelRegelID] in table 'BestelregelSet'
ALTER TABLE [dbo].[BestelregelSet]
ADD CONSTRAINT [PK_BestelregelSet]
    PRIMARY KEY CLUSTERED ([BestelRegelID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GebruikerID] in table 'BestellingSet'
ALTER TABLE [dbo].[BestellingSet]
ADD CONSTRAINT [FK_GebruikerBestelling]
    FOREIGN KEY ([GebruikerID])
    REFERENCES [dbo].[GebruikerSet]
        ([GebruikerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GebruikerBestelling'
CREATE INDEX [IX_FK_GebruikerBestelling]
ON [dbo].[BestellingSet]
    ([GebruikerID]);
GO

-- Creating foreign key on [BestellingID] in table 'BestelregelSet'
ALTER TABLE [dbo].[BestelregelSet]
ADD CONSTRAINT [FK_BestelregelBestelling]
    FOREIGN KEY ([BestellingID])
    REFERENCES [dbo].[BestellingSet]
        ([BestellingID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BestelregelBestelling'
CREATE INDEX [IX_FK_BestelregelBestelling]
ON [dbo].[BestelregelSet]
    ([BestellingID]);
GO

-- Creating foreign key on [ProductID] in table 'BestelregelSet'
ALTER TABLE [dbo].[BestelregelSet]
ADD CONSTRAINT [FK_ProductBestelregel]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[ProductSet]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductBestelregel'
CREATE INDEX [IX_FK_ProductBestelregel]
ON [dbo].[BestelregelSet]
    ([ProductID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------