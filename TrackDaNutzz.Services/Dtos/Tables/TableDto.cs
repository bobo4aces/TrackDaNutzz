using TrackDaNutzz.Services.Dtos.Stakes;
using TrackDaNutzz.Services.Dtos.Variants;

namespace TrackDaNutzz.Services.Dtos.Tables
{
    public class TableDto
    {
        public int Id { get; set; }

        public string TableName { get; set; }

        public string ClientName { get; set; }

        public int Size { get; set; }

        public int VariantId { get; set; }
        public VariantDto Variant { get; set; }

        public int StakeId { get; set; }

        public StakeDto Stake { get; set; }
    }
}
