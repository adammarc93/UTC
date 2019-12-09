IF OBJECT_ID('crud_TruckRead') IS NOT NULL
BEGIN 
    DROP PROC crud_TruckRead
END 
GO
CREATE PROC crud_TruckRead
    @TruckId int
AS 
BEGIN
	SELECT * FROM [UTC].[dbo].Trucks
		WHERE (Id = @TruckId)
END
GO