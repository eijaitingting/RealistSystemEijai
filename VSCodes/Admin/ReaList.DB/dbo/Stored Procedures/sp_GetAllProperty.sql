CREATE PROCEDURE [dbo].[sp_GetAllProperty]
As
Begin
	SELECT
    Properties.PropertyName, Properties.Overview,
    Properties.TotalPrice, PropertyLocation.Region,
    PropertyLocation.Municipality,
    PropertyLocation.City, PropertyLocation.Barangay,
    PropertyLocation.Street, PropertyLocation.ZipCode,
    Properties.FloorAreaSize, Properties.DevelopmentInfo,
    Properties.VSPhotos, Properties.PropertyStatus
    FROM Properties
    INNER JOIN PropertyLocation ON Properties.PropertyID = PropertyLocation.PropertyID ;
End;
Return 0;