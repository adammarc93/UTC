SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].InsertCarTrigger 
   ON  [UTC].[dbo].[Cars] 
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [UTC].[dbo].Logs (VehicleId, Change, Brand, Model, TotalCost, YearOfProduction, Mileage, Fuel, CarType, Seats, Color, CarStatus)
	SELECT Id, 'insert', Brand, Model, TotalCost, YearOfProduction, Mileage, Fuel, CarType, Seats, Color, CarStatus FROM inserted
END
