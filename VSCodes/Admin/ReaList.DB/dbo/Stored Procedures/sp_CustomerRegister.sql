
-- Customer Account

CREATE PROCEDURE sp_CustomerRegister
	@CustomerID int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(50),
	@Password nvarchar(50),
	@AccountStatus tinyint,
	@isVerified bit,
	@DateCreated datetime2
AS
BEGIN
	INSERT INTO Customers(FirstName, LastName, Email, [Password], AccountStatus, isVerified, DateCreated) 
	VALUES (@FirstName, @LastName, @Email, @Password, @AccountStatus, @isVerified, @DateCreated);
END
Return 0

