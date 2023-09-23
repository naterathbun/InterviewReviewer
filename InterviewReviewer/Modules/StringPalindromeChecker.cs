using InterviewReviewer.Interfaces;

namespace InterviewReviewer.Modules
{
    internal class StringPalindromeChecker : IModule
    {
        public string Name { get; set; } = "String Palindrome Checker";

        public string DescribeModule()
        {
            return "Enter a string and this module will let you know if it is a palindrome (or not).\n";
        }

        public void Run()
        {
            Console.Write("Please enter a string: ");
            var stringToCheck = Console.ReadLine() ?? "";

            char[] stringArray = stringToCheck.ToCharArray();
            Array.Reverse(stringArray);
            var reversedString = new string(stringArray);

            if (IsPalindrome(stringToCheck, reversedString))
                Console.WriteLine("\nWhen reversed, the string {0} is {1}, which IS a palindrome.", stringToCheck, reversedString);
            else
                Console.WriteLine("\nWhen reversed, the string {0} is {1}, which IS NOT a palindrome.", stringToCheck, reversedString);
        }

        private bool IsPalindrome(string stringToCheck, string reversedString)
        {
            return stringToCheck == reversedString ? true : false;
        }
    }
}