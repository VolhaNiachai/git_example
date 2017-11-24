using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoaderOfPlagins
{
    public class Helper:IPlugin
    {
        public void Go(string parameters, string path)
        {
            foreach(IPlugin plugin in PluginLoader.Plugins)
            {
                Console.WriteLine(plugin.Name + plugin.Explanation);
            }
        }

        public string Name
        {
            get
            {
                return "help";
            }
        }

        public string Explanation
        {
            get
            {
                return "This is helper";
            }
        }
    }
}
