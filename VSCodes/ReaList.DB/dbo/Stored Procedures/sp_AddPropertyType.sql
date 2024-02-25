
CREATE PROCEDURE sp_AddPropertyType
	@PropertyTypeName nvarchar(50)
AS
BEGIN
	INSERT INTO PropertyType VALUES (@PropertyTypeName) 
END
RETURN 0