CREATE PROCEDURE sp_UpdateBooking
	@BookingID int,
	@VisitDate datetime2,
	@VisitTime nvarchar(50),
	@BookingStatus int,
	@DateUpdated datetime2
AS
BEGIN
	UPDATE Bookings
	SET 
		VisitDate = @VisitDate,
		VisitTime = @VisitTime,
		BookingStatus = @BookingStatus,
		DateUpdated = @DateUpdated
	WHERE BookingID = @BookingID
END
RETURN 0