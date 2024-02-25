CREATE TABLE [dbo].[Amenities] (
    [AmenitiesID]   INT            IDENTITY (1, 1) NOT NULL,
    [PropertyID]    INT            NULL,
    [AmenitiesName] NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([AmenitiesID] ASC)
);

