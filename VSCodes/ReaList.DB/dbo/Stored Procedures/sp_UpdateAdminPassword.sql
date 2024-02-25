
-- Create the stored procedure for updating Agent passwords
Create PROCEDURE [dbo].[sp_UpdateAdminPassword]
    @AdminID INT,
    @Password NVARCHAR(MAX),
    @ResetPasswordCode NVARCHAR(MAX)
AS
BEGIN
    UPDATE Admin
    SET
        Password = @Password,
        ResetPasswordCode = @ResetPasswordCode
    WHERE
        AdminID = @AdminID;
END