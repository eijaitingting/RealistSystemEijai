CREATE PROCEDURE sp_AgentLogin
	@Email nvarchar(50),
	@Password nvarchar(50)
AS
BEGIN
	SELECT AgentID, Email, [Password] FROM Agents
	WHERE Email = @Email AND [Password] = @Password
END
RETURN