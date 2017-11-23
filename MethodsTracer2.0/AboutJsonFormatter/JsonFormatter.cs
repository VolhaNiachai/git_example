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
using LoaderOfPlagins;

namespace AboutJsonFormatter
{
    public class JsonFormatter : IPlugin
    {
        public void FormateToJson()
         {
             Tracer.GetInstance().GetTraceResult();
             using (StreamWriter streamWriter = new StreamWriter("ResultJson.json"))
             {
                 streamWriter.Write(JsonConvert.SerializeObject(Tracer.GetInstance().Result));
             }
         }
        public void Go(string parameters)
        {
            FormateToJson();
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
