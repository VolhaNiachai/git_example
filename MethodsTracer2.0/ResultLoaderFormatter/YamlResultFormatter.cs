using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodsTracer;
using YamlFormatterInterface;
using System.Reflection;

namespace ResultLoaderFormatter
{
    public class YamlResultFormatter
    {
        public void FormateToYaml(Tracer tracer, Assembly yamlFormatterAssembly)
        {
            foreach (Type type in yamlFormatterAssembly.GetExportedTypes())
            {
                if (type.IsClass && typeof(IYamlFormatter).IsAssignableFrom(type))
                {
                    IYamlFormatter jsonFormatter = (IYamlFormatter)Activator.CreateInstance(type);
                    jsonFormatter.FormateToYaml(tracer);
                }
            }
        }
    }
}