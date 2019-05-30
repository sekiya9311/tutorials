using System.Collections.Generic;

namespace SolidPractice.SingleResponsibilityPrinciple.Good.interfaces
{
    public interface IPersonMapper
    {
        Person Map(IList<string> values);
    }
}
