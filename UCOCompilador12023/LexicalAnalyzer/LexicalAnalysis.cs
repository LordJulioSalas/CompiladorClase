﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
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
            Concanate("0");
            CreateComponentReturningIndex(Category.DECIMAL, ComponentType.DUMMY);
        }

        private static void ProcessState18()
        {
            //Error;
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
                INSTANCE.Component = LexicalComponent.CreateNormalComponent(lineNumber, initialPosition, finalPosition, category, INSTANCE.Lexeme, ComponentType.NORMAL);
            }
            else if (ComponentType.DUMMY.Equals(type))
            {
                INSTANCE.Component = LexicalComponent.CreateDummyComponent(lineNumber, initialPosition, finalPosition, category, INSTANCE.Lexeme, ComponentType.DUMMY);
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

        private static bool IsComma()
        {
            return ",".Equals(Scanner.GetCurrentCharacter());
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
