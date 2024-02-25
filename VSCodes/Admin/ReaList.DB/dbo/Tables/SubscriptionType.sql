CREATE TABLE [dbo].[SubscriptionType] (
    [SubscriptionTypeID]   INT            NOT NULL,
    [SubscriptionTypeName] NVARCHAR (255) NULL,
    [SubscriptionPrice]    DECIMAL (18)   NULL,
    PRIMARY KEY CLUSTERED ([SubscriptionTypeID] ASC)
);

