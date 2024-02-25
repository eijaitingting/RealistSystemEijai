CREATE PROCEDURE sp_GetSpecificProperty
	@PropertyID int
AS
BEGIN
	SELECT
		P.*,
		PL.*,
		STRING_AGG(A.AmenitiesName, ', ') AS Amenities,
		STRING_AGG(F.FeaturesName, ', ') AS Features,
		PR.*,
		PP.*
	FROM Properties P
		JOIN PropertyLocation PL ON P.PropertyID = PL.PropertyID
		JOIN Amenities A ON P.PropertyID = A.PropertyID
		JOIN Features F ON P.PropertyID = F.PropertyID
		JOIN PropertyRatings PR ON P.PropertyID = PR.PropertyID
		JOIN PropertyPhotos PP ON P.PropertyID = PP.PropertyID
	WHERE P.PropertyID = @PropertyID
	GROUP BY
		P.PropertyID,
		P.AgentID,
		P.PropertyCategoryID,
		P.PropertyTypeID,
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
		PL.PropertyLocationID,
		PL.PropertyID,
		PL.Region,
		PL.Municipality,
		PL.City,
		PL.Barangay,
		PL.Street,
		PL.ZipCode,
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
		PP.PropertyID,
		PP.PropertyPhotosID,
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