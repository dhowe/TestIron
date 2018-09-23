using System;
using System.IO;
using IronMeta.App;
using IronMeta.Generator;
using NUnit.Framework;

namespace IronMeta.Tests
{
    [TestFixture]
    public class ParserTests
    {
        private static Matcher.MatchResult<char, string> Parse(string input)
        {
            var parser = new PegParser();
            var result = parser.GetMatch(input, parser.Expression);
            Assert.That(result.Success, Is.True, "Error: " + result.Error + ", at char " + result.ErrorIndex);
            return result;
        }

        [Test]
        public void SimpleCommands()
        {
            var input = "SAY";
            Console.WriteLine(Parse(input).Result);
            Assert.That(Parse(input).Result, Is.EqualTo(input));

            input = "SAY hello";
            Console.WriteLine(Parse(input).Result);
            Assert.That(Parse(input).Result, Is.EqualTo(input));
        }
    }
}