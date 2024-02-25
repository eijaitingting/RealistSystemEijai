CREATE PROCEDURE sp_GetAllComplaintsByAgent
	@AgentID int
AS
BEGIN
	SELECT * FROM Complaints WHERE AgentID = @AgentID
END