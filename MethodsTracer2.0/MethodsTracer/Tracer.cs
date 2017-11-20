using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using System.Threading;

namespace MethodsTracer
{
  public class Tracer : ITracer
  {
    public List<TraceResult> Result = new List<TraceResult>();
    //public TraceResult result;
    private static Tracer instance;
        //public Stopwatch stopWatch = new Stopwatch();
        //StackFrame stackFrame = new StackFrame();
        //StackTrace stackTrace = new StackTrace();
        public TraceResult TResult { get; set; }

        public Stopwatch Timer { get; set; }

    public void StartTrace()
    {
      Timer = new Stopwatch();
      Timer.Start();
    }

    public void StopTrace()
    {
        //var st = new StackTrace();
        //var currentMet = st.GetFrame(1);
        Timer.Stop();
        /*TResult = new TraceResult
        {
            MethodsName = currentMet.GetMethod().Name,
            MethodsTypeName = currentMet.GetMethod().DeclaringType.Name,
            QuantityOfParameters = currentMet.GetMethod().GetParameters().Length,
            CurrentTime = Timer.ElapsedMilliseconds
        };
        Result.Add(TResult);*/
     }

    //public void ToConsole()
    //    {
    //        foreach (var item in Result)
    //        {
    //            Console.WriteLine($"Class: {item.MethodsTypeName},method: {item.MethodsName},count: {item.QuantityOfParameters},time: {item.CurrentTime}");
    //        }
    //    }



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
        /*public List<TraceResult> GetListOfResults()
        {

          for (int i = 0; i < stackTrace.FrameCount; i++)
          {
            Result.Add(GetTraceResult(i, stackTrace));
          }
          return Result;
        }*/
  
    public static Tracer GetInstance()
    {
      if (instance == null)
        instance = new Tracer();
      return instance;
    }
  }
}


/*XmlSerializer serializer = new XmlSerializer(typeof(List<List<object>>));
using (FileStream fileStream = new FileStream("Results.xml", FileMode.OpenOrCreate))
{
  serializer.Serialize(fileStream, result.Result);*/

