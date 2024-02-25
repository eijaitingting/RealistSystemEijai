CREATE PROCEDURE dbo.sp_GetResolvedAgentComplaints
AS
BEGIN
SELECT * FROM Complaints WHERE ComplaintCategory = 3
END
RETURN 0