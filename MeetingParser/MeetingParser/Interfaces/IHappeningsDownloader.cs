using System.Collections.Generic;
using MeetingParser.Entities;

namespace MeetingParser.Interfaces
{
    public interface IHappeningsDownloader
    {
        void ConstructURL(string city, string target);
        List<Happening> GetFromWeb();
    }
}
