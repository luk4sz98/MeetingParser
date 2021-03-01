using Microsoft.Extensions.DependencyInjection;
using MeetingParser.Interfaces;
using MeetingParser.Services;


namespace MeetingParser
{
    class Program
    {
        public static void Main()
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<ConsoleApp>().Run();
        }
        
        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IHappeningsDownloader, HappeningsDownloader>();
            services.AddTransient<IPrinter, Printer>();
            services.AddTransient<IUserInputService, UserInputService>();
            services.AddTransient<IUIElements, UIElements>();

            services.AddTransient<ConsoleApp>(); 

            return services;
        }
    }
}

// https://crossweb.pl/wydarzenia/wroclaw-trojmiasto/it/
