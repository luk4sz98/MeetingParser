using MeetingParser.Enums;

namespace MeetingParser.Interfaces
{
    public interface IUserInputService
    {
        Cities GetCityChoice();
        TypesOfEvent GetTypeChoice();
    }
}
