CREATE TABLE [dbo].[TransactionProducts]
(
	[TransactionId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	[Quantity] INT NOT NULL,
	[Discount] FLOAT NULL, 
	CONSTRAINT [PK_TransactionProducts] PRIMARY KEY CLUSTERED ([TransactionId] ASC, [ProductId] ASC),
	CONSTRAINT [FK_TransactionProducts_Inventory_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Inventory] ([ProductId]) on delete cascade,
    CONSTRAINT [FK_TransactionProducts_Transactions_TransactionId] FOREIGN KEY ([TransactionId]) REFERENCES [Transactions] ([TransactionId]) on delete cascade
);
