CREATE PROCEDURE sp_GetPropertyType
AS
BEGIN

SET NOCOUNT ON;

    SELECT PropertyTypeName, 'CONDOMINIUM' AS Category FROM PropertyType
    SELECT PropertyTypeName, 'LAND' AS Category FROM PropertyType
    SELECT PropertyTypeName, 'HOUSE' AS Categoty FROM PropertyType

END
