
CREATE PROCEDURE sp_GetAllActiveProperties
AS
BEGIN
	SELECT * FROM Properties WHERE PropertyStatus = 1
END
RETURN 0