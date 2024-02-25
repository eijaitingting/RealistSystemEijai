CREATE PROCEDURE dbo.sp_GetReopenedCustomerComplaints
AS
BEGIN
SELECT * FROM Complaints WHERE ComplaintCategory = 6
END
RETURN 0