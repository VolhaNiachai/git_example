using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodsTracer;

namespace PluginLoader
{
    public interface IFormatPlugin
    {
        string Name { get; }
        string Explanation { get; }
        void Format(string path);
    }
}