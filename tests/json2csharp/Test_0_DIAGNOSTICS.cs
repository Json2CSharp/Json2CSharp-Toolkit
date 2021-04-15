
using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Xamasoft.JsonClassGenerator;
using Xamasoft.JsonClassGenerator.CodeWriters;

namespace TESTS_JSON_TO_CSHARP
{
    [TestClass]
    public class Test_0_DIAGNOSTICS
    {
        [TestMethod]
        public void Run()
        {
            // Assert.Inconclusive(message: "This test is not yet implemented.");

            string path       = Path.Combine(Environment.CurrentDirectory, "Test_0_DIAGNOSTICS_INPUT.txt");
            string resultPath = Path.Combine(Environment.CurrentDirectory, "Test_0_DIAGNOSTICS_OUTPUT.txt");
            string input = File.ReadAllText(path);
            CSharpCodeWriter csharpCodeWriter = new CSharpCodeWriter();
            JsonClassGenerator jsonClassGenerator = new JsonClassGenerator();
            jsonClassGenerator.CodeWriter = csharpCodeWriter;
            
            jsonClassGenerator.UseJsonAttributes = true;
            jsonClassGenerator.UseJsonPropertyName = true;

            string returnVal = jsonClassGenerator.GenerateClasses(input, errorMessage: out _).ToString();
            string resultsCompare = File.ReadAllText(resultPath);

            string expected = resultsCompare.Replace(Environment.NewLine, "").Replace(" ", "").Replace("\t", "");
            string actual   = returnVal     .Replace(Environment.NewLine, "").Replace(" ", "").Replace("\t", "");
           // Assert.AreEqual(expected, actual);
        }
    }
}
