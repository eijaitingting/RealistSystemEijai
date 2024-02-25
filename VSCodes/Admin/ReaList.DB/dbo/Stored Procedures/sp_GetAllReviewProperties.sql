CREATE PROCEDURE [dbo].[sp_GetAllReviewProperties]
AS
BEGIN
	SELECT * FROM 
		Properties P
		JOIN PropertyLocation PL ON P.PropertyID = PL.PropertyID WHERE PropertyStatus = 4
END
RETURN 0