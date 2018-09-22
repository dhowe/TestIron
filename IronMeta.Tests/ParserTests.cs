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
        private static Matcher.MatchResult<char, int> Parse(string input)
        {
            var parser = new DialogicParser();
            var result = parser.GetMatch(input, parser.Expression);
            Assert.That(result.Success, Is.True, "Error: " + result.Error + ", at char " + result.ErrorIndex);
            return result;
        }

        [Test]
        public void Test1()
        {
            Assert.That(Parse("7*2").Result, Is.EqualTo(14));
        }
    }

    [SetUpFixture]
    public class TestSetup
    {
        private static bool GenerateParser(string[] args = null)
        {
            Console.WriteLine("GenerateParser");

            if (args == null || args.Length == 0) args = new[] { "/Users/dhowe/Projects/TestIron/IronMeta.App/DialogicParser.ironmeta" };

            const string message = "IronMeta -n {0} -o {1} {2}: {3}";

            var options = Options.Parse(args);
            var inputInfo = new FileInfo(options.InputFile);
            var outputInfo = new FileInfo(options.OutputFile);

            if (outputInfo.Exists && outputInfo.LastWriteTimeUtc > inputInfo.LastWriteTimeUtc && !options.Force)
            {
                Console.WriteLine(string.Format(message, options.Namespace, outputInfo.FullName, inputInfo.FullName, "input is older than output; not generating"));
                return true;
            }
            else
            {
                var match = CSharpShell.Process(inputInfo.FullName, outputInfo.FullName, options.Namespace, true);
                if (match.Success)
                {
                    Console.WriteLine(string.Format(message, options.Namespace, outputInfo.FullName, inputInfo.FullName));
                    return true;
                }
                else
                {
                    int num, offset;
                    var line = match.MatchState.GetLine(match.MatchState.LastErrorIndex, out num, out offset);
                    Console.Error.WriteLine("{0}({1},{2}): error: {3}", inputInfo.FullName, num, offset, match.MatchState.LastError);
                    Console.Error.WriteLine("{0}", line);
                    Console.Error.WriteLine("{0}^", new string(' ', offset));
                    return false;
                }
            }
        }

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            if (!GenerateParser()) throw new Exception("Couldn't create parser");
        }
    }
}