CREATE TABLE [dbo].[Notifications] (
    [NotificationID]      INT            IDENTITY (1, 1) NOT NULL,
    [AgentID]             INT            NULL,
    [CustomerID]          INT            NULL,
    [NotificationTitle]   NVARCHAR (255) NULL,
    [NotificationDetails] NVARCHAR (255) NULL,
    [IsRead]              BIT            NULL,
    [DateCreated]         DATETIME2 (7)  NULL,
    PRIMARY KEY CLUSTERED ([NotificationID] ASC)
);

