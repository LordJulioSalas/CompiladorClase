using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCOCompilador12023.LexicalAnalyzer;

namespace UCOCompilador12023.Crosscutting
{
    public class TablaSimbolos:TablaComponentes
    {
        private static TablaSimbolos INSTANCE=new TablaSimbolos();

        private TablaSimbolos() { 
        
        }

        public static TablaComponentes GetTablaSimbolos()
        {
            return INSTANCE;
        }
    }
}
