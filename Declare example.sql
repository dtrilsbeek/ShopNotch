

DECLARE @Id int, 
		@Name nvarchar(100),
		@ParentId int, 
		@ParentName nvarchar(100)
		 
SELECT @Id = Id, @Name = Name, @ParentId = ParentId FROM Category