using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackDaNutzz.ViewModels.Players
{
    public class ActivePlayerViewModel
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
    }
}
