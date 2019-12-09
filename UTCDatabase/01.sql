/****** Created table Cars  ******/
CREATE TABLE [UTC].[dbo].Cars (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Brand varchar(50) NOT NULL,
    Model varchar(50) NOT NULL,
    TotalCost INT NOT NULL,
	YearOfProduction INT NOT NULL,
	Mileage INT NOT NULL,
	Fuel varchar(25) NOT NULL,
	CarType varchar(25) NOT NULL,
	Seats INT NOT NULL,
	Color varchar(25) NOT NULL,
	CarStatus varchar(25) NOT NULL
);