
Create PROCEDURE [dbo].[sp_UpdateAdminResetCode]
    @Email NVARCHAR(255),
    @ResetPasswordCode UNIQUEIDENTIFIER
AS
BEGIN
    -- Check if the agent exists based on the provided email address
    DECLARE @AdminID INT

    SELECT @AdminID = AdminID
    FROM Admin
    WHERE Email = @Email

    -- If the agent exists, update the ResetPasswordCode
    IF @AdminID IS NOT NULL
    BEGIN
        UPDATE Admin
        SET ResetPasswordCode = @ResetPasswordCode
        WHERE Email = @Email
    END

    SELECT 'Success' AS Result
END