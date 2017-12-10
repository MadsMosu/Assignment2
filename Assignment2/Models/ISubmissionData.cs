using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyClassLibrary;

namespace Assignment2.Models
{
    public interface ISubmissionData
    {

        IEnumerable<Submission> GetAll();

        void AddSubmission(Submission sub);

        bool VerifyNewSubmission(string serialNumber);
    }
}
