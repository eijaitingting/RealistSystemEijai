CREATE PROCEDURE sp_AddPropertyCategory
	@PropertyCategoryName nvarchar(50)
AS
BEGIN
	INSERT INTO PropertyCategory VALUES (@PropertyCategoryName) 
END
RETURN 0