using InterviewReviewer.Interfaces;

namespace InterviewReviewer.Challenge_Classes
{
    internal class StringReverser : IChallenge
    {
        public string Name { get; set; } = "String Reverser";

        public string GetName()
        {
            return Name;
        }

        public string DescribeChallenge()
        {
            return "Enter a string, and the output will be that string reversed.";
        }

        public void DoChallenge()
        {
            




        }
    }
}
