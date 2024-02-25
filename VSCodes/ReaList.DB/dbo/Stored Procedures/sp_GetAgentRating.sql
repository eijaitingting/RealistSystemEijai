CREATE PROCEDURE sp_GetAgentRating
	@BookingID int,
	@AgentID int,
    @CustomerID int
AS
BEGIN
    SELECT AgentID, CustomerID FROM AgentRatings WHERE BookingID = @BookingID
END
RETURN 0