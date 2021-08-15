using Hastprogrammet.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hastprogrammet.CustomAttributes
{
    public class ValidateAuthorIdExistInDb:ValidationAttribute
    {
        public new string ErrorMessage { get; set; } = "Invalid horse. Use the search function to find your horse.";
        private HorseContext Context { get; set; } = new HorseContext();        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {            
            int id = (int)value;
            
            var authorExists = Context.Horses.Any(a => a.Id == id);
            if (!authorExists)
            {                
                return new ValidationResult(ErrorMessage);
                //return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }
            return null;
        }
    }
}
