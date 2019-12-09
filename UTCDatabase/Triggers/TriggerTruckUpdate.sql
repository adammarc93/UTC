SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[UpdateTruckTrigger] 
   ON  [UTC].[dbo].[Trucks] 
   AFTER UPDATE
AS 
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [UTC].[dbo].Logs (VehicleId, Change, Brand, Model, TotalCost, YearOfProduction, Mileage, Fuel, Color, CarStatus,
									  PrevBrand, PrevModel, PrevTotalCost, PrevYearOfProduction, PrevMileage, PrevFuel, PrevCarType, PrevCarStatus)
	SELECT i.Id, 'update', i.Brand, i.Model, i.TotalCost, i.YearOfProduction, i.Mileage, i.Fuel, i.Color, i.CarStatus,
		   d.Brand, d.Model, d.TotalCost, d.YearOfProduction, d.Mileage, d.Fuel, d.Color, d.CarStatus
	FROM inserted i, deleted d
END
