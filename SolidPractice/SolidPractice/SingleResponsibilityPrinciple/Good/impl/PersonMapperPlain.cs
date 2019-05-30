using System.Collections.Generic;
using SolidPractice.SingleResponsibilityPrinciple.Good.interfaces;

namespace SolidPractice.SingleResponsibilityPrinciple.Good.impl
{
    public class PersonMapperPlain : IPersonMapper
    {
        public Person Map(IList<string> values)
        {
            var age = int.Parse(values[1]);
            var height = double.Parse(values[2]);
            var weight = double.Parse(values[3]);

            var person = new Person()
            {
                Name = values[0],
                Age = age,
                Height = height,
                Weight = weight,
            };
            return person;
        }
    }
}