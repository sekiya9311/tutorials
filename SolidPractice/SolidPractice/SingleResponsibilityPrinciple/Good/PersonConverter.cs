using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using SolidPractice.SingleResponsibilityPrinciple.Good.interfaces;

namespace SolidPractice.SingleResponsibilityPrinciple.Good
{
    public class PersonConverter
    {
        private readonly IPersonInputter _inputter;
        private readonly IPersonParser _parser;
        private readonly IPersonOutputter _outputter;

        public PersonConverter(
            IPersonInputter inputter,
            IPersonParser parser,
            IPersonOutputter outputter)
        {
            if (inputter is null)
            {
                throw new ArgumentNullException(nameof(inputter));
            }
            if (parser is null)
            {
                throw new ArgumentNullException(nameof(parser));
            }
            if (outputter is null)
            {
                throw new ArgumentNullException(nameof(outputter));
            }

            _inputter = inputter;
            _parser = parser;
            _outputter = outputter;
        }

        public void Convert()
        {
            var lines = _inputter.GetPersonData();

            var persons = _parser.ParseToPersonEntity(lines);

            _outputter.OutputPersons(persons);
        }
    }
}