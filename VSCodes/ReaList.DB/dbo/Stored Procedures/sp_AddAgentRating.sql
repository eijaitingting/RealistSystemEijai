
-- Agent Ratings

Create PROCEDURE sp_AddAgentRating
	@AgentRatingsID int,
	@BookingID int,
	@AgentID int,
	@CustomerID int,
	@AgentRatings int,
	@Feedback nvarchar(255),
	@DateCreated datetime2
AS
BEGIN
	INSERT INTO AgentRatings (BookingID, AgentID, CustomerID, AgentRatings, Feedback, DateCreated)
	VALUES (@BookingID, @AgentID, @CustomerID, @AgentRatings, @Feedback, @DateCreated)
END
RETURN