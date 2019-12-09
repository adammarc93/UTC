IF OBJECT_ID('crud_CarUpdate') IS NOT NULL
BEGIN
	DROP PROCEDURE crud_CarUpdate
END
GO
CREATE PROCEDURE crud_CarUpdate
	(
		@Id INT,
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
	UPDATE [UTC].[dbo].Cars
		SET Brand=@Brand, Model=@Model, TotalCost=@TotalCost, YearOfProduction=@YearOfProduction,
            Mileage=@Mileage, Fuel=@Fuel, CarType=@CarType, Seats=@Seats, Color=@Color, CarStatus=@CarStatus
        WHERE Id=@Id
END