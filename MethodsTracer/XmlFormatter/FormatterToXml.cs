using System;
using MethodsTracer;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Threading;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Linq;

namespace XmlFormatter
{
    public class FormatterToXml
    {
        
        public void FormatToXml(Tracer tracer)
        {
            List<TraceResult> Result = new List<TraceResult>(tracer.GetListOfResults());
            XmlSerializer serializer = new XmlSerializer(typeof(List<TraceResult>));
            StringBuilder emptyString = new StringBuilder();
            using (FileStream fileStream = new FileStream("Result.xml", FileMode.Create))
            {
                XDocument xDocument = new XDocument();
                XElement root = new XElement("root");
                XElement thread = new XElement("thread");
                thread.Add(new XAttribute("id",Thread.CurrentThread.ManagedThreadId.ToString()));
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
              /* XDocument xDocument = new XDocument(
                        new XElement("root",
                        new XElement("thread", "ID of the current thread", Thread.CurrentThread.ManagedThreadId,
                    from item in Result
                    select  new XElement("Results",
                            new XAttribute("MethodName", item.MethodsName),
                            new XAttribute("MethodsTypeName", item.MethodsTypeName),
                            new XAttribute("QuantityOfParameters", item.QuantityOfParameters),
                            new XElement("TimeSpan", item.CurrentTime)))));
                xDocument.Save(fileStream);*/
            }
        }
    }
}
