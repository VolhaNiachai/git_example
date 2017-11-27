using System;
using System.IO;
using MethodsTracer;
using System.Yaml.Serialization;
using PluginLoader;

namespace YamlFormatter
{
    public class YamlFormatPlugin : IFormatPlugin
    {
        public void Format(string path)
        {
            var serializer = new YamlSerializer();
            File.WriteAllText(@path, serializer.Serialize(Tracer.Instance.Result));
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
