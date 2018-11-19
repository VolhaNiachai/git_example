using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsTracer
{
  public class TraceResult
  {
    public string MethodsName { get; set; }
    public string MethodsTypeName { get; set; }
    public int QuantityOfParameters { get; set; }
    public long CurrentTime { get; set; }
  }
}
