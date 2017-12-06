using System.Collections.Generic;
using System.Diagnostics;

namespace MethodsTracer
{
    public class Tracer : ITracer
    {
        public List<TraceResult> Result { get; private set; }
        private static Tracer instance = null;
        public Stopwatch Timer { get; set; }

        public static Tracer GetInstance()
        {
            if (instance == null)
            {
                instance = new Tracer() { Result = new List<TraceResult>() };
            }
            return instance;
        }

        public void StartTrace()
        {
            Timer = new Stopwatch();
            Timer.Start();
        }

        public void StopTrace()
        {
            Timer.Stop();
            GetTraceResult();
        }

        private void GetTraceResult()
        {
            StackTrace stackTrace = new StackTrace();
            TraceResult result = new TraceResult();
            result = new TraceResult();
            result.MethodsName = stackTrace.GetFrame(2).GetMethod().Name;
            result.MethodsTypeName = stackTrace.GetFrame(2).GetMethod().DeclaringType.Name;
            result.QuantityOfParameters = stackTrace.GetFrame(2).GetMethod().GetParameters().Length;
            result.CurrentTime = Timer.ElapsedMilliseconds;
            Result.Add(result);
        }
    }
}


