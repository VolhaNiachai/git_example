using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodsTracer;

namespace ITraceResultFormatter
{
  public interface ITraceResultFormatter
  {
    string GetFormat();
    void Format(TraceResult traceResult);
  }
}
