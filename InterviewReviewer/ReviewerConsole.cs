using InterviewReviewer.Interfaces;

namespace InterviewReviewer
{
    internal class ReviewerConsole
    {
        public List<IModule> Modules { get; set; }

        public ReviewerConsole(List<IModule> modules)
        {
            Modules = modules;
        }

        public void DisplayMenu()
        {
            while (true) 
            {
                ListModules();                

                var choice = Console.ReadLine();

                if (int.TryParse(choice, out int choiceNumber) && choiceNumber > 0 && choiceNumber <= Modules.Count())
                {
                    var module = Modules[choiceNumber - 1];

                    Console.WriteLine("{0}: {1}", module.Name, module.DescribeModule());
                    
                    module.Run();
                    Console.WriteLine("\n\nPress Enter to return to main menu.");
                    Console.ReadLine();
                }
            }
        }

        private void ListModules()
        {
            Console.Clear();
            Console.WriteLine("C# Interview Reviewer");
            Console.WriteLine("---------------------\n");
            Console.WriteLine("Choose a Module Number:\n");

            for (int i = 1; i <= Modules.Count; i++)
            {
                Console.WriteLine("{0}: {1}", i, Modules[i - 1].Name);
            }

            Console.WriteLine("\n");
        }
    }
}