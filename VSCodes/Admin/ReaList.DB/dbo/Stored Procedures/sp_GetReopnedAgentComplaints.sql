CREATE PROCEDURE dbo.sp_GetReopnedAgentComplaints
AS
BEGIN
SELECT * FROM Complaints WHERE ComplaintCategory = 5
END
RETURN 0