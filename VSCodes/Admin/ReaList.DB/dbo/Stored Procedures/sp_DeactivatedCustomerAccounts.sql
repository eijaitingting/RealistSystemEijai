
CREATE PROCEDURE [dbo].[sp_DeactivatedCustomerAccounts]
AS
BEGIN
	SELECT * FROM 
		Customers WHERE AccountStatus = 3
END
RETURN 0