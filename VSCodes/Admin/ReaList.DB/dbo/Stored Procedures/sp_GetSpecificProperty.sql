CREATE PROCEDURE [dbo].[sp_GetSpecificProperty]
@PropertyID int
As
Begin
	Select * From Properties Where PropertyID = @PropertyID
End;
Return 0;