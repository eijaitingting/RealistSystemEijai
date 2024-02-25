CREATE TABLE [dbo].[Subscription] (
    [SubscriptionID]     INT            IDENTITY (1, 1) NOT NULL,
    [SubscriptionTypeID] INT            NULL,
    [AgentID]            INT            NULL,
    [ReferenceNumber]    NVARCHAR (255) NULL,
    [StartDate]          DATE           NULL,
    [ExpiryDate]         DATE           NULL,
    [IsActive]           BIT            NULL,
    PRIMARY KEY CLUSTERED ([SubscriptionID] ASC)
);



