CREATE PROCEDURE sp_UpdateBookingPostStatus
	@BookingID int,
	@BookingPostStatus int
AS
BEGIN
	UPDATE Bookings
	SET BookingPostStatus = @BookingPostStatus
	WHERE BookingID = @BookingID
END
RETURN 0