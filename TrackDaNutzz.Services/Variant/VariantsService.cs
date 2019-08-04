using System;
using System.Linq;
using TrackDaNutzz.Data;
using TrackDaNutzz.Services.Dtos.Hands;
using TrackDaNutzz.Services.Dtos.Variants;

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

        public VariantDto GetVariantById(int variantId)
        {
            //TODO: Use Automapper
            Data.Models.Variant variant = this.context.Variants.SingleOrDefault(v => v.Id == variantId);
            if (variant == null)
            {
                throw new ArgumentException($"Invalid variant id - {variantId}");
            }
            VariantDto variantDto = new VariantDto()
            {
                Id = variant.Id,
                Limit = variant.Limit,
                Name = variant.Name
            };
            return variantDto;
        }
    }
}
