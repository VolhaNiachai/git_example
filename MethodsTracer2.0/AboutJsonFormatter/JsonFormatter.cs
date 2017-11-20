using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using JsonFormatterInterface;
using MethodsTracer;
using Newtonsoft.Json;

namespace AboutJsonFormatter
{
    public class JsonFormatter : IJsonFormatter
    {
        public void FormateToJson(Tracer tracer)
        {
            Tracer.GetInstance().GetTraceResult();
            using (StreamWriter streamWriter = new StreamWriter("ResultJson.json"))
            {
                streamWriter.Write(JsonConvert.SerializeObject(tracer.Result));
            }
        }
    }
}
