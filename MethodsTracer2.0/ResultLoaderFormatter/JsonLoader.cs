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
    public class JsonLoader
    {
        public Assembly JsonLoadedAssembly
        { get; set; }

        public void LoadJson(string pathName)
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
                    JsonLoadedAssembly = Assembly.LoadFrom(formatterName);
                }
                catch (Exception)
                {
                    continue;
                }
                break;
            }
        }
    }
}
