using System.Collections.Generic;

namespace SolidPractice.SingleResponsibilityPrinciple.Good.interfaces
{
    public interface IPersonParser
    {
        IEnumerable<Person> ParseToPersonEntity(IEnumerable<string> lines);
    }
}