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
            Console.Write("Please enter a positive integer: ");
            var userInputNumber = Console.ReadLine() ?? "0";
            var numberToCheck = int.Parse(userInputNumber);

            if (IsPrimeNumber(numberToCheck))
                Console.WriteLine("\nYes, your number, {0}, IS a prime number.", numberToCheck);
            else
                Console.WriteLine("\nNo, your number, {0}, IS NOT a prime number", numberToCheck);
        }

        private bool IsPrimeNumber(int numberToCheck)
        {
            // Check special cases (Negatives, 0, 1, 2, 3) and numbers divisable by 2 or 3
            if (numberToCheck <= 1 || numberToCheck % 2 == 0 || numberToCheck % 3 == 0)
                return false;
            if (numberToCheck == 2 || numberToCheck == 3)
                return true;

            // Check for factors using the 6k+/-1 rule
            for (int i = 5; i * i <= numberToCheck; i += 6)
            {
                if (numberToCheck % i == 0 || numberToCheck % (i + 2) == 0)
                    return false;
            }

            // Everything else is prime
            return true;
        }
    }
}