CREATE TABLE [dbo].[Bookings] (
    [BookingID]         INT           IDENTITY (1, 1) NOT NULL,
    [AgentID]           INT           NULL,
    [PropertyID]        INT           NULL,
    [CustomerID]        INT           NULL,
    [VisitDate]         DATE          NULL,
    [VisitTime]         NVARCHAR (50) NULL,
    [BookingStatus]     TINYINT       NULL,
    [BookingPostStatus] TINYINT       NULL,
    [DateCreated]       DATETIME2 (7) NULL,
    [DateUpdated]       DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([BookingID] ASC)
);



