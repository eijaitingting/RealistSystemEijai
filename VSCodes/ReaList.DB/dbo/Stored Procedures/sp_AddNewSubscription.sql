
CREATE PROCEDURE [dbo].[sp_AddNewSubscription]
    @SubscriptionTypeID INT,
    @AgentID INT,
    @ReferenceNumber NVARCHAR(255),
	@SubPhoto NVARCHAR(MAX)
AS
BEGIN
    DECLARE @StartDate DATETIME = GETDATE(); -- Today's date and time
    DECLARE @ExpiryDate DATETIME = DATEADD(DAY, 30, @StartDate); -- 30 days after today

    INSERT INTO Subscription (SubscriptionTypeID, AgentID, ReferenceNumber, StartDate, ExpiryDate, IsActive,SubPhoto)
    VALUES (@SubscriptionTypeID, @AgentID, @ReferenceNumber, @StartDate, @ExpiryDate, 1,@SubPhoto); -- Setting IsActive to true

    -- You may choose to return something meaningful based on your needs
    RETURN 0;
END