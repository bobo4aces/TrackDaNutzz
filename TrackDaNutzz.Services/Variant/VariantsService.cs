using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Data;
using TrackDaNutzz.Services.Dtos.Hands;

namespace TrackDaNutzz.Services.Variant
{
    public class VariantsService : IVariantsService
    {
        private readonly TrackDaNutzzDbContext context;

        public VariantsService(TrackDaNutzzDbContext context)
        {
            this.context = context;
        }
        public int AddVariant(HandInfoDto handInfoDto)
        {
            Data.Models.Variant variant = this.context.Variants.SingleOrDefault(v => v.Name == handInfoDto.VariantName && v.Limit == handInfoDto.Limit);
            if (variant != null)
            {
                return variant.Id;
            }
            variant = new Data.Models.Variant()
            {
                Limit = handInfoDto.Limit,
                Name = handInfoDto.VariantName
            };
            this.context.Variants.Add(variant);
            this.context.SaveChanges();
            return variant.Id;
        }
    }
}
