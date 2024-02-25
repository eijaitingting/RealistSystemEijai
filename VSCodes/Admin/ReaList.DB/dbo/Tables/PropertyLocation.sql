CREATE TABLE [dbo].[PropertyLocation] (
    [PropertyLocationID] INT            IDENTITY (1, 1) NOT NULL,
    [PropertyID]         INT            NULL,
    [Region]             NVARCHAR (255) NULL,
    [Municipality]       NVARCHAR (255) NULL,
    [City]               NVARCHAR (255) NULL,
    [Barangay]           NVARCHAR (255) NULL,
    [Street]             NVARCHAR (255) NULL,
    [ZipCode]            NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([PropertyLocationID] ASC)
);

