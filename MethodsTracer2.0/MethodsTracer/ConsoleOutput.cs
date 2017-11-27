using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsTracer
{
    public class ConsoleOutput
    {
        public void OutputToConsole()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < Tracer.GetInstance().Result.Count; i++)
            {
                stringBuilder.AppendLine(Tracer.GetInstance().Result[i].MethodsName);
                stringBuilder.AppendLine(Tracer.GetInstance().Result[i].MethodsTypeName);
                stringBuilder.AppendLine(Tracer.GetInstance().Result[i].QuantityOfParameters.ToString());
                stringBuilder.AppendLine(Tracer.GetInstance().Result[i].CurrentTime.ToString());
                stringBuilder.Append("\n");
            }
            Console.WriteLine(stringBuilder);
        }
    }
}

