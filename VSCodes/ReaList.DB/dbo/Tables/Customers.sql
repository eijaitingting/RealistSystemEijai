CREATE TABLE [dbo].[Customers] (
    [CustomerID]        INT              IDENTITY (1, 1) NOT NULL,
    [FirstName]         NVARCHAR (50)    NULL,
    [LastName]          NVARCHAR (50)    NULL,
    [Birthdate]         DATE             NULL,
    [PhoneNumber]       NVARCHAR (11)    NULL,
    [Email]             NVARCHAR (50)    NULL,
    [Password]          NVARCHAR (MAX)   NULL,
    [ActivationCode]    UNIQUEIDENTIFIER NULL,
    [IsEmailVerified]   BIT              NULL,
    [Address]           NVARCHAR (255)   NULL,
    [ProfilePicture]    NVARCHAR (255)   NULL,
    [GovtIdType]        NVARCHAR (50)    NULL,
    [GovtIdNumber]      NVARCHAR (20)    NULL,
    [SelfiePhoto]       NVARCHAR (255)   NULL,
    [isVerified]        BIT              NULL,
    [AccountStatus]     TINYINT          NULL,
    [DateCreated]       DATETIME2 (7)    NULL,
    [DateUpdated]       DATETIME2 (7)    NULL,
    [ResetPasswordCode] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK__Customer__A4AE64B894418159] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);





