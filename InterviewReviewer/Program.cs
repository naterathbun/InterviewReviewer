using InterviewReviewer;
using InterviewReviewer.Challenge_Classes;
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
            var challengeProvider = serviceProvider.GetRequiredService<ChallengeProvider>();
            var challengesList = challengeProvider.GetChallenges();
                        
            var reviewerConsole = new ReviewerConsole(challengesList);
            reviewerConsole.DisplayChallenges();
        }

        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                // List all Challenges here to add to main menu
                services.AddTransient<IChallenge, StringPalindromeChecker>();
                services.AddTransient<IChallenge, PrimeNumberChecker>();
                services.AddTransient<IChallenge, StringReverser>();
                services.AddTransient<IChallenge, StringSubstringFinder>();

                services.AddScoped<ChallengeProvider>();
            });

    public class ChallengeProvider
    {
        private readonly IEnumerable<IChallenge> _challenges;

        public ChallengeProvider(IEnumerable<IChallenge> challenges)
        {
            _challenges = challenges;
        }

        public List<IChallenge> GetChallenges()
        {
            return _challenges.ToList();
        }
    }
}