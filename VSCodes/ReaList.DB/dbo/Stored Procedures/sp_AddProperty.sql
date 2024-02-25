
-- PROPERTIES

CREATE PROCEDURE sp_AddProperty
	@PropertyID int,
	@AgentID int,
	@PropertyCategoryID int,
	@PropertyTypeID int,
	@PropertyName nvarchar(50),
	@Overview nvarchar(255),
	@TotalPrice decimal(18,2),
	@Bedrooms int,
	@Bathrooms int,
	@FloorAreaSize int,
    @Region nvarchar(50),
    @Municipality nvarchar(50),
    @City nvarchar(50),
    @Barangay nvarchar(50),
    @Street nvarchar(255),
    @Zipcode nvarchar(6),
	@DevelopmentInfo nvarchar(255),
	@AmenitiesName nvarchar(255),
	@FeaturesName nvarchar(255),
	@RoadRatings int,
	@SafetyRatings int,
	@CleanlinessRatings int,
	@ParkingRatings int,
	@TrafficRatings int,
	@SchoolRatings int,
	@RestaurantRatings int,
	@TotalRatings int,
	@MainPhoto nvarchar(max),
	@SecondPhoto nvarchar(max),
	@ThirdPhoto nvarchar(max),
	@FourthPhoto nvarchar(max),
	@FifthPhoto nvarchar(max),
	@SixthPhoto nvarchar(max),
	@SeventhPhoto nvarchar(max),
	@EightPhoto nvarchar(max),
	@NinthPhoto nvarchar(max),
	@TenthPhoto nvarchar(max),
	@PropertyStatus tinyint,
	@DateCreated datetime2
AS
BEGIN
	INSERT INTO Properties(
		AgentID,
		PropertyCategoryID,
		PropertyTypeID,
		PropertyName,
		Overview,
		TotalPrice, 
		Bedrooms, 
		Bathrooms, 
		FloorAreaSize, 
		DevelopmentInfo, 
		PropertyStatus, 
		DateCreated) 
	VALUES (
		@AgentID,
		@PropertyCategoryID,
		@PropertyTypeID,
		@PropertyName, 
		@Overview, 
		@TotalPrice, 
		@Bedrooms,
		@Bathrooms, 
		@FloorAreaSize, 
		@DevelopmentInfo, 
		@PropertyStatus, 
		@DateCreated)
	
	SET @PropertyID = SCOPE_IDENTITY()

	INSERT INTO PropertyLocation(
		PropertyID,
		Region, 
		Municipality, 
		City, 
		Barangay, 
		Street, 
		ZipCode)
	VALUES (
		@PropertyID,
		@Region,
		@Municipality, 
		@City, 
		@Barangay, 
		@Street,
		@Zipcode)

	INSERT INTO Amenities(
		PropertyID,
		AmenitiesName)
	VALUES (
		@PropertyID,
		@AmenitiesName)

	INSERT INTO Features(
		PropertyID,
		FeaturesName)
	VALUES (
		@PropertyID,
		@FeaturesName)

	INSERT INTO PropertyRatings(
		PropertyID,
		RoadRatings,
		SafetyRatings,
		CleanlinessRatings,
		ParkingRatings,
		TrafficRatings,
		SchoolRatings,
		RestaurantRatings,
		TotalRatings)
	VALUES (
		@PropertyID,
		@RoadRatings,
		@SafetyRatings,
		@CleanlinessRatings,
		@ParkingRatings,
		@TrafficRatings,
		@SchoolRatings,
		@RestaurantRatings,
		@TotalRatings)

	INSERT INTO PropertyPhotos (
		PropertyID,
		MainPhoto,
		SecondPhoto,
		ThirdPhoto,
		FourthPhoto,
		FifthPhoto,
		SixthPhoto,
		SeventhPhoto,
		EightPhoto,
		NinthPhoto,
		TenthPhoto)
	VALUES (
		@PropertyID,
		@MainPhoto,
		@SecondPhoto,
		@ThirdPhoto,
		@FourthPhoto,
		@FifthPhoto,
		@SixthPhoto,
		@SeventhPhoto,
		@EightPhoto,
		@NinthPhoto,
		@TenthPhoto)
END
RETURN 0