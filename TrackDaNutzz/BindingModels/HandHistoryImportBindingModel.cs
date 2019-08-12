using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using TrackDaNutzz.ValidationAttributes;

namespace TrackDaNutzz.BindingModels
{
    public class HandHistoryImportBindingModel
    {
        [Required(ErrorMessage = "Select at least one .txt file")]
        [DataType(DataType.Upload, ErrorMessage = "It must be a file")]
        [FileExtension("Invalid file format", ".txt")]
        public IFormFile File { get; set; }
    }
}
