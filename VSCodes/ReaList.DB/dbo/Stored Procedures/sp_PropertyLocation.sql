
CREATE PROCEDURE sp_PropertyLocation
	@PropertyLocationID int,
	@PropertyID int,
	@Region nvarchar(255),
	@Municipality nvarchar(255),
	@City nvarchar(255),
	@Barangay nvarchar(255),
    @Street nvarchar(255), 
	@ZipCode nvarchar(255)
AS
BEGIN
	INSERT INTO PropertyLocation(PropertyID, Region, Municipality, Barangay, Street, ZipCode)
	VALUES (@PropertyID, @Region, @Municipality, @Barangay, @Street, @ZipCode);
END
RETURN 0