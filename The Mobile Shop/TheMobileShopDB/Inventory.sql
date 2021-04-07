CREATE TABLE [dbo].[Inventory]
(
[ProductId] INT NOT NULL PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL, 
[Description] NVARCHAR(250),
[Quantity] INT NOT NULL,
[CategoryId] INT NOT NULL,
[Brand] NVARCHAR(50),
[Cost] FLOAT NOT NULL,
[Price] FLOAT NOT NULL,

CONSTRAINT [FK_Inventory_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([CategoryId])
);
