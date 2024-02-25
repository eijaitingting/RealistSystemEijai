
CREATE PROCEDURE sp_GetAllSoldProperties
AS
BEGIN
	SELECT * FROM Properties WHERE PropertyStatus = 2
END
RETURN 0