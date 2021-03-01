using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using MeetingParser.Entities;
using MeetingParser.Interfaces;

namespace MeetingParser.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IPrinter _printer;
        private List<Happening> _happenings;
        
        public EmailSender( IPrinter printer)
        {
            _printer = printer;
        }

        public bool Send(List<Happening> happenings)
        {
            _happenings = happenings;

            try
            {
                using (var message = new MailMessage())
                {
                    InicializeMessageConfig(message);

                    using (var client = new SmtpClient())
                    {
                        InicializeClientConfig(client);
                        client.Send(message);
                    }
                }
            }
            catch(SmtpException ex)
            {
                _printer.PrintException(ex);

                return false;
            }
            return true;
        }
        
        private void InicializeMessageConfig(MailMessage message)
        {
            message.To.Add(new MailAddress("the recipient's address"));
            message.From = new MailAddress("the sender's address");
            message.Subject = "Test";
            message.Body = GenerateContents();
        }
        
        private void InicializeClientConfig(SmtpClient client)
        {
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.Credentials = new NetworkCredential("the sender's address", "password");
            client.EnableSsl = true;
        }

        private string GenerateContents()
        {
            var mailContent = new StringBuilder();

            for (int i = 0; i < 5; i++)
            {
                mailContent.AppendLine(_happenings[i].Title);
                mailContent.AppendLine(_happenings[i].Type);
                mailContent.AppendLine(_happenings[i].IsPaid);
                mailContent.AppendLine(_happenings[i].Place);
                mailContent.AppendLine(_happenings[i].Date.ToString() + "\n");
            }

            return mailContent.ToString();
        }
    }
}
