CREATE TABLE [dbo].[SubscriptionType] (
    [SubscriptionTypeID]   INT             IDENTITY (1, 1) NOT NULL,
    [SubscriptionTypeName] NVARCHAR (255)  NULL,
    [SubscriptionPrice]    DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([SubscriptionTypeID] ASC)
);

