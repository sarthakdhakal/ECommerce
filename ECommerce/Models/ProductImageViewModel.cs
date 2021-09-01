using System;
using System.Collections.Generic;

namespace ECommerce.Models
{
    public class ProductImageViewModel
    {
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public Nullable<int> ProductId { get; set; }
    
        public virtual Product Product { get; set; }
    }
}