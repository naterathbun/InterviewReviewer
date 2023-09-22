using InterviewReviewer.Interfaces;

namespace InterviewReviewer.Challenge_Classes
{
    internal class PrimeNumberChecker : IChallenge
    {
        public string Name { get; set; } = "Prime Number Checker";

        public string GetName()
        {
            return Name;
        }

        public string DescribeChallenge()
        {
            return "Enter a positive integer, and the output will be a bool stating if that number is a prime or not.";
        }

        public void DoChallenge()
        {
            




        }
    }
}
