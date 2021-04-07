using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TheMobileShopCodeFirstFromDB
{
    public partial class TheMobileShopEntities : DbContext
    {
        public TheMobileShopEntities()
            : base("name=TheMobileShopConnection")
        {
        }

        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<TransactionProduct> TransactionProducts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Inventories)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);
        }
    }
}
