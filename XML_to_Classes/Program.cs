namespace XML_to_Classes;

public class Program {
    public static void Main(string[] args) {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "sbe.v1.rc4.xml");
        var output = "example";
        XmlToClassConverter.ConvertXml(path, output);
    }
}