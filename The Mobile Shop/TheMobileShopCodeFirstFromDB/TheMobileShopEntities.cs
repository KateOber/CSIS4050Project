using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TheMobileShopCodeFirstFromDB
{
     /// <summary>
    /// This is an entity class to hold all the Dbsets for each of the database tables 
    /// </summary>
    public partial class TheMobileShopEntities : DbContext
    {
        public TheMobileShopEntities()
            : base("name=TheMobileShopConnection")
        {
        }
         //Dbset corresponding to each table of the database
        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<TransactionProduct> TransactionProducts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        
        /// <summary>
        /// This method defines the model for each of the context 
        /// </summary>
        /// <param name="modelBuilder">It is used to map each of the DAL class to the databse schema</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Inventories)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);
        }
    }
}
