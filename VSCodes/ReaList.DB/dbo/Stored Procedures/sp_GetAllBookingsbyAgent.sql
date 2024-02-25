CREATE PROCEDURE sp_GetAllBookingsbyAgent
	@AgentID int
AS
BEGIN
	SELECT 
		B.BookingID,
		P.PropertyName,
		PL.City,
		PL.Municipality,
		B.VisitDate,
		B.VisitTime,
		CONCAT(C.FirstName, ' ', C.LastName) AS CustomerName,
		C.PhoneNumber,
		C.Email,
		B.BookingStatus,
		B.BookingPostStatus
	FROM Bookings B
		JOIN Properties P ON B.PropertyID = P.PropertyID
		JOIN PropertyLocation PL ON P.PropertyID = PL.PropertyID
		JOIN Customers C ON B.CustomerID = C.CustomerID
	WHERE B.AgentID = @AgentID
END
RETURN