CREATE PROCEDURE [dbo].[GetCategoryWithParentById]
	@Id int
AS
		SELECT  child.Id, child.Name, 
		parent.Id AS ParentId,  
		parent.Name AS ParentName  
	FROM Category AS child  
	LEFT JOIN Category AS parent ON child.ParentId = parent.Id
	WHERE child.Id = @Id
