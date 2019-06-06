using System;
using System.Collections.Generic;
using System.Linq;
using SolidPractice.SingleResponsibilityPrinciple.Good.interfaces;

namespace SolidPractice.SingleResponsibilityPrinciple.Good.impl
{
    public class PersonParserPlain : IPersonParser
    {
        private readonly IPersonSplitter _splitter;
        private readonly IPersonValidator _validator;
        private readonly IPersonMapper _mapper;

        public PersonParserPlain(IPersonSplitter splitter, IPersonValidator validator, IPersonMapper mapper)
        {
            if (splitter is null)
            {
                throw new ArgumentNullException(nameof(splitter));
            }
            if (validator is null)
            {
                throw new ArgumentNullException(nameof(validator));
            }
            if (mapper is null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            _validator = validator;
            _splitter = splitter;
            _mapper = mapper;
        }

        public IEnumerable<Person> ParseToPersonEntity(IEnumerable<string> lines)
        {
            //foreach (var line in lines)
            //{
            //    var values = _splitter.Split(line).ToArray();
            //    if (!_validator.Validate(values))
            //    {
            //        continue;
            //    }

            //    var person = _mapper.Map(values);
            //    yield return person;
            //}

            return lines
                .Select(l => _splitter.Split(l).ToArray())
                .Where(_validator.Validate)
                .Select(_mapper.Map);
        }
    }
}