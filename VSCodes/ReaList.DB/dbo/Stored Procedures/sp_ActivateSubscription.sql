
Create PROCEDURE [dbo].[sp_ActivateSubscription]
	@SubscriptionID int
	
AS
BEGIN
	UPDATE Subscription
	SET IsActive = 1
	WHERE SubscriptionID = @SubscriptionID
END
RETURN 0