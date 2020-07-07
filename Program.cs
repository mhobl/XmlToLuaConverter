using CommandLine;
using System;

namespace XmlToLuaTableConverter
{
    class Program
    {
        public class Options
        {
            [Option('i', "input", Required = true, HelpText = "Path to the input XML file")]
            public string InputFileName { get; set; }
            [Option('o', "output", Required = false, HelpText = "Path to the output LUA file (default: same folder as the executable)")]
            public string OutputFileName { get; set; }
        }
        static void Main(string[] args)
        {
            string xmlFileName = string.Empty;
            string luaFileName = @".\MonolithDKP.lua";
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    xmlFileName = o.InputFileName;
                    if (o.OutputFileName != null && o.OutputFileName != "")
                    {
                        luaFileName = o.OutputFileName;
                    }
                });

            LuaConverter luaConverter = new LuaConverter();
            Console.WriteLine("Starting to read XML data...");
            var dkpEntryList = luaConverter.ReadXmlFile(xmlFileName);
            Console.WriteLine("Convert data and write LUA table file...");
            var result = luaConverter.WriteLuaTableFile(dkpEntryList, luaFileName);
            if (result)
            {
                Console.WriteLine("Successfully finished the data convert!");
            }
            else
            {
                Console.WriteLine("Error occured during data convert!");
            }

        }
    }
}
