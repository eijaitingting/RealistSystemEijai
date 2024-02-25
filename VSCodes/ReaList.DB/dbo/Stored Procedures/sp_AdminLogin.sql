
Create PROCEDURE [dbo].[sp_AdminLogin]
	@Email nvarchar(50),
	@Password nvarchar(MAX)
	
AS
BEGIN
	SELECT AdminID, Email, [Password] FROM Admin
	WHERE Email = @Email AND [Password] = @Password 
END
RETURN