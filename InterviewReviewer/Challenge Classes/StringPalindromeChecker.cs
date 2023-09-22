using InterviewReviewer.Interfaces;
using System.Numerics;

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
            return "This program will let you know if the string is or is not a palindrome.\n";
        }

        public void DoChallenge()
        {
            Console.Write("Please enter a string: ");
            var stringToCheck = Console.ReadLine();

            char[] stringArray = stringToCheck.ToCharArray();
            Array.Reverse(stringArray);
            var reversedString = new string(stringArray);

            Console.Write("When reversed, the string {0} is {1}, which is", stringToCheck, reversedString);

            if (stringToCheck != reversedString)
                Console.Write(" not");

            Console.Write(" a palindrome!");
            Console.ReadLine();
        }
    }
}