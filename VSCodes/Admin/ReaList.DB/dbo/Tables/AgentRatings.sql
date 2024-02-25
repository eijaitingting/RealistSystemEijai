CREATE TABLE [dbo].[AgentRatings] (
    [AgentRatingsID]       INT           NOT NULL,
    [AgentID]              INT           NULL,
    [CustomerID]           INT           NULL,
    [AgentRatings]         INT           NULL,
    [DateOfEvent]          DATETIME      NULL,
    [TotalAgentRatingsAve] DECIMAL (18)  NULL,
    [DateCreated]          DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([AgentRatingsID] ASC)
);

