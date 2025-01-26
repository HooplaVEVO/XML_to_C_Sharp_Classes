using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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
