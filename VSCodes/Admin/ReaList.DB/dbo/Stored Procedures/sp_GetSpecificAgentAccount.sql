
CREATE PROCEDURE sp_GetSpecificAgentAccount
	@AgentID int
AS
BEGIN
	SELECT * FROM Agents WHERE AgentID = @AgentID
END
RETURN 0

