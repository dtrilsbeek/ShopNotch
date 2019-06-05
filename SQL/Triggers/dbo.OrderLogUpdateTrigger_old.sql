CREATE TRIGGER [dbo].[OrderLogUpdateTrigger] ON [dbo].[Order]
AFTER UPDATE AS
BEGIN

	DECLARE	@OrderId int,
	@LogText text

	SELECT @OrderId = [Order].Id
	FROM [Order]

	EXEC NewOrderLog @OrderId, @LogText;


END
GO