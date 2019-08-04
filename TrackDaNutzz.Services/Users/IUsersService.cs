namespace TrackDaNutzz.Services.Users
{
    public interface IUsersService
    {
        string GetCurrentlyLoggedUsername();
        string GetCurrentlyLoggedUserId(string username);
    }
}
