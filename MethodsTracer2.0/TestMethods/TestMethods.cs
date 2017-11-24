using System;
using System.Diagnostics;
using System.Threading;
using MethodsTracer;
using LoaderOfPlagins;
using System.Linq;

namespace TestMethods
{
    public class Methods
    {
        TraceResult traceResult = new TraceResult();

        static void Main(string[] args)
        {
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
            bool checker = true;
            while (checker)
            {
                try
                {
                    if (args.Length == 1)
                    {
                        if (args[0] == "exit")
                        {
                            Environment.Exit(0);
                        }
                        if (args[0] == "help")
                        {
                            Helper helper = new Helper();
                            helper.Go(args[0], string.Empty);
                        }
                    }
                    if (args.Length <= 2)
                    {
                        if (args[1] == "console")
                        {
                            ConsoleOutput consoleOutPut = new ConsoleOutput();
                            consoleOutPut.OutputToConsole();
                        }
                        else
                        {
                            Console.WriteLine("Enter path");
                        }
                    }
                    if(args.Length > 2)
                    {
                        foreach (IPlugin plugin in PluginLoader.Plugins)
                        {
                            if (plugin.Name.Equals(args[1]))
                            {
                                if (args[0] == "--f" && args[2] == "--o")
                                {
                                    plugin.Go(args[1], args[3]);
                                    break;
                                }
                            }
                        }
                    }                   
                    checker = false;
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
