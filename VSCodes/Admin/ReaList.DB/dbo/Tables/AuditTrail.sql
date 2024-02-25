CREATE TABLE [dbo].[AuditTrail] (
    [AuditTrailID] INT            NOT NULL,
    [UserID]       INT            NULL,
    [Action]       NVARCHAR (255) NULL,
    [TableName]    NVARCHAR (255) NULL,
    [ColumnName]   NVARCHAR (255) NULL,
    [OldValue]     NVARCHAR (255) NULL,
    [NewValue]     NVARCHAR (255) NULL,
    [DateUpdated]  DATETIME2 (7)  NULL,
    PRIMARY KEY CLUSTERED ([AuditTrailID] ASC)
);

