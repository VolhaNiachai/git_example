using System;
using System.Diagnostics;
using System.Threading;
using MethodsTracer;
using PluginLoader;
using System.Linq;

namespace TestMethods
{
    public class Methods
    {
        static void Main(string[] args)
        {
            Methods methods = new Methods();
            Console.WriteLine("This app is for transform document to xml, json, yaml formats");
            methods.UpperTestMethod();
            try
            {
                Loader loader = new Loader();
                loader.LoadPlugins();
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("There no loaded plugins", e.Message));
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                Environment.Exit(0);
            }
            bool checker = true;
            while (checker)
            {
                try
                {
                    if(args.Length == 0)
                    {
                        throw new ArgumentNullException();
                    }
                    if (args.Length == 1)
                    {
                        if (args[0] == "exit")
                        {
                            Environment.Exit(0);
                        }
                        if ((args[0] == "help") || (args[0] == "--h"))
                        {
                            Helper helper = new Helper();
                            helper.Help();
                            break;
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
                    if (args.Length > 2)
                    {
                        foreach (var plugin in Loader.Plugins)
                        {
                            if (plugin.Name.Equals(args[1]))
                            {
                                if (args[0] == "--f" && args[2] == "--o")
                                {
                                    plugin.Format(args[3]);
                                    break;
                                }
                            }
                        }
                    }
                    checker = false;
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("Enter any command");
                    break;
                }
                catch(Exception e)
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
