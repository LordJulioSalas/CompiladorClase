using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCOCompilador12023.ErrorManager
{
    public class ErrorManagement
    {
        private static Dictionary<ErrorLevel, List<Error>> ErrorMap = new Dictionary<ErrorLevel, List<Error>>();
        private static Boolean IsInitialized = false;

        static ErrorManagement()
        {
            Inicializar();
        }
        private static void Inicializar()
        {
            ErrorMap.Clear();
            ErrorMap.Add(ErrorLevel.LEXICO, new List<Error>());
            ErrorMap.Add(ErrorLevel.SINTACTICO, new List<Error>());
            ErrorMap.Add(ErrorLevel.SEMANTICO, new List<Error>());
        }
        public static void Agregar(Error error)
        {
            if (error != null)
            {
                ErrorMap[error.Level].Add(error);
            }
        }

        public static Boolean HayErrores()
        {
            return HayErroresAnalisis() || HayErroresSintesis();
        }
        public static Boolean HayErrores(ErrorLevel errorLevel)
        {
            return ErrorMap[errorLevel].Count > 0;
        }

        public static Boolean HayErroresAnalisis()
        {
            return HayErrores(ErrorLevel.LEXICO) || HayErrores(ErrorLevel.SINTACTICO) || HayErrores(ErrorLevel.SEMANTICO);
        }

        public static Boolean HayErroresSintesis()
        {
            return HayErrores(ErrorLevel.LEXICO) || HayErrores(ErrorLevel.SINTACTICO) || HayErrores(ErrorLevel.SEMANTICO);
        }

        public static List<Error> GetErrors(ErrorLevel errorLevel) {
            return ErrorMap[errorLevel];
        }
    }
    }
