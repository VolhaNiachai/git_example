using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlFormatterInterface;
using TraceResultFormatter;
using MethodsTracer;
using JsonFormatterInterface;
using YamlFormatterInterface;
using ResultLoaderFormatter;


namespace TestMethods
{
    public class Menu
    {
        public void ChooseFormat(Tracer tracer, XmlLoader xmlLodaer, JsonLoader jsonLoader, YamlLoader yamlLoader)
        {
            Console.WriteLine("Press xml, concsole, json or yaml");
            string choosedFormat = Console.ReadLine();
            switch (choosedFormat)
            {
                case "xml":
                    XmlResultFormatter xmlResultFormatter = new XmlResultFormatter();
                    xmlResultFormatter.FormateToXml(tracer, xmlLodaer.XmlLoadedAssembly);
                    break;
                case "console":
                    ConsoleResultFormatter consoleResultFormatter = new ConsoleResultFormatter();
                    consoleResultFormatter.OutputConsoleResult(tracer);
                    break;
                case "json":
                    JsonResultFormatter jsonResultFormatter = new JsonResultFormatter();
                    jsonResultFormatter.FormateToJson(tracer, jsonLoader.JsonLoadedAssembly);
                    break;
                case "yaml":
                    YamlResultFormatter yamlResultFormatter = new YamlResultFormatter();
                    yamlResultFormatter.FormateToYaml(tracer, yamlLoader.YamlLoadedAssembly);
                    break;
                default:
                    Console.WriteLine("Default");
                    break;
            }
        }
    }
}
