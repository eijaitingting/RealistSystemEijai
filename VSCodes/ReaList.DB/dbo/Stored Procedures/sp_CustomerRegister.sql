
-- Customer Account

CREATE PROCEDURE [dbo].[sp_CustomerRegister]
	@CustomerID int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(50),
	@Password nvarchar(MAX),
	@ActivationCode uniqueidentifier,
	@IsEmailVerified bit,
	@AccountStatus tinyint,
	@isVerified bit,
	@DateCreated datetime2
AS
BEGIN
	INSERT INTO Customers(FirstName, LastName, Email, [Password],ActivationCode,IsEmailVerified, AccountStatus, isVerified, DateCreated) 
	VALUES (@FirstName, @LastName, @Email, @Password,@ActivationCode,@IsEmailVerified, @AccountStatus, @isVerified, @DateCreated);
END
Return 0