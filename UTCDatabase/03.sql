/****** Created table CarsLogs  ******/
CREATE TABLE [UTC].[dbo].Logs (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    VehicleId INT NOT NULL,
	Change varchar(20) NOT NULL,
	ChangeTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
	PrevBrand varchar(50) DEFAULT NULL,
	Brand varchar(50) NOT NULL,
    PrevModel varchar(50) DEFAULT NULL,
	Model varchar(50) NOT NULL,
	PrevTotalCost INT DEFAULT NULL,
    TotalCost INT NOT NULL,
	PrevYearOfProduction INT DEFAULT NULL,
	YearOfProduction INT NOT NULL,
	PrevMileage INT DEFAULT NULL,
	Mileage INT NOT NULL,
	PrevFuel varchar(25) DEFAULT NULL,
	Fuel varchar(25) NOT NULL,
	PrevCarType varchar(25) DEFAULT NULL,
	CarType varchar(25) DEFAULT NULL,
	PrevSeats INT DEFAULT NULL,
	Seats INT DEFAULT NULL,
	PrevColor varchar(25) DEFAULT NULL,
	Color varchar(25) NOT NULL,
	PrevCarStatus varchar(25) DEFAULT NULL,
	CarStatus varchar(25) NOT NULL
);