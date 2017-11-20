using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodsTracer;

namespace XmlFormatterInterface
{
  public interface IXmlFormatter
  {
    void FormateToXml(Tracer tracer);
  }
}
