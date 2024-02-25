CREATE PROCEDURE [dbo].[sp_AddProperty]
	@PropertyID int,
	@AgentID int,
	@PropertyCategoryID int,
	@PropertyTypeID  int,
	@PropertyName nvarchar(255),
	@Overview nvarchar(255),
	@TotalPrice decimal,
	@Bedrooms int,
	@Bathrooms int,
	@FloorAreaSize int,
    @Region nvarchar(50),
    @Municipality nvarchar(50),
    @City nvarchar(50),
    @Barangay nvarchar(50),
    @Street nvarchar(50),
    @Zipcode nvarchar(50),
	@DevelopmentInfo nvarchar(255),
	@VSPhotos varbinary,
	@PropertyStatus tinyint,
	@DateCreated datetime2
AS
BEGIN
INSERT INTO Properties(PropertyName, Overview, TotalPrice, Bedrooms, Bathrooms, FloorAreaSize, DevelopmentInfo, VSPhotos, PropertyStatus, DateCreated) 
VALUES (@PropertyName, @Overview, @TotalPrice, @Bedrooms, @Bathrooms, @FloorAreaSize, @DevelopmentInfo, @VSPhotos, @PropertyStatus, @DateCreated);
INSERT INTO PropertyLocation(Region, Municipality, City, Barangay, Street, ZipCode)
VALUES (@Region, @Municipality, @City, @Barangay, @Street, @Zipcode);
END
RETURN 0