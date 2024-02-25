CREATE PROCEDURE dbo.sp_GetAgentComplaints
AS
BEGIN
SELECT * FROM Complaints WHERE ComplaintCategory = 1 
END
RETURN 0