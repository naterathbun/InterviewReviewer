using InterviewReviewer.Challenge_Classes;
using InterviewReviewer.Interfaces;

namespace InterviewReviewer
{
    internal class ReviewerConsole
    {
        public List<IChallenge> Challenges { get; set; }

        public ReviewerConsole()
        {
            Challenges = new List<IChallenge>()
            {
                new PrimeNumberChecker(),
                new StringPalindromeChecker(),
                new StringReverser(),
                new StringSubstringFinder()
            };
        }

        public void DisplayChallenges()
        {
            while (true) 
            {
                Console.Clear();
                Console.WriteLine("C# Interview Reviewer");
                Console.WriteLine("---------------------\n");
                Console.WriteLine("Choose a Challenge Number:\n");

                for (int i = 1; i <= Challenges.Count(); i++)
                {
                    Console.WriteLine(i + ": " + Challenges[i - 1].GetName());
                }

                Console.WriteLine("\n");
                var choice = Console.ReadLine();

                if (int.TryParse(choice, out int choiceNumber) && choiceNumber > 0 && choiceNumber <= Challenges.Count())
                {
                    Console.WriteLine("Opening Challenge {0}...", choiceNumber);
                    Console.ReadLine();
                }
            }
        }

        public void ListChallenges()
        {
            var challengeNumber = 1;

            foreach (IChallenge challenge in Challenges)
            {
                Console.WriteLine(challengeNumber.ToString() + ": " + challenge.GetName());
                challengeNumber++;
            }
        }
    }
}
