﻿using InterviewReviewer.Interfaces;

namespace InterviewReviewer.Modules
{
    internal class PrimeNumberChecker : IModule
    {
        public string Name { get; set; } = "Prime Number Checker";


        public string DescribeModule()
        {
            return "Enter a positive integer, and the output will be a bool stating if that number is a prime or not.";
        }

        public void Run()
        {
            




        }
    }
}