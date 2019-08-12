using System.ComponentModel.DataAnnotations;

namespace TrackDaNutzz.ViewModels
{
    public class ImportSuccessViewModel
    {
        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "Total Files")]
        public int FilesCount { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "Total Hands")]
        public int HandsCount { get; set; }
    }
}
