using System;

namespace MeetingParser.Interfaces
{
    public interface IPrinter
    {
        void PrintCityChoice();
        void PrintTypeChoice();
        void PrintException(Exception ex);
        void PrintDeliverySuccess();
        void PrintDeliveryFailure();
        void PrintInvalidInputMessage();
    }
}
