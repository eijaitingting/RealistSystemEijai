
CREATE PROCEDURE sp_GetSpecificAgentAccount
	@AgentID int
As
Begin
	Select * From Agents Where AgentID = @AgentID
End;
Return 0;
