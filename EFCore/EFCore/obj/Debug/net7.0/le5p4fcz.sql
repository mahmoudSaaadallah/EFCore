IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Employees] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231211194908_initalCreate', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO Employees (Name) VALUES ('Ahmed')
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231211223513_migration2', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Blogs] (
    [Id] int NOT NULL IDENTITY,
    [Url] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Blogs] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231212004359_migration3', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Post] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Content] nvarchar(max) NULL,
    [BlogId] int NOT NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Post_Blogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [Blogs] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Post_BlogId] ON [Post] ([BlogId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231212010822_adding_Post', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AuditEntry] (
    [Id] int NOT NULL IDENTITY,
    [UserName] nvarchar(max) NOT NULL,
    [Action] nvarchar(max) NULL,
    CONSTRAINT [PK_AuditEntry] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231212013040_adding_AuditEntry', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Post] DROP CONSTRAINT [FK_Post_Blogs_BlogId];
GO

ALTER TABLE [Post] DROP CONSTRAINT [PK_Post];
GO

IF SCHEMA_ID(N'Blogging') IS NULL EXEC(N'CREATE SCHEMA [Blogging];');
GO

EXEC sp_rename N'[Post]', N'Posts';
ALTER SCHEMA [Blogging] TRANSFER [Posts];
GO

EXEC sp_rename N'[Blogging].[Posts].[IX_Post_BlogId]', N'IX_Posts_BlogId', N'INDEX';
GO

ALTER TABLE [Blogging].[Posts] ADD CONSTRAINT [PK_Posts] PRIMARY KEY ([Id]);
GO

ALTER TABLE [Blogging].[Posts] ADD CONSTRAINT [FK_Posts_Blogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [Blogs] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231212115238_changePostTableNameToPosts', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER SCHEMA [Blogging] TRANSFER [Employees];
GO

ALTER SCHEMA [Blogging] TRANSFER [Blogs];
GO

ALTER SCHEMA [Blogging] TRANSFER [AuditEntry];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231212121849_changePostTableNameToPostsAndChanggingSchema', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Blogging].[Posts] ADD [PostAddingTime] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231212124613_addingAddedTimePropToPostsTableWithDifferantNamePostAddingTime', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Blogging].[Posts] ADD [Rating] Decimal(5,2) NOT NULL DEFAULT 0.0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231212134721_addingNewPropToPostsTableWithSpecificDataType', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @description AS sql_variant;
SET @description = N'This is a comment for Url in data base.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Blogging', 'TABLE', N'Blogs', 'COLUMN', N'Url';
GO

CREATE TABLE [Blogging].[Books] (
    [bookNumber] int NOT NULL IDENTITY,
    [title] nvarchar(max) NOT NULL,
    [Author] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([bookNumber])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231212154500_addingBookTableWithPKAsBookNumber', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Blogging].[Books] DROP CONSTRAINT [PK_Books];
GO

ALTER TABLE [Blogging].[Books] ADD CONSTRAINT [PK_BookNumber] PRIMARY KEY ([bookNumber]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231212155302_changingTheNameOfPrimaryKeyForBookSTable', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231212182831_test', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Blogging].[Books] ADD [Rating] decimal(18,2) NOT NULL DEFAULT 4.0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231212185556_putADefaultValueToRatingColumnInBooksTable', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Blogging].[Books] ADD [Createdon] datetime2 NOT NULL DEFAULT (GETDATE());
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231212203029_AddingCreatedonColumnToBookTableWithDefaultSqlFunction', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Blogging].[Employees] ADD [NetSalary] Decimal(10,2) NOT NULL DEFAULT 0.0;
GO

ALTER TABLE [Blogging].[Employees] ADD [TotalSalary] Decimal(10,2) NOT NULL DEFAULT 0.0;
GO

ALTER TABLE [Blogging].[Employees] ADD [Taxes] AS [TotalSalary] * 0.3;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231212223319_addingTotalSalary_TaxesAndNetSalaryToTableEmployeesAndGetBothOfTaxesAndNetSalaryDependOnTotalSalary', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Blogging].[Employees]') AND [c].[name] = N'NetSalary');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Blogging].[Employees] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Blogging].[Employees] DROP COLUMN [NetSalary];
ALTER TABLE [Blogging].[Employees] ADD [NetSalary] AS [TotalSalary] - (0.3 * [TotalSalary]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231212223703_modifyNetSalaryColumnInTableEmployees', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Blogging].[Categories] (
    [Id] tinyint NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231213000450_creatingCategoryTable', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Blogging].[Persons] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(70) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Persons] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Blogging].[Addresses] (
    [Id] int NOT NULL IDENTITY,
    [Street] nvarchar(max) NOT NULL,
    [City] nvarchar(max) NOT NULL,
    [PostalCode] nvarchar(max) NOT NULL,
    [PersonId] int NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Addresses_Persons_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Blogging].[Persons] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Addresses_PersonId] ON [Blogging].[Addresses] ([PersonId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231214212255_createPersonAndAddressTablesWithOneToOneRelationBetweenBothOfThem', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Blogging].[Universities] (
    [Id] int NOT NULL IDENTITY,
    [UniversityName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Universities] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Blogging].[Students] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [UniversityId] int NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Students_Universities_UniversityId] FOREIGN KEY ([UniversityId]) REFERENCES [Blogging].[Universities] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Students_UniversityId] ON [Blogging].[Students] ([UniversityId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231214221623_CreatUniversityAndStudentTablesWithOneToManyRelationBetweenThem', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Blogging].[Cars] (
    [Id] int NOT NULL IDENTITY,
    [LicensePlate] nvarchar(450) NOT NULL,
    [Model] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY ([Id]),
    CONSTRAINT [AK_Cars_LicensePlate] UNIQUE ([LicensePlate])
);
GO

CREATE TABLE [Blogging].[RecordOfSales] (
    [Id] int NOT NULL IDENTITY,
    [DateSold] datetime2 NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [CarLicensePlate] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_RecordOfSales] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_RecordOfSales_Cars_CarLicensePlate] FOREIGN KEY ([CarLicensePlate]) REFERENCES [Blogging].[Cars] ([LicensePlate]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_RecordOfSales_CarLicensePlate] ON [Blogging].[RecordOfSales] ([CarLicensePlate]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231214232901_CreatCarAndTecordOfSalesTablesWithOneToManyRelationBetweenThem', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Blogging].[Actors] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Actors] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Blogging].[Movies] (
    [Id] int NOT NULL IDENTITY,
    [MovieTitle] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Blogging].[ActorMovie] (
    [ActorsId] int NOT NULL,
    [MoviesId] int NOT NULL,
    CONSTRAINT [PK_ActorMovie] PRIMARY KEY ([ActorsId], [MoviesId]),
    CONSTRAINT [FK_ActorMovie_Actors_ActorsId] FOREIGN KEY ([ActorsId]) REFERENCES [Blogging].[Actors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ActorMovie_Movies_MoviesId] FOREIGN KEY ([MoviesId]) REFERENCES [Blogging].[Movies] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ActorMovie_MoviesId] ON [Blogging].[ActorMovie] ([MoviesId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231216141346_AddingActorAndMovieTablesWithRelationManyToManyBetweenBothOfThem', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Blogging].[ActorMovie] DROP CONSTRAINT [FK_ActorMovie_Actors_ActorsId];
GO

ALTER TABLE [Blogging].[ActorMovie] DROP CONSTRAINT [FK_ActorMovie_Movies_MoviesId];
GO

EXEC sp_rename N'[Blogging].[ActorMovie].[MoviesId]', N'MovieId', N'COLUMN';
GO

EXEC sp_rename N'[Blogging].[ActorMovie].[ActorsId]', N'ActorId', N'COLUMN';
GO

EXEC sp_rename N'[Blogging].[ActorMovie].[IX_ActorMovie_MoviesId]', N'IX_ActorMovie_MovieId', N'INDEX';
GO

ALTER TABLE [Blogging].[ActorMovie] ADD CONSTRAINT [FK_ActorMovie_Actors_ActorId] FOREIGN KEY ([ActorId]) REFERENCES [Blogging].[Actors] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [Blogging].[ActorMovie] ADD CONSTRAINT [FK_ActorMovie_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Blogging].[Movies] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231216144907_AddingTheActorMovieTableByMyself', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Blogging].[Persons]') AND [c].[name] = N'LastName');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Blogging].[Persons] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Blogging].[Persons] ALTER COLUMN [LastName] nvarchar(450) NOT NULL;
GO

CREATE TABLE [Blogging].[Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [IX_Persons_FirstName_LastName] ON [Blogging].[Persons] ([FirstName], [LastName]);
GO

CREATE INDEX [IX_Users_Email] ON [Blogging].[Users] ([Email]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231216232312_addingUserTableWithAnIndexAndMakingCompositeIndexInThePersonTable', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'LicensePlate', N'Model') AND [object_id] = OBJECT_ID(N'[Blogging].[Cars]'))
    SET IDENTITY_INSERT [Blogging].[Cars] ON;
INSERT INTO [Blogging].[Cars] ([Id], [LicensePlate], [Model])
VALUES (1, N'307', N'BMW'),
(2, N'703', N'Audy'),
(3, N'901', N'KIA');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'LicensePlate', N'Model') AND [object_id] = OBJECT_ID(N'[Blogging].[Cars]'))
    SET IDENTITY_INSERT [Blogging].[Cars] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231217140902_testingDataSeedingOnCarModel', N'7.0.14');
GO

COMMIT;
GO

