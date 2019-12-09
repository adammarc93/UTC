IF OBJECT_ID('crud_CarRead') IS NOT NULL
BEGIN 
    DROP PROC crud_CarRead
END 
GO
CREATE PROC crud_CarRead
    @CarId int
AS 
BEGIN
	SELECT * FROM [UTC].[dbo].Cars
		WHERE (Id = @CarId)
END
GO