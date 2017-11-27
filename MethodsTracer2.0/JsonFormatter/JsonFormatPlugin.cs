using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using MethodsTracer;
using Newtonsoft.Json;
using PluginLoader;

namespace JsonFormatter
{
    public class JsonFormatPlugin : IFormatPlugin
    {
        public void Format(string path)
        {
            File.WriteAllText(@path, JsonConvert.SerializeObject(Tracer.Instance.Result));
        }
        public string Name
        {
            get
            {
                return "json";
            }
        }

        public string Explanation
        {
            get
            {
                return "This plugin formates the file to json";
            }
        }

    }
}
