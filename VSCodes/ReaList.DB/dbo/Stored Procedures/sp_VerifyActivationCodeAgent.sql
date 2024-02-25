CREATE PROCEDURE sp_VerifyActivationCodeAgent
    @ActivationCode UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Agents
    SET IsEmailVerified = 1, ActivationCode = NULL
    WHERE ActivationCode = @ActivationCode;
END;