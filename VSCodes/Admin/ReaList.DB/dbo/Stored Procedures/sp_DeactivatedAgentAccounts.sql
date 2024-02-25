CREATE PROCEDURE [dbo].[sp_DeactivatedAgentAccounts]
AS
BEGIN
	SELECT * FROM 
		Agents WHERE AccountStatus = 3
END
RETURN 0