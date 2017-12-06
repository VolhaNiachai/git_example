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
        public static List<IFormatPlugin> Plugins { get; set; }

        public void LoadPlugins()
        {
            Plugins = new List<IFormatPlugin>();
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
        }
        public void CollectPlugins()
        {
            Type interfaceType = typeof(IFormatPlugin);
            Type[] types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass)
                .ToArray();
            foreach (Type type in types)
            {
                Plugins.Add((IFormatPlugin)Activator.CreateInstance(type));
            }
        }
    }
}