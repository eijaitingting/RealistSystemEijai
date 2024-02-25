
CREATE PROCEDURE [dbo].[sp_Unsubscribe]
	
	

AS
BEGIN
Declare @SubscriptionID int

    UPDATE Subscription
    SET isActive =0
    WHERE SubscriptionID = @SubscriptionID;

   
END
 RETURN 0;