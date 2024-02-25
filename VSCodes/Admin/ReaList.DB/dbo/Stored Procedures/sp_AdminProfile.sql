
CREATE PROCEDURE dbo.sp_AdminProfile

@AdminID int,
@FirstName nvarchar(255),
@LastName nvarchar(255),
@Email nvarchar(255),
@Password nvarchar(255),
@DateUpdated datetime2

AS
BEGIN
UPDATE Admin
SET 
		FirstName = @FirstName,
		LastName = @LastName,
		Email = @Email,
		[Password] = @Password,
		DateUpdated = @DateUpdated

	WHERE AdminID = @AdminID
RETURN 
END