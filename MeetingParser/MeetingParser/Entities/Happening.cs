using System;

namespace MeetingParser.Entities
{
    public class Happening
    {
        public string Title { get; set; }
        public string Place { get; set; }
        public string Type { get; set; }
        public string IsPaid { get; set; }
        public DateTime Date { get; set; } 

        public Happening(string title, string place, string type,string isPaid, DateTime date)
        {
            Title = title;
            Place = place;
            Type = type;
            IsPaid = isPaid;
            Date = date;
        }
    }
}
