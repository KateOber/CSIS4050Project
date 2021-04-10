using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TheMobileShopCodeFirstFromDB
{
    public static class SeedDatabaseExtension
    {
        /// <summary>
        /// extension method of TheMobileShopEntities to 
        /// delete the DB, then create it and seed all tables with initial data
        /// </summary>
        public static void SeedDatabase(this TheMobileShopEntities context)
        {
            context.Database.Delete();
            context.Database.Create();

            context.SaveChanges();

            context.Employees.Load();
            context.Categories.Load();
            context.Inventories.Load();
            context.Transactions.Load();
            context.TransactionProducts.Load();

            //context.Database.ExecuteSqlCommand("drop view DetailedTransactions");

            //string createView = "CREATE VIEW[dbo].[DetailedTransactions] AS " +
            //    "SELECT[Transactions].*, [Inventory].* FROM[TransactionProducts] " +
            //    "inner join[Transactions] on[Transactions].TransactionId = [TransactionProducts].TransactionId " +
            //    "inner join[Inventory] on[Inventory].ProductId = [TransactionProducts].ProductId";

            //context.Database.ExecuteSqlCommand(createView);
            //context.SaveChanges();

            //seed EMPLOYEES

            List<Employee> employeesList = new List<Employee>()
            {
                new Employee {EmployeeId = 1, EmployeeCode = "ADM-001", FirstName = "Kate", LastName = "Obertas", PhoneNumber = "2362868281", Email = "kate@gmail.ca", IsAdmin = 1},
                new Employee {EmployeeId = 2, EmployeeCode = "ADM-002", FirstName =  "Indu Priya", LastName = "Addepalli", PhoneNumber = "1234567891",Email = "indupriyaaddepalli@student.douglas.ca",IsAdmin = 1},
                new Employee {EmployeeId = 3, EmployeeCode = "ADM-003", FirstName = "Naga Sudheer", LastName ="Bolla",PhoneNumber = "1234567892", Email ="sudheerbolla@student.douglas.ca", IsAdmin = 1},
                new Employee {EmployeeId = 4, EmployeeCode = "EMP-001", FirstName = "Paul", LastName = "Allen",  PhoneNumber = "7784567893", Email = "pallen@outlook.com", IsAdmin = 0 },
                new Employee {EmployeeId = 5, EmployeeCode = "EMP-002", FirstName = "Linus", LastName = "Torvalds",  PhoneNumber = "6721233467", Email = "linux@yahoo.com", IsAdmin = 0 },
            };

            //dictionary to set the Employee field in Transactions
            Dictionary<int, Employee> employees = employeesList.ToDictionary(e => e.EmployeeId, e => e);
            context.Employees.AddRange(employees.Values);
            context.SaveChanges();


            List<Category> categoriesList = new List<Category>()
            {
                new Category { CategoryId = 1, CategoryCode = "SP", CategoryName = "Smartphone"},
                new Category { CategoryId = 2, CategoryCode = "TA", CategoryName = "Tablet" },
                new Category { CategoryId = 3, CategoryCode = "AC", CategoryName = "Accessory"},
                new Category { CategoryId = 4, CategoryCode = "CP", CategoryName = "Cell Phone" }
             };

            Dictionary<int, Category> categories = categoriesList.ToDictionary(c => c.CategoryId, c => c);
            context.Categories.AddRange(categories.Values);
            context.SaveChanges();

            List<Inventory> inventoriesList = new List<Inventory>()
            {
                new Inventory {ProductId = 1, Name = "Galaxy A11 32GB", Description ="Samsung Galaxy A11 smartphone. Its 6.4\" Infinity-O display with large HD+ screen. The triple-camera setup. Its long-lasting lithium-ion battery allows you to use your phone for extended hours without needing to recharge.", Quantity = 15, Category = categories[1], Brand = "Samsung", Cost = 184.55, Price = 409.99},
                new Inventory {ProductId = 2, Name = "iPhone 12 Pro Max", Description ="5.8-inch Super Retina XDR OLED display Water and dust resistant (4 meters for up to 30 minutes, IP68) Triple-camera system with 12MP Ultra Wide, Wide, and Telephoto cameras; Night mode, Portrait mode, and 4K video up to 60fp", Quantity = 10, Category = categories[1], Brand = "Apple", Cost = 1000.00, Price = 1599.99 },
                new Inventory {ProductId = 3, Name = "Pixel 5", Description ="Dimensions 6in (H) x 2.77in (W) x 0.31in (D) Weight 5.33 ounces Operating System Android Display and User Interface: Display Size 6 Display Technology N/A Pixel Density 432 PPI", Quantity = 8, Category = categories[1], Brand = "Google", Cost = 800.00 , Price = 1399.99 },
                new Inventory {ProductId = 4, Name = "Nokia 3310 2G", Description ="Nokia 3310 2G Feature Phone Dual SIM 2.4inch Color Screen BT 1500mAh 64MB 2MP Camera FM MP3 With LED Flashlight GSM Cell Phone", Quantity = 10, Category = categories[4], Brand = "Nokia", Cost = 10.00 , Price =  25.66},
                new Inventory {ProductId = 5, Name = "Galaxy Tab A 8\" 32GB", Description ="Galaxy Tab A 8\" 32GB','Samsung Galaxy Tab A 8\" 32GB Android Tablet with Quad-Core Processor - Black", Quantity = 5, Category = categories[2], Brand = "Samsung", Cost = 80.00 , Price = 199.99 },
                new Inventory {ProductId = 6, Name = "iPad Pro (12.9-inch, Wi-Fi, 128GB)", Description ="iPad Pro (12.9-inch, Wi-Fi, 128GB)','Apple iPad Pro (12.9-inch, Wi-Fi, 128GB) - Space Grey 12.9-inch edge-to-edge Liquid Retina display with ProMotion, True Tone and P3 wide colour", Quantity = 6 , Category = categories[2], Brand = "Apple", Cost =900.00 , Price = 1299.98 },
                new Inventory {ProductId = 7, Name = "Leather Cover for Galaxy S20", Description ="Leather Cover for Galaxy S20','Give your phone an elegant look and feel with this premium European leather cover. Its refined aluminum buttons add style and a distinct sense of luxury. With a soft grip and slim design.", Quantity = 3 , Category = categories[3], Brand = "Samsung", Cost = 10.00, Price = 35.00 },
                new Inventory {ProductId = 8, Name = "5W USB Power Adapter", Description ="5W USB Power Adapter','Featuring an ultracompact design, this power adapter offers fast, efficient charging at home, in the office or on the go. It works with any Apple Watch, iPhone or iPod model.", Quantity = 30, Category = categories[3], Brand = "Apple", Cost = 5.00, Price =  23.98},
                new Inventory {ProductId = 9, Name = "TUNE 120TWS Headphones", Description ="TUNE 120TWS Headphones','Truly Wireless Headphones. They are powerful in sound thanks to a 5.8mm driver featuring JBL Pure Bass sound and colorful in design.", Quantity = 3, Category = categories[3], Brand = "JBL", Cost = 40.00 , Price =  99.98},
                new Inventory {ProductId = 10, Name = "Moto G8 Power Lite XT2055-2 64GB 4GB", Description ="Moto G8 Power Lite XT2055-2 64GB 4GB','Motorola Moto G8 Power Lite XT2055-2 64GB 4GB - Dual Sim - Brand New Unlocked - Arctic Blue", Quantity = 5, Category = categories[4], Brand = "Motorola", Cost = 100.00 , Price = 249.99 }
                new Inventory {ProductId = 11, Name = "Rain Design Mobile Stand for iPhone", Description = "Angled stand design lets you comfortably view your smartphone",Quantity = 4, Category = categories[3] , Brand = "Rain Design", Cost = 24.99, Price = 29.99 },
                new Inventory {ProductId = 12, Name = "Apple 20W USB-C Power Adapter", Description = "Pair it with iPhone 8 or later to take advantage of the fast-charging feature", Quantity = 15, Category = categories[3], Brand = "Apple", Cost = 24.99, Price = 29.99},
                new Inventory {ProductId = 13, Name = "Mobifoto Mobilite Clip 3.5 Ring Light", Description = "Clip-on ring light enhances your photos and videos with ideal levels of illumination in any ambient lighting condition", Quantity = 6, Category = categories[3], Brand="Mobifoto",Cost = 29.99, Price = 34.99 },
                new Inventory {ProductId = 14, Name = "Jabra Talk 15 Bluetooth Headset", Description = "Engineered to deliver high-quality calls over a Bluetooth connection", Quantity = 9, Category = categories[3],Brand = "Jabra",Cost = 29.99,Price = 34.99},
                new Inventory {ProductId = 15, Name = "Apple EarPods In-Ear Headphones with Lightning Connector - White", Description = "Design is defined by the geometry of the ear, making them more comfortable for more people", Quantity = 20, Category = categories[3], Brand = "Apple", Cost=29.99,Price = 34.99 },
                new Inventory {ProductId = 16, Name = "Belkin 1.83m (6 ft.) Lightning to Aux Cable - Black", Description = "3.5 mm connector is ideal for using an Apple device to listen to music through your car speakers", Quantity = 10, Category = categories[3], Brand = "Belkin",Cost = 39.99,Price = 45.99 },
                new Inventory {ProductId = 17, Name = "Samsung Galaxy Tab S6 Lite 10.4 128GB Android Tablet", Description = "Android OS with One UI 2 offers fast boot times, efficient power management, and much more", Quantity = 4, Category = categories[2], Brand = "Samsung",Cost = 429.99, Price = 489.99},
                new Inventory {ProductId = 18, Name = "Lenovo Tab M8 8 16GB Android 9 Tablet", Description = "8 touchscreen with 1280x800 native resolution and 83% panel-to-body ratio displays your movies and games in crisp, bright visuals", Quantity = 5, Category = categories[2], Brand = "Lenovo", Cost = 109.99, Price = 149.99},
                new Inventory {ProductId = 19, Name = "Apple iPad 10.2 128GB with Wi-Fi (8th Generation)", Description = "2160 x 1620 resolution at 264 pixels per inch (ppi) and 500 nits brightness", Quantity = 6, Category = categories[2], Brand = "Apple",Cost = 549.99,Price=599.99},
                new Inventory {ProductId = 20, Name = "Mophie Power Boost XXL 20800 mAh Power Bank", Description = "Massive battery capacity of 20,800 mAh provides up to 77 hours of extra runtime for your devices like smartphones and tablets", Quantity = 24,Category = categories[3], Brand = "Mophie",Cost = 39.99, Price = 44.99},
                new Inventory {ProductId = 21, Name = "LG Velvet 128GB", Description = "Large 6.8 edge-to-edge OLED screen is designed for entertainment, giving you a full cinematic picture for all your shows and movies", Quantity = 12, Category = categories[4], Brand = "LG",Cost = 129.99,Price = 169.99},
                new Inventory {ProductId = 22, Name = "Samsung Galaxy Xcover 4.5 16GB", Description = "LTE cat 4, GPS/GLONASS, Wi-Fi a/b/g/n (2.4+5GHz), Bluetooth 4.2 , NFC connectivity",Quantity=3,Category=categories[4],Brand="Samsung",Cost=199.99,Price=239.99},
                new Inventory {ProductId = 23, Name = "Google Pixel 2XL Phone 64GB", Description = "Pixel 2 XL features a smart camera that takes beautiful photos even in low light, a fast-charging battery and the Google Assistant built-in", Quantity = 5, Category = categories[4], Brand = "Google", Cost = 293.49, Price = 333.99},
                new Inventory {ProductId = 24, Name = "Google Pixel 4a 128GB", Description = "OLED display with 443ppi presents everything in vibrant, detailed hues", Quantity = 6, Category = categories[1],Brand = "Google", Cost = 479.99, Price = 512.99 },
                new Inventory {ProductId = 25, Name = "Samsung Galaxy S21 5G 128GB", Description = "Adaptive 120Hz display makes scrolling fast and silky-smooth, and helps conserve battery life", Quantity = 4, Category = categories[1], Brand = "Samsung",Cost = 1029.99,Price = 1199.99}
            };

            Dictionary<int, Inventory> inventories = inventoriesList.ToDictionary(i => i.ProductId, i => i);
            context.Inventories.AddRange(inventories.Values);
            context.SaveChanges();

            DateTime date = new DateTime(2021, 4, 3, 13, 40, 0);

            List<Transaction> transactionsList = new List<Transaction>()
            {
                new Transaction {TransactionId = 1, Date = date, PaymentMethod = "Cash", TotalCost = 2300.00, TaxAmount = 480.12, TotalDiscount = 20.00, TotalPrice = 4000.50, Employee = employees[1]},
                new Transaction {TransactionId = 2, Date = date, PaymentMethod = "Cash", TotalCost = 149.99, TaxAmount = 39.99, TotalDiscount = 4.99, TotalPrice = 189.99, Employee = employees[2]},
                new Transaction {TransactionId = 3, Date = date, PaymentMethod = "Cash", TotalCost = 29.99, TaxAmount = 4.99, TotalDiscount = 0.00, TotalPrice = 34.98, Employee = employees[3]},
                new Transaction {TransactionId = 4, Date = date, PaymentMethod = "Cash", TotalCost = 129.99, TaxAmount = 39.99, TotalDiscount = 9.99, TotalPrice = 169.98, Employee = employees[3]},
                new Transaction {TransactionId = 5, Date = date, PaymentMethod = "Cash", TotalCost = 24.99, TaxAmount = 5.99, TotalDiscount = 0.00, TotalPrice = 30.98, Employee = employees[2]},
                new Transaction {TransactionId = 6, Date = date, PaymentMethod = "Cash", TotalCost = 129.99, TaxAmount = 29.99, TotalDiscount = 9.99, TotalPrice = 149.99, Employee = employees[1]},
                new Transaction {TransactionId = 7, Date = date, PaymentMethod = "Cash", TotalCost = 99.99, TaxAmount = 11.99, TotalDiscount = 2.99, TotalPrice = 108.99, Employee = employees[2]},
                new Transaction {TransactionId = 8, Date = date, PaymentMethod = "Cash", TotalCost = 139.99, TaxAmount = 16.99, TotalDiscount = 0.00, TotalPrice = 156.98, Employee = employees[1]},
                new Transaction {TransactionId = 9, Date = date, PaymentMethod = "Cash", TotalCost = 199.99, TaxAmount = 23.99, TotalDiscount = 9.99, TotalPrice = 213.99, Employee = employees[2]},
                new Transaction {TransactionId = 10, Date = date, PaymentMethod = "Cash", TotalCost = 479.99, TaxAmount = 57.59, TotalDiscount = 24.99, TotalPrice = 512.59, Employee = employees[3]}
            };

            Dictionary<int, Transaction> transactions = transactionsList.ToDictionary(t => t.TransactionId, t => t);
            context.Transactions.AddRange(transactions.Values);
            context.SaveChanges();

            List<TransactionProduct> transactionProducts = new List<TransactionProduct>()
            {
                new TransactionProduct{Transaction = transactions[1], Inventory = inventories[1], Quantity = 1, Discount = 20.00},
                new TransactionProduct{Transaction = transactions[2], Inventory = inventories[2], Quantity = 2, Discount = 4.99},
                new TransactionProduct{Transaction = transactions[3], Inventory = inventories[3], Quantity = 1, Discount = 0.00},
                new TransactionProduct{Transaction = transactions[4], Inventory = inventories[3], Quantity = 1, Discount = 9.99},
                new TransactionProduct{Transaction = transactions[6], Inventory = inventories[9], Quantity = 1, Discount = 9.99},
                new TransactionProduct{Transaction = transactions[7], Inventory = inventories[12], Quantity = 2, Discount = 9.99},
                new TransactionProduct{Transaction = transactions[9], Inventory = inventories[19], Quantity = 1, Discount = 9.99},
                new TransactionProduct{Transaction = transactions[5], Inventory = inventories[14], Quantity = 1, Discount = 14.99}
            };

            context.TransactionProducts.AddRange(transactionProducts);
            context.SaveChanges();


    }
}
}
