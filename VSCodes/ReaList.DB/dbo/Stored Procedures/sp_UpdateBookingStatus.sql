CREATE PROCEDURE sp_UpdateBookingStatus
	@BookingID int,
	@BookingStatus int
AS
BEGIN
	UPDATE Bookings
	SET BookingStatus = @BookingStatus
	WHERE BookingID = @BookingID
END
RETURN 0