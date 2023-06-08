using System;
using System.IO;
using System.Xml;

namespace learnCsharp;

public class UseXml
{
    static readonly string androidURI = "http://schemas.android.com/apk/res/android";

    public static void one()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("../../../../haha.xml");
        var app = doc.SelectSingleNode("//application");
        var appIdNode = doc.CreateElement("meta-data");
        appIdNode.SetAttribute("name", androidURI, "pvr.app.id");
        appIdNode.SetAttribute("value", androidURI, "12341341234");
        app.AppendChild(appIdNode);
        Console.WriteLine(doc.OuterXml);
        doc.Save("baga.xml");
        Console.WriteLine(Path.GetFullPath("baga.xml"));
    }
}