CREATE PROCEDURE [dbo].[NewOrderLog]
	@OrderId int,
	@LogText text
AS
	INSERT INTO OrderLog  
	(OrderId, LogText)  
	VALUES (@OrderId, @LogText);

RETURN 0
