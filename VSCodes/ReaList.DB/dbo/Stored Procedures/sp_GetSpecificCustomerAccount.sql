
CREATE PROCEDURE sp_GetSpecificCustomerAccount
	@CustomerID int
AS
BEGIN
	SELECT * FROM Customers WHERE CustomerID = @CustomerID
END
RETURN 0