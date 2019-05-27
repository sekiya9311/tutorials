using System.Collections.Generic;

namespace SolidPractice.SingleResponsibilityPrinciple.Good.interfaces
{
    public interface IPersonOutputter
    {
        void OutputPersons(IEnumerable<Person> persons);
    }
}