SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[DeleteTruckTrigger]
   ON  [UTC].[dbo].[Trucks] 
   AFTER DELETE
AS 
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [UTC].[dbo].Logs (VehicleId, Change, Brand, Model, TotalCost, YearOfProduction, Mileage, Fuel, Color, CarStatus)
	SELECT Id, 'delete', Brand, Model, TotalCost, YearOfProduction, Mileage, Fuel, Color, CarStatus FROM deleted
END
GO
