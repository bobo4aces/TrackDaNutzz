﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackDaNutzz.ViewModels
{
    public class HandViewModel
    {
        public long Id { get; set; }
        public long Number { get; set; }
        public DateTime Time { get; set; }
        public string TimeZone { get; set; }
        public DateTime LocalTime { get; set; }
        public string LocalTimeZone { get; set; }
        public int Button { get; set; }

        public decimal Pot { get; set; }

        public decimal Rake { get; set; }

        public int TableId { get; set; }

        public long? BoardId { get; set; }
    }
}
