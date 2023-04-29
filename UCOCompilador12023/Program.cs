using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Cache.AddLine(Line.Create(2, "       ?  678  "));
            Cache.AddLine(Line.Create(3, ""));
            Cache.AddLine(Line.Create(4, "4"));

            LexicalAnalysis.Initialize();

            try
            {
                LexicalComponent component = LexicalAnalysis.Analyze();

                while (!Category.EOF.Equals(component.GetCategory()))
                {
                    Console.WriteLine(component.ToString());
                    Console.WriteLine("___________________________________________________________");
                    component = LexicalAnalysis.Analyze();
                }
            }
            catch (Exception exception)
            {

                Console.WriteLine("¡¡¡¡¡ERROR DE COMPILACIÓN!!!!!!");
                Console.WriteLine(exception.Message);
            }

            if (ErrorManagment.HayErrores())
            {
                foreach(Error error in ErrorManagment.GetErrors(ErrorLevel.LEXICO))
                {
                    Console.WriteLine(error.ToString());
                    Console.WriteLine("___________________________________________________________");
                }
            }

            
            Console.ReadKey();

        }
    }
}
