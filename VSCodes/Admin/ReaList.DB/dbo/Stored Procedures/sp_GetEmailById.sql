CREATE PROCEDURE [dbo].[sp_GetEmailById]
	@ID int,
    @Email NVARCHAR(50)
AS
BEGIN
   SELECT AgentID, Email FROM Agents WHERE AgentID = @ID AND Email = @Email
    UNION ALL
    SELECT CustomerID, Email FROM Customers WHERE CustomerID = @ID AND Email = @Email
    UNION ALL
    SELECT AdminID, Email FROM [Admin] WHERE AdminID = @ID AND Email = @Email
END
RETURN 0