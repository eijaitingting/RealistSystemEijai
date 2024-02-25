
-- COMPLAINTS

CREATE PROCEDURE sp_AddComplaint
	@ComplaintID int,
	@AgentID int,
	@CustomerID int,
    @ComplaintCategory tinyint,
    @DateOfEvent datetime,
    @ComplaintSubject nvarchar(255),
    @ComplaintDetails nvarchar(255),
	@ComplaintStatus tinyint,
    @DateCreated datetime2
AS
BEGIN
	INSERT INTO Complaints(
		AgentId, 
		CustomerID, 
		ComplaintCategory, 
		DateOfEvent, 
		ComplaintSubject, 
		ComplaintDetails,  
		ComplaintStatus,
		DateCreated)
	VALUES(
		@AgentID, 
		@CustomerID, 
		@ComplaintCategory, 
		@DateOfEvent, 
		@ComplaintSubject,
		@ComplaintDetails,
		@ComplaintStatus,
		@DateCreated);
END
RETURN 0