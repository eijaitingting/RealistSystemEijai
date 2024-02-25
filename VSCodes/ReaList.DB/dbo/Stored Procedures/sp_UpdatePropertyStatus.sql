CREATE PROCEDURE sp_UpdatePropertyStatus
	@PropertyID int,
	@PropertyStatus tinyint
AS
BEGIN
	UPDATE Properties
	SET PropertyStatus = @PropertyStatus
	WHERE PropertyID = @PropertyID
END
RETURN 0