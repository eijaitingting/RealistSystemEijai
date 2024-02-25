
CREATE PROCEDURE [dbo].[sp_BannedCustomerAccounts]
AS
BEGIN
	SELECT * FROM 
		Customers WHERE AccountStatus = 4
END
RETURN 0