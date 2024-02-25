CREATE PROCEDURE sp_CustomerProfile
	@CustomerID int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Birthdate date,
	@PhoneNumber nvarchar(11),
	@Email nvarchar(50),
	@Address nvarchar(255),
	@ProfilePicture nvarchar(255),
	@DateUpdated datetime
AS
BEGIN
	UPDATE Customers
	SET 
		FirstName = @FirstName,
		LastName = @LastName,
		Birthdate = @Birthdate,
		PhoneNumber = @PhoneNumber,
		Email = @Email,
		[Address] = @Address,
		ProfilePicture = @ProfilePicture,
		DateUpdated = @DateUpdated
	WHERE CustomerID = @CustomerID
RETURN 0
END