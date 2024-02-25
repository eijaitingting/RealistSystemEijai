CREATE TABLE [dbo].[Features] (
    [FeaturesID]   INT            IDENTITY (1, 1) NOT NULL,
    [PropertyID]   INT            NULL,
    [FeaturesName] NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([FeaturesID] ASC)
);

