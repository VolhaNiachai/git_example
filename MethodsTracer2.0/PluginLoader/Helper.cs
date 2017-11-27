﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginLoader
{
    public class Helper
    {
        public void Help()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Following plugins are loaded: ");
            foreach (IFormatPlugin plugin in Loader.Plugins)
            {
                stringBuilder.AppendLine(plugin.Name);
                stringBuilder.AppendLine(plugin.Explanation);
            }
            Console.WriteLine(stringBuilder);
        }
    }
}
