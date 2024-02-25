CREATE PROCEDURE sp_GetAllAgentAccount
As
Begin
	Select * From Agents Where AccountStatus = 1
End;
Return 0;
