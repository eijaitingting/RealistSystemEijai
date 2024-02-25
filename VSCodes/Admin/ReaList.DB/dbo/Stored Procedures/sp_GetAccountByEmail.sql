CREATE PROCEDURE sp_GetAccountByEmail
    @Email NVARCHAR(50)
AS
BEGIN
    SELECT Email FROM Agents WHERE Email = @Email
    UNION ALL
    SELECT Email FROM Customers WHERE Email = @Email
        UNION ALL
    SELECT Email FROM [Admin] WHERE Email = @Email
END
RETURN 0

