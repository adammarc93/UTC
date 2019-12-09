IF OBJECT_ID('crud_TruckReadAll') IS NOT NULL
BEGIN 
    DROP PROC crud_TruckReadAll
END 
GO
CREATE PROC crud_TruckReadAll
AS 
BEGIN 
	SELECT * FROM [UTC].[dbo].Trucks
END
GO