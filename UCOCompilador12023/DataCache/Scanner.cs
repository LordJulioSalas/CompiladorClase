using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCOCompilador12023.DataCache
{
    public class Scanner
    {
        private readonly static Scanner INSTANCE = new Scanner();
        private int CurrentNumberLine;
        private int CurrentIndex;
        private Line CurrrentLine;
        private string CurrentCharacter;

        public static void Initialize()
        {
            INSTANCE.CurrentNumberLine = 0;
            LoadNextLine();
        }

        public static void LoadNextLine()
        {
            INSTANCE.CurrentNumberLine = INSTANCE.CurrentNumberLine + 1;
            INSTANCE.CurrentIndex = 1;
            INSTANCE.CurrrentLine = Cache.GetLine(INSTANCE.CurrentNumberLine);
            INSTANCE.CurrentNumberLine = INSTANCE.CurrrentLine.GetNumeroLinea();
            INSTANCE.CurrentCharacter = "";

        }

        public static string ReadNextCharacter()
        {
            if("@EOF@".Equals(INSTANCE.CurrrentLine.GetContenidoLinea()))
            {
                INSTANCE.CurrentCharacter = "@EOF@";
                INSTANCE.CurrentIndex = 1;
            }
            else if (INSTANCE.CurrentIndex <= INSTANCE.CurrrentLine.GetContenidoLinea().Length)
            {
                INSTANCE.CurrentCharacter = INSTANCE.CurrrentLine.GetContenidoLinea().ToCharArray()[INSTANCE.CurrentIndex - 1].ToString();
                INSTANCE.CurrentIndex = INSTANCE.CurrentIndex + 1;
            }
            else
            {
                INSTANCE.CurrentCharacter = "@FL@";
                INSTANCE.CurrentIndex = INSTANCE.CurrrentLine.GetContenidoLinea().Length + 1;
            }

            return INSTANCE.CurrentCharacter;
        }

        public static void ReturnIndex()
        {
            if (!"@FL@".Equals(INSTANCE.CurrentCharacter))
            {
            INSTANCE.CurrentIndex = INSTANCE.CurrentIndex - 1;
            }
        }

        public static int GetCurrentNumberLine()
        {
            return INSTANCE.CurrentNumberLine;
        }

        public static int GetCurrentIndex()
        {
            return INSTANCE.CurrentIndex;
        }

        public static string GetCurrentCharacter()
        {
            return INSTANCE.CurrentCharacter;
        }
    }
}
