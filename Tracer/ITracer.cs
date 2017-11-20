using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace MethodsTracer
{
    public interface ITracer
    {
        // метод вызывается в начале замеряемого метода
        void StartTrace();

        // метод вызывается в конце замеряемого метода
        void StopTrace();

        // возвращает объект с результатами измерений
        TraceResult GetTraceResult();
    }
}
