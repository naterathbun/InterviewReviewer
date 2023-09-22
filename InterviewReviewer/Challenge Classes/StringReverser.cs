using InterviewReviewer.Interfaces;

namespace InterviewReviewer.Challenge_Classes
{
    internal class StringReverser : IChallenge
    {
        public string Name { get; set; } = "String Reverser";


        public string DescribeChallenge()
        {
            return "This program will reverse a string you provide.\n";
        }

        public void DoChallenge()
        {
            Console.Write("Please enter a string: ");
            var stringToReverse = Console.ReadLine();

            char[] stringArray = stringToReverse.ToCharArray();
            Array.Reverse(stringArray);
            var reversedString = new string(stringArray);

            Console.Write("When reversed, the string {0} is {1}.", stringToReverse, reversedString);
        }
    }
}