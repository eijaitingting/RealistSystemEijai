﻿
CREATE PROCEDURE sp_GetAllAgentAccount
AS
BEGIN
	SELECT * FROM Agents WHERE AccountStatus = 1
END
RETURN 0

