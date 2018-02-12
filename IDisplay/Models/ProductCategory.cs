using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace IDisplay.Models
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }

        [DisplayName("Product Category")]
        [Required(ErrorMessage = "You must enter {0}")]
        public string ProductCategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}