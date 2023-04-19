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
        private ComponentType ComponentType;
        private string Lexeme;

        public LexicalComponent(int lineNumber, int initialPosition, int finalPosition, Category category, string lexeme, ComponentType componentType)
        {
            LineNumber = lineNumber;
            InitialPosition = initialPosition;
            FinalPosition = finalPosition;
            Category = category;
            Lexeme = lexeme;
            ComponentType = componentType;  
        }

        public LexicalComponent(int lineNumber, int initialPosition, int finalPosition, Category category, string lexeme)
        {
            LineNumber = lineNumber;
            InitialPosition = initialPosition;
            FinalPosition = finalPosition;
            Category = category;
            Lexeme = lexeme;
        }

        public static LexicalComponent Create(int lineNumber, int initialPosition, int finalPosition, Category category, string lexeme)
        {
            return new LexicalComponent(lineNumber, initialPosition, finalPosition, category, lexeme);
        }
        public static LexicalComponent Create(int lineNumber, int initialPosition, int finalPosition, Category category, string lexeme, ComponentType componentType)
        {
            return new LexicalComponent(lineNumber, initialPosition, finalPosition, category, lexeme, componentType);
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
            StringBuilder sb=new StringBuilder();
            sb.Append("Categoria: ").Append(GetCategory()).Append("\n");
            sb.Append("Lexema: ").Append(GetLexeme()).Append("\n");
            sb.Append("Numero de linea: ").Append(GetLineNumber()).Append("\n");
            sb.Append("Posicion inicial en la linea: ").Append(GetInitialPosition()).Append("\n");
            sb.Append("Posicion final en la linea: ").Append(GetFinalPosition()).Append("\n");

            return sb.ToString();
        }

        public static  LexicalComponent CreateNormalComponent(int lineNumber, int initialPosition, int finalPosition, Category category, string lexeme)
        {
            return LexicalComponent.Create(lineNumber, initialPosition, finalPosition, category, lexeme, ComponentType.NORMAL);
        }
        public static LexicalComponent CreateDummy(int lineNumber, int initialPosition, int finalPosition, Category category, string lexeme)
        {
            return LexicalComponent.Create(lineNumber, initialPosition, finalPosition, category, lexeme, ComponentType.DUMMY);
        }
    }
}
