CREATE TABLE [dbo].[Order]
(
	[order_id] INT NOT NULL PRIMARY KEY, 
    [customer_pnone_no] INT NULL, 
    [customer_name] VARCHAR(50) NULL, 
    [order_date] DATETIME NULL, 
    [price] NCHAR(10) NULL
)
