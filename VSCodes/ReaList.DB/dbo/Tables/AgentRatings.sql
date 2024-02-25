CREATE TABLE [dbo].[AgentRatings] (
    [AgentRatingsID] INT            IDENTITY (1, 1) NOT NULL,
    [BookingID]      INT            NULL,
    [AgentID]        INT            NULL,
    [CustomerID]     INT            NULL,
    [AgentRatings]   INT            NULL,
    [Feedback]       NVARCHAR (255) NULL,
    [DateCreated]    DATETIME2 (7)  NULL,
    PRIMARY KEY CLUSTERED ([AgentRatingsID] ASC)
);

