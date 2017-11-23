using System.Collections.Generic;
using System.Diagnostics;

namespace MethodsTracer
{
  public class Tracer : ITracer
  {
    public List<TraceResult> Result = new List<TraceResult>();
        private static Tracer instance = null;

        public static Tracer Instance => instance ?? (instance = new Tracer());
        public TraceResult TResult { get; set; }

        public Stopwatch Timer { get; set; }

    public void StartTrace()
    {
      Timer = new Stopwatch();
      Timer.Start();
    }

    public void StopTrace()
    {
        Timer.Stop();
     }
        public TraceResult GetTraceResult()
        {
            StackTrace stackTrace = new StackTrace();
            TraceResult result = new TraceResult();
            result = new TraceResult();
                result.MethodsName = stackTrace.GetFrame(1).GetMethod().Name;
                result.MethodsTypeName = stackTrace.GetFrame(1).GetMethod().DeclaringType.Name;
                result.QuantityOfParameters = stackTrace.GetFrame(1).GetMethod().GetParameters().Length;
                result.CurrentTime = Timer.ElapsedMilliseconds;
                Result.Add(result);
            return result;
        }
  }
}


