CREATE PROCEDURE [dbo].[sp_ValidateAgentPassword]
        @OldPassword NVARCHAR(MAX),
	@NewPassword NVARCHAR(MAX),
    @AgentID int
AS
BEGIN
    DECLARE @StoredPassword NVARCHAR(MAX)

    -- Retrieve the password from the customers table for the given CustomerID
    SELECT @StoredPassword = Password
    FROM Agents
    WHERE AgentID = @AgentID

    -- Check if the retrieved password matches the provided password
    IF @StoredPassword = @OldPassword
    BEGIN 
	UPDATE Agents
        SET Password = @NewPassword
        WHERE AgentID = @AgentID
        -- Passwords match, return success
        SELECT 'Success' AS Result
    END
    
	 END