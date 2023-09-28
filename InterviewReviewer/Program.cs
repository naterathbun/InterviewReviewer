using InterviewReviewer;
using InterviewReviewer.Modules;
using InterviewReviewer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;                        
            var moduleProvider = serviceProvider.GetRequiredService<ModuleProvider>();
            var modulesList = moduleProvider.GetModules();
                        
            var reviewerConsole = new ReviewerConsole(modulesList);
            reviewerConsole.DisplayMenu();
        }

        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                // Register a new module in the container here to add it to the program.
                services.AddTransient<IModule, StringReverser>();
                services.AddTransient<IModule, StringPalindromeChecker>();
                services.AddTransient<IModule, PrimeNumberChecker>();                
                services.AddTransient<IModule, WeatherForecaster>();
                services.AddTransient<IModule, JournalWriter>();
                services.AddTransient<IModule, EmailSender>();

                services.AddScoped<ModuleProvider>();
            });

    public class ModuleProvider
    {
        private readonly IEnumerable<IModule> _modules;

        public ModuleProvider(IEnumerable<IModule> modules)
        {
            _modules = modules;
        }

        public List<IModule> GetModules()
        {
            return _modules.ToList();
        }
    }
}