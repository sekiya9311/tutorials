using System;
using System.Collections.Generic;
using SolidPractice.SingleResponsibilityPrinciple.Good.interfaces;

namespace SolidPractice.SingleResponsibilityPrinciple.Good.impl
{
    public class PersonValidatorPlain : IPersonValidator
    {
        public bool Validate(IList<string> values)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Count != 4)
            {
                return false;
            }

            if (!int.TryParse(values[1], out var _))
            {
                return false;
            }
            if (!double.TryParse(values[2], out var _))
            {
                return false;
            }
            if (!double.TryParse(values[3], out var _))
            {
                return false;
            }

            return true;
        }
    }
}