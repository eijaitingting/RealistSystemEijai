CREATE TABLE [dbo].[PasswordResets] (
    [Email]       NVARCHAR (255) NULL,
    [Token]       NVARCHAR (255) NULL,
    [DateCreated] DATETIME2 (7)  NULL
);

