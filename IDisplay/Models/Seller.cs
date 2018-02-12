using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDisplay.Models
{
    public class Seller
    {
        public int SellerId { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        [MaxLength(200)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(5000, MinimumLength = 6, ErrorMessage = "Password must be 6 characters or more")]
        public string Password { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string Address { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        public bool Active { get; set; }

  
        public string Role { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }

}