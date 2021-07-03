using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectInitializerGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tests
{
    public class Base
    {
        public void Run(string testName)
        {
            string input = File.ReadAllText(Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "\\") + testName + "\\" + testName + "_INPUT" + ".txt");
            string expected = File.ReadAllText(Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "") + testName + "\\" + testName + "_OUTPUT" + ".txt");

            CSharpWriter writer = new CSharpWriter(); 
            Generator generator = new Generator(writer);
            string output = generator.Analyse(input).Write();
            
            Assert.AreEqual(expected.Replace(Environment.NewLine, "").Replace(" ", "").Replace("\t", ""), output.Replace(Environment.NewLine, "").Replace(" ", "").Replace("\t", ""));

        }
        
    }
}
