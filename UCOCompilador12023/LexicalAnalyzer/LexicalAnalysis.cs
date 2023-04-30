using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCOCompilador12023.DataCache;
using UCOCompilador12023.ErrorManager;

namespace UCOCompilador12023.LexicalAnalyzer
{
    public class LexicalAnalysis
    {
        private readonly static LexicalAnalysis INSTANCE = new LexicalAnalysis();
        private int CurrentState;
        private string Lexeme;
        private bool Continue;
        private LexicalComponent Component;

        public static void Initialize()
        {
            Scanner.Initialize();
        }

        private static void Restart()
        {
            INSTANCE.CurrentState = 0;
            INSTANCE.Lexeme = "";
            INSTANCE.Continue = true;
        }

        private static void Concanate()
        {
            INSTANCE.Lexeme = INSTANCE.Lexeme + Scanner.GetCurrentCharacter();
        }

        private static void Concanate(string character)
        {
            INSTANCE.Lexeme = INSTANCE.Lexeme + character;
        }

        private static void DevourBlankCharacter()
        {
            Scanner.ReadNextCharacter();

            while (" ".Equals(Scanner.GetCurrentCharacter()))
            {
                Scanner.ReadNextCharacter();
            }
        }


        public static LexicalComponent Analyze()
        {
            Restart();

            while (INSTANCE.Continue)
            {
                if (INSTANCE.CurrentState == 0)
                {
                    ProcessState0();
                }
                if (INSTANCE.CurrentState == 1)
                {
                    ProcessState1();
                }
                if (INSTANCE.CurrentState == 2)
                {
                    ProcessState2();
                }
                if (INSTANCE.CurrentState == 3)
                {
                    ProcessState3();
                }
                if (INSTANCE.CurrentState == 4)
                {
                    ProcessState4();
                }
                if (INSTANCE.CurrentState == 5)
                {
                    ProcessState5();
                }
                if (INSTANCE.CurrentState == 6)
                {
                    ProcessState6();
                }
                if (INSTANCE.CurrentState == 7)
                {
                    ProcessState7();
                }
                if (INSTANCE.CurrentState == 8)
                {
                    ProcessState8();
                }
                if (INSTANCE.CurrentState == 9)
                {
                    ProcessState9();
                }
                if (INSTANCE.CurrentState == 10)
                {
                    ProcessState10();
                }
                if (INSTANCE.CurrentState == 11)
                {
                    ProcessState11();
                }
                if (INSTANCE.CurrentState == 12)
                {
                    ProcessState12();
                }
                if (INSTANCE.CurrentState == 13)
                {
                    ProcessState13();
                }
                if (INSTANCE.CurrentState == 14)
                {
                    ProcessState14();
                }
                if (INSTANCE.CurrentState == 15)
                {
                    ProcessState15();
                }
                if (INSTANCE.CurrentState == 16)
                {
                    ProcessState16();
                }
                if (INSTANCE.CurrentState == 17)
                {
                    ProcessState17();
                }
                if (INSTANCE.CurrentState == 18)
                {
                    ProcessState18();
                }
                if (INSTANCE.CurrentState == 19)
                {
                    ProcessState19();
                }
                if (INSTANCE.CurrentState == 20)
                {
                    ProcessState20();
                }
                if (INSTANCE.CurrentState == 21)
                {
                    ProcessState21();
                }
                if (INSTANCE.CurrentState == 22)
                {
                    ProcessState22();
                }
                if (INSTANCE.CurrentState == 23)
                {
                    ProcessState23();
                }
                if (INSTANCE.CurrentState == 24)
                {
                    ProcessState24();
                }
                if (INSTANCE.CurrentState == 25)
                {
                    ProcessState25();
                }
                if (INSTANCE.CurrentState == 26)
                {
                    ProcessState26();
                }
            }

            return INSTANCE.Component;
        }

        private static void ProcessState0()
        {
            DevourBlankCharacter();

            if (IsLetter() || IsCurrency() || IsUnderline())
            {
                Concanate();
                INSTANCE.CurrentState = 4;
            }
            else if (IsDigit())
            {
                Concanate();
                INSTANCE.CurrentState = 1;
            }
            else if (IsAddition())
            {
                Concanate();
                INSTANCE.CurrentState = 5;
            }
            else if (IsEndOfLine())
            {
                INSTANCE.CurrentState = 13;
            }
            else if (IsEndOfFile())
            {
                INSTANCE.CurrentState = 12;
            }
            else if (IsMinus())
            {
                INSTANCE.CurrentState = 6;
            }
            else if (IsMultiplication())
            {
                INSTANCE.CurrentState = 7;
            }
            else if (IsSlash())
            {
                INSTANCE.CurrentState = 8;
            }
            else if (IsModule())
            {
                INSTANCE.CurrentState = 9;
            }
            else if (IsLeftParenthesis())
            {
                INSTANCE.CurrentState = 10;
            }
            else if (IsRightParenthesis())
            {
                INSTANCE.CurrentState = 11;
            }
            else if (IsEqual())
            {
                INSTANCE.CurrentState = 19;
            }
            else if (IsColon())
            {
                INSTANCE.CurrentState = 22;
            }
            else if (IsLessThan())
            {
                INSTANCE.CurrentState = 20;
            }
            else if (IsGreaterThan())
            {
                INSTANCE.CurrentState = 21;
            }
            else if (IsExclamationMark())
            {
                INSTANCE.CurrentState = 30;
            }
            else { INSTANCE.CurrentState = 18; }
        }

        private static void ProcessState1()
        {
            Scanner.ReadNextCharacter();

            if (IsDigit())
            {
                Concanate();
                INSTANCE.CurrentState = 1;
            }
            else if (IsComma())
            {
                Concanate();
                INSTANCE.CurrentState = 2;
            }
            else
            {
                INSTANCE.CurrentState = 14;
            }
        }

        private static void ProcessState2()
        {
            Scanner.ReadNextCharacter();

            if (IsDigit())
            {
                Concanate();
                INSTANCE.CurrentState = 3;
            }
            else
            {
                INSTANCE.CurrentState = 17;
            }
        }

        private static void ProcessState3()
        {
            Scanner.ReadNextCharacter();

            if (IsDigit())
            {
                Concanate();
                INSTANCE.CurrentState = 3;
            }
            else
            {
                INSTANCE.CurrentState = 15;
            }
        }

        private static void ProcessState4()
        {
            Scanner.ReadNextCharacter();

            if (IsLetter() || IsCurrency() || IsUnderline() || IsDigit())
            {
                Concanate();
                INSTANCE.CurrentState = 4;
            }
            else
            {
                INSTANCE.CurrentState = 16;
            }
        }

        private static void ProcessState5()
        {
            CreateComponentReturningIndex(Category.SUMA, ComponentType.NORMAL);
        }

        private static void ProcessState6()
        {
            CreateComponentReturningIndex(Category.RESTA, ComponentType.NORMAL);
        }
        private static void ProcessState7()
        {
            CreateComponentReturningIndex(Category.MULTIPLICACION, ComponentType.NORMAL);
        }
        private static void ProcessState8()
        {
            Scanner.ReadNextCharacter();

            if (IsMultiplication())
            {
                Concanate();
                INSTANCE.CurrentState = 34;
            }
            else if (IsSlash())            
            {
                Concanate();
                INSTANCE.CurrentState = 36;
            }
            else
            {
                INSTANCE.CurrentState = 33;
            }
        }
        private static void ProcessState9()
        {
            CreateComponentReturningIndex(Category.MODULO, ComponentType.NORMAL);
        }

        private static void ProcessState10()
        {
            CreateComponentReturningIndex(Category.PARENTESIS_QUE_ABRE, ComponentType.NORMAL);
        }
        private static void ProcessState11()
        {
            CreateComponentReturningIndex(Category.PARENTESIS_QUE_CIERRA, ComponentType.NORMAL);
        }
        private static void ProcessState12()
        {
            CreateComponentWithouReturnIndex(Category.EOF, ComponentType.NORMAL);
        }
        private static void ProcessState13()
        {
            Scanner.LoadNextLine();
            Restart();
        }

        private static void ProcessState14()
        {
            CreateComponentReturningIndex(Category.ENTERO, ComponentType.NORMAL);
        }

        private static void ProcessState15()
        {
            CreateComponentReturningIndex(Category.DECIMAL, ComponentType.NORMAL);
        }
        private static void ProcessState16()
        {
            CreateComponentReturningIndex(Category.IDENTIFICADOR, ComponentType.NORMAL);
        }
        private static void ProcessState17()
        {
            
            CreateComponentReturningIndex(Category.DECIMAL, ComponentType.DUMMY);
            string fail = "Numero decimal no valido";
            string cause = "Se ha recibido un caracter que no corresponde a un digito...";
            string solution = "Asegurese de que luego del separador decimal continue un digito..";
            CreateLexicalError(ErrorType.CONTROLABLE, fail, cause, solution, Category.DECIMAL, INSTANCE.Lexeme + Scanner.GetCurrentCharacter());
            Concanate("0");

            CreateComponentReturningIndex(Category.DECIMAL, ComponentType.DUMMY);
        }

        private static void ProcessState18()
        {

            CreateComponentReturningIndex(Category.DECIMAL, ComponentType.DUMMY);
            string fail = "Compnenete lexico no valido";
            string cause = "Se ha recibido un simbolo desconocido por el lenguaje....";
            string solution = "Asegurese de que solo existan simbolos aceptados por el lenguaje...";
            CreateLexicalError(ErrorType.STOPPER, fail, cause, solution, Category.GENERAL, Scanner.GetCurrentCharacter());
            
        }

        private static void ProcessState19()
        {
            CreateComponentWithouReturnIndex(Category.IGUAL_QUE, ComponentType.NORMAL);
        }

        private static void ProcessState20()
        {
            Scanner.ReadNextCharacter();
            if (IsEqualTo(">")) {
            Concanate();
            INSTANCE.CurrentState = 23;
            }
            else if (IsEqualTo("=")) {
            Concanate();
            INSTANCE.CurrentState = 24;
            }
            else { 
            INSTANCE.CurrentState = 25;
            }
        }
        private static void ProcessState21()
        {
            Scanner.ReadNextCharacter();
            if (IsEqualTo("="))
            {
                Concanate();
                INSTANCE.CurrentState = 26;
            }
            else
            {
                INSTANCE.CurrentState = 27;
            }
        }

        private static void ProcessState22()
        {
            Scanner.ReadNextCharacter();
            if (IsEqualTo("="))
            {
                Concanate();
                INSTANCE.CurrentState = 28;
            }
            else
            {
                INSTANCE.CurrentState = 29;
            }
        }

        private static void ProcessState23()
        {
           CreateComponentWithouReturnIndex(Category.DIFERENTE_QUE, ComponentType.NORMAL);  
        }

        private static void ProcessState24()
        {
            CreateComponentWithouReturnIndex(Category.MENOR_IGUAL_QUE, ComponentType.NORMAL);
        }

        private static void ProcessState25()
        {
            CreateComponentReturningIndex(Category.MENOR_QUE, ComponentType.NORMAL);
        }

        private static void ProcessState26()
        {
            CreateComponentWithouReturnIndex(Category.MAYOR_IGUAL_QUE, ComponentType.NORMAL);
        }
        private static void CreateComponent(Category category, ComponentType type)
        {
            int lineNumber = Scanner.GetCurrentNumberLine();
            int initialPosition = Scanner.GetCurrentIndex() - INSTANCE.Lexeme.Length;
            int finalPosition = Scanner.GetCurrentIndex() - 1;

            if (ComponentType.NORMAL.Equals(type))
            {
                INSTANCE.Component = LexicalComponent.CreateNormalComponent(lineNumber, initialPosition, finalPosition, category, INSTANCE.Lexeme);
            }
            else if (ComponentType.DUMMY.Equals(type))
            {
                INSTANCE.Component = LexicalComponent.CreateDummyComponent(lineNumber, initialPosition, finalPosition, category, INSTANCE.Lexeme);
            }
        }

