CREATE TABLE [dbo].[Amenities] (
    [AmenitiesID]   INT            NOT NULL,
    [PropertyID]    INT            NULL,
    [AmenitiesName] NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([AmenitiesID] ASC)
);

