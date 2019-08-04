using TrackDaNutzz.Services.Dtos.Hands;

namespace TrackDaNutzz.Services.Clients
{
    public interface IClientsService
    {
        int AddClient(HandInfoDto handInfoDto);
        string GetClientNameById(int clientId);
    }
}
