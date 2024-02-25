CREATE TABLE [dbo].[PropertyPhotos] (
    [PropertyPhotosID] INT           NOT NULL,
    [PropertyID]       INT           NULL,
    [Photos]           VARBINARY (1) NULL,
    PRIMARY KEY CLUSTERED ([PropertyPhotosID] ASC)
);

