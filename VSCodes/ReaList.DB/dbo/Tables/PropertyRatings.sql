CREATE TABLE [dbo].[PropertyRatings] (
    [PropertyRatingsID]  INT             IDENTITY (1, 1) NOT NULL,
    [PropertyID]         INT             NULL,
    [RoadRatings]        INT             NULL,
    [SafetyRatings]      INT             NULL,
    [CleanlinessRatings] INT             NULL,
    [ParkingRatings]     INT             NULL,
    [TrafficRatings]     INT             NULL,
    [SchoolRatings]      INT             NULL,
    [RestaurantRatings]  INT             NULL,
    [TotalRatings]       DECIMAL (18, 1) NULL,
    PRIMARY KEY CLUSTERED ([PropertyRatingsID] ASC)
);



