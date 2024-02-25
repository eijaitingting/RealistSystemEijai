
CREATE PROCEDURE [dbo].[sp_UpdateAgentResetCode]
    @Email NVARCHAR(255),
    @ResetPasswordCode UNIQUEIDENTIFIER
AS
BEGIN
    -- Check if the agent exists based on the provided email address
    DECLARE @AgentID INT

    SELECT @AgentID = AgentID
    FROM Agents
    WHERE Email = @Email

    -- If the agent exists, update the ResetPasswordCode
    IF @AgentID IS NOT NULL
    BEGIN
        UPDATE Agents
        SET ResetPasswordCode = @ResetPasswordCode
        WHERE Email = @Email
    END

    SELECT 'Success' AS Result
END