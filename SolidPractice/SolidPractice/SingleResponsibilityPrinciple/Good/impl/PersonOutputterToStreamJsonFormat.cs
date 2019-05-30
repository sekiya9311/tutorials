using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using SolidPractice.SingleResponsibilityPrinciple.Good.interfaces;

namespace SolidPractice.SingleResponsibilityPrinciple.Good.impl
{
    public class PersonOutputterToStreamJsonFormat : IPersonOutputter
    {
        private Stream _outputStream;

        public PersonOutputterToStreamJsonFormat(Stream outputStream)
        {
            if (outputStream is null)
            {
                throw new ArgumentNullException(nameof(outputStream));
            }

            _outputStream = outputStream;
        }

        public void OutputPersons(IEnumerable<Person> persons)
        {
            if (persons is null)
            {
                throw new ArgumentNullException(nameof(persons));
            }

            using (var writer = new StreamWriter(_outputStream))
            {
                var personArrayOfJson = JsonConvert.SerializeObject(persons);
                writer.WriteLine(personArrayOfJson);
            }
        }
    }
}