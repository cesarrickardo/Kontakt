
CREATE TABLE [dbo].[tblCustomerChanges](
	[CustomerID] [nchar](5) NOT NULL,
	[ContactNameOLD] [nvarchar](40) NOT NULL,
	[ContactNameNEW] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_tblCustomerChanges] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

