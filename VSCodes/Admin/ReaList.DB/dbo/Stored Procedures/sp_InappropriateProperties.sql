CREATE PROCEDURE [dbo].[sp_InappropriateProperties]
AS
BEGIN
	SELECT * FROM 
		Properties P
		JOIN PropertyLocation PL ON P.PropertyID = PL.PropertyID WHERE PropertyStatus = 5
END
RETURN 0