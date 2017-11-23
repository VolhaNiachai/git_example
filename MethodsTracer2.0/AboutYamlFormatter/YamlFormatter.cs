using System;
using System.IO;
using MethodsTracer;
using System.Yaml.Serialization;
using LoaderOfPlagins;

namespace AboutYamlFormatter
{
    public class YamlFormatter : IPlugin
    {
        public void FormateToYaml(TraceResult traceResult, string path)
        {
            var serializer = new YamlSerializer();
            File.WriteAllText(@path, serializer.Serialize(traceResult));
        }
        public void Go(string parameters, string path)
        {
            FormateToYaml(Tracer.Instance.GetTraceResult(), path);
        }

        public string Name
        {
            get
            {
                return "yaml";
            }
        }

        public string Explanation
        {
            get
            {
                return "This plugin formates the file to yaml";
            }
        }
    }
}
