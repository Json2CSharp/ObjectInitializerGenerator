using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectInitializerGenerator
{
    public class CSharpWriter : ICodeWriter
    {
        private readonly StringBuilder builder;
        bool UseAssignmentStatements; 
        public CSharpWriter(Dictionary<string, string> settings = null)
        {
            builder = new StringBuilder();

            if (settings != null)
            {
                foreach (var item in settings)
                {
                    UseAssignmentStatements = item.Key == SettingTypes.UseAssignmentStatements.ToString() && bool.Parse(item.Value);
                }
            }
        }

        public string Write(List<ObjectModel> objectModels)
        {
            foreach (ObjectModel classObject in objectModels)
            {
                WriteClassMember(classObject);
                builder.AppendLine("};");
            }

            return builder.ToString();
        }

        private void WriteClassMember(ObjectModel classObject) {

            string accessorClassName = classObject.SyntaxName.ToLowerInvariant();
            if (UseAssignmentStatements)
            {
                builder.AppendFormat("{0} {1} = new {0}();{2}", classObject.SyntaxName, accessorClassName, Environment.NewLine);
            }
            else
            {
                builder.AppendFormat("{0} {1} = new {0}() {{ {2}", classObject.SyntaxName, accessorClassName, Environment.NewLine);
            }

            if (classObject.Children.Any())
            {
                foreach (ObjectModel child in classObject.Children)
                {
                    WritePropertyMember(child, classObject, accessorClassName);
                }
            }
        }

        private void WritePropertyMember(ObjectModel propertyModel, ObjectModel parentModel, string accessorClassName) {

            if (UseAssignmentStatements)
            {
               // builder.AppendFormat("{0} {1} = new {0}();{2}", classObject.SyntaxName, classObject.SyntaxName.ToLowerInvariant(), Environment.NewLine);
                builder.AppendLine();
            }
            else
            {
                if (propertyModel.TokenType == SyntaxKind.ClassDeclaration)
                {

                }
                else if (propertyModel.TokenType == SyntaxKind.PropertyDeclaration)
                {
                    try
                    {
                        switch (propertyModel.NodeType)
                        {
                            case SyntaxKind.ArrayType: // Handle Arrays
                                    builder.AppendFormat("{0} = {1},{2}", propertyModel.SyntaxName, CSharpTypesMapping.Map(propertyModel.PropertyType), Environment.NewLine);
                                break;
                            case SyntaxKind.GenericName: // Handle Lists
                                    builder.AppendFormat("{0} = {1},{2}", propertyModel.SyntaxName, CSharpTypesMapping.Map(propertyModel.PropertyType), Environment.NewLine);
                                break;
                            case SyntaxKind.ClassDeclaration: // Class Property
                                    builder.AppendFormat("{0} = {1},{2}", propertyModel.SyntaxName, CSharpTypesMapping.Map(propertyModel.PropertyType), Environment.NewLine);
                                break;
                            case SyntaxKind.PredefinedType: // Any Non Generic Property : bool
                            case SyntaxKind.IdentifierName: // Any Non Generic Property : Boolean
                            case SyntaxKind.NullableType: // Any Nullabe Type : Datetime?
                                    builder.AppendFormat("{0} = {1},{2}", propertyModel.SyntaxName, CSharpTypesMapping.Map(propertyModel.PropertyType), Environment.NewLine);
                                break;
                            default:
                                throw new NotImplementedException(string.Format("propertyModel.NodeType {0} not handled in WritePropertyMember, CSharpWriter", propertyModel.NodeType));
                        }
                    }
                    catch (Exception ex)
                    {
                        builder.AppendFormat("// Unknown Property : {0} {1}", propertyModel.SyntaxName, Environment.NewLine);
                    }
                }
            }
        }
    }
}
