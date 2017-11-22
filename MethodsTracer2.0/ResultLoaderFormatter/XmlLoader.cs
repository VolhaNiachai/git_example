using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodsTracer;
using System.Reflection;
using System.IO;

namespace ResultLoaderFormatter
{
    public class XmlLoader
    {
        public Assembly XmlLoadedAssembly
        {get;set;}

        public void LoadXml(string pathName)
        {
            bool checker = true;
            while (checker)
            {
                try
                {
                    string formatterName = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                                      pathName);
                    if (!File.Exists(formatterName))
                    {
                        throw new ArgumentNullException();
                    }
                    XmlLoadedAssembly = Assembly.LoadFrom(formatterName);
                }
                catch(Exception)
                {
                    continue;
                }
            break;
            }
        }
    }
}
