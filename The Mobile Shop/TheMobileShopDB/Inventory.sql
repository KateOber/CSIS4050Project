CREATE TABLE [dbo].[Inventory]
(
[ProductId] INT NOT NULL PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL, 
[Description] NVARCHAR(250),
[Quantity] INT NOT NULL,
[Price] NUMERIC,
[CategoryId] INT NOT NULL,
[Brand] NVARCHAR(50),
[GrossPrice] NUMERIC,
[NetPrice] NUMERIC,
[Tax] NUMERIC,
[Discount] NUMERIC

CONSTRAINT [FK_Inventory_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([CategoryId])
);
