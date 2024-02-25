CREATE PROCEDURE [dbo].[sp_GetAgentDataByResetCode]
     @ResetPasswordCode UNIQUEIDENTIFIER
	
AS
BEGIN
    -- Your SQL query to select data
    SELECT *
    FROM Agents
    WHERE ResetPasswordCode = @ResetPasswordCode
END