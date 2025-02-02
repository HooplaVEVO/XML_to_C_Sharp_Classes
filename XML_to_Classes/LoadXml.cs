using System;
using System.Xml.Linq;

namespace XML_to_Classes
{
    public static class LoadXml
    {
       public static XElement From(string path) {
            return XElement.Load(path);
        }

        //Filter method if needed?
    }
}
