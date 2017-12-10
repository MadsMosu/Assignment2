using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Assignment2.Models
{
    public class SerialNumbersData : ISerialNumbersData
    {

        private List<string> _serialNumbers;

        protected const string filePath = @"..\MyClassLibrary\serialNumbers.bin";

        public SerialNumbersData()
        {
            _serialNumbers = new List<string>();
            AddSerialNumbers();
        }

        public IEnumerable<string> GetAll()
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();

                var otherList = (List<string>)binaryFormatter.Deserialize(stream);
                return otherList;
            }
        }

        public bool VerifySerialNumber(string serialNumber)
        {
            return GetAll().Contains(serialNumber);
        }

        protected Random random = new Random();
        protected string RandomSerialNumber(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void AddSerialNumbers()
        {
            for (var i = 0; i < 100; i++)
            {
                _serialNumbers.Add(RandomSerialNumber(16));
            }
            using (Stream stream = File.Open(filePath, FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, _serialNumbers);
                stream.Close();
            }
        }
    }
}
