CREATE PROCEDURE sp_GetPropertyCategory
AS
BEGIN

SET NOCOUNT ON;

    SELECT PropertyCategoryName, 'RENTED' AS Category FROM PropertyCategory
    SELECT PropertyCategoryName, 'SOLD' AS Category FROM PropertyCategory
    SELECT PropertyCategoryName, 'ACTIVE' AS Categoty FROM PropertyCategory

END
