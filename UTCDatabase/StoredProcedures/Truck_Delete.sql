IF OBJECT_ID('crud_TruckDelete') IS NOT NULL
BEGIN
	DROP PROCEDURE crud_TruckDelete
END
GO
CREATE PROCEDURE crud_TruckDelete
	(
		@Id INT
	)
AS
BEGIN
	DELETE FROM [UTC].[dbo].Trucks WHERE Id=@Id
END