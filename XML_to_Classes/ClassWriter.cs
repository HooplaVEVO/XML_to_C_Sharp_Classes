using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_to_Classes
{
    internal static class ClassWriter
    {
        public static void Write(IEnumerable<Class> classes, string fileName) {
            var textWriter = new StreamWriter(fileName+".cs");

            using (textWriter) {
                foreach (var @class in classes) {
                    //Write Headers
                    textWriter.WriteLine("[System.SerializableAttribute()]");
                    textWriter.WriteLine("[System.ComponentModel.DesignerCategoryAttribute(\"code\")]");
                    // Will need dynamic header writing eventually
                    // Write class-level attributes
                    if (@class.isRoot) {
                        textWriter.WriteLine("[XmlRoot(ElementName=\"{0}\", Namespace=\"{1}\",IsNullable=false)]", @class.Name, @class.Namespace);
                    }
                    //textWriter.WriteLine("[System.Xml.Serialization.XmlElementAttribute(\"{0}\")]", @class.XmlName);
                    textWriter.WriteLine("[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]");
                    textWriter.WriteLine("public partial class {0} {{", @class.Name);
                    textWriter.WriteLine();

                    //Write field declarations
                    foreach (var field in @class.Fields) {
                        textWriter.WriteLine("private {0} {1};",field.Type,ToCamelCase(field.Name+"Field"));
                        textWriter.WriteLine();
                    }

                    // Write fields getters/setters
                    foreach (var field in @class.Fields) {
                        var attributeType = field.XmlType == XmlType.Element ? "Element" : "Attribute";
                        //Conditional checking for invalid names
                        if(field.Name == "enum"||field.Name == "class") {
                            field.Name = '@' + field.Name;
                        }
                        textWriter.WriteLine("    [Xml{0}({0}Name=\"{1}\", Namespace=\"{2}\")]", attributeType, field.Name, field.Namespace);
                        textWriter.WriteLine("    public {0} {1} {{ get; set; }}", field.Type, field.Name);
                    }

                    textWriter.WriteLine("}");
                    textWriter.WriteLine(); // Add a blank line between classes for readability
                }
            }
        }
        public static string ToCamelCase(string input) {
            if (string.IsNullOrEmpty(input)) return input;

            var words = input.Split(new[] { '_', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var camelCaseString = words[0].ToLower();

            for (int i = 1; i < words.Length; i++) {
                camelCaseString += Char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }

            return camelCaseString;
        }
    }
}
