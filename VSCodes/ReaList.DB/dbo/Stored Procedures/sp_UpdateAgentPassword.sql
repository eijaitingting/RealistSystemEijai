
-- Create the stored procedure for updating Agent passwords
CREATE PROCEDURE [dbo].[sp_UpdateAgentPassword]
    @AgentID INT,
    @Password NVARCHAR(MAX),
    @ResetPasswordCode NVARCHAR(MAX)
AS
BEGIN
    UPDATE Agents
    SET
        Password = @Password,
        ResetPasswordCode = @ResetPasswordCode
    WHERE
        AgentID = @AgentID;
END