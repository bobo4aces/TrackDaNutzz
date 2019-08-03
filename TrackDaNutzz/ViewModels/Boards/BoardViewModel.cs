using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrackDaNutzz.ViewModels.Boards
{
    public class BoardViewModel
    {
        [Display(Name = "Id")]
        public long Id { get; set; }
        [Display(Name = "Flop")]
        public string Flop { get; set; }
        [Display(Name = "Turn")]
        public string Turn { get; set; }
        [Display(Name = "River")]
        public string River { get; set; }
    }
}
