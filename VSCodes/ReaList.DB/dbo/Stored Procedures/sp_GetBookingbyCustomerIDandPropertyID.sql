
CREATE PROCEDURE [dbo].[sp_GetBookingbyCustomerIDandPropertyID]
    @CustomerID int,
	@PropertyID int
AS
BEGIN
    SELECT CustomerID, PropertyID FROM Bookings WHERE PropertyID = @PropertyID AND CustomerID = @CustomerID AND BookingStatus != '4'
END
RETURN 0