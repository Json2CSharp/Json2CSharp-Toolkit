
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamasoft.JsonClassGenerator;
using Xamasoft.JsonClassGenerator.CodeWriters;

namespace TESTS_JSON_TO_CSHARP
{

    [TestClass]
    public class Test_4_BracketError
    {

        [TestMethod]
        public void Run()
        {
            string path       = Path.Combine(Environment.CurrentDirectory, "Test_4_BracketError_INPUT.txt");
            string resultPath = Path.Combine(Environment.CurrentDirectory, "Test_4_BracketError_OUTPUT.txt");

            string input = File.ReadAllText(path);
            string errorMessage = string.Empty;
            CSharpCodeWriter csharpCodeWriter = new CSharpCodeWriter();
            JsonClassGenerator jsonClassGenerator = new JsonClassGenerator();
            jsonClassGenerator.CodeWriter = csharpCodeWriter;
            string returnVal = jsonClassGenerator.GenerateClasses(input, out errorMessage).ToString();
            string resultsCompare = File.ReadAllText(resultPath);
            Assert.AreEqual(resultsCompare.Replace(Environment.NewLine, "").Replace(" ", "").Replace("\t", ""), returnVal.Replace(Environment.NewLine, "").Replace(" ", "").Replace("\t", ""));

            string path1 = Directory.GetCurrentDirectory().Replace("bin\\Debug", "") + @"Test_4_BracketError_INPUT_1.txt";
            string resultPath1 = Directory.GetCurrentDirectory().Replace("bin\\Debug", "") + @"Test_4_BracketError_OUTPUT_1.txt";
            string input1 = File.ReadAllText(path1);
            string errorMessage1 = string.Empty;
            CSharpCodeWriter csharpCodeWriter1 = new CSharpCodeWriter();
            JsonClassGenerator jsonClassGenerator1 = new JsonClassGenerator();
            jsonClassGenerator1.CodeWriter = csharpCodeWriter1;
            string returnVal1 = jsonClassGenerator1.GenerateClasses(input1, out errorMessage1).ToString();
            string resultsCompare1 = File.ReadAllText(resultPath1);
            Assert.AreEqual(resultsCompare1.Replace(Environment.NewLine, "").Replace(" ", "").Replace("\t", ""), returnVal1.Replace(Environment.NewLine, "").Replace(" ", "").Replace("\t", ""));


        }
    }
}
