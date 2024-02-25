
CREATE PROCEDURE sp_GetSpecificComplaint
	@ComplaintID int
AS
BEGIN
	SELECT * FROM Complaints WHERE ComplaintID = @ComplaintID
END