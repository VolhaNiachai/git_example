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
        private static Tracer instance;
        public Stopwatch stopWatch = new Stopwatch();
        StackFrame stackFrame = new StackFrame();
        //StackTrace stackTrace = new StackTrace();
        public List<TraceResult> Result = new List<TraceResult>();
        public void StartTrace()
        {
            stopWatch.Start();
        }
        public void StopTrace()
        {
            stopWatch.Stop();
        }

        public TraceResult GetTraceResult(int currentNumberOfMethod, StackTrace stackTrace)
        {
            TraceResult result = new TraceResult();
            StartTrace();
            Thread.Sleep(50);
            result.MethodsName = stackTrace.GetFrame(currentNumberOfMethod).GetMethod().Name;
            result.MethodsTypeName = stackTrace.GetFrame(currentNumberOfMethod).GetMethod().DeclaringType.Name;
            result.QuantityOfParameters = stackTrace.GetFrame(currentNumberOfMethod).GetMethod().GetParameters().Length;
            result.CurrentTime = stopWatch.ElapsedMilliseconds;
            /*for (int i = 0; i < Results.Count; i++)
            {
              for (int j = 0; j < Results[i].Count; j++)
              {
                Console.WriteLine(Results[i][j]);
              }
            }*/
            return result;
        }
        public List<TraceResult> GetListOfResults()
        {
            StackTrace stackTrace = new StackTrace();
            //TraceResult traceResult;
            for (int i = 0; i < stackTrace.FrameCount; i++)
            {
                Result.Add(GetTraceResult(i, stackTrace));
            }
            return Result;
        }
        public void OutputConsoleResult()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < Result.Count; i++)
            {
                stringBuilder.Append(Result[i].MethodsName);
                stringBuilder.Append(Result[i].MethodsTypeName);
                stringBuilder.Append(Result[i].QuantityOfParameters);
                stringBuilder.Append(Result[i].CurrentTime);
                stringBuilder.Append("\n");
            }
            Console.WriteLine(stringBuilder);
        }
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

