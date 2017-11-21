using System;
using System.Collections.Generic;
using System.Text;
using MethodsTracer;


namespace YamlFormatterInterface
{
    public interface IYamlFormatter
    {
        void FormateToYaml(Tracer tracer);
    }
}
