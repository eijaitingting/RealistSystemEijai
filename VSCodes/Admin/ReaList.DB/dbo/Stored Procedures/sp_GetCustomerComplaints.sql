CREATE PROCEDURE dbo.sp_GetCustomerComplaints
AS
BEGIN
SELECT * FROM Complaints WHERE ComplaintCategory = 2
END
RETURN 0