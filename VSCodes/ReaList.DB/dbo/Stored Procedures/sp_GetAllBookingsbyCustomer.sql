CREATE PROCEDURE sp_GetAllBookingsbyCustomer
	@CustomerID int
AS
BEGIN
	SELECT 
		B.*,
		CONCAT(PL.Street, ' ', PL.Barangay, ' ', PL.City, ' ', PL.Municipality, ' ', PL.Region, ' ', PL.ZipCode) AS [Location],
		P.PropertyName,
		PC.PropertyCategoryName,
		PT.PropertyTypeName,
		PP.MainPhoto
	FROM Bookings B
		JOIN Properties P ON B.PropertyID = P.PropertyID
		JOIN PropertyLocation PL ON P.PropertyID = PL.PropertyID
		JOIN PropertyCategory PC ON P.PropertyCategoryID = PC.PropertyCategoryID
		JOIN PropertyType PT ON P.PropertyTypeID = PT.PropertyTypeID
		JOIN PropertyPhotos PP ON P.PropertyID = PP.PropertyID
	WHERE CustomerID = @CustomerID
END
RETURN