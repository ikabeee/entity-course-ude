USE DbEntityCore;
GO

-- Create a view

CREATE OR ALTER VIEW dbo.GetCategories AS
SELECT c.Category_Id, c.Title, c.Active, c.CreatedAt FROM
Category c
GO;

-- Create a stored procedure
CREATE OR ALTER PROCEDURE dbo.GetCategoryById
    @userId INT AS
    SET NOCOUNT ON;
    SELECT * FROM dbo.[User] u
    WHERE u.Id = @userId;
GO