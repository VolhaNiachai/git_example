using System;
using System.Diagnostics;
using System.Threading;
using MethodsTracer;
using LoaderOfPlagins;
using System.Linq;
using AboutJsonFormatter;

namespace TestMethods
{
    public class Methods
    {
    TraceResult traceResult = new TraceResult();
    
        static void Main(string[] args)
        {
            JsonFormatter jsonFormatter = new JsonFormatter();
            Methods methods = new Methods();
            methods.UpperTestMethod();
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
                    string inputedLine = Console.ReadLine();
                    if (inputedLine == "exit")
                    {
                        Environment.Exit(0);
                    }
                    if (inputedLine.Contains("console"))
                    {
                        ConsoleOutput consoleOutPut = new ConsoleOutput();
                        consoleOutPut.OutputToConsole();
                        continue;
                    }
                    if (inputedLine.Contains("--f") && (!inputedLine.Contains("--o")))
                    {
                        Console.WriteLine("Enter path");
                        continue;
                    }
                    string[] inputedLines = inputedLine.Split().ToArray();
                    string formatName = String.Empty;
                    if(inputedLines.Length == 1)
                    {
                        formatName = inputedLines[0];
                    }
                    else
                    {
                        formatName = inputedLines[1];
                    }
          
                    foreach(IPlugin plugin in PluginLoader.Plugins)
                    {
                        if (plugin.Name.Equals(formatName))             
                        {
                           
                                if (inputedLine.Contains("--f") && inputedLine.Contains("--o"))
                            {
                                string path = inputedLines[3];
                                string parameters = inputedLine[1].ToString().Replace(string.Format("{0} ", formatName), string.Empty);
                                plugin.Go(parameters, path);
                                break;
                            }
                            string helpParameters = inputedLine[1].ToString().Replace(string.Format("{0} ", formatName), string.Empty);
                            plugin.Go(helpParameters, String.Empty);
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
        Tracer.Instance.StartTrace();
        Stopwatch currentTime = Tracer.Instance.Timer;
        Thread.Sleep(50);
        LowerTestMethod();
        Tracer.Instance.Timer = currentTime;
        Tracer.Instance.StopTrace();
        Tracer.Instance.GetTraceResult();
    }
    public void LowerTestMethod()
    {
          
        Tracer.Instance.StartTrace();
        Stopwatch currentTime = Tracer.Instance.Timer;
        Thread.Sleep(10);
        LostTestMethod();
        Tracer.Instance.Timer = currentTime;
        Tracer.Instance.StopTrace();
        Tracer.Instance.GetTraceResult();

    }
    public void LostTestMethod()
    {
        Tracer.Instance.StartTrace();
        Stopwatch currentTime = Tracer.Instance.Timer;
        Thread.Sleep(18);
        Tracer.Instance.Timer = currentTime;
        Tracer.Instance.StopTrace();
        Tracer.Instance.GetTraceResult();
    }   
  }
}
