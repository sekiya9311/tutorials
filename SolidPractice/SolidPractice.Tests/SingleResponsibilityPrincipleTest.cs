﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        private static readonly string[] inputs = new[] { "hoge,10,12.3,45,6", "fuga,21,65.4,32.1", "a" };
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

            inputter.Verify(i => i.GetPersonData(), Times.Once);
            parser.Verify(p => p.ParseToPersonEntity(tmpStrArray), Times.Once);
            outputter.Verify(o => o.OutputPersons(tmpPersonArray), Times.Once);

            Assert.Throws<ArgumentNullException>(
                "inputter", () => new PersonConverter(null, parser.Object, outputter.Object));
            Assert.Throws<ArgumentNullException>(
                "parser", () => new PersonConverter(inputter.Object, null, outputter.Object));
            Assert.Throws<ArgumentNullException>(
                "outputter", () => new PersonConverter(inputter.Object, parser.Object, null));
        }

        [Fact]
        public void PersonParserPlainTest()
        {
            var splitter = new Mock<IPersonSplitter>();
            var validator = new Mock<IPersonValidator>();
            var mapper = new Mock<IPersonMapper>();

            var tmpIn = inputs[0].Split(",");
            var tmpOut = tmpPersonArray.Concat(tmpPersonArray);
            splitter
                .Setup(s => s.Split(It.IsIn(inputs.SkipLast(1))))
                .Returns(tmpIn);
            splitter
                .Setup(s => s.Split(inputs.Last()))
                .Returns(new[] { inputs.Last() });
            validator
                .Setup(v => v.Validate(tmpIn))
                .Returns(true);
            validator
                .Setup(v => v.Validate(new[] { inputs.Last() }))
                .Returns(false);
            mapper
                .Setup(m => m.Map(tmpIn))
                .Returns(tmpPersonArray[0]);
            var parser = new PersonParserPlain(splitter.Object, validator.Object, mapper.Object);
            var res = parser.ParseToPersonEntity(inputs);

            Assert.Equal(tmpOut, res);

            Assert.Throws<ArgumentNullException>(
                "splitter", () => new PersonParserPlain(null, validator.Object, mapper.Object));
            Assert.Throws<ArgumentNullException>(
                "validator", () => new PersonParserPlain(splitter.Object, null, mapper.Object));
            Assert.Throws<ArgumentNullException>(
                "mapper", () => new PersonParserPlain(splitter.Object, validator.Object, null));
        }
    }
}
