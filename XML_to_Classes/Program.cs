using System.Xml.Linq;
using System.Xml.Serialization;

namespace XML_to_Classes;

public class Program {
    public static void Main(string[] args) {
        var xmlPath = Path.Combine(Directory.GetCurrentDirectory(), "sbe.v1.rc4.xml");
        var output = "example";
        XmlToClassConverter.ConvertXml(xmlPath, output);

        
        // Create an instance of XmlSerializer for the root class
        XmlSerializer serializer = new XmlSerializer(typeof(messageSchema));

        // Deserialize the XML into an object
        using (FileStream stream = new FileStream(xmlPath, FileMode.Open)) {
            var messageSchema = (messageSchema)serializer.Deserialize(stream);
            // Process the deserialized object
            var messages = messageSchema.message;
            foreach (var message in messages) {
                Console.WriteLine($"Message Name: {message.name}, ID: {message.id}, Block Length: {message.blockLength}");
            }
        }
        
    }
}
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class typesType
{

    private String lengthfield;

    private String namefield;

    private String primitivetypefield;

    [XmlAttribute(AttributeName = "length", Namespace = "")]
    public String length { get; set; }
    [XmlAttribute(AttributeName = "name", Namespace = "")]
    public String name { get; set; }
    [XmlAttribute(AttributeName = "primitiveType", Namespace = "")]
    public String primitiveType { get; set; }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class compositeType
{

    private String namefield;

    private String primitivetypefield;

    [XmlAttribute(AttributeName = "name", Namespace = "")]
    public String name { get; set; }
    [XmlAttribute(AttributeName = "primitiveType", Namespace = "")]
    public String primitiveType { get; set; }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class typesComposite
{

    private List<compositeType> typefield;

    private String namefield;

    [XmlElement(ElementName = "type", Namespace = "")]
    public List<compositeType> type { get; set; }
    [XmlAttribute(AttributeName = "name", Namespace = "")]
    public String name { get; set; }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class enumValidValue
{

    private String namefield;

    [XmlAttribute(AttributeName = "name", Namespace = "")]
    public String name { get; set; }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class typesEnum
{

    private List<enumValidValue> validvaluefield;

    private String encodingtypefield;

    private String namefield;

    [XmlElement(ElementName = "validValue", Namespace = "")]
    public List<enumValidValue> validValue { get; set; }
    [XmlAttribute(AttributeName = "encodingType", Namespace = "")]
    public String encodingType { get; set; }
    [XmlAttribute(AttributeName = "name", Namespace = "")]
    public String name { get; set; }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class setChoice
{

    private String namefield;

    [XmlAttribute(AttributeName = "name", Namespace = "")]
    public String name { get; set; }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class typesSet
{

    private List<setChoice> choicefield;

    private String encodingtypefield;

    private String namefield;

    [XmlElement(ElementName = "choice", Namespace = "")]
    public List<setChoice> choice { get; set; }
    [XmlAttribute(AttributeName = "encodingType", Namespace = "")]
    public String encodingType { get; set; }
    [XmlAttribute(AttributeName = "name", Namespace = "")]
    public String name { get; set; }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class messageSchemaTypes
{

    private List<typesType> typefield;

    private List<typesComposite> compositefield;

    private List<typesEnum> enumfield;

    private List<typesSet> setfield;

    [XmlElement(ElementName = "type", Namespace = "")]
    public List<typesType> type { get; set; }
    [XmlElement(ElementName = "composite", Namespace = "")]
    public List<typesComposite> composite { get; set; }
    [XmlElement(ElementName = "@enum", Namespace = "")]
    public List<typesEnum> @enum { get; set; }
    [XmlElement(ElementName = "set", Namespace = "")]
    public List<typesSet> set { get; set; }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class messageField
{

    private String idfield;

    private String namefield;

    private String typefield;

    [XmlAttribute(AttributeName = "id", Namespace = "")]
    public String id { get; set; }
    [XmlAttribute(AttributeName = "name", Namespace = "")]
    public String name { get; set; }
    [XmlAttribute(AttributeName = "type", Namespace = "")]
    public String type { get; set; }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class messageSchemaMessage
{

    private List<messageField> fieldfield;

    private String blocklengthfield;

    private String idfield;

    private String namefield;

    [XmlElement(ElementName = "field", Namespace = "")]
    public List<messageField> field { get; set; }
    [XmlAttribute(AttributeName = "blockLength", Namespace = "")]
    public String blockLength { get; set; }
    [XmlAttribute(AttributeName = "id", Namespace = "")]
    public String id { get; set; }
    [XmlAttribute(AttributeName = "name", Namespace = "")]
    public String name { get; set; }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class groupField
{

    private String idfield;

    private String namefield;

    private String presencefield;

    private String typefield;

    [XmlAttribute(AttributeName = "id", Namespace = "")]
    public String id { get; set; }
    [XmlAttribute(AttributeName = "name", Namespace = "")]
    public String name { get; set; }
    [XmlAttribute(AttributeName = "presence", Namespace = "")]
    public String presence { get; set; }
    [XmlAttribute(AttributeName = "type", Namespace = "")]
    public String type { get; set; }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class messageGroup
{

    private groupField fieldfield;

    private String idfield;

    private String dimensiontypefield;

    private String namefield;

    [XmlElement(ElementName = "field", Namespace = "")]
    public groupField field { get; set; }
    [XmlAttribute(AttributeName = "id", Namespace = "")]
    public String id { get; set; }
    [XmlAttribute(AttributeName = "dimensionType", Namespace = "")]
    public String dimensionType { get; set; }
    [XmlAttribute(AttributeName = "name", Namespace = "")]
    public String name { get; set; }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class messageData
{

    private String namefield;

    private String typefield;

    private String idfield;

    private String semantictypefield;

    private String descriptionfield;

    [XmlAttribute(AttributeName = "name", Namespace = "")]
    public String name { get; set; }
    [XmlAttribute(AttributeName = "type", Namespace = "")]
    public String type { get; set; }
    [XmlAttribute(AttributeName = "id", Namespace = "")]
    public String id { get; set; }
    [XmlAttribute(AttributeName = "semanticType", Namespace = "")]
    public String semanticType { get; set; }
    [XmlAttribute(AttributeName = "description", Namespace = "")]
    public String description { get; set; }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlRoot(ElementName = "messageSchema", Namespace = "http://fixprotocol.io/2016/sbe", IsNullable = false)]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class messageSchema
{

    private messageSchemaTypes typesfield;

    private List<messageSchemaMessage> messagefield;

    private String sbefield;

    private String xsifield;

    private String byteorderfield;

    private String idfield;

    private String packagefield;

    private String semanticversionfield;

    private String versionfield;

    private String schemalocationfield;

    [XmlElement(ElementName = "types", Namespace = "")]
    public messageSchemaTypes types { get; set; }
    [XmlElement(ElementName = "message", Namespace = "http://fixprotocol.io/2016/sbe")]
    public List<messageSchemaMessage> message { get; set; }
    [XmlAttribute(AttributeName = "sbe", Namespace = "http://www.w3.org/2000/xmlns/")]
    public String sbe { get; set; }
    [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
    public String xsi { get; set; }
    [XmlAttribute(AttributeName = "byteOrder", Namespace = "")]
    public String byteOrder { get; set; }
    [XmlAttribute(AttributeName = "id", Namespace = "")]
    public String id { get; set; }
    [XmlAttribute(AttributeName = "package", Namespace = "")]
    public String package { get; set; }
    [XmlAttribute(AttributeName = "semanticVersion", Namespace = "")]
    public String semanticVersion { get; set; }
    [XmlAttribute(AttributeName = "version", Namespace = "")]
    public String version { get; set; }
    [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public String schemaLocation { get; set; }
}

