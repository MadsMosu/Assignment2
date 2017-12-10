using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    public interface ISerialNumbersData
    {
        IEnumerable<string> GetAll();
        bool VerifySerialNumber(string serialNumber);
    }
}
