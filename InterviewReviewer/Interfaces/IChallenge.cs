using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewReviewer.Interfaces
{
    public interface IChallenge
    {
        public string Name { get; set; }

        public string GetName();
        public string DescribeChallenge();
        public void DoChallenge();
    }
}
