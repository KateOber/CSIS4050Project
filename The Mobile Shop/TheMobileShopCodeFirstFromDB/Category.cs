namespace TheMobileShopCodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    /// <summary>
    /// Corresponds to the Category table in the database
    /// </summary>
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int CategoryId { get; set; } //Auto generated ID

        [Required]
        [StringLength(10)]
        public string CategoryCode { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //list of categories for the inventory
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
