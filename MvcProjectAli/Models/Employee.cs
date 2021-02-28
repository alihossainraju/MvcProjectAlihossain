//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcProjectAli.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;


    public partial class Employee
    {
        public int EmployeeID { get; set; }

        [Display(Name = "Tourist Name")]
        [Required(ErrorMessage = "Please input your name here!!!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 char")]
        public string Name { get; set; }

        [Display(Name = "Position Name")]
        [Required(ErrorMessage = "Please input your position name here!!!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 char")]
        public string Position { get; set; }

        [Display(Name = "Name of Office")]
        [Required(ErrorMessage = "Please input your office name here!!!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 char")]
        public string Office { get; set; }

        [Display(Name = "Payment Amount")]
        [Required(ErrorMessage = "Please input your salary amount here!!!")]
        [Range(99,35000, ErrorMessage = "Amount must be 99 to 35000 tk.")]
        public int Salary { get; set; }

        [Display(Name = "Upload Image")]
        public string ImagePath { get; set; }

        
        public HttpPostedFileBase ImageUpload { get; set; }

        public Employee()
        {
            ImagePath = "~/AppFiles/Images/default.png";
        }

        [Required(ErrorMessage = "Please input your password here")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(\S)+", ErrorMessage = "Whitespace not Allowed in Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Input same password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Please input same password here!!")]
        public string ConfirmPassword { get; set; }

    }
}
