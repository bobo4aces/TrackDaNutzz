using System;
using System.Collections.Generic;
using System.Text;
using TrackDaNutzz.Data;

namespace TrackDaNutzz.Services.Hands
{
    public class HandsService : IHandsService
    {
        private readonly TrackDaNutzzDbContext context;

        public HandsService(TrackDaNutzzDbContext context)
        {
            this.context = context;
        }

    }
}
