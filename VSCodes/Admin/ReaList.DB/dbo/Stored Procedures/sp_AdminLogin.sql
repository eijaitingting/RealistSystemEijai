CREATE PROCEDURE [dbo].[sp_AdminLogin]
	@Email nvarchar(50),
	@Password nvarchar(50)
AS
BEGIN
	SELECT AdminID, Email, [Password] FROM [Admin]
	WHERE Email = @Email And [Password] = @Password
END
RETURN 0