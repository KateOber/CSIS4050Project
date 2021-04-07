CREATE TABLE [dbo].[Transactions]
(	
[TransactionId] INT NOT NULL PRIMARY KEY IDENTITY,
[Date] DATE NOT NULL,
[PaymentMethod] NVARCHAR(20),
[TotalCost] FLOAT NOT NULL,
[TaxAmount] FLOAT NOT NULL,
[TotalDiscount] FLOAT,
[TotalPrice] FLOAT NOT NULL, 
[EmployeeId] INT NOT NULL,

CONSTRAINT [FK_Transactions_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([EmployeeId]) on delete cascade
)
