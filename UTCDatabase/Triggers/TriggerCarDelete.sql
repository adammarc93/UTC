SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[DeleteCarTrigger]
   ON  [UTC].[dbo].[Cars] 
   AFTER DELETE
AS 
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [UTC].[dbo].Logs (VehicleId, Change, Brand, Model, TotalCost, YearOfProduction, Mileage, Fuel, CarType, Seats, Color, CarStatus)
	SELECT Id, 'delete', Brand, Model, TotalCost, YearOfProduction, Mileage, Fuel, CarType, Seats, Color, CarStatus FROM deleted
END
