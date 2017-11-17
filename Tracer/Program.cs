using System;
using System.Collections.Generic;
using System.Text;

namespace MethodsTracer
{
    public class Program
    {
        Tracer tracer = Tracer.GetInstance();
        TraceResult traceResult = new TraceResult();
        public TimeSpan timeSpan;
        static void Main(string[] args)
        {
            TraceResult traceResult = new TraceResult();
            /*List<List<object>> Result = traceResult.Result;
            for(int i = 0; i < traceResult.Result.Count; i++)
            {
                for(int j = 0; j < traceResult.Result[i].Count; i++)
                {
                    Console.WriteLine(traceResult.Result[i][j]);
                }
            }*/
           // traceROutputResult();
            Console.ReadKey();
        }
        /*public int UpperTestMethod()
        {
            tracer.StartTrace();
            LowerTestMethod();
            tracer.StopTrace();
            return timeSpan.Milliseconds;
        }
        public int LowerTestMethod()
        {
            tracer.StartTrace();
            traceResult.GetResult();
            tracer.StopTrace();
            return timeSpan.Milliseconds;
        }*/
    }
}
