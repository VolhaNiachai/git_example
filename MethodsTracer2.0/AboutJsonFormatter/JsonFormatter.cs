using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using MethodsTracer;
using Newtonsoft.Json;
using LoaderOfPlagins;

namespace AboutJsonFormatter
{
    public class JsonFormatter : IPlugin
    {
        public void FormateToJson(TraceResult traceResult, string path)
         {
            File.WriteAllText(@path, JsonConvert.SerializeObject(traceResult));
         }
        public void Go(string parameters, string path)
        {
            FormateToJson(Tracer.Instance.GetTraceResult(), path);
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
