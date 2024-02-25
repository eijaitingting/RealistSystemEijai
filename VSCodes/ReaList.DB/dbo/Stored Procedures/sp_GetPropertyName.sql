
CREATE PROCEDURE sp_GetPropertyName
	@PropertyName nvarchar(50)
AS
BEGIN
	SELECT * FROM Properties WHERE PropertyName = @PropertyName
END
RETURN 0