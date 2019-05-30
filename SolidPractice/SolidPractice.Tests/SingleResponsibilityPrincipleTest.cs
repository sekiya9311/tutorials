using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using SolidPractice.SingleResponsibilityPrinciple;
using SolidPractice.SingleResponsibilityPrinciple.Good;
using SolidPractice.SingleResponsibilityPrinciple.Good.impl;
using SolidPractice.SingleResponsibilityPrinciple.Good.interfaces;

namespace SolidPractice.Tests
{
    public class SingleResponsibilityPrincipleTest
    {
        private static readonly string[] inputs = new[] { "hoge,10,12.3,45,6", "fuga,21,65.4,32.1" };
        private static readonly string[] tmpStrArray = new[] { "a", "i", "u", "e", "o" };
        private static readonly Person[] tmpPersonArray = new[]
        {
            new Person()
            {
                Name = "aiueo",
                Age = 11,
                Height = 22.2,
                Weight = 33.3
            }
        };

        [Fact]
        public void PersonConverterTest()
        {
            var inputter = new Mock<IPersonInputter>();
            var parser = new Mock<IPersonParser>();
            var outputter = new Mock<IPersonOutputter>();

            inputter
                .Setup(i => i.GetPersonData())
                .Returns(tmpStrArray);
            parser
                .Setup(p => p.ParseToPersonEntity(tmpStrArray))
                .Returns(tmpPersonArray);

            var converter = new PersonConverter(inputter.Object, parser.Object, outputter.Object);
            converter.Convert();

            outputter.Verify(o => o.OutputPersons(tmpPersonArray), Times.Once);
        }
    }
}
