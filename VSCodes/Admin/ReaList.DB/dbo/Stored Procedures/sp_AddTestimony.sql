CREATE PROCEDURE dbo.sp_AddTestimony
    @Testimony nvarchar(255),
    @isDisplayed bit,
    @DateCreated datetime2
AS
BEGIN
INSERT INTO Testimonies(Testimony, isDisplayed, DateCreated)
VALUES(@Testimony, @isDisplayed, @DateCreated);
END
RETURN 0