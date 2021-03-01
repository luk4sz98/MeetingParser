using System;
using MeetingParser.Interfaces;
using MeetingParser.Enums;

namespace MeetingParser.Services
{
    public class UserInputService : IUserInputService
    {
        public Cities GetCityChoice()
        {
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out var userChoice);
            return (Cities)userChoice;
        }

        public TypesOfEvent GetTypeChoice()
        { 
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out var userChoice);
            return (TypesOfEvent)userChoice;
        }
    }
}
