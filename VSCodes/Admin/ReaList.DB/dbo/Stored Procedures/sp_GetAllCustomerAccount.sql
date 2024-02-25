
CREATE PROCEDURE sp_GetAllCustomerAccount
AS
BEGIN
	SELECT * FROM Customers WHERE AccountStatus = 1
END
RETURN 0

