using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectInitializerGenerator;
using System;
using System.Collections.Generic;
using System.IO;

namespace Tests
{
    [TestClass]
    public class TEST_1_BASIC_TYPES_TEST : Base
    {
        [TestMethod]
        public void Run()
        {
            Run("TEST_1_BASIC_TYPES_TEST");

            TestClass testclass = new TestClass()
            {
                TestBool = true,
                TestBoolean = true,
                TestString = "",
                TestString_2 = "",
                TestGuid = Guid.NewGuid(),
                // Unknown Property : TestDateTime 
                TestDateTimeOffset = DateTimeOffset.Now,
                TestChar = 'd',
                NullableTestInt = 1,
                NullableTestBoolean = true,
                // Unknown Property : NullableTestDateTime 
                NullableTestDateTimeOffset = DateTimeOffset.Now,
            };

        }

        public class TestClass
        {
            public bool TestBool { get; set; }
            public Boolean TestBoolean { get; set; }
            public string TestString { get; set; }
            public String TestString_2 { get; set; }
            public Guid TestGuid { get; set; }
            public DateTime TestDateTime { get; set; }
            public DateTimeOffset TestDateTimeOffset { get; set; }
            public char TestChar { get; set; }

            public int? NullableTestInt { get; set; }
            public bool? NullableTestBoolean { get; set; }
            public DateTime? NullableTestDateTime { get; set; }
            public DateTimeOffset? NullableTestDateTimeOffset { get; set; }
        }

        // public class TestClass
        // {
        //     public byte[] TestByteArray { get; set; }
        //     public List<string> TestStringList { get; set; }
        //     public IEnumerable<string> TestIEnumerableList{ get; set; }
        //     public Dictionary<string, string> TestDictionary { get; set; }
        // }
    }
}