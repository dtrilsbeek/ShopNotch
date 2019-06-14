CREATE TRIGGER dbo.OrderLogUpdateTrigger
ON [dbo].[Order]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO [dbo].OrderLog(
        OrderId,
		LogText
    )
    SELECT
        i.Id,
        'Order Updated'
    FROM
        inserted i

END