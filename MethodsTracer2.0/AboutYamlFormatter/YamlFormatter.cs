using System;
using System.IO;
using MethodsTracer;
using System.Yaml.Serialization;
using LoaderOfPlagins;

namespace AboutYamlFormatter
{
    public class YamlFormatter : IPlugin
    {
        public void FormateToYaml()
        {
            using (StreamWriter streamWriter = new StreamWriter("YamlResult.yaml"))
            {
                var serializer = new YamlSerializer();
                streamWriter.Write(serializer.Serialize(Tracer.GetInstance().Result));
            }
        }
        public void Go(string parameters)
        {
            FormateToYaml();
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
