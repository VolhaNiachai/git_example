using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace PluginLoader
{
    public class Loader
    {
        public static List<IPlugin> Plugins
        { get; set; }

        public void LoadPlugins()
        {
            Plugins = new List<IPlugin>();

            if (Directory.Exists(Constants.Foldername))
            {
                string[] files = Directory.GetFiles(Constants.Foldername);
                foreach (string file in files)
                {
                    if (file.EndsWith(".dll"))
                    {
                        Assembly.LoadFile(Path.GetFullPath(file));
                    }
                }
            }
            Type interfaceType = typeof(IPlugin);
            Type[] types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass)
                .ToArray();
            foreach (Type type in types)
            {
                Plugins.Add((IPlugin)Activator.CreateInstance(type));
            }
        }

    }
}