        private static void CreateLexicalError(ErrorType errorType, string fail, string cause, string solution, Category expecteCategory, string lexeme)
        {
            int lineNumber = Scanner.GetCurrentNumberLine();
            
            Error error;

            if (ErrorType.STOPPER.Equals(errorType))
            {
                int initialPosition = Scanner.GetCurrentIndex() - 1;
                int finalPosition = Scanner.GetCurrentIndex() - 1;
                error = Error.CreateStopperLexicalError(lineNumber, initialPosition, finalPosition, fail, cause, solution, expecteCategory, lexeme);

                ErrorManagment.Agregar(error);
                throw new Exception("Se ha presentado un error tipo STOPPER durante el análisis lexico. No es posible continuar con el proceso de compílación gasta que el error haya solucionado. Por favor verifique la consola de errores para tener más detalles del problema que se ha presentado....");
            }
            else if (ErrorType.CONTROLABLE.Equals(errorType))
            {
                int initialPosition = Scanner.GetCurrentIndex() - INSTANCE.Lexeme.Length;
                int finalPosition = Scanner.GetCurrentIndex() - 1;

                error = Error.CreateStopperLexicalError(lineNumber, initialPosition, finalPosition, fail, cause, solution, expecteCategory, lexeme);
                ErrorManagment.Agregar(error);
            }

            
        }

        private static void CreateComponentWithouReturnIndex(Category category, ComponentType type)
        {
            INSTANCE.Continue = false;

            CreateComponent(category, type);
        }

        private static void CreateComponentReturningIndex(Category category, ComponentType type)
        {
            Scanner.ReturnIndex();
            INSTANCE.Continue = false;

            CreateComponent(category, type);
        }

        private static bool IsLetter()
        {
            return Char.IsLetter(Scanner.GetCurrentCharacter().ToCharArray()[0]);
        }
        private static bool IsDigit()
        {
            return Char.IsDigit(Scanner.GetCurrentCharacter().ToCharArray()[0]);
        }
        private static bool IsCurrency()
        {
            return "$".Equals(Scanner.GetCurrentCharacter());
        }

        private static bool IsUnderline()
        {
            return "_".Equals(Scanner.GetCurrentCharacter());
        }

        private static bool IsAddition()
        {
            return "+".Equals(Scanner.GetCurrentCharacter());
        }
        private static bool IsMinus()
        {
            return "-".Equals(Scanner.GetCurrentCharacter());
        }
        private static bool IsMultiplication()
        {
            return "*".Equals(Scanner.GetCurrentCharacter());
        }
        private static bool IsComma()
        {
            return ",".Equals(Scanner.GetCurrentCharacter());
        }
        private static bool IsSlash()
        {
            return "/".Equals(Scanner.GetCurrentCharacter());
        }
        private static bool IsModule()
        {
            return "%".Equals(Scanner.GetCurrentCharacter());
        }
        private static bool IsLeftParenthesis()
        {
            return "(".Equals(Scanner.GetCurrentCharacter());
        }

        private static bool IsRightParenthesis()
        {
            return ")".Equals(Scanner.GetCurrentCharacter());
        }
        private static bool IsEqual()
        {
            return "=".Equals(Scanner.GetCurrentCharacter());
        }
        private static bool IsColon()
        {
            return ":".Equals(Scanner.GetCurrentCharacter());
        }
        private static bool IsGreaterThan()
        {
            return ">".Equals(Scanner.GetCurrentCharacter());
        }

        private static bool IsLessThan()
        {
            return "<".Equals(Scanner.GetCurrentCharacter());
        }
        private static bool IsExclamationMark()
        {
            return "!".Equals(Scanner.GetCurrentCharacter());
        }
        private static bool IsEqualTo(String s) { 
        return s.Equals(Scanner.GetCurrentCharacter()); 
        }
        private static bool IsEndOfLine()
        {
            return "@FL@".Equals(Scanner.GetCurrentCharacter());
        }

        private static bool IsEndOfFile()
        {
            return "@EOF@".Equals(Scanner.GetCurrentCharacter());
        }

    }
}
