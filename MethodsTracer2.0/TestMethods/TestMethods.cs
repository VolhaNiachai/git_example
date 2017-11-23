using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using XmlFormatterInterface;
using MethodsTracer;
using ResultLoaderFormatter;
using LoaderOfPlagins;
using System.Linq;
using AboutJsonFormatter;

namespace TestMethods
{
  public class Methods
  {
    TraceResult traceResult = new TraceResult();
    Tracer tracer = Tracer.GetInstance();
    
    static void Main(string[] args)
    {
            JsonFormatter jsonFormatter = new JsonFormatter();
            Methods methods = new Methods();
            PluginLoader pluginloader = new PluginLoader();
            try
            {
                PluginLoader loader = new PluginLoader();
                loader.LoadPlugins();
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Plugins couldn't be loaded: {0}", e.Message));
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                Environment.Exit(0);
            }
            while (true)
            {
                try
                {
                    string line = Console.ReadLine();
                    string name = line.Split(new char[] { ' ' }).FirstOrDefault();
                    if (line == "exit")
                    {
                        Environment.Exit(0);
                    }
                    foreach(IPlugin plugin in PluginLoader.Plugins)
                    {
                        if (plugin.Name.Equals(name))
                        {
                            string parameters = line.Replace(string.Format("{0} ", name), string.Empty);
                            plugin.Go(parameters);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(string.Format("Caught exception: {0}", e.Message));
                }
            }
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
