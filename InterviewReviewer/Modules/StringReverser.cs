using InterviewReviewer.Interfaces;

namespace InterviewReviewer.Modules
{
    internal class StringReverser : IModule
    {
        public string Name { get; set; } = "String Reverser";


        public string DescribeModule()
        {
            return "This program will reverse a string you provide.\n";
        }

        public void Run()
        {
            Console.Write("Please enter a string: ");
            var stringToReverse = Console.ReadLine() ?? "";            

            char[] stringArray = stringToReverse.ToCharArray();
            Array.Reverse(stringArray);
            var reversedString = new string(stringArray);

            Console.Write("When reversed, the string {0} is {1}.", stringToReverse, reversedString);
        }
    }
}