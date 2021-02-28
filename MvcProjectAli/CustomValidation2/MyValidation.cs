using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProjectAli.CustomValidation2
{
    public class MyValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string message = value.ToString();
                if (message.Contains("AC"))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Must be field AC or Non AC");
        }
    }
}