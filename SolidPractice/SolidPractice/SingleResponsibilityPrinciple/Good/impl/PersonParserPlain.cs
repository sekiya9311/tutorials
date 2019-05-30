using System;
using System.Collections.Generic;
using SolidPractice.SingleResponsibilityPrinciple.Good.interfaces;

namespace SolidPractice.SingleResponsibilityPrinciple.Good.impl
{
    public class PersonParserPlain : IPersonParser
    {
        private readonly IPersonValidator _validator;
        private readonly IPersonMapper _mapper;

        public PersonParserPlain(IPersonValidator validator, IPersonMapper mapper)
        {
            if (validator is null)
            {
                throw new ArgumentNullException(nameof(validator));
            }
            if (mapper is null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            _validator = validator;
            _mapper = mapper;
        }

        public IEnumerable<Person> ParseToPersonEntity(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var values = line.Split(new[] { ',' });
                if (!_validator.Validate(values))
                {
                    continue;
                }

                var person = _mapper.Map(values);
                yield return person;
            }
        }
    }
}