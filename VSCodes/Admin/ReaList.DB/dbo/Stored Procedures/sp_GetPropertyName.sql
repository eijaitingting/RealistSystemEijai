CREATE PROCEDURE sp_GetPropertyName
@PropertyName nvarchar(50)
As
Begin
	Select * From Properties Where PropertyName = @PropertyName
End;
Return 0;