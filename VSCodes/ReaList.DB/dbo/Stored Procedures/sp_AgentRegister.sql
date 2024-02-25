--These are the stored procedures, make sure that the query is set to ReaListDB

-- Agent Account
CREATE PROCEDURE [dbo].[sp_AgentRegister]
	@AgentID int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(50),
	@Password nvarchar(MAX),
	@ActivationCode uniqueidentifier,
	@IsEmailVerified bit,
	@AccountStatus tinyint,
	@isVerified bit,
	@DateCreated datetime2
AS
BEGIN
	INSERT INTO Agents(FirstName, LastName, Email, [Password],ActivationCode,IsEmailVerified, AccountStatus, isVerified, DateCreated) 
	VALUES (@FirstName, @LastName, @Email, @Password,@ActivationCode,@IsEmailVerified,  @AccountStatus, @isVerified, @DateCreated);
END
RETURN 0