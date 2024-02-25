CREATE PROCEDURE sp_VerifyActivationCodeCustomer
    @ActivationCode UNIQUEIDENTIFIER
AS
BEGIN
    UPDATE Customers
    SET IsEmailVerified = 1
    WHERE ActivationCode = @ActivationCode;
END;