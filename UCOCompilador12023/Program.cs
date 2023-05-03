using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCOCompilador12023.CrossCutting;
using UCOCompilador12023.DataCache;
using UCOCompilador12023.ErrorManager;
using UCOCompilador12023.LexicalAnalyzer;

namespace UCOCompilador12023
{
    class Program
    {
        static void Main(string[] args)
        {
            // Precarga de datos
            Cache.AddLine(Line.Create(1, "123 456           678,8"));
            Cache.AddLine(Line.Create(2, "?         678  "));
            Cache.AddLine(Line.Create(3, ""));
            Cache.AddLine(Line.Create(4, "4"));

            LexicalAnalysis.Initialize();

            try
            {
                LexicalComponent component = LexicalAnalysis.Analyze();

                while (!Category.EOF.Equals(component.GetCategory()))
                {
                    component= LexicalAnalysis.Analyze();
                }
            }
            catch (Exception exception) {
                Console.WriteLine("¡¡¡¡¡ERROR DE COMPILACION!!!!!");
                Console.WriteLine(exception.Message);
            }




            Console.WriteLine(TablaSimbolos.GetTablaSimbolos());
            if (TablaMaestra.GetComponetsAsList(ComponentType.LITERAL).Count() > 0) {
                Console.WriteLine("Literales: ");

                foreach (LexicalComponent componentTmp in TablaMaestra.GetComponetsAsList(ComponentType.LITERAL))
                {
                    Console.WriteLine("================================");
                    Console.WriteLine(componentTmp.ToString());
                }
            }

            if (TablaMaestra.GetComponetsAsList(ComponentType.NORMAL).Count() > 0)
            {
                Console.WriteLine("Simbolos: ");

                foreach (LexicalComponent componentTmp in TablaMaestra.GetComponetsAsList(ComponentType.NORMAL))
                {
                    Console.WriteLine("================================");
                    Console.WriteLine(componentTmp.ToString());
                }
            }

            if (TablaMaestra.GetComponetsAsList(ComponentType.DUMMY).Count() > 0)
            {
                Console.WriteLine("Dummies: ");

                foreach (LexicalComponent componentTmp in TablaMaestra.GetComponetsAsList(ComponentType.DUMMY))
                {
                    Console.WriteLine("================================");
                    Console.WriteLine(componentTmp.ToString());
                }
            }

            if (TablaMaestra.GetComponetsAsList(ComponentType.PALABRA_RESERVADA).Count() > 0)
            {
                Console.WriteLine("Palabras reservadas: ");

                foreach (LexicalComponent componentTmp in TablaMaestra.GetComponetsAsList(ComponentType.PALABRA_RESERVADA))
                {
                    Console.WriteLine("================================");
                    Console.WriteLine(componentTmp.ToString());
                }
            }


            if (ErrorManagement.HayErrores())
            {
                foreach(Error error in ErrorManagement.GetErrors(ErrorLevel.LEXICO))
                {
                    Console.WriteLine(error.ToString());
                    Console.WriteLine("___________________________________________________________");
                }
            }

            
            Console.ReadKey();
        }
    }
}
