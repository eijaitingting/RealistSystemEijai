
-- BOOKINGS

CREATE PROCEDURE sp_AddBooking
	@BookingID int,
	@AgentID int,
	@CustomerID int,
	@PropertyID int,
	@VisitDate date,
    @VisitTime nvarchar(50),
	@BookingStatus tinyint,
	@BookingPostStatus tinyint,
    @DateCreated datetime2
AS
BEGIN
	INSERT INTO Bookings(
		AgentID,
		CustomerID,
		PropertyID,
		VisitDate,
		VisitTime,
		BookingStatus,
		BookingPostStatus,
		DateCreated)
	VALUES(
		@AgentID,
		@CustomerID,
		@PropertyID,
		@VisitDate,
		@VisitTime,
		@BookingStatus,
		@BookingPostStatus,
		@DateCreated);
END
RETURN 0