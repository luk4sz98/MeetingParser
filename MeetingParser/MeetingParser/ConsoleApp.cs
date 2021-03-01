using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;
using MeetingParser.Services;
using MeetingParser.Interfaces;

namespace MeetingParser
{
    public class ConsoleApp
    {
        private readonly IEmailSender _emailSender;
        private readonly IPrinter _printer;
        private readonly IUIElements _UIElements;
        private readonly IHappeningsDownloader _happeningsDownloader;

        public ConsoleApp(IEmailSender emailSender, IPrinter printer, IUIElements UIElements, IHappeningsDownloader happeningsDownloader)
        {
            _emailSender = emailSender;
            _printer = printer;
            _UIElements = UIElements;
            _happeningsDownloader = happeningsDownloader;
        }

        public void Run()
        {
            _happeningsDownloader.ConstructURL(_UIElements.GetCity(), _UIElements.GetTarget());

            if (_emailSender.Send(_happeningsDownloader.GetFromWeb()))
            {
                _printer.PrintDeliverySuccess();
            }
            else
            {
               _printer.PrintDeliveryFailure();
            }
        }
    }
}
