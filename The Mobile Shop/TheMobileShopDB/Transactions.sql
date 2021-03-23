CREATE TABLE [dbo].[Transactions]
(	
[TransactionId] INT NOT NULL PRIMARY KEY IDENTITY,
[ProductId] INT NOT NULL,
[Quantity] INT,
[Date] DATE,
[Time] TIME,
[PaymentMode] NVARCHAR(50),
[GrossPrice] NUMERIC,
[NetPrice] NUMERIC,
[Tax] NUMERIC,
[Discount] NUMERIC
)
