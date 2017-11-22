using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodsTracer;
using JsonFormatterInterface;
using System.Reflection;

namespace ResultLoaderFormatter
{
    public class JsonResultFormatter
    {
        public void FormateToJson(Tracer tracer, Assembly jsonFormatterAssembly)
        {
            foreach (Type type in jsonFormatterAssembly.GetExportedTypes())
            {
                if (type.IsClass && typeof(IJsonFormatter).IsAssignableFrom(type))
                {
                    IJsonFormatter jsonFormatter = (IJsonFormatter)Activator.CreateInstance(type);
                    jsonFormatter.FormateToJson(tracer);
                }
            }
        }
    }
}
