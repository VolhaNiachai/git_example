using System;
using MethodsTracer;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Threading;
using System.Text;
using System.IO;
using System.Xml.Linq;
using LoaderOfPlagins;

namespace AboutXmlFormatter
{
  public class XmlFormatter : IPlugin
  {
    public void FormateToXml()
    {

      List<TraceResult> Result = new List<TraceResult>(Tracer.GetInstance().Result);
      XmlSerializer serializer = new XmlSerializer(typeof(List<TraceResult>));
      StringBuilder emptyString = new StringBuilder();
      using (FileStream fileStream = new FileStream("Result.xml", FileMode.Create))
      {
        XDocument xDocument = new XDocument();
        XElement root = new XElement("root");
        XElement thread = new XElement("thread");
        thread.Add(new XAttribute("id", Thread.CurrentThread.ManagedThreadId.ToString()));
        xDocument.Add(root);
        root.Add(thread);
        foreach (var item in Result)
        {
          var element = new XElement("method");
          element.Add(new XAttribute("MethodName", item.MethodsName));
          element.Add(new XAttribute("MethodsTypeName", item.MethodsTypeName));
          element.Add(new XAttribute("QuantityOfParameters", item.QuantityOfParameters));
          element.Add(new XAttribute("TimeSpan", item.CurrentTime));
          thread.Add(element);
        }
        xDocument.Save(fileStream);
      }
    }
    public void Go(string parameters)
    {
            FormateToXml();
    }

    public string Name
    {
        get
        {
            return "xml";
        }
    }

    public string Explanation
    {
        get
        {
            return "This plugin formates the file to xml";
        }
    }
    }
}
