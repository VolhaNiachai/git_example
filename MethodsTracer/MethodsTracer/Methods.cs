using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using XmlFormatter;

namespace MethodsTracer
{
    public class Methods
    {
        Tracer tracer = Tracer.GetInstance();
        TraceResult traceResult = new TraceResult();
        static void Main(string[] args)
        {
            Methods methods = new Methods();
            methods.UpperTestMethod();
            methods.GetXml();
            Console.ReadKey();
        }
        public TimeSpan timeSpan;
        public void UpperTestMethod()
        {
            tracer.StartTrace();
            Thread.Sleep(50);
            LowerTestMethod();
            tracer.StopTrace();
        }
        public void LowerTestMethod()
        {
            tracer.StartTrace();
            Thread.Sleep(10);
            LostTestMethod();
            tracer.StopTrace();
        }
        public void LostTestMethod()
        {
            tracer.StartTrace();
            Thread.Sleep(18);
            tracer.GetListOfResults();
            tracer.OutputConsoleResult();
            tracer.StopTrace();
        }
        public void GetXml()
        {
            FormatterToXml formatterToXml = new FormatterToXml();
            formatterToXml.FormatToXml(tracer);
        }
    }
}
