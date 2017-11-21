using System;
using YamlFormatterInterface;
using System.IO;
using MethodsTracer;
using System.Yaml.Serialization;

namespace AboutYamlFormatter
{
    public class YamlFormatter : IYamlFormatter
    {
        public void FormateToYaml(Tracer tracer)
        {
            using (StreamWriter streamWriter = new StreamWriter("YamlResult.yaml"))
            {
                var serializer = new YamlSerializer();
                streamWriter.Write(serializer.Serialize(tracer.Result));
            }
        }
    }
}
