using System;
using System.Collections.Generic;

namespace ECommerce.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        
        public Nullable<int> ProductPrice { get; set; }
        public Nullable<int> ProductQuantity { get; set; }
        
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}