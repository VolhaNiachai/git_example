using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MethodsTracer;
using System.IO;
using JsonFormatterInterface;

namespace TraceResultFormatter
{
    public class JsonResultFormatter
    {
        public void GetJson(Tracer tracer)
        {
            string AboutJsonFormatterName = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                                         "AboutJsonFormatter.dll");
            if (!File.Exists(AboutJsonFormatterName))
            {
                throw new ArgumentNullException();
            }
            Assembly AboutJsonFormatterAssembly = Assembly.LoadFrom(AboutJsonFormatterName);
            foreach (Type type in AboutJsonFormatterAssembly.GetExportedTypes())
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
