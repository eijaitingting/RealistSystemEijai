CREATE PROCEDURE sp_AgentProfile
	@AgentID int,
	@AgentType nvarchar(50),
	@FirstName nvarchar(50),
	@MiddleName nvarchar(50),
	@LastName nvarchar(50),
	@Suffix nvarchar(10),
	@Birthdate date,
	@Gender nvarchar(6),
	@PhoneNumber nvarchar(11),
	@Email nvarchar(50),
	@Address nvarchar(255),
	@ProfilePicture nvarchar(255),
	@AgentAbout nvarchar(255),
	@CompanyName nvarchar(100),
	@Education nvarchar(100),
	@Organizations nvarchar(255),
	@LicenseIdNumber nvarchar(20),
	@DateUpdated datetime
AS
BEGIN
	UPDATE Agents
	SET 
		AgentType = @AgentType,
		FirstName = @FirstName,
		MiddleName = @MiddleName,
		LastName = @LastName,
		Suffix = @Suffix,
		Birthdate = @Birthdate,
		Gender = @Gender,
		PhoneNumber = @PhoneNumber,
		Email = @Email,
		[Address] = @Address,
		ProfilePicture = @ProfilePicture,
		AgentAbout = @AgentAbout,
		CompanyName = @CompanyName,
		Education = @Education,
		Organizations = @Organizations,
		LicenseIdNumber = @LicenseIdNumber,
		DateUpdated = @DateUpdated
	WHERE AgentID = @AgentID
RETURN 0
END