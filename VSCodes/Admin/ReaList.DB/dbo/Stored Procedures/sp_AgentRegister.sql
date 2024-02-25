CREATE PROCEDURE sp_AgentRegister
	@AgentID int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(50),
	@Password nvarchar(50),
	@AccountStatus tinyint,
	@isVerified bit,
	@DateCreated datetime2
AS
BEGIN
	INSERT INTO Agents(FirstName, LastName, Email, [Password], AccountStatus, isVerified, DateCreated) 
	VALUES (@FirstName, @LastName, @Email, @Password, @AccountStatus, @isVerified, @DateCreated);
END
RETURN 0

