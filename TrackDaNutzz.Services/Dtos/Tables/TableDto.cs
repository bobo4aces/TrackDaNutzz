using System;
using System.Collections.Generic;
using System.Text;

namespace TrackDaNutzz.Services.Dtos.Tables
{
    public class TableDto
    {
        public string TableName { get; set; }
        public string TableSize { get; set; }
        public bool PlayMoney { get; set; }
        public int ButtonSeat { get; set; }
    }
}
