IF OBJECT_ID('crud_CarReadAll') IS NOT NULL
BEGIN 
    DROP PROC crud_CarReadAll
END 
GO
CREATE PROC crud_CarReadAll
AS 
BEGIN 
	SELECT * FROM [UTC].[dbo].Cars
END
GO