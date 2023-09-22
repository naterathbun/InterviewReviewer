using InterviewReviewer.Interfaces;

namespace InterviewReviewer.Challenge_Classes
{
    internal class StringPalindromeChecker : IChallenge
    {
        public string Name { get; set; } = "String Palindrome Checker";

        public string GetName()
        {
            return Name;
        }

        public string DescribeChallenge()
        {
            return "Enter a string, and the output will be a bool stating if that string is or is not a palindrome.";
        }

        public void DoChallenge()
        {
            




        }
    }
}
