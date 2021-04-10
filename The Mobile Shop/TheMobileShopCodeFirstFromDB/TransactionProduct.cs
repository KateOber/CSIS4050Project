namespace TheMobileShopCodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    /// <summary>
    /// Corresponds to the TransactionProduct table conatins productID's of all the products
    /// that the transaction is being processed for and the quantity of the products so that 
    /// the purchased quantity will be deducted from the inventory so it will be easy for the 
    /// employees to find the product availability information depending on quantity
    /// </summary>
    public partial class TransactionProduct
    {
        //TransactionId from the Transaction table
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransactionId { get; set; }
        
        //ProductId from the inventory table
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double? Discount { get; set; }

        public virtual Inventory Inventory { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
