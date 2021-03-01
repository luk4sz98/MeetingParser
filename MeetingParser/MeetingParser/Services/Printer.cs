using System;
using MeetingParser.Interfaces;

namespace MeetingParser.Services
{
    public class Printer : IPrinter
    {
        public void PrintCityChoice()
        {
            Console.Clear();
            Console.WriteLine("Wybierz miasto, z którego mają zostać pobrane wydarzenia:\n");
            Console.WriteLine("1. Kraków");
            Console.WriteLine("2. Warszawa");
            Console.WriteLine("3. Wrocław");
            Console.WriteLine("4. Trójmiasto");
            Console.WriteLine("5. Poznań");
            Console.WriteLine("6. Katowice\n");
            Console.WriteLine("Twój wybór: ");
        }

        public void PrintTypeChoice()
        {
            Console.Clear();
            Console.WriteLine("Wybierz rodzaj wydarzenia, które Cię interesuje:\n");
            Console.WriteLine("1. IT");
            Console.WriteLine("2. Startup");
            Console.WriteLine("3. E-marketing");
            Console.WriteLine("4. UX\n");
            Console.WriteLine("Twój wybór: ");
        }

        public void PrintException(Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }

        public void PrintDeliverySuccess()
        {
            Console.Clear();
            Console.WriteLine("\nWiadomość dostarczona!");
        }

        public void PrintDeliveryFailure()
        {
            Console.WriteLine("\nNie udało się dostarczyć wiadomości!");
        }

        public void PrintInvalidInputMessage()
        {
            Console.Write("\nWprowadzono niepoprawne dane! Wciśnij dowolny przycisk aby kontynuować. . .");
            Console.ReadKey();
        }
    }
}
