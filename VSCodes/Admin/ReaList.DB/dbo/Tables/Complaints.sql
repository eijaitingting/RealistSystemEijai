CREATE TABLE [dbo].[Complaints] (
    [ComplaintsID]      INT            IDENTITY (1, 1) NOT NULL,
    [AgentID]           INT            NULL,
    [CustomerID]        INT            NULL,
    [ComplaintCategory] TINYINT        NULL,
    [DateOfEvent]       DATETIME2 (7)  NULL,
    [ComplaintSubject]  NVARCHAR (255) NULL,
    [ComplaintDetails]  NVARCHAR (255) NULL,
    [ComplaintImages]   VARBINARY (1)  NULL,
    [DateCreated]       DATETIME2 (7)  NULL,
    PRIMARY KEY CLUSTERED ([ComplaintsID] ASC)
);

