using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UCOCompilador12023.LexicalAnalyzer;

namespace UCOCompilador12023.ErrorManager
{
    public class Error
    {
        public int LineNumber { get => LineNumber; set => LineNumber = value; }
        public int InitialPosition { get => InitialPosition; set => InitialPosition = value; }
        public int FinalPosition { get => FinalPosition; set => FinalPosition = value; }
        public string Fail { get => Fail; set => Fail = value; }
        public string Cause { get => Cause; set => Cause = value; }
        public string Solution { get => Solution; set => Solution = value; }
        public ErrorLevel Level { get => Level; set => Level = value; }
        public ErrorType Type { get => Type; set => Type = value; }
        public Category Category { get => Category; set => Category = value; }
        public string Lexeme { get => Lexeme; set => Lexeme = value; }

        public Error(int lineNumber, int initialPosition, int finalPosition, string fail, string cause, string solution, ErrorLevel level, ErrorType type, Category category, string lexeme)
        {
            LineNumber = lineNumber;
            InitialPosition = initialPosition;
            FinalPosition = finalPosition;
            Fail = fail;
            Cause = cause;
            Solution = solution;
            Level = level;
            Type = type;
            Category = category;
            Lexeme = lexeme;
        }
        public static Error CreateStopperLexicalError(int lineNumber, int initialPosition, int finalPosition, string fail, string cause, string solution, Category category, string lexeme)
        {
            return new Error(lineNumber,initialPosition,finalPosition, fail, cause, solution, ErrorLevel.LEXICO, ErrorType.STOPPER, category, lexeme);
        }
        public static Error CreateNotStopperLexicalError(int lineNumber, int initialPosition, int finalPosition, string fail, string cause, string solution, Category category, string lexeme)
        {
            return new Error(lineNumber, initialPosition, finalPosition, fail, cause, solution, ErrorLevel.LEXICO, ErrorType.CONTROLABLE, category, lexeme);
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Numero de linea: ").Append(Category).Append("\n");
            sb.Append("Posicion inicial: ").Append(Lexeme).Append("\n");
            sb.Append("Posicion final: ").Append(LineNumber).Append("\n");
            sb.Append("Fallo: ").Append(InitialPosition).Append("\n");
            sb.Append("Causa: ").Append(FinalPosition).Append("\n");
            sb.Append("Solucion: ").Append(FinalPosition).Append("\n");
            sb.Append("Nivel: ").Append(FinalPosition).Append("\n");
            sb.Append("Tipo: ").Append(FinalPosition).Append("\n");
            sb.Append("Categoria: ").Append(FinalPosition).Append("\n");
            sb.Append("Lexema: ").Append(FinalPosition).Append("\n");

            return sb.ToString();
        }
    
    }
}
