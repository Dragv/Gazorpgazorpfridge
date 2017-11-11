using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace Gazorpgazorpfridge.Models
{
    public class ExistModel : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var fr_model = db.Modelos.Where(u => u.codigo == (string)value).FirstOrDefault();

            if (fr_model == null)
            {
                return new ValidationResult("The inserted code does not exist");
            } else
            {
                return ValidationResult.Success;
            }
            //return base.IsValid(value, validationContext);
        }
    }
}