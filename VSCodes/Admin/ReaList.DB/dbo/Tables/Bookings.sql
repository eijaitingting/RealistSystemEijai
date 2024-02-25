CREATE TABLE [dbo].[Bookings] (
    [BookingID]         INT           NOT NULL,
    [AgentID]           INT           NULL,
    [PropertyTypeID]    INT           NULL,
    [CustomerID]        INT           NULL,
    [VisitDate]         DATE          NULL,
    [VisitStartTime]    TIME (7)      NULL,
    [VisitEndTime]      TIME (7)      NULL,
    [BookingStatus]     TINYINT       NULL,
    [BookingPostStatus] TINYINT       NULL,
    [DateCreated]       DATETIME2 (7) NULL,
    [DateUpdated]       DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([BookingID] ASC)
);

