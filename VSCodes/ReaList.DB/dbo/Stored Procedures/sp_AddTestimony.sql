
-- TESTIMONIES

CREATE PROCEDURE sp_AddTestimony
	@TestimonyID int,
	@AgentID int,
    @Testimony nvarchar(255),
    @isDisplayed bit,
    @DateCreated datetime2
AS
BEGIN
	INSERT INTO Testimonies(AgentID, Testimony, isDisplayed, DateCreated)
	VALUES(@AgentID, @Testimony, @isDisplayed, @DateCreated);
END
RETURN 0