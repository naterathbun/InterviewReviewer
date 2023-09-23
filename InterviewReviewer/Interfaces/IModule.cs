using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewReviewer.Interfaces
{
    public interface IModule
    {
        public string Name { get; set; }

        public string DescribeModule();
        public void Run();
    }
}
