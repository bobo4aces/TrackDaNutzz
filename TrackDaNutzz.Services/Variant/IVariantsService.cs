using System;
using System.Collections.Generic;
using System.Text;
using TrackDaNutzz.Services.Dtos.Hands;

namespace TrackDaNutzz.Services.Variant
{
    public interface IVariantsService
    {
        int AddVariant(HandInfoDto handInfoDto);
    }
}
