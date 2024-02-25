CREATE PROCEDURE dbo.sp_GetSpecificComplaint
	@ComplaintsID int
AS
BEGIN
	SELECT * FROM Complaints WHERE ComplaintsID = @ComplaintsID
END
