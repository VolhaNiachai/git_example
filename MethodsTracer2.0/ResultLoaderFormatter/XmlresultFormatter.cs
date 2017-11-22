using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodsTracer;
using XmlFormatterInterface;
using System.Reflection;

namespace ResultLoaderFormatter
{
    public class XmlResultFormatter
    {
        public void FormateToXml(Tracer tracer, Assembly xmlFormatterAssembly)
        {
            foreach (Type type in xmlFormatterAssembly.GetExportedTypes())
            {
                if (type.IsClass && typeof(IXmlFormatter).IsAssignableFrom(type))
                {
                    IXmlFormatter jsonFormatter = (IXmlFormatter)Activator.CreateInstance(type);
                    jsonFormatter.FormateToXml(tracer);
                }
            }
        }
    }
}