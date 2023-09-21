using InterviewReviewer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
