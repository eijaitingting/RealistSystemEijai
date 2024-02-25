
CREATE PROCEDURE [dbo].[sp_BannedAgentAccounts]
AS
BEGIN
	SELECT * FROM 
		Agents WHERE AccountStatus = 4
END
RETURN 0