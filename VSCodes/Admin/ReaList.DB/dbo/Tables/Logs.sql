CREATE TABLE [dbo].[Logs] (
    [LogID]      INT            NOT NULL,
    [AgentID]    INT            NULL,
    [CustomerID] INT            NULL,
    [ActionType] TINYINT        NULL,
    [ActionName] NVARCHAR (255) NULL,
    [ActionDate] DATETIME2 (7)  NULL,
    PRIMARY KEY CLUSTERED ([LogID] ASC)
);

