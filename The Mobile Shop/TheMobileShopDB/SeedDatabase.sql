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
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('11','Rain Design Mobile Stand for iPhone','Angled stand design lets you comfortably view your smartphone','4','3','Rain Design','24.99','29.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('12','Apple 20W USB-C Power Adapter','Pair it with iPhone 8 or later to take advantage of the fast-charging feature','15','3','Apple','24.99','29.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('13','Mobifoto Mobilite Clip 3.5 Ring Light','Clip-on ring light enhances your photos and videos with ideal levels of illumination in any ambient lighting condition','6','3','Mobifoto','29.99','34.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('14','Jabra Talk 15 Bluetooth Headset','Engineered to deliver high-quality calls over a Bluetooth connection','9','3','Jabra','29.99','34.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('15','Apple EarPods In-Ear Headphones with Lightning Connector - White','Design is defined by the geometry of the ear, making them more comfortable for more people','20','3','Apple','29.99','34.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('16','Belkin 1.83m (6 ft.) Lightning to Aux Cable - Black','3.5 mm connector is ideal for using an Apple device to listen to music through your car speakers','10','3','Belkin','39.99','45.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('17','Samsung Galaxy Tab S6 Lite 10.4 128GB Android Tablet','Android OS with One UI 2 offers fast boot times, efficient power management, and much more','4','2','Samsung','429.99','489.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('18','Lenovo Tab M8 8 16GB Android 9 Tablet','8 touchscreen with 1280x800 native resolution and 83% panel-to-body ratio displays your movies and games in crisp, bright visuals','5','2','Lenovo','109.99','149.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('19','Apple iPad 10.2 128GB with Wi-Fi (8th Generation)','2160 x 1620 resolution at 264 pixels per inch (ppi) and 500 nits brightness','6','2','Apple','549.99','599.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('20','Mophie Power Boost XXL 20800 mAh Power Bank','Massive battery capacity of 20,800 mAh provides up to 77 hours of extra runtime for your devices like smartphones and tablets','24','3','Mophie','39.99','44.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('21','LG Velvet 128GB','Large 6.8 edge-to-edge OLED screen is designed for entertainment, giving you a full cinematic picture for all your shows and movies','12','4','LG','129.99','169.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('22','Samsung Galaxy Xcover 4.5 16GB','LTE cat 4, GPS/GLONASS, Wi-Fi a/b/g/n (2.4+5GHz), Bluetooth 4.2 , NFC connectivity','3','4','Samsung','199.99','239.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('23','Google Pixel 2XL Phone 64GB','Pixel 2 XL features a smart camera that takes beautiful photos even in low light, a fast-charging battery and the Google Assistant built-in','5','4','Google','293.49','333.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('24','Google Pixel 4a 128GB','OLED display with 443ppi presents everything in vibrant, detailed hues','6','1','Google','479.99','512.99');
INSERT INTO [dbo].[Inventory] ([ProductId],[Name],[Description],[Quantity],[CategoryId],[Brand],[Cost],[Price]) VALUES ('25','Samsung Galaxy S21 5G 128GB','Adaptive 120Hz display makes scrolling fast and silky-smooth, and helps conserve battery life','4','1','Samsung','1029.99','1199.99');
SET IDENTITY_INSERT [dbo].[Inventory] OFF
GO

SET IDENTITY_INSERT [dbo].[Transactions] ON
INSERT INTO [dbo].[Transactions] ([TransactionId],[Date],[PaymentMethod],[TotalCost],[TaxAmount],[TotalDiscount],[TotalPrice],[EmployeeId]) VALUES ('1','2021-04-03','Cash','2300.00','480.12','20.00','4000.50','1');
INSERT INTO [dbo].[Transactions] ([TransactionId],[Date],[PaymentMethod],[TotalCost],[TaxAmount],[TotalDiscount],[TotalPrice],[EmployeeId]) VALUES ('2','2021-02-12','Cash','149.99','39.99','4.99','189.99','2');
INSERT INTO [dbo].[Transactions] ([TransactionId],[Date],[PaymentMethod],[TotalCost],[TaxAmount],[TotalDiscount],[TotalPrice],[EmployeeId]) VALUES ('3','2021-03-15','Cash','29.99','4.99','0.00','34.98','3');
INSERT INTO [dbo].[Transactions] ([TransactionId],[Date],[PaymentMethod],[TotalCost],[TaxAmount],[TotalDiscount],[TotalPrice],[EmployeeId]) VALUES ('4','2021-03-16','Cash','129.99','39.99','9.99','169.98','3');
INSERT INTO [dbo].[Transactions] ([TransactionId],[Date],[PaymentMethod],[TotalCost],[TaxAmount],[TotalDiscount],[TotalPrice],[EmployeeId]) VALUES ('5','2021-04-01','Cash','24.99','5.99','0.00','30.98','2');
INSERT INTO [dbo].[Transactions] ([TransactionId],[Date],[PaymentMethod],[TotalCost],[TaxAmount],[TotalDiscount],[TotalPrice],[EmployeeId]) VALUES ('6','2021-04-01','Cash','129.99','29.99','9.99','149.99','1');
INSERT INTO [dbo].[Transactions] ([TransactionId],[Date],[PaymentMethod],[TotalCost],[TaxAmount],[TotalDiscount],[TotalPrice],[EmployeeId]) VALUES ('7','2021-03-21','Cash','99.99','11.99','2.99','108.99','2');
INSERT INTO [dbo].[Transactions] ([TransactionId],[Date],[PaymentMethod],[TotalCost],[TaxAmount],[TotalDiscount],[TotalPrice],[EmployeeId]) VALUES ('8','2021-02-11','Cash','139.99','16.99','0.00','156.98','1');
INSERT INTO [dbo].[Transactions] ([TransactionId],[Date],[PaymentMethod],[TotalCost],[TaxAmount],[TotalDiscount],[TotalPrice],[EmployeeId]) VALUES ('9','2021-03-16','Cash','199.99','23.99','9.99','213.99','2');
INSERT INTO [dbo].[Transactions] ([TransactionId],[Date],[PaymentMethod],[TotalCost],[TaxAmount],[TotalDiscount],[TotalPrice],[EmployeeId]) VALUES ('10','2021-02-16','Cash','479.99','57.59','24.99','512.59','3');
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO

INSERT INTO [dbo].[TransactionProducts] ([TransactionId],[ProductId],[Quantity],[Discount]) VALUES ('1','1','1','20.00');
INSERT INTO [dbo].[TransactionProducts] ([TransactionId],[ProductId],[Quantity],[Discount]) VALUES ('2','2','2','4.99');
INSERT INTO [dbo].[TransactionProducts] ([TransactionId],[ProductId],[Quantity],[Discount]) VALUES ('3','3','1','0.00');
INSERT INTO [dbo].[TransactionProducts] ([TransactionId],[ProductId],[Quantity],[Discount]) VALUES ('4','3','1','9.99');
INSERT INTO [dbo].[TransactionProducts] ([TransactionId],[ProductId],[Quantity],[Discount]) VALUES ('6','9','1','9.99');
INSERT INTO [dbo].[TransactionProducts] ([TransactionId],[ProductId],[Quantity],[Discount]) VALUES ('7','12','2','9.99');
INSERT INTO [dbo].[TransactionProducts] ([TransactionId],[ProductId],[Quantity],[Discount]) VALUES ('9','19','1','9.99');
INSERT INTO [dbo].[TransactionProducts] ([TransactionId],[ProductId],[Quantity],[Discount]) VALUES ('5','14','1','14.99'); 
GO



