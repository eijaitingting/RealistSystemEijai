
CREATE PROCEDURE sp_GetAllRentedProperties
AS
BEGIN
	SELECT * FROM Properties WHERE PropertyStatus = 3
END
RETURN 0