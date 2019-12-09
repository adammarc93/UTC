IF OBJECT_ID('crud_TruckUpdate') IS NOT NULL
BEGIN
	DROP PROCEDURE crud_TruckUpdate
END
GO
CREATE PROCEDURE crud_TruckUpdate
	(
		@Id INT,
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
	UPDATE [UTC].[dbo].Trucks
		SET Brand=@Brand, Model=@Model, TotalCost=@TotalCost, YearOfProduction=@YearOfProduction,
            Mileage=@Mileage, Fuel=@Fuel, Color=@Color, CarStatus=@CarStatus
        WHERE Id=@Id
END