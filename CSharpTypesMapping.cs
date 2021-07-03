using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectInitializerGenerator
{
    internal static class CSharpTypesMapping
    {
        private static readonly Dictionary<string, string> Mappings = new Dictionary<string, string>
        {
            { "string", "\"\"" },
            { "String", "\"\"" },

            { "bool", "true" },
            { "bool?", "true" },
            { "Boolean", "true" },
            { "Boolean?", "true" },
            
            { "Guid", "Guid.NewGuid()"},
            
            { "Datetime", "DateTime.Now"},
            { "Datetime?", "DateTime.Now"},
            { "DateTime", "DateTime.Now"},
            { "DateTime?", "DateTime.Now"},
            
            { "DateTimeOffset", "DateTimeOffset.Now"},
            { "DateTimeOffset?", "DateTimeOffset.Now"},

            { "int", "1"},
            { "int?", "1"},
            
            { "uint", "1"},
            { "long", "1"},
            { "double", "1"},
            { "Double", "1"},
            { "float", "1"},
            { "decimal", "1"},

            { "char", "\'c\'"},

        };

        static internal string Map(string type)
        {
            return Mappings[type];
        }
    }
}
