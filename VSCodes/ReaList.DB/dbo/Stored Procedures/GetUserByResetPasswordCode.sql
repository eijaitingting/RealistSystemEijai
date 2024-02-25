
CREATE PROCEDURE [dbo].[GetUserByResetPasswordCode]
    @ResetPasswordCode uniqueidentifier
AS
BEGIN
    -- Declare variables to store the user records
    DECLARE @CustomerID int
    DECLARE @AgentID int
	DECLARE @AdminID int

    -- Check if a user with the given ResetPasswordCode exists in the Customer table
    SELECT @CustomerID = CustomerID
    FROM Customers
    WHERE ResetPasswordCode = @ResetPasswordCode

    -- Check if a user with the given ResetPasswordCode exists in the Agent table
    SELECT @AgentID = AgentID
    FROM Agents
    WHERE ResetPasswordCode = @ResetPasswordCode

	SELECT @AdminID = @AdminID
    FROM Admin
    WHERE ResetPasswordCode = @ResetPasswordCode
    -- If a Customer is found, return the Customer data
    IF @CustomerID IS NOT NULL
    BEGIN
        SELECT *
        FROM Customers
        WHERE CustomerID = @CustomerID
    END
    -- If an Agent is found, return the Agent data
    ELSE IF @AgentID IS NOT NULL
    BEGIN
        SELECT *
        FROM Agents
        WHERE AgentID = @AgentID
    END
	 ELSE IF @AdminID IS NOT NULL
    BEGIN
        SELECT *
        FROM Admin
        WHERE AdminID = @AdminID
    END
    ELSE
    BEGIN
        -- If no user is found, return NULL or an appropriate message
        -- You can customize the response as needed
        SELECT NULL AS Id, NULL AS UserName, NULL AS Email -- Add other columns
    END
END