using System.Collections.Generic;

namespace SolidPractice.SingleResponsibilityPrinciple.Good.interfaces
{
    public interface IPersonInputter
    {
        IEnumerable<string> GetPersonData();
    }
}
