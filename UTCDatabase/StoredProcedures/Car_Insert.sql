IF OBJECT_ID('crud_CarInsert') IS NOT NULL
BEGIN
	DROP PROCEDURE crud_CarInsert
END
GO
CREATE PROCEDURE crud_CarInsert
	(
		@Brand varchar(50),
		@Model varchar(50),
		@TotalCost INT,
		@YearOfProduction INT,
		@Mileage INT,
		@Fuel varchar(25),
		@CarType varchar(25),
		@Seats INT,
		@Color varchar(25),
		@CarStatus varchar(25)
	)
AS
BEGIN
	INSERT INTO [UTC].[dbo].Cars (Brand, Model, TotalCost, YearOfProduction, Mileage, Fuel, CarType, Seats, Color, CarStatus)
		VALUES (@Brand, @Model, @TotalCost, @YearOfProduction, @Mileage, @Fuel, @CarType, @Seats, @Color, @CarStatus)
END