using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrackDaNutzz.ValidationAttributes;
using System.Linq;
using System.Threading.Tasks;

namespace TrackDaNutzz.BindingModels
{
    public class HandHistoryImportBindingModel
    {
        [Required(ErrorMessage = "Select at least one .txt file")]
        [DataType(DataType.Upload, ErrorMessage = "It must be a file")]
        [FileExtension("Invalid file format",".txt")]
        public IFormFile File { get; set; }
    }
}
