using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_to_Classes
{
    internal static class XmlToClassConverter
    {
        public static void ConvertXml(string path,string output) {
            var root = LoadXml.From(path);
            var classes = ClassExtractor.ExtractClasses(root);
            ClassWriter.Write(classes,output);

        }
    }
}
