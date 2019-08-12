using System;
using System.ComponentModel.DataAnnotations;

namespace TrackDaNutzz.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class YearValidationAttribute : ValidationAttribute
    {
        public int MininumAge { get; set; }
        public int MaximumAge { get; set; }
        public string ErrorMessageExtension { get; set; }

        public YearValidationAttribute(int mininumAge, int maximumAge, string errorMessage)
        {
            MininumAge = mininumAge;
            MaximumAge = maximumAge;
            ErrorMessageExtension = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = (DateTime)value;
            DateTime currentDate = DateTime.Today;
            if (value != null)
            {
                DateTime minAge = date.AddYears(this.MininumAge);
                DateTime maxAge = date.AddYears(this.MaximumAge);
                if (minAge.CompareTo(currentDate) == 1 || currentDate.CompareTo(maxAge) == 1)
                {
                    return new ValidationResult(this.ErrorMessageExtension);
                }
            }
            return ValidationResult.Success;
        }
    }
}
