using InterviewReviewer.Challenge_Classes;
using InterviewReviewer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewReviewer
{
    internal class ReviewerConsole
    {
        public List<IChallenge> Challanges { get; set; }

        public ReviewerConsole()
        {
            Challanges = new List<IChallenge>()
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

            ListChallenges();
            var choice = Console.ReadLine();


        }

        public void ListChallenges()
        {
            var challengeNumber = 1;

            foreach (IChallenge challenge in Challanges)
            {
                Console.WriteLine(challengeNumber.ToString() + ": " + challenge.GetName());
                challengeNumber++;
            }
        }
    }
}
