IF OBJECT_ID('crud_TruckInsert') IS NOT NULL
BEGIN
	DROP PROCEDURE crud_TruckInsert
END
GO
CREATE PROCEDURE crud_TruckInsert
	(
		@Brand varchar(50),
		@Model varchar(50),
		@TotalCost INT,
		@YearOfProduction INT,
		@Mileage INT,
		@Fuel varchar(25),
		@Color varchar(25),
		@CarStatus varchar(25)
	)
AS
BEGIN
	INSERT INTO [UTC].[dbo].Trucks (Brand, Model, TotalCost, YearOfProduction, Mileage, Fuel, Color, CarStatus)
		VALUES (@Brand, @Model, @TotalCost, @YearOfProduction, @Mileage, @Fuel, @Color, @CarStatus)
END