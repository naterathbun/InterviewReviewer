namespace InterviewReviewer.Interfaces
{
    public interface IModule
    {
        public string Name { get; set; }

        public string DescribeModule();
        public void Run();
    }
}