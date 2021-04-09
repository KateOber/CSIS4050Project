namespace TheMobileShopCodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    /// <summary>
    /// This class holds the inventory details of the products can be accessed by both regular employee and admin 
    /// </summary>
    [Table("Inventory")]
    public partial class Inventory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory()
        {
            TransactionProducts = new HashSet<TransactionProduct>();
        }
        
        //unique ID generated for every single product in the inventory list
        [Key]
        public int ProductId { get; set; }
        
        /// <summary>
        /// General product details and quantity information of the product.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int Quantity { get; set; }
        
        //Every product has a category retrieving the categoryID as a foreign key from the category table
        public int CategoryId { get; set; }

        [StringLength(50)]
        public string Brand { get; set; }
        
        //Cost holds the amount "The Mobile shop" gets the product for
        public double Cost { get; set; }
        
        ////Price is the amount "The Mobile Shop" is selling to the customers
        public double Price { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionProduct> TransactionProducts { get; set; } //list of productId's for the TransactionProducts table 
    }
}
