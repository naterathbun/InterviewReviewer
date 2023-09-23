using InterviewReviewer.Interfaces;

namespace InterviewReviewer.Modules
{
    internal class PrimeNumberChecker : IModule
    {
        public string Name { get; set; } = "Prime Number Checker";


        public string DescribeModule()
        {
            return "Enter a positive integer, and this module will tell you if that number is a prime or not.";
        }

        public void Run()
        {
            




        }
    }
}
