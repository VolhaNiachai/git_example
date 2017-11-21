using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MethodsTracer;
using YamlFormatterInterface;
using System.IO;
using System.Reflection;

namespace TraceResultFormatter
{
    public class YamlResultFormatter
    {
        public void GetYaml(Tracer tracer)
        {
            string AboutYamlFormatterName = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                                         "AboutYamlFormatter.dll");
            if (!File.Exists(AboutYamlFormatterName))
            {
                throw new ArgumentNullException();
            }
            Assembly AboutYamlFormatterAssembly = Assembly.LoadFrom(AboutYamlFormatterName);
            foreach (Type type in AboutYamlFormatterAssembly.GetExportedTypes())
            {
                if (type.IsClass && typeof(IYamlFormatter).IsAssignableFrom(type))
                {
                    IYamlFormatter yamlFormatter = (IYamlFormatter)Activator.CreateInstance(type);
                    yamlFormatter.FormateToYaml(tracer);
                }
            }
        }
    }
}

