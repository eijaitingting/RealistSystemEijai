
CREATE PROCEDURE sp_CustomerLogin
	@Email nvarchar(50),
	@Password nvarchar(50)
AS
BEGIN
	SELECT CustomerID, Email, [Password] FROM Customers
	WHERE Email = @Email And [Password] = @Password
END
RETURN 0

