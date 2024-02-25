CREATE PROCEDURE [dbo].[sp_PropertyLocation]
	@PropertyLocationID int,
	@PropertyTypeID  int,
	@Region nvarchar(255),
	@Municipality nvarchar(255),
	@City nvarchar(255),
	@Barangay nvarchar(255),
    @Street nvarchar(255), 
	@ZipCode nvarchar(255)
AS
INSERT INTO PropertyLocation(Region, Municipality, Barangay, Street, ZipCode)
VALUES (@Region, @Municipality, @Barangay, @Street, @ZipCode);