using System;
using System.IO;
using System.Collections.Generic;
using SolidPractice.SingleResponsibilityPrinciple.Good.interfaces;

namespace SolidPractice.SingleResponsibilityPrinciple.Good.impl
{
    public class PersonInputterFromStream : IPersonInputter
    {
        private Stream _inputStream;

        public PersonInputterFromStream(Stream inputStream)
        {
            if (inputStream is null)
            {
                throw new ArgumentNullException(nameof(inputStream));
            }

            _inputStream = inputStream;
        }

        public IEnumerable<string> GetPersonData()
        {
            using (var reader = new StreamReader(_inputStream))
            {
                var lines = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    lines.Add(line);
                }
                return lines;
            }
        }
    }
}