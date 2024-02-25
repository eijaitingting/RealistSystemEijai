CREATE PROCEDURE sp_EditProperty
	@PropertyID int,
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
	@DateUpdated datetime2
AS
BEGIN
	UPDATE Properties
	SET 
		PropertyCategoryID = @PropertyCategoryID,
		PropertyTypeID = @PropertyTypeID,
		PropertyName = @PropertyName,
		Overview = @Overview,
		TotalPrice = @TotalPrice, 
		Bedrooms = @Bedrooms, 
		Bathrooms = @Bathrooms, 
		FloorAreaSize = @FloorAreaSize, 
		DevelopmentInfo = @DevelopmentInfo,
		DateUpdated = @DateUpdated
	WHERE PropertyID = @PropertyID

	UPDATE PropertyLocation
	SET
		Region = @Region,
		Municipality = @Municipality,
		City = @City,
		Barangay = @Barangay,
		Street = @Street,
		Zipcode = @Zipcode
	WHERE PropertyID = @PropertyID

	UPDATE Amenities
	SET
		AmenitiesName = @AmenitiesName
	WHERE PropertyID = @PropertyID

	UPDATE Features
	SET
		FeaturesName = @FeaturesName
	WHERE PropertyID = @PropertyID

	UPDATE PropertyRatings
	SET
		RoadRatings = @RoadRatings,
		SafetyRatings = @SafetyRatings,
		CleanlinessRatings = @CleanlinessRatings,
		ParkingRatings = @ParkingRatings,
		TrafficRatings = @TrafficRatings,
		SchoolRatings = @SchoolRatings,
		RestaurantRatings = @RestaurantRatings,
		TotalRatings = @TotalRatings
	WHERE PropertyID = @PropertyID

	UPDATE PropertyPhotos
	SET
		MainPhoto = @MainPhoto,
		SecondPhoto = @SecondPhoto,
		ThirdPhoto = @ThirdPhoto,
		FourthPhoto = @FourthPhoto,
		FifthPhoto = @FifthPhoto,
		SixthPhoto = @SixthPhoto,
		SeventhPhoto = @SeventhPhoto,
		EightPhoto = @EightPhoto,
		NinthPhoto = @NinthPhoto,
		TenthPhoto = @TenthPhoto
	WHERE PropertyID = @PropertyID
RETURN 0
END