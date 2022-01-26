using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MeroBolee.Attribute
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class DateLessThanAttribute : ValidationAttribute
    {

        private string DateToCompareFieldName { get; set; }

        public DateLessThanAttribute(string dateToCompareFieldName)
        {
            DateToCompareFieldName = dateToCompareFieldName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime currentDate = (DateTime)value;
            DateTime futureDate = (DateTime)validationContext.ObjectType
                                    .GetProperty(DateToCompareFieldName)
                                    .GetValue(validationContext.ObjectInstance, null);

            PropertyInfo propertyInfo = validationContext.ObjectType.GetProperty(validationContext.MemberName);

            if (currentDate < futureDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"{propertyInfo.Name} should be earlier than {DateToCompareFieldName}");
            }
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class DateGreaterThanAttribute : ValidationAttribute
    {

        private string DateToCompareFieldName { get; set; }

        public DateGreaterThanAttribute(string dateToCompareFieldName)
        {
            DateToCompareFieldName = dateToCompareFieldName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime currentDate = (DateTime)value;
            DateTime pastDate = (DateTime)validationContext.ObjectType
                                    .GetProperty(DateToCompareFieldName)
                                    .GetValue(validationContext.ObjectInstance, null);
            PropertyInfo propertyInfo = validationContext.ObjectType.GetProperty(validationContext.MemberName);

            if (currentDate > pastDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"{propertyInfo.Name} should be later than {DateToCompareFieldName}");
            }
        }
    }


    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ShouldBeFutureDateAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime currentDate = (DateTime)value;
            PropertyInfo propertyInfo = validationContext.ObjectType.GetProperty(validationContext.MemberName);
            
            if (currentDate > DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"{propertyInfo.Name} should be a future date");
            }
        }
    }


}
