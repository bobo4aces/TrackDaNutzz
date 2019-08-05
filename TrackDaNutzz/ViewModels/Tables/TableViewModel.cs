using System.ComponentModel.DataAnnotations;

namespace TrackDaNutzz.ViewModels.Tables
{
    public class TableViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Table Name")]
        public string TableName { get; set; }
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Display(Name = "Size")]
        public int Size { get; set; }
        [Display(Name = "Variant Name")]
        public string VariantName { get; set; }
        [Display(Name = "Variant Limit")]
        public string VariantLimit { get; set; }
        [Display(Name = "Currency")]
        public string Currency { get; set; }
        [Display(Name = "Currency Symbol")]
        public char CurrencySymbol { get; set; }
        [Display(Name = "Small Blind")]
        public decimal SmallBlind { get; set; }
        [Display(Name = "Big Blind")]
        public decimal BigBlind { get; set; }
    }
}
