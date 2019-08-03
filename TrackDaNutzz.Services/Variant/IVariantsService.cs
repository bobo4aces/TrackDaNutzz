using System;
using System.Collections.Generic;
using System.Text;
using TrackDaNutzz.Services.Dtos.Hands;
using TrackDaNutzz.Services.Dtos.Variants;

namespace TrackDaNutzz.Services.Variant
{
    public interface IVariantsService
    {
        int AddVariant(HandInfoDto handInfoDto);
        VariantDto GetVariantById(int variantId);
    }
}
