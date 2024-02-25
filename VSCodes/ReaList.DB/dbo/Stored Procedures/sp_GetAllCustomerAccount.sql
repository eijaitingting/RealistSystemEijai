
CREATE PROCEDURE sp_GetAllCustomerAccount
AS
BEGIN
	SELECT * FROM Customers WHERE AccountStatus = 1
End
Return 0