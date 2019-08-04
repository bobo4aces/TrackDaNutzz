using TrackDaNutzz.Services.Dtos.Stakes;

namespace TrackDaNutzz.Services.Dtos.Tables
{
    public class TableByHandIdDto
    {
        public int TableId { get; set; }
        public StakeDto Stake { get; set; }
    }
}
