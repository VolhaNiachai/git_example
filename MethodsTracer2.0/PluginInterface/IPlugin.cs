using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodsTracer;

namespace LoaderOfPlagins
{
    public interface IPlugin
    {
        string Name { get; }
        string Explanation { get; }
        void Go(string patameters);
    }
}
