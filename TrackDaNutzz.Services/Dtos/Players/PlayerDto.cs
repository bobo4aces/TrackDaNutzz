using System;
using System.Collections.Generic;
using System.Text;

namespace TrackDaNutzz.Services.Dtos.Players
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
    }
}
