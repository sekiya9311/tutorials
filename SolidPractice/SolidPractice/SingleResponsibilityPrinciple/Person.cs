using System;
using System.Collections.Generic;
using System.Text;

namespace SolidPractice.SingleResponsibilityPrinciple
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public override bool Equals(object obj)
            => (obj is Person p) &&
                p.Name == this.Name &&
                p.Age == this.Age &&
                p.Height == this.Height &&
                p.Weight == this.Weight;

        public override int GetHashCode()
            => this.Name.GetHashCode() ^
                this.Age.GetHashCode() ^
                this.Height.GetHashCode() ^
                this.Weight.GetHashCode();
    }
}
