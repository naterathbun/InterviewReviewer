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
            Console.WriteLine("C# Interview Reviewer");
            Console.WriteLine("---------------------\n");
            Console.WriteLine("Choose a Challenge:\n");

            var choice = int.Parse(Console.ReadLine());

            // check choice is valid
            // non null
            // is an int
            // is <= Challenges.Count







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
