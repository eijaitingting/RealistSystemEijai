CREATE TABLE [dbo].[Admin] (
    [AdminID]     INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (255) NULL,
    [LastName]    NVARCHAR (255) NULL,
    [Email]       NVARCHAR (255) NULL,
    [Password]    NVARCHAR (255) NULL,
    [DateCreated] DATETIME2 (7)  NULL,
    [DateUpdated] DATETIME2 (7)  NULL,
    PRIMARY KEY CLUSTERED ([AdminID] ASC)
);

