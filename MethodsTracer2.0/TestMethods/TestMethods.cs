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
            XmlLoader xmlLoader = new XmlLoader();
            xmlLoader.LoadXml("AboutXmlFormatter.dll");
            JsonLoader jsonLoader = new JsonLoader();
            jsonLoader.LoadJson("AboutJsonFormatter.dll");
            YamlLoader yamlLoader = new YamlLoader();
            yamlLoader.LoadYaml("AboutYamlFormatter.dll");
            methods.UpperTestMethod();
            if (args[0].Equals("--h"))
            {
                methods.menu.ChooseFormat(methods.tracer, xmlLoader, jsonLoader, yamlLoader);
            }
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
