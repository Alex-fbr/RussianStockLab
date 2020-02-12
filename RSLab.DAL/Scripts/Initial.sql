IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [dbo].[Stocks] (
    [Id] int NOT NULL IDENTITY,
    [SECID] nvarchar(max) NULL,
    [SHORTNAME] nvarchar(max) NULL,
    [OpenPrice] float NOT NULL,
    [ClosePrice] float NOT NULL,
    [LowPrice] float NOT NULL,
    [HighPrice] float NOT NULL,
    [WaPrice] float NOT NULL,
    [CurrentDate] datetime2 NOT NULL,
    [IndustrialSector] int NOT NULL,
    CONSTRAINT [PK_Stocks] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200212184247_00.InitialCreateDb', N'3.1.1');

GO

