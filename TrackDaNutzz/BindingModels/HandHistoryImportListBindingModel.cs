using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackDaNutzz.BindingModels
{
    public class HandHistoryImportListBindingModel
    {
        public IList<HandHistoryImportBindingModel> Files { get; set; }
    }
}
