using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCOCompilador12023.LexicalAnalyzer
{
    public class LexicalComponent
    {
        private int LineNumber;
        private int InitialPosition;
        private int FinalPosition;
        private Category Category;
        private string Lexeme;
        private ComponentType Type { get; set; }

        public LexicalComponent(int lineNumber, int initialPosition, int finalPosition, Category category, string lexeme, ComponentType type)
        {
            LineNumber = lineNumber;
            InitialPosition = initialPosition;
            FinalPosition = finalPosition;
            Category = category;
            Lexeme = lexeme;
            Type = type;
        }

        public static LexicalComponent CreateNormalComponent(int lineNumber, int initialPosition, int finalPosition, Category category, string lexeme)
        {
            return new LexicalComponent(lineNumber, initialPosition, finalPosition, category, lexeme, ComponentType.NORMAL);
        }

        public static LexicalComponent CreateDummyComponent(int lineNumber, int initialPosition, int finalPosition, Category category, string lexeme)
        {
            return new LexicalComponent(lineNumber, initialPosition, finalPosition, category, lexeme, ComponentType.DUMMY);
        }
        public static LexicalComponent CreateLiteralComponent(int lineNumber, int initialPosition, int finalPosition, Category category, string lexeme, ComponentType type)
        {
            return new LexicalComponent(lineNumber, initialPosition, finalPosition, category, lexeme, ComponentType.LITERAL);
        }
        public static LexicalComponent CreatePalabraReservadaComponent(int lineNumber, int initialPosition, int finalPosition, Category category, string lexeme)
        {
            return new LexicalComponent(lineNumber, initialPosition, finalPosition, category, lexeme, ComponentType.PALABRA_RESERVADA);
        }

        public static LexicalComponent CreatePalabraReservadaComponent(int lineNumber, int initialPosition, int finalPosition, Category category, string lexeme, ComponentType type)
        {
            return new LexicalComponent(lineNumber, initialPosition, finalPosition, category, lexeme, ComponentType.DUMMY);
        }
        public static LexicalComponent CreateLiteralComponent(int lineNumber, int initialPosition, int finalPosition, Category category, string lexeme, ComponentType type)
        {
            return new LexicalComponent(lineNumber, initialPosition, finalPosition, category, lexeme, ComponentType.DUMMY);
        }

        public void SetLineNumber(int lineNumber)
        {
            LineNumber = lineNumber;
        }

        public void SetInitialPosition(int initialPosition)
        {
            InitialPosition = initialPosition;
        }

        public void SetFinalPosition(int finalPosition)
        {
            FinalPosition = finalPosition;
        }

        public void SetCategory(Category category)
        {
            Category = category;
        }

        public void SetLexeme(string lexeme)
        {
            Lexeme = lexeme;
        }

        public ComponentType GetType()
        {
            return Type;
        }

        public int GetLineNumber()
        {
            return LineNumber;
        }

        public int GetInitialPosition()
        {
            return InitialPosition;
        }

        public int GetFinalPosition()
        {
            return FinalPosition;
        }

        public Category GetCategory()
        {
            return Category;
        }

        public string GetLexeme()
        {
            return Lexeme;
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Categoría: ").Append(Type).Append("\n");
            sb.Append("Categoría: ").Append(GetCategory()).Append("\n");
            sb.Append("Lexema: ").Append(GetLexeme()).Append("\n");
            sb.Append("Número de línea: ").Append(GetLineNumber()).Append("\n");
            sb.Append("Posición inicial de la línea: ").Append(GetInitialPosition()).Append("\n");
            sb.Append("Posición final de la línea: ").Append(GetFinalPosition()).Append("\n");

            return sb.ToString();
        }
    }
}
