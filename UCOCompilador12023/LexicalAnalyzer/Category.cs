using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCOCompilador12023.LexicalAnalyzer
{
    public enum Category
    {
        ENTERO, DECIMAL, IDENTIFICADOR, MAYOR_QUE, MENOR_QUE, DIFERENTE_QUE, IGUAL_QUE, MAYOR_IGUAL_QUE, MENOR_IGUAL_QUE, SUMA, RESTA, MULTIPLICACION, DIVISION, EOF, MODULO, PARENTESIS_QUE_ABRE, PARENTESIS_QUE_CIERRA, ASIGNACION
    }
}
