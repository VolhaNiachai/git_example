using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace MethodsTracer
{
  public interface ITracer
  {
    void StartTrace();
    void StopTrace();
  }
}
