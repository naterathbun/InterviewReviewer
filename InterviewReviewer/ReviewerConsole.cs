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
                new StringPalindromeChecker(),
                new StringReverser(),
                new StringSubstringFinder(),
                new PrimeNumberChecker(),
            };
        }

        public void DisplayChallenges()
        {
            while (true) 
            {
                ListChallenges();                

                var choice = Console.ReadLine();

                if (int.TryParse(choice, out int choiceNumber) && choiceNumber > 0 && choiceNumber <= Challenges.Count())
                {
                    var challenge = Challenges[choiceNumber - 1];

                    Console.WriteLine("{0}: {1}", challenge.Name, challenge.DescribeChallenge());
                    
                    challenge.DoChallenge();
                }
            }
        }

        private void ListChallenges()
        {
            Console.Clear();
            Console.WriteLine("C# Interview Reviewer");
            Console.WriteLine("---------------------\n");
            Console.WriteLine("Choose a Challenge Number:\n");

            for (int i = 1; i <= Challenges.Count(); i++)
            {
                Console.WriteLine("{0}: {1}",i, Challenges[i - 1].GetName());
            }

            Console.WriteLine("\n");
        }
    }
}