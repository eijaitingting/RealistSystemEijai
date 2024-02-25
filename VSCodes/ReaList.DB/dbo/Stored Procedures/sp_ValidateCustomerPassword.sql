CREATE PROCEDURE [dbo].[sp_ValidateCustomerPassword]
    @OldPassword NVARCHAR(MAX),
	@NewPassword NVARCHAR(MAX),
    @CustomerID int
AS
BEGIN
    DECLARE @StoredPassword NVARCHAR(MAX)

    -- Retrieve the password from the customers table for the given CustomerID
    SELECT @StoredPassword = Password
    FROM Customers
    WHERE CustomerID = @CustomerID

    -- Check if the retrieved password matches the provided password
    IF @StoredPassword =@OldPassword
    BEGIN
		        UPDATE Customers
        SET Password = @NewPassword
        WHERE CustomerID = @CustomerID
        -- Passwords match, return success
        SELECT 'Success' AS Result
    END
    
	 END