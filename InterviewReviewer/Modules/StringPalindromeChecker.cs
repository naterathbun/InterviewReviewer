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

            Console.Write("When reversed, the string {0} is {1}, which is", stringToCheck, reversedString);

            if (stringToCheck != reversedString)
                Console.Write(" not");

            Console.Write(" a palindrome!");            
        }
    }
}