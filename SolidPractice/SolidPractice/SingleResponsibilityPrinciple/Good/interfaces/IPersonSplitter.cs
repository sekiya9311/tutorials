using System;
using System.Collections.Generic;

namespace SolidPractice.SingleResponsibilityPrinciple.Good.interfaces
{
    public interface IPersonSplitter
    {
        IEnumerable<string> Split(string line);
    }
}
