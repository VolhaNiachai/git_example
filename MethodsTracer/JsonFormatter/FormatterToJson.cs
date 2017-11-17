using System;
using System.Dynamic;
using MethodsTracer;
using System.Collections.Generic;

namespace JsonFormatter
{
    public class FormatterToJson
    {
        public void FotmattoJson(Tracer tracer)
        {
            List<TraceResult> Result = new List<TraceResult>(tracer.GetListOfResults());
            var ResultToJson = new ExpandoObject() as IDictionary<string, object>;
            foreach(var item in Result)
            {
                ResultToJson["MethodsName"] = item.MethodsName;
                ResultToJson["MethodsTypeName"] = item.MethodsTypeName;
                ResultToJson["QuantityOfParameters"] = item.QuantityOfParameters;
                ResultToJson["Current time"] = item.CurrentTime;
            }
            
        }
    }
}
