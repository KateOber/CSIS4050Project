/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE[TheMobileShopDB]
GO

SET IDENTITY_INSERT [dbo].[Employees] ON
INSERT INTO [dbo].[Employees] ([EmployeeId], [EmployeeCode], [FirstName], [LastName], [PhoneNumber], [Email], [IsAdmin]) VALUES (1,'ADM-001','Kate','Obertas','2362868281','kate@gmail.ca',1) 
INSERT INTO [dbo].[Employees] ([EmployeeId], [EmployeeCode], [FirstName], [LastName], [PhoneNumber], [Email], [IsAdmin]) VALUES (2,'ADM-002','Indu Priya','Addepalli','1234567891','indupriyaaddepalli@student.douglas.ca',1);
INSERT INTO [dbo].[Employees] ([EmployeeId], [EmployeeCode], [FirstName], [LastName], [PhoneNumber], [Email], [IsAdmin]) VALUES (3,'ADM-003','Naga Sudheer','Bolla','1234567892','sudheerbolla@student.douglas.ca',1);
INSERT INTO [dbo].[Employees] ([EmployeeId], [EmployeeCode], [FirstName], [LastName], [PhoneNumber], [Email], [IsAdmin]) VALUES (4,'EMP-001','Paul','Allen','7784567893','pallen@outlook.com',0);
INSERT INTO [dbo].[Employees] ([EmployeeId], [EmployeeCode], [FirstName], [LastName], [PhoneNumber], [Email], [IsAdmin]) VALUES (5,'EMP-002','Linus','Torvalds','6721233467','linux@yahoo.com',0);
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO

SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT INTO [dbo].[Categories] ([CategoryId],[CategoryCode],[CategoryName]) VALUES ('1','SP','Smartphone');
INSERT INTO [dbo].[Categories] ([CategoryId],[CategoryCode],[CategoryName]) VALUES ('2','TA','Tablet');
INSERT INTO [dbo].[Categories] ([CategoryId],[CategoryCode],[CategoryName]) VALUES ('3','AC','Accessory');
INSERT INTO [dbo].[Categories] ([CategoryId],[CategoryCode],[CategoryName]) VALUES ('4','CP','Cell Phone');
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO

SET IDENTITY_INSERT [dbo].[Inventory] ON
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('1','Galaxy A11 32GB','Samsung Galaxy A11 smartphone. Its 6.4\" Infinity-O display with large HD+ screen. The triple-camera setup. Its long-lasting lithium-ion battery allows you to use your phone for extended hours without needing to recharge.','15','1','Samsung','184.55','409.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('2','iPhone 12 Pro Max','5.8-inch Super Retina XDR OLED display Water and dust resistant (4 meters for up to 30 minutes, IP68) Triple-camera system with 12MP Ultra Wide, Wide, and Telephoto cameras; Night mode, Portrait mode, and 4K video up to 60fp','10','1','Apple','1000.00','1599.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('3','Pixel 5','Dimensions 6in (H) x 2.77in (W) x 0.31in (D) Weight 5.33 ounces Operating System Android Display and User Interface: Display Size 6 Display Technology N/A Pixel Density 432 PPI','8','1','Google','800.00','1399.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('4','Nokia 3310 2G','Nokia 3310 2G Feature Phone Dual SIM 2.4inch Color Screen BT 1500mAh 64MB 2MP Camera FM MP3 With LED Flashlight GSM Cell Phone','10','4','Nokia','10.00','25.66');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('5','Galaxy Tab A 8\" 32GB','Samsung Galaxy Tab A 8\" 32GB Android Tablet with Quad-Core Processor - Black','5','2','Samsung','80.00','199.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('6','iPad Pro (12.9-inch, Wi-Fi, 128GB)','Apple iPad Pro (12.9-inch, Wi-Fi, 128GB) - Space Grey 12.9-inch edge-to-edge Liquid Retina display with ProMotion, True Tone and P3 wide colour','6','2','Apple','900.00','1299.98');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('7','Leather Cover for Galaxy S20','Give your phone an elegant look and feel with this premium European leather cover. Its refined aluminum buttons add style and a distinct sense of luxury. With a soft grip and slim design.','3','3','Samsung','10.00','35.00');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('8','5W USB Power Adapter','Featuring an ultracompact design, this power adapter offers fast, efficient charging at home, in the office or on the go. It works with any Apple Watch, iPhone or iPod model.','30','3','Apple','5.00','23.98');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('9','TUNE 120TWS Headphones','Truly Wireless Headphones. They are powerful in sound thanks to a 5.8mm driver featuring JBL Pure Bass sound and colorful in design. ','3','3','JBL','40.00','99.98');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('10','Moto G8 Power Lite XT2055-2 64GB 4GB','Motorola Moto G8 Power Lite XT2055-2 64GB 4GB - Dual Sim - Brand New Unlocked - Arctic Blue','5','4','Motorola','100.00','249.99');
SET IDENTITY_INSERT [dbo].[Inventory] OFF
GO

SET IDENTITY_INSERT [dbo].[Transactions] ON
INSERT INTO [dbo].[Transactions] ([TransactionId],[Date],[PaymentMethod],[TotalCost],[TaxAmount],[TotalDiscount],[TotalPrice],[EmployeeId]) VALUES ('1','2021-04-03','Cash','2300.00','480.12','20.00','4000.50','1');
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO

INSERT INTO [dbo].[TransactionProducts] ([TransactionId],[ProductId],[Quantity],[Discount]) VALUES ('1','1','1',NULL);
INSERT INTO [dbo].[TransactionProducts] ([TransactionId],[ProductId],[Quantity],[Discount]) VALUES ('1','2','2','20.00');
INSERT INTO [dbo].[TransactionProducts] ([TransactionId],[ProductId],[Quantity],[Discount]) VALUES ('1','3','1',NULL);
GO



GO
