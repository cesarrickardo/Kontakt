
CREATE TRIGGER [dbo].[TestNewTrigger] 
   ON  [dbo].[Customers]
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from 
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO tblCustomerChanges
        ([CustomerID], [ContactNameOLD],[ContactNameNEW])
 select i.CustomerID, d.ContactName, i.ContactName
 from inserted i
 inner join deleted d on i.CustomerID= d.CustomerID
 where d.ContactName <> i.ContactName

    -- Insert statements for trigger here
END
GO

ALTER TABLE [dbo].[Customers] ENABLE TRIGGER [TestNewTrigger]
GO

