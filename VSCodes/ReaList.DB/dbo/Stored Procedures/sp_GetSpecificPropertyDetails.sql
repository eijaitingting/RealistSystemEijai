CREATE PROCEDURE sp_GetSpecificPropertyDetails
	@PropertyID int
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
		STRING_AGG(AM.AmenitiesName, ', ') AS Amenities,
		STRING_AGG(F.FeaturesName, ', ') AS Features,
		P.isAppropriate,
		P.PropertyStatus,
		P.DateCreated,
		P.DateUpdated,
		CONCAT(PL.Street,' ', PL.Barangay, ' ', PL.City, ' ', PL.Municipality, ' ', PL.Region, ' ', PL.ZipCode) AS [Location],
		PR.*,
		PP.*
	FROM 
		Properties P
		JOIN PropertyLocation PL ON P.PropertyID = PL.PropertyID
		JOIN PropertyCategory PC ON P.PropertyCategoryID = PC.PropertyCategoryID
		JOIN PropertyType PT ON P.PropertyTypeID = PT.PropertyTypeID
		JOIN Agents A ON P.AgentID = A.AgentID
		JOIN Amenities AM ON P.PropertyID = AM.PropertyID
		JOIN Features F ON P.PropertyID = F.PropertyID
		JOIN PropertyRatings PR ON P.PropertyID = PR.PropertyID
		JOIN PropertyPhotos PP ON P.PropertyID = PP.PropertyID
	WHERE
		P.PropertyID = @PropertyID
	GROUP BY
		P.PropertyID,
		P.AgentID,
		CONCAT(A.FirstName, ' ', A.LastName),
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
		CONCAT(PL.Street,' ', PL.Barangay, ' ', PL.City, ' ', PL.Municipality, ' ', PL.Region, ' ', PL.ZipCode),
		PR.PropertyRatingsID,
		PR.PropertyID,
		PR.RoadRatings,
		PR.SafetyRatings,
		PR.CleanlinessRatings,
		PR.ParkingRatings,
		PR.TrafficRatings,
		PR.SchoolRatings,
		PR.RestaurantRatings,
		PR.TotalRatings,
		PP.PropertyPhotosID,
		PP.PropertyID,
		PP.MainPhoto,
		PP.SecondPhoto,
		PP.ThirdPhoto,
		PP.FourthPhoto,
		PP.FifthPhoto,
		PP.SixthPhoto,
		PP.SeventhPhoto,
		PP.EightPhoto,
		PP.NinthPhoto,
		PP.TenthPhoto
END
Return 0