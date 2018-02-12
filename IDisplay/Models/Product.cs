using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDisplay.Models
{
    public class Product
    {
        public int ProductId  { get; set; }
 
        [DisplayName("Product Category")]
        public int ProductCategoryId { get; set; }

        [DisplayName("User")]
        public int UserId { get; set; }

        [DisplayName("Product")]
        [Required(ErrorMessage = "You must enter {0}")]
        public string ProductName { get; set; }

        [DisplayName("Product Description")]
        [Required(ErrorMessage = "You must enter {0}")]
        public string ProductDescription { get; set; }

        [DisplayName("Regular Price")]
        [Required(ErrorMessage = "You must enter {0}")]
        public double ProductPrice { get; set; }

        [DisplayName("Promotional Price")]
        [Required(ErrorMessage = "You must enter {0}")]
        public double PromotionalPrice { get; set; }

        [DisplayName("Product Image")]
        public string ImageUrl { get; set; }


        public virtual ProductCategory ProductCategory { get; set; }

        public virtual Seller Seller { get; set; }

    }
}