using System.Collections.Generic;
using MeetingParser.Entities;

namespace MeetingParser.Interfaces
{
    public interface IEmailSender
    {
        bool Send(List<Happening> happenings);
    }
}
