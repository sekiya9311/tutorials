using System.Collections.Generic;

namespace SolidPractice.SingleResponsibilityPrinciple.Good.interfaces
{
    public interface IPersonValidator
    {
        bool Validate(IList<string> values);
    }
}
