SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[UpdateCarTrigger] 
   ON  [UTC].[dbo].[Cars] 
   AFTER UPDATE
AS 
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [UTC].[dbo].Logs (VehicleId, Change, Brand, Model, TotalCost, YearOfProduction, Mileage, Fuel, CarType, Seats, Color, CarStatus,
									  PrevBrand, PrevModel, PrevTotalCost, PrevYearOfProduction, PrevMileage, PrevFuel, PrevCarType, PrevSeats, PrevColor, PrevCarStatus)
	SELECT i.Id, 'update', i.Brand, i.Model, i.TotalCost, i.YearOfProduction, i.Mileage, i.Fuel, i.CarType, i.Seats, i.Color, i.CarStatus,
		   d.Brand, d.Model, d.TotalCost, d.YearOfProduction, d.Mileage, d.Fuel, d.CarType, d.Seats, d.Color, d.CarStatus
	FROM inserted i, deleted d
END