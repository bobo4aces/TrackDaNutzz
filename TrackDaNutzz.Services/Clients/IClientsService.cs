using System;
using System.Collections.Generic;
using System.Text;
using TrackDaNutzz.Services.Dtos.Hands;

namespace TrackDaNutzz.Services.Clients
{
    public interface IClientsService
    {
        int AddClient(HandInfoDto handInfoDto);
    }
}
