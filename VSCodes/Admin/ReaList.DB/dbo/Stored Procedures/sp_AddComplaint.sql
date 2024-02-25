CREATE PROCEDURE [dbo].[sp_AddComplaint]
    @ComplaintCategory tinyint,
    @DateOfEvent datetime,
    @ComplaintSubject nvarchar(255),
    @ComplaintDetails nvarchar(255),
    @ComplaintImages varbinary,
    @DateCreated datetime2
AS
BEGIN
INSERT INTO Complaints(ComplaintCategory, DateOfEvent, ComplaintSubject, ComplaintDetails, ComplaintImages, DateCreated)
VALUES(@ComplaintCategory, @DateOfEvent, @ComplaintSubject, @ComplaintDetails, @ComplaintImages, @DateCreated);
END
RETURN 0