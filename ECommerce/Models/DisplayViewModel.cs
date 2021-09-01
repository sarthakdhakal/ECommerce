using System;
using System.Collections.Generic;

namespace ECommerce.Models
{
    public class DisplayViewModel
    {
               public int ProductId { get; set; }
                public string ProductName { get; set; }
                public Nullable<int> ProductPrice { get; set; }
                public Nullable<int> ProductQuantity { get; set; }
                public int ImageId { get; set; }
                public string ImagePath { get; set; }

                public List<DisplayViewModel> DisplayViewModelsList { get; set; }
                public List<DisplayViewModel> ImageViewModelsList { get; set; }
    }
}