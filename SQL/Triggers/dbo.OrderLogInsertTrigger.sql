CREATE TRIGGER dbo.OrderLogInsertTrigger
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
        'Order inserted'
    FROM
        inserted i

END