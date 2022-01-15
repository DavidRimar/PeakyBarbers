using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakyBarbers.BLL.CustomValidators
{

    // Date greater than DateTime Now
    public class DateGreaterThanNow : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateTime = Convert.ToDateTime(value);

            return (DateTime.Compare(dateTime, DateTime.Now) >= 0)
                ? ValidationResult.Success
                : new ValidationResult("You can only select a day in the future.");
        }
    }

}
