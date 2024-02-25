
Create PROCEDURE [dbo].[sp_UpdateSubscription]
	@SubscriptionID int
	
AS
BEGIN
	UPDATE Subscription
	SET IsActive = 0
	WHERE SubscriptionID = @SubscriptionID
END
RETURN 0