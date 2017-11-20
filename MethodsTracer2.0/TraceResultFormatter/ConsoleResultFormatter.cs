using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodsTracer;

namespace TraceResultFormatter
{
    public class ConsoleResultFormatter
    {
        public void OutputConsoleResult(Tracer tracer)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<TraceResult> Result = new List<TraceResult>(tracer.Result);
            for (int i = 0; i < Result.Count; i++)
            {
                stringBuilder.Append(Result[i].MethodsName);
                stringBuilder.Append(Result[i].MethodsTypeName);
                stringBuilder.Append(Result[i].QuantityOfParameters);
                stringBuilder.Append(Result[i].CurrentTime);
                stringBuilder.Append("\n");
            }
            Console.WriteLine(stringBuilder);
        }
    }
}
