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

CREATE TABLE [Cursos] (
    [Id] int NOT NULL IDENTITY,
    [NomeCurso] nvarchar(max) NULL,
    [Descrição] nvarchar(max) NULL,
    [DataInicio] datetime2 NOT NULL,
    [DataTermino] datetime2 NOT NULL,
    [TipoUrgencia] int NOT NULL,
    CONSTRAINT [PK_Cursos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Estagios] (
    [Id] int NOT NULL IDENTITY,
    [NomeEmpresa] nvarchar(max) NULL,
    [DataInicio] datetime2 NOT NULL,
    [DataTermino] datetime2 NOT NULL,
    [TipoUrgencia] int NOT NULL,
    CONSTRAINT [PK_Estagios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Faculdades] (
    [Id] int NOT NULL IDENTITY,
    [NomeFaculdade] nvarchar(max) NULL,
    [Descrição] nvarchar(max) NULL,
    [DataInicio] datetime2 NOT NULL,
    [DataTermino] datetime2 NOT NULL,
    [TipoUrgencia] int NOT NULL,
    CONSTRAINT [PK_Faculdades] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NULL,
    [Idade] int NOT NULL,
    [TempoEstudo] time NOT NULL,
    [Email] nvarchar(max) NULL,
    [PasswordString] nvarchar(max) NULL,
    [Perfil] nvarchar(max) NULL DEFAULT N'colaboradores',
    [DataAcesso] datetime2 NULL,
    [PasswordSalt] varbinary(max) NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [CursoUsuario] (
    [CursosId] int NOT NULL,
    [UsuarioId] int NOT NULL,
    CONSTRAINT [PK_CursoUsuario] PRIMARY KEY ([CursosId], [UsuarioId]),
    CONSTRAINT [FK_CursoUsuario_Cursos_CursosId] FOREIGN KEY ([CursosId]) REFERENCES [Cursos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CursoUsuario_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [EstagioUsuario] (
    [EstagiosId] int NOT NULL,
    [UsuarioId] int NOT NULL,
    CONSTRAINT [PK_EstagioUsuario] PRIMARY KEY ([EstagiosId], [UsuarioId]),
    CONSTRAINT [FK_EstagioUsuario_Estagios_EstagiosId] FOREIGN KEY ([EstagiosId]) REFERENCES [Estagios] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_EstagioUsuario_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [FaculdadeUsuario] (
    [FaculdadesId] int NOT NULL,
    [UsuarioId] int NOT NULL,
    CONSTRAINT [PK_FaculdadeUsuario] PRIMARY KEY ([FaculdadesId], [UsuarioId]),
    CONSTRAINT [FK_FaculdadeUsuario_Faculdades_FaculdadesId] FOREIGN KEY ([FaculdadesId]) REFERENCES [Faculdades] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_FaculdadeUsuario_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataInicio', N'DataTermino', N'Descrição', N'NomeCurso', N'TipoUrgencia') AND [object_id] = OBJECT_ID(N'[Cursos]'))
    SET IDENTITY_INSERT [Cursos] ON;
INSERT INTO [Cursos] ([Id], [DataInicio], [DataTermino], [Descrição], [NomeCurso], [TipoUrgencia])
VALUES (1, '2023-07-01T00:00:00.0000000', '2023-07-30T00:00:00.0000000', N'Um curso introdutório de programação em Python.', N'Introdução à Programação em Python', 1),
(2, '2023-08-15T00:00:00.0000000', '2023-09-15T00:00:00.0000000', N'Aprenda a criar sites utilizando HTML e CSS.', N'Desenvolvimento Web com HTML e CSS', 0),
(3, '2023-09-01T00:00:00.0000000', '2023-10-15T00:00:00.0000000', N'Aprofunde seus conhecimentos em JavaScript e aprenda técnicas avançadas de programação.', N'JavaScript Avançado', 2),
(4, '2023-07-10T00:00:00.0000000', '2023-08-05T00:00:00.0000000', N'Um curso introdutório sobre ciência de dados utilizando a linguagem Python.', N'Introdução à Ciência de Dados com Python', 1),
(5, '2023-08-20T00:00:00.0000000', '2023-09-30T00:00:00.0000000', N'Aprenda a criar aplicativos para dispositivos Android utilizando Java e Android Studio.', N'Desenvolvimento de Aplicações Android', 2),
(6, '2023-09-05T00:00:00.0000000', '2023-10-05T00:00:00.0000000', N'Aprenda os conceitos de programação orientada a objetos utilizando a linguagem C#.', N'Programação Orientada a Objetos em C#', 1),
(7, '2023-08-01T00:00:00.0000000', '2023-09-30T00:00:00.0000000', N'Aprenda a desenvolver aplicações web full stack utilizando Node.js no backend e React no frontend.', N'Desenvolvimento Full Stack com Node.js e React', 2),
(8, '2023-10-01T00:00:00.0000000', '2023-09-30T00:00:00.0000000', N'Um curso introdutório sobre os fundamentos e aplicações da inteligência artificial.', N'Introdução à Inteligência Artificial', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataInicio', N'DataTermino', N'Descrição', N'NomeCurso', N'TipoUrgencia') AND [object_id] = OBJECT_ID(N'[Cursos]'))
    SET IDENTITY_INSERT [Cursos] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataInicio', N'DataTermino', N'NomeEmpresa', N'TipoUrgencia') AND [object_id] = OBJECT_ID(N'[Estagios]'))
    SET IDENTITY_INSERT [Estagios] ON;
INSERT INTO [Estagios] ([Id], [DataInicio], [DataTermino], [NomeEmpresa], [TipoUrgencia])
VALUES (1, '2023-07-01T00:00:00.0000000', '2023-12-31T00:00:00.0000000', N'Empresa ABC', 0),
(2, '2023-08-15T00:00:00.0000000', '2024-02-29T00:00:00.0000000', N'Empresa XYZ', 1),
(3, '2023-09-01T00:00:00.0000000', '2024-03-31T00:00:00.0000000', N'Empresa 123', 2),
(4, '2023-10-01T00:00:00.0000000', '2024-03-31T00:00:00.0000000', N'Empresa ABCD', 1),
(5, '2023-11-15T00:00:00.0000000', '2024-06-30T00:00:00.0000000', N'Empresa XYZW', 0),
(6, '2024-01-01T00:00:00.0000000', '2024-07-31T00:00:00.0000000', N'Empresa 1234', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataInicio', N'DataTermino', N'NomeEmpresa', N'TipoUrgencia') AND [object_id] = OBJECT_ID(N'[Estagios]'))
    SET IDENTITY_INSERT [Estagios] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataInicio', N'DataTermino', N'Descrição', N'NomeFaculdade', N'TipoUrgencia') AND [object_id] = OBJECT_ID(N'[Faculdades]'))
    SET IDENTITY_INSERT [Faculdades] ON;
INSERT INTO [Faculdades] ([Id], [DataInicio], [DataTermino], [Descrição], [NomeFaculdade], [TipoUrgencia])
VALUES (1, '2023-09-01T00:00:00.0000000', '2027-06-30T00:00:00.0000000', N'Faculdade focada em cursos de ciência da computação e desenvolvimento de software.', N'Faculdade de Ciência da Computação', 2),
(2, '2023-08-15T00:00:00.0000000', '2028-07-31T00:00:00.0000000', N'Faculdade especializada em cursos de engenharia de software e desenvolvimento ágil.', N'Faculdade de Engenharia de Software', 2),
(3, '2023-09-01T00:00:00.0000000', '2027-06-30T00:00:00.0000000', N'Faculdade com enfoque em cursos de sistemas de informação e gestão de projetos de TI.', N'Faculdade de Sistemas de Informação', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataInicio', N'DataTermino', N'Descrição', N'NomeFaculdade', N'TipoUrgencia') AND [object_id] = OBJECT_ID(N'[Faculdades]'))
    SET IDENTITY_INSERT [Faculdades] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Idade', N'PasswordSalt', N'PasswordString', N'Perfil', N'TempoEstudo', N'Username') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] ON;
INSERT INTO [Usuarios] ([Id], [DataAcesso], [Email], [Idade], [PasswordSalt], [PasswordString], [Perfil], [TempoEstudo], [Username])
VALUES (1, NULL, N'seuEmail@gmail.com', 0, 0x20285F524EF1A5C59F9F006E1770EC0BD1B163CB70D53046AFF011587C192D66F75168D5CDEC367A05ECDA069056C70693982A8407CE86C6D9AD02236F1C32C6196897FEF012D3B3FDD75833F596E013090334448E97152B1914002500031D0D795A092516DE6455F66D3ACBE1481D2A8BC6463A89292FB43F445908A7420198, N'', N'chefe', '00:00:00', N'PrimeiroUsuario');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Idade', N'PasswordSalt', N'PasswordString', N'Perfil', N'TempoEstudo', N'Username') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] OFF;
GO

CREATE INDEX [IX_CursoUsuario_UsuarioId] ON [CursoUsuario] ([UsuarioId]);
GO

CREATE INDEX [IX_EstagioUsuario_UsuarioId] ON [EstagioUsuario] ([UsuarioId]);
GO

CREATE INDEX [IX_FaculdadeUsuario_UsuarioId] ON [FaculdadeUsuario] ([UsuarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230620233255_InicialCreate', N'7.0.5');
GO

COMMIT;
GO

