using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCOCompilador12023.DataCache;
using UCOCompilador12023.LexicalAnalyzer;

namespace UCOCompilador12023
{
    class Program
    {
        static void Main(string[] args)
        {
            // Precarga de datos
            Cache.AddLine(Line.Create(1, "123 456 678,8"));
            Cache.AddLine(Line.Create(2, "                   678          "));
            Cache.AddLine(Line.Create(3, ""));
            Cache.AddLine(Line.Create(4, "4"));

            Scanner.Initialize();
            Scanner.ReadNextCharacter();

            LexicalAnalysis.Initialize();
            LexicalComponent component = LexicalAnalysis.Analyze();

            while (!Category.EOF.Equals(Scanner.GetCurrentCharacter()))
            {
                Console.WriteLine(component.ToString());
                component = LexicalAnalysis.Analyze();

                Console.ReadKey();


            }
        }
    }
}
