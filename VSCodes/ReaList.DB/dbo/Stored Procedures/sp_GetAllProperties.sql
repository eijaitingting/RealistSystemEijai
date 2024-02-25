
Create PROCEDURE [dbo].[sp_GetAllProperties]
AS
BEGIN
	SELECT 
		P.PropertyID,
		P.AgentID,
		CONCAT(A.FirstName, ' ', A.LastName) AS AgentName,
		A.AgentType,
		PC.PropertyCategoryName,
		PT.PropertyTypeName,
		P.PropertyName,
		P.Overview,
		P.TotalPrice,
		P.Bedrooms,
		P.Bathrooms,
		P.FloorAreaSize,
		P.DevelopmentInfo,
		P.VSPhotos,
		P.isAppropriate,
		P.PropertyStatus,
		P.DateCreated,
		P.DateUpdated,
		CONCAT(PL.Street,' ', PL.Barangay, ' ', PL.City, ' ', PL.Municipality, ' ', PL.Region, ' ', PL.ZipCode) AS [Location],
		PP.MainPhoto
	FROM 
		Properties P
		JOIN PropertyLocation PL ON P.PropertyID = PL.PropertyID
		JOIN PropertyCategory PC ON P.PropertyCategoryID = PC.PropertyCategoryID
		JOIN PropertyType PT ON P.PropertyTypeID = PT.PropertyTypeID
		JOIN Agents A ON P.AgentID = A.AgentID
		JOIN PropertyPhotos PP ON P.PropertyID = PP.PropertyID

END
RETURN 0