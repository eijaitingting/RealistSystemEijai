CREATE PROCEDURE [dbo].[sp_UpdateCustomerResetCode]
    @Email NVARCHAR(255),
    @ResetPasswordCode UNIQUEIDENTIFIER
AS
BEGIN
    -- Check if the user exists based on the provided email address
  
    DECLARE @CustomerID INT

    

    SELECT @CustomerID = CustomerID
    FROM Customers
    WHERE Email = @Email

    -- If the user exists, update the ResetPasswordCode
  

    IF @CustomerID IS NOT NULL
    BEGIN
        UPDATE Customers
        SET ResetPasswordCode = @ResetPasswordCode
        WHERE Email = @Email
    END
	  SELECT 'Success' AS Result
END