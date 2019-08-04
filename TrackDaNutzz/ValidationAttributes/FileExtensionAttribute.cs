using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrackDaNutzz.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FileExtensionAttribute : ValidationAttribute
    {
        public string ErrorMessageExtension { get; set; }
        public string[] FileExtensions { get; set; }
        public FileExtensionAttribute(string errorMessage, params string[] fileExtensions)
        {
            this.ErrorMessageExtension = errorMessage;
            this.FileExtensions = fileExtensions;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IFormFile file = (IFormFile)value;
            if (value != null)
            {
                if (this.FileExtensions.Any(e => file.FileName.EndsWith(e)))
                {
                    return new ValidationResult(this.ErrorMessageExtension);
                }
            }
            return ValidationResult.Success;
        }
    }
}
