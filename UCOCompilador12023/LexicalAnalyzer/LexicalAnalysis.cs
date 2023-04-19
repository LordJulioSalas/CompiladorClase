using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UCOCompilador12023.DataCache;

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

                else if(INSTANCE.CurrentState == 1) {
                ProcessState1();
                }
                else if (INSTANCE.CurrentState == 2) { 
                }
                else if (INSTANCE.CurrentState == 3) { }
                else if (INSTANCE.CurrentState == 4) { }
                else if (INSTANCE.CurrentState == 5) { }
                else if (INSTANCE.CurrentState == 6) { }
                else if (INSTANCE.CurrentState == 7) { }
                else if (INSTANCE.CurrentState == 8) { }
                else if (INSTANCE.CurrentState == 9) { }
                else if (INSTANCE.CurrentState == 10) { }
                else if (INSTANCE.CurrentState == 11) { }
                else if (INSTANCE.CurrentState == 12) { }
                else if (INSTANCE.CurrentState == 13) {
                    ProcessState13();
                        }
                else if (INSTANCE.CurrentState == 14) { 
                ProcessState14();
                }
                else if (INSTANCE.CurrentState == 15) { 
                ProcessState15();   
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
            else if (IsEndOfLine()) {
                Concanate();
                INSTANCE.CurrentState = 13;
            }
            else if (isEndOfFile())
            {
                INSTANCE.CurrentState = 12;
            }

        }

        private static void ProcessState1()
        {
            Scanner.ReadNextCharacter();
            if (IsDigit())
            {
                Concanate();
            }
            //else if ()
            //{
            //}

            else
            {

            }
        }

        private static void ProcessState3()
        {
        }

        private static void ProcessState12()
        {
            CreateComponentWithoutReturningIndex(Category.EOF);
            Restart();
        }
        private static void ProcessState13()
        {
            Scanner.LoadNextLine();
            Restart();
        }
        private static void ProcessState14()
        {
            CreateComponentReturningIndex(Category.ENTERO);
        }

        private static void ProcessState15()
        {
            CreateComponentReturningIndex(Category.DECIMAL);
        }

        private static void ProcessState17()
        {
            Concanate("0");
            CreateComponentReturningIndex(Category.DECIMAL);
        }




        private static void CreateComponent(Category category, ComponentType type)
        {
            int lineNumber=Scanner.GetCurrentNumberLine();
            int finalPosition=Scanner.GetCurrentIndex()-1;
            int initialPosition = Scanner.GetCurrentIndex() - INSTANCE.Lexeme.Length;

            if (ComponentType.NORMAL.Equals(type))
            {
                INSTANCE.Component = LexicalComponent.CreateNormalComponent(lineNumber, initialPosition, finalPosition, category, INSTANCE.Lexeme);
            }
            else if (ComponentType.DUMMY.Equals(type))
            {
                INSTANCE.Component = LexicalComponent.CreateDummy(lineNumber, initialPosition, finalPosition, category, INSTANCE.Lexeme);
            }

            INSTANCE.Component = LexicalComponent.Create(lineNumber,initialPosition,finalPosition,category,INSTANCE.Lexeme);
        }
        private static void CreateComponentWithoutReturningIndex(Category category)
        {
            INSTANCE.Continue = false;
            CreateComponent(category, ComponentType.NORMAL);
        }
        private static void CreateComponentReturningIndex(Category category)
        {
            Scanner.ReturnIndex();
            INSTANCE.Continue = false;
            CreateComponent(category, ComponentType.NORMAL);
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

        private static bool IsEndOfLine()
        {
            return "@FL@".Equals(Scanner.GetCurrentCharacter());    
        }

        private static bool isEndOfFile()
        {
            return "@EOF@".Equals(Scanner.GetCurrentCharacter());
        }

    }
}
