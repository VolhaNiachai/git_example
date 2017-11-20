using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodsTracer;

namespace JsonFormatterInterface
{
  public interface IJsonFormatter
  {
    void FormateToJson(Tracer tracer);
  }
}
