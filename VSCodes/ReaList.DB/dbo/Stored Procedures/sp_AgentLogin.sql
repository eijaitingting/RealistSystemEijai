
CREATE PROCEDURE [dbo].[sp_AgentLogin]
	@Email nvarchar(50),
	@Password nvarchar(MAX),
	@IsEmailVerified bit
AS
BEGIN
	SELECT AgentID, Email, [Password] FROM Agents
	WHERE Email = @Email AND [Password] = @Password And IsEmailVerified = @IsEmailVerified
END
RETURN

