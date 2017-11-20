using System;
using YamlDotNet.Serialization;
using YamlFormatterInterface;
using System.IO;
using MethodsTracer;
using System.Yaml.Serialization;

namespace AboutYamlFormatter
{
    public class YamlFormatter:IYamlFormatter
    {
       public void FormateToaml(Tracer tracer)
       {
            var serializer = new YamlSerializer();
            Console.WriteLine( serializer.Serialize(tracer.Result));
        }
    }
}
