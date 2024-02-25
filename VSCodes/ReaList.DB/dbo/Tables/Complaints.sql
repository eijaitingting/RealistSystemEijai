CREATE TABLE [dbo].[Complaints] (
    [ComplaintID]       INT            IDENTITY (1, 1) NOT NULL,
    [AgentID]           INT            NULL,
    [CustomerID]        INT            NULL,
    [ComplaintCategory] TINYINT        NULL,
    [DateOfEvent]       DATE           NULL,
    [ComplaintSubject]  NVARCHAR (255) NULL,
    [ComplaintDetails]  NVARCHAR (255) NULL,
    [ComplaintImages]   VARBINARY (1)  NULL,
    [ComplaintStatus]   TINYINT        NULL,
    [DateCreated]       DATETIME2 (7)  NULL,
    PRIMARY KEY CLUSTERED ([ComplaintID] ASC)
);

