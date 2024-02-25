CREATE PROCEDURE dbo.sp_GetResolvedCustomerComplaints
AS
BEGIN
SELECT * FROM Complaints WHERE ComplaintCategory = 4
END
RETURN 0