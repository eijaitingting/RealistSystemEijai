CREATE PROCEDURE sp_GetSpecificBooking
	@BookingID int
AS
BEGIN
	SELECT * FROM Bookings WHERE BookingID = @BookingID
END
RETURN 0