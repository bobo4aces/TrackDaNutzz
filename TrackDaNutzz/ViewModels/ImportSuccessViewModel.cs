using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrackDaNutzz.ViewModels
{
    public class ImportSuccessViewModel
    {
        [Required]
        [Range(0,int.MaxValue)]
        [Display(Name = "Total Files")]
        public int FilesCount { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "Total Hands")]
        public int HandsCount { get; set; }
    }
}
