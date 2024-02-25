Create PROCEDURE [dbo].[sp_ValidateAdminPassword]
        @OldPassword NVARCHAR(MAX),
	@NewPassword NVARCHAR(MAX),
    @AdminID int
AS
BEGIN
    DECLARE @StoredPassword NVARCHAR(MAX)

    -- Retrieve the password from the customers table for the given CustomerID
    SELECT @StoredPassword = Password
    FROM Admin
    WHERE AdminID = @AdminID

    -- Check if the retrieved password matches the provided password
    IF @StoredPassword = @OldPassword
    BEGIN 
	UPDATE Admin
        SET Password = @NewPassword
        WHERE AdminID = @AdminID
        -- Passwords match, return success
        SELECT 'Success' AS Result
    END
    
END