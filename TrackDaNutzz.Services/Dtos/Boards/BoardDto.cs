using System;
using System.Collections.Generic;
using System.Text;

namespace TrackDaNutzz.Services.Dtos.Boards
{
    public class BoardDto
    {
        public long Id { get; set; }

        public string Flop { get; set; }

        public string Turn { get; set; }

        public string River { get; set; }
    }
}
