CREATE PROCEDURE dbo.sp_AdminRegister

@FirstName nvarchar(255),
@LastName nvarchar(255),
@Email nvarchar(255),
@Password nvarchar(255),
@DateCreated datetime2

AS
BEGIN
INSERT INTO [Admin] (FirstName, LastName, Email, [Password], DateCreated)
VALUES (@FirstName, @LastName, @Email, @Password, @DateCreated);
END
RETURN 0