CREATE PROCEDURE [dbo].[sp_UpdateResetCode]
    @Email NVARCHAR(255),
    @ResetPasswordCode UNIQUEIDENTIFIER
AS
BEGIN
    -- Check if the user exists based on the provided email address
    DECLARE @AgentID INT
    DECLARE @CustomerID INT

    SELECT @AgentID = AgentID
    FROM Agents
    WHERE Email = @Email

    SELECT @CustomerID = CustomerID
    FROM Customers
    WHERE Email = @Email

    -- If the user exists, update the ResetPasswordCode
    IF @AgentID IS NOT NULL
    BEGIN
        UPDATE Agents
        SET ResetPasswordCode = @ResetPasswordCode
        WHERE Email = @Email
    END

    IF @CustomerID IS NOT NULL
    BEGIN
        UPDATE Customers
        SET ResetPasswordCode = @ResetPasswordCode
        WHERE Email = @Email
    END
	  SELECT 'Success' AS Result
END