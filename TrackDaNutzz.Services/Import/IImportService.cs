using System;
using System.Collections.Generic;
using System.Text;
using TrackDaNutzz.Services.Dtos.Hands;
using TrackDaNutzz.Services.Dtos.Import;

namespace TrackDaNutzz.Services.Import
{
    public interface IImportService
    {
        void Add(ImportHandDto handDto);
    }
}
