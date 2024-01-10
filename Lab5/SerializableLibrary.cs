using System.Text.Json;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Reflection.Emit;
using System.IO;

namespace Lab5;

public class SerializableLibrary : Library
{

    public string JsonSerialize()
    {
        return JsonSerializer.Serialize<IEnumerable<Book>>(_catalog);
    }

    public void JsonSerialize(string path)
    {
        string jsonString = JsonSerializer.Serialize<IEnumerable<Book>>(_catalog);
        File.WriteAllText(path, jsonString);

    }

    public string XmlSerialize()
    {
        var serializer = new XmlSerializer(typeof(List<Book>));
        using var writer = new StringWriter();
        serializer.Serialize(writer, _catalog);
        return writer.ToString();
    }

    public void XmlSeriaize(string path)
    {
        var serializer = new XmlSerializer(typeof(List<Book>));
        using var writer = new StringWriter();
        serializer.Serialize(writer, _catalog);
        File.WriteAllText(path, writer.ToString());
    }
    public void LoadFromJson(string json)
    {
        _catalog = JsonSerializer.Deserialize<List<Book>>(json);
    }

    public void LoadFromXml(string xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));

        using (StringReader stringReader = new StringReader(xml))
        {
            _catalog = (List<Book>)serializer.Deserialize(stringReader);
        }

    }
}
