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
CREATE TABLE [Roles] (
    [RoleId] int NOT NULL IDENTITY,
    [RoleName] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([RoleId])
);

CREATE TABLE [Tasks] (
    [TaskId] int NOT NULL IDENTITY,
    [Title] nvarchar(255) NOT NULL,
    [Description] NTEXT NULL,
    [Status] nvarchar(20) NOT NULL DEFAULT N'Pending',
    [TeamId] int NOT NULL,
    [AssignedToUserId] int NOT NULL,
    [CreatedByUserId] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL DEFAULT (GETDATE()),
    [UpdatedAt] datetime2 NOT NULL DEFAULT (GETDATE()),
    [DueDate] datetime2 NULL,
    CONSTRAINT [PK_Tasks] PRIMARY KEY ([TaskId]),
    CONSTRAINT [CK_Tasks_Status] CHECK (Status IN ('Pending', 'In Progress', 'Completed', 'Overdue', 'Cancelled'))
);

CREATE TABLE [Teams] (
    [TeamId] int NOT NULL IDENTITY,
    [TeamName] nvarchar(100) NOT NULL,
    [LeaderId] int NULL,
    [CreatedAt] datetime2 NOT NULL DEFAULT (GETDATE()),
    [UpdatedAt] datetime2 NOT NULL DEFAULT (GETDATE()),
    CONSTRAINT [PK_Teams] PRIMARY KEY ([TeamId])
);

CREATE TABLE [Users] (
    [UserId] int NOT NULL IDENTITY,
    [Email] nvarchar(255) NOT NULL,
    [PasswordHash] nvarchar(255) NOT NULL,
    [FirstName] nvarchar(100) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [RoleId] int NOT NULL,
    [TeamId] int NULL,
    [LastTokenIssueAt] datetime2 NOT NULL DEFAULT (GETDATE()),
    [CreatedAt] datetime2 NOT NULL DEFAULT (GETDATE()),
    [UpdatedAt] datetime2 NOT NULL DEFAULT (GETDATE()),
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId]),
    CONSTRAINT [FK_Users_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([RoleId]),
    CONSTRAINT [FK_Users_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [Teams] ([TeamId]) ON DELETE SET NULL
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'RoleName') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] ON;
INSERT INTO [Roles] ([RoleId], [RoleName])
VALUES (1, N'Global Administrator'),
(2, N'Team Leader'),
(3, N'Team Member'),
(4, N'User without Team');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'RoleName') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] OFF;

CREATE UNIQUE INDEX [UK_Roles_RoleName] ON [Roles] ([RoleName]);

CREATE INDEX [IX_Tasks_Assignee_Status] ON [Tasks] ([AssignedToUserId], [Status]);

CREATE INDEX [IX_Tasks_Creator] ON [Tasks] ([CreatedByUserId]);

CREATE INDEX [IX_Tasks_DueDate] ON [Tasks] ([DueDate]);

CREATE INDEX [IX_Tasks_Team_Assignee_Status] ON [Tasks] ([TeamId], [AssignedToUserId], [Status]);

CREATE INDEX [IX_Tasks_Team_Status] ON [Tasks] ([TeamId], [Status]);

CREATE INDEX [IX_Tasks_Title] ON [Tasks] ([Title]);

CREATE INDEX [IX_Teams_LeaderId] ON [Teams] ([LeaderId]);

CREATE UNIQUE INDEX [UK_Teams_TeamName] ON [Teams] ([TeamName]);

CREATE INDEX [IX_Users_RoleId] ON [Users] ([RoleId]);

CREATE INDEX [IX_Users_Team_Role] ON [Users] ([TeamId], [RoleId]);

CREATE INDEX [IX_Users_TeamId] ON [Users] ([TeamId]);

CREATE INDEX [IX_Users_TokenIssue] ON [Users] ([LastTokenIssueAt]);

CREATE UNIQUE INDEX [UK_Users_Email] ON [Users] ([Email]);

ALTER TABLE [Tasks] ADD CONSTRAINT [FK_Tasks_AssignedTo] FOREIGN KEY ([AssignedToUserId]) REFERENCES [Users] ([UserId]);

ALTER TABLE [Tasks] ADD CONSTRAINT [FK_Tasks_CreatedBy] FOREIGN KEY ([CreatedByUserId]) REFERENCES [Users] ([UserId]);

ALTER TABLE [Tasks] ADD CONSTRAINT [FK_Tasks_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [Teams] ([TeamId]) ON DELETE CASCADE;

ALTER TABLE [Teams] ADD CONSTRAINT [FK_Teams_LeaderId] FOREIGN KEY ([LeaderId]) REFERENCES [Users] ([UserId]) ON DELETE SET NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250727155800_InitialCreate', N'9.0.7');

COMMIT;
GO

