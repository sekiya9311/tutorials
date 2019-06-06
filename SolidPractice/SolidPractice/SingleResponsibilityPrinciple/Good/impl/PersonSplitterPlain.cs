using System;
using System.Collections.Generic;
using SolidPractice.SingleResponsibilityPrinciple.Good.interfaces;

namespace SolidPractice.SingleResponsibilityPrinciple.Good.impl
{
    public class PersonSplitterPlain : IPersonSplitter
    {
        public IEnumerable<string> Split(string line)
            => line.Split(new[] { ',' });
    }
}
