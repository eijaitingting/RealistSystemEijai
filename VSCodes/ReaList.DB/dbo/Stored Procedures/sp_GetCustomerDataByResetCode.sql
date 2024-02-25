CREATE PROCEDURE [dbo].[sp_GetCustomerDataByResetCode]
     @ResetPasswordCode UNIQUEIDENTIFIER
	
AS
BEGIN
    -- Your SQL query to select data
    SELECT *
    FROM Customers
    WHERE ResetPasswordCode = @ResetPasswordCode
END