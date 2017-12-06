using System;
using System.Diagnostics;
using System.Threading;
using MethodsTracer;
using PluginLoader;

namespace TestMethods
{
    public class Methods
    {
        static void Main(string[] args)
        {
            Methods methods = new Methods();
            Tracer.GetInstance();
            Console.WriteLine("This app is for transform document to xml, json, yaml formats");
            methods.UpperTestMethod();
            try
            {
                Loader loader = new Loader();
                loader.LoadPlugins();
                loader.CollectPlugins();
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
                    if (args.Length == 0)
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
                            Helper.Help(Loader.Plugins);
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
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Enter any command");
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(string.Format("Caught exception: {0}", e.Message));
                    continue;
                }
            }
        }

        public TimeSpan timeSpan;

        public void UpperTestMethod()
        {
            Tracer.GetInstance().StartTrace();
            Stopwatch currentTime = Tracer.GetInstance().Timer;
            Thread.Sleep(50);
            LowerTestMethod();
            Tracer.GetInstance().Timer = currentTime;
            Tracer.GetInstance().StopTrace();
        }
        public void LowerTestMethod()
        {
            Tracer.GetInstance().StartTrace();
            Stopwatch currentTime = Tracer.GetInstance().Timer;
            Thread.Sleep(10);
            LostTestMethod();
            Tracer.GetInstance().Timer = currentTime;
            Tracer.GetInstance().StopTrace();
        }
        public void LostTestMethod()
        {
            Tracer.GetInstance().StartTrace();
            Stopwatch currentTime = Tracer.GetInstance().Timer;
            Thread.Sleep(18);
            Tracer.GetInstance().Timer = currentTime;
            Tracer.GetInstance().StopTrace();
        }
    }
}
