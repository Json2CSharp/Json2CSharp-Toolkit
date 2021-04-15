
using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Xamasoft.JsonClassGenerator;
using Xamasoft.JsonClassGenerator.CodeWriters;

namespace TESTS_JSON_TO_CSHARP
{
    [TestClass]
    public class Test_10_SETTINGS_IMMUTABLE_CLASSES
    {
        [TestMethod]
        public void Run()
        {
            string path       = Path.Combine(Environment.CurrentDirectory, "Test_10_SETTINGS_IMMUTABLE_CLASSES_INPUT.txt");
            string resultPath = Path.Combine(Environment.CurrentDirectory, "Test_10_SETTINGS_IMMUTABLE_CLASSES_OUTPUT.txt");

            string input      = File.ReadAllText(path);

            JsonClassGenerator jsonClassGenerator = new JsonClassGenerator()
            {
                CodeWriter          = new CSharpCodeWriter(),
                ImmutableClasses    = true,
                UseJsonPropertyName = false,
                UsePascalCase       = true,
                UseJsonAttributes   = true
            };

            string returnVal      = jsonClassGenerator.GenerateClasses(input, errorMessage: out _).ToString();
            string resultsCompare = File.ReadAllText(resultPath);

            string expected = resultsCompare.Replace(Environment.NewLine, "").Replace(" ", "").Replace("\t", "");
            string actual   = returnVal     .Replace(Environment.NewLine, "").Replace(" ", "").Replace("\t", "");
            Assert.AreEqual(expected, actual);
        }
    }
}
