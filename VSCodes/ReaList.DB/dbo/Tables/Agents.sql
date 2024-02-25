﻿CREATE TABLE [dbo].[Agents] (
    [AgentID]           INT              IDENTITY (1, 1) NOT NULL,
    [AgentType]         NVARCHAR (50)    NULL,
    [FirstName]         NVARCHAR (50)    NULL,
    [MiddleName]        NVARCHAR (50)    NULL,
    [LastName]          NVARCHAR (50)    NULL,
    [Suffix]            NVARCHAR (10)    NULL,
    [Birthdate]         DATE             NULL,
    [Gender]            NVARCHAR (6)     NULL,
    [PhoneNumber]       NVARCHAR (11)    NULL,
    [Email]             NVARCHAR (50)    NULL,
    [Password]          NVARCHAR (MAX)   NULL,
    [ActivationCode]    UNIQUEIDENTIFIER NULL,
    [IsEmailVerified]   BIT              NULL,
    [ResetPasswordCode] UNIQUEIDENTIFIER NULL,
    [Address]           NVARCHAR (255)   NULL,
    [ProfilePicture]    NVARCHAR (255)   NULL,
    [AgentAbout]        NVARCHAR (255)   NULL,
    [CompanyName]       NVARCHAR (100)   NULL,
    [Education]         NVARCHAR (100)   NULL,
    [Organizations]     NVARCHAR (255)   NULL,
    [GovtIdType]        NVARCHAR (50)    NULL,
    [GovtIdNumber]      NVARCHAR (20)    NULL,
    [LicenseIdNumber]   NVARCHAR (20)    NULL,
    [SelfiePhoto]       NVARCHAR (255)   NULL,
    [Certifications]    NVARCHAR (255)   NULL,
    [isVerified]        BIT              NULL,
    [AccountStatus]     TINYINT          NULL,
    [DateCreated]       DATETIME2 (7)    NULL,
    [DateUpdated]       DATETIME2 (7)    NULL,
    CONSTRAINT [PK__Agents__9AC3BFD1E21CCC75] PRIMARY KEY CLUSTERED ([AgentID] ASC)
);






