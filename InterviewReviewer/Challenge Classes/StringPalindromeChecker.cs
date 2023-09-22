using InterviewReviewer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
