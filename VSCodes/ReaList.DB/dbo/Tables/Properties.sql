CREATE TABLE [dbo].[Properties] (
    [PropertyID]         INT             IDENTITY (1, 1) NOT NULL,
    [AgentID]            INT             NULL,
    [PropertyCategoryID] INT             NULL,
    [PropertyTypeID]     INT             NULL,
    [PropertyName]       NVARCHAR (255)  NULL,
    [Overview]           NVARCHAR (255)  NULL,
    [TotalPrice]         DECIMAL (18, 2) NULL,
    [Bedrooms]           INT             NULL,
    [Bathrooms]          INT             NULL,
    [FloorAreaSize]      INT             NULL,
    [DevelopmentInfo]    NVARCHAR (255)  NULL,
    [VSPhotos]           VARBINARY (1)   NULL,
    [isAppropriate]      BIT             NULL,
    [PropertyStatus]     TINYINT         NULL,
    [DateCreated]        DATETIME2 (7)   NULL,
    [DateUpdated]        DATETIME2 (7)   NULL,
    PRIMARY KEY CLUSTERED ([PropertyID] ASC)
);

