using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsTracer
{
    public class ConsoleOutput
    {
        StringBuilder stringBuilder = new StringBuilder();

        public void OutputToConsole()
        {
            for (int i = 0; i < Tracer.Instance.Result.Count; i++)
            {
                stringBuilder.AppendLine(Tracer.Instance.Result[i].MethodsName);
                stringBuilder.AppendLine(Tracer.Instance.Result[i].MethodsTypeName);
                stringBuilder.AppendLine(Tracer.Instance.Result[i].QuantityOfParameters.ToString());
                stringBuilder.AppendLine(Tracer.Instance.Result[i].CurrentTime.ToString());
                stringBuilder.Append("\n");
            }
            Console.WriteLine(stringBuilder);
        }
    }
}
    
