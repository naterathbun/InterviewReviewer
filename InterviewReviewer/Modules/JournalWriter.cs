using InterviewReviewer.Interfaces;

namespace InterviewReviewer.Modules
{
    internal class JournalWriter : IModule
    {
        public string Name { get; set; } = "Journal Writer";

        public string DescribeModule()
        {
            return "Type some text here and the module will append whatever you write to a .txt file along with the date you wrote it.\n";
        }

        public void Run()
        {
            var path = "MyJournal.txt";
            var journalEntry = GetJournalEntry();

            try
            {
                if (File.Exists(path))
                {
                    File.AppendAllText(path, journalEntry);
                    Console.WriteLine("Succesfully saved a journal entry to {0}.", path);
                }
                else
                {
                    File.WriteAllText(path, journalEntry);
                    Console.WriteLine("Succesfully started a new journal and saved entry to {0}.", path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong saving journal entry: {0}", ex.Message);
            }
        }

        private string GetJournalEntry()
        {
            Console.Write("Write your journal entry here: ");
            var journalEntry = Console.ReadLine() ?? "";
            var date = GetFormattedDate();

            return string.Format("{0}{1}", date, journalEntry);
        }

        private string GetFormattedDate()
        {
            var day = DateTime.Now.ToString("dddd");
            var date = DateTime.Now.ToString("yyyy-MM-dd");

            return string.Format("{0}, {1}\n", day, date);
        }
    }
}