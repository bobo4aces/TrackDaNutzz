using TrackDaNutzz.Services.Dtos.Users;

namespace TrackDaNutzz.Services.Users
{
    public interface IUsersService
    {
        //string Add(UserDto user);
        //string Remove(string id);
        string GetCurrentlyLoggedUsername();
        string GetCurrentlyLoggedUserId(string username);
    }
}
