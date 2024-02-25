
CREATE PROCEDURE [dbo].[sp_CustomerLogin]
	@Email nvarchar(50),
	@Password nvarchar(MAX),
	@IsEmailVerified bit
AS
BEGIN
	SELECT CustomerID, Email, [Password] FROM Customers
	WHERE Email = @Email And [Password] = @Password And IsEmailVerified = @IsEmailVerified
END
RETURN 0