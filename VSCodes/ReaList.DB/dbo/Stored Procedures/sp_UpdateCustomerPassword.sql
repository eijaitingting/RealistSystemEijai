CREATE PROCEDURE sp_UpdateCustomerPassword
    @CustomerID INT,
    @Password NVARCHAR(MAX),
    @ResetPasswordCode NVARCHAR(MAX)
AS
BEGIN
    UPDATE Customers
    SET
        Password = @Password,
        ResetPasswordCode = @ResetPasswordCode
    WHERE
        CustomerID = @CustomerID;
END