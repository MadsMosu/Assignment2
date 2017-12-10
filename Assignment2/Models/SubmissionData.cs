using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyClassLibrary;

namespace Assignment2.Models
{
    public class SubmissionData : ISubmissionData
    {
        private List<Submission> _submissions;

        protected const string filePath = @"..\MyClassLibrary\submissions.bin";

        public SubmissionData()
        {
            _submissions = new List<Submission>();
        }

        public IEnumerable<Submission> GetAll()
        {
            if (File.Exists(filePath) && File.ReadAllBytes(filePath).Length != 0)
            {
                using (Stream stream = File.Open(filePath, FileMode.Open))
                {
                    var binaryFormatter = new BinaryFormatter();
                    var otherList = (List<Submission>) binaryFormatter.Deserialize(stream);
                    return otherList;
                }
            }
            return new List<Submission>();
        }

        public void AddSubmission(Submission sub)
        {
            _submissions.Add(sub);
            using (Stream stream = File.Open(filePath, FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, _submissions);
                stream.Close();
            }
        }

        public bool VerifyNewSubmission(string serialNumb)
        {
            foreach (var sub in GetAll())
            {
                if (serialNumb.Equals(sub.SerialNumb)) return false;
            }
            return true;
        }
    }
}
    
