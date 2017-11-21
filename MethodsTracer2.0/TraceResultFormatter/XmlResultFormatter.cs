using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MethodsTracer;
using XmlFormatterInterface;
using System.IO;
using System.Reflection;



namespace TraceResultFormatter
{
    public class XmlResultFormatter 
    {
        public void GetXml(Tracer tracer)
        {
            string AboutXmlFormatterName = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                                         "AboutXmlFormatter.dll");
            if (!File.Exists(AboutXmlFormatterName))
            {
                throw new ArgumentNullException();
            }
            Assembly AboutXmlFormatterAssembly = Assembly.LoadFrom(AboutXmlFormatterName);
            foreach (Type type in AboutXmlFormatterAssembly.GetExportedTypes())
            {
                if (type.IsClass && typeof(IXmlFormatter).IsAssignableFrom(type))
                {
                    IXmlFormatter xmlFormatter = (IXmlFormatter)Activator.CreateInstance(type);
                    xmlFormatter.FormateToXml(tracer);
                }
            }
        }
    }
}
