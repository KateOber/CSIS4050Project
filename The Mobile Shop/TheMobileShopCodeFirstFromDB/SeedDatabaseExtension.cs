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
            };

            Dictionary<int, Inventory> inventories = inventoriesList.ToDictionary(i => i.ProductId, i => i);
            context.Inventories.AddRange(inventories.Values);
            context.SaveChanges();

            DateTime date = new DateTime(2021, 4, 3, 13, 40, 0);

            List<Transaction> transactionsList = new List<Transaction>()
            {
                new Transaction {TransactionId = 1, Date = date, PaymentMethod = "Cash", TotalCost = 2300.00, TaxAmount = 480.12, TotalDiscount = 20.00, TotalPrice = 4000.50, Employee = employees[1]},
            };

            Dictionary<int, Transaction> transactions = transactionsList.ToDictionary(t => t.TransactionId, t => t);
            context.Transactions.AddRange(transactions.Values);
            context.SaveChanges();

            List<TransactionProduct> transactionProducts = new List<TransactionProduct>()
            {
                new TransactionProduct{Transaction = transactions[1], Inventory = inventories[1], Quantity = 1, Discount = 0},
                new TransactionProduct{Transaction = transactions[1], Inventory = inventories[2], Quantity = 2, Discount = 20.0},
                new TransactionProduct{Transaction = transactions[1], Inventory = inventories[3], Quantity = 1, Discount = 0}
            };

            context.TransactionProducts.AddRange(transactionProducts);
            context.SaveChanges();


    }
}
}
