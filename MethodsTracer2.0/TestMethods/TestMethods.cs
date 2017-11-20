using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using XmlFormatterInterface;
using MethodsTracer;

namespace TestMethods
{
  public class Methods
  {
    TraceResult traceResult = new TraceResult();
    Tracer tracer = Tracer.GetInstance();
    Menu menu = new Menu();
    static void Main(string[] args)
    {
            Methods methods = new Methods();
            methods.UpperTestMethod();
            methods.menu.ChooseFormat(methods.tracer);
            Console.ReadKey();
    }

    public TimeSpan timeSpan;

    public void UpperTestMethod()
    {
            tracer.StartTrace();
            Stopwatch currentTime = tracer.Timer;
            Thread.Sleep(50);
            LowerTestMethod();
            tracer.Timer = currentTime;
            tracer.StopTrace();
            tracer.GetTraceResult();
    }
    public void LowerTestMethod()
    {
          
            tracer.StartTrace();
            Stopwatch currentTime = tracer.Timer;
            Thread.Sleep(10);
            LostTestMethod();
            tracer.Timer = currentTime;
            tracer.StopTrace();
            tracer.GetTraceResult();

    }
    public void LostTestMethod()
    {
            tracer.StartTrace();
            Stopwatch currentTime = tracer.Timer;
            Thread.Sleep(18);
            tracer.Timer = currentTime;
            tracer.StopTrace();
            tracer.GetTraceResult();
    }
  }
}
