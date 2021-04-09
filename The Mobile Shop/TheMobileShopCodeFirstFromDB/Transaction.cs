namespace TheMobileShopCodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    /// <summary>
    /// Corresponds to the Transaction table
    /// </summary>
    public partial class Transaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transaction()
        {
            TransactionProducts = new HashSet<TransactionProduct>();
        }
        
        //unique Id auto-genertaed for the transaction table
        public int TransactionId { get; set; }
        
        /// <summary>
        /// Transaction details with date, payment, cost information
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [StringLength(20)]
        public string PaymentMethod { get; set; }

        public double TotalCost { get; set; }

        public double TaxAmount { get; set; }

        public double? TotalDiscount { get; set; }

        public double TotalPrice { get; set; }
        
        //Employee Id from the employee table to track the information of the sales by employee by their employee id
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionProduct> TransactionProducts { get; set; }
    }
}
