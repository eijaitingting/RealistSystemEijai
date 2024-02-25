Create PROCEDURE [dbo].[sp_GetAdminDataByResetCode]
     @ResetPasswordCode UNIQUEIDENTIFIER
	
AS
BEGIN
    -- Your SQL query to select data
    SELECT *
    FROM Admin
    WHERE ResetPasswordCode = @ResetPasswordCode
END