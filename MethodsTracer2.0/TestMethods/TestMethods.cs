using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using XmlFormatterInterface;
using MethodsTracer;
using ResultLoaderFormatter;

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
            Loader loader = new Loader();
            loader.Load("AboutJsonFormatter.dll");
            loader.Load("AboutYamlFormatter.dll");
            loader.Load("AboutXmlFormatter.dll");
            methods.UpperTestMethod();
            methods.menu.ChooseFormat(methods.tracer, loader);
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
