using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace MvcProjectAli.ViewModels
{
    public class ChefVB
    {
        public int ChefID { get; set; }

        [Display(Name = "Chef's Name")]
        [Required(ErrorMessage = "Please input your name here!!!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 char")]
        public string ChefName { get; set; }

        [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "Please input your phone number here!!!")]
        public string CellPhone { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please input your E-mail address here!!!")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Display(Name = "Contact Address")]
        [Required(ErrorMessage = "Please input your address here!!!")]
        [DataType(DataType.MultilineText)]
        public string ContactAddress { get; set; }
    }
}