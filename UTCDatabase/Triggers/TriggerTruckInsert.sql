SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].InsertTruckTrigger 
   ON  [UTC].[dbo].[Trucks] 
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [UTC].[dbo].Logs (VehicleId, Change, Brand, Model, TotalCost, YearOfProduction, Mileage, Fuel, Color, CarStatus)
	SELECT Id, 'insert', Brand, Model, TotalCost, YearOfProduction, Mileage, Fuel, Color, CarStatus FROM inserted
END
