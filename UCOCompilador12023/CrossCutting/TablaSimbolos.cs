using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCOCompilador12023.LexicalAnalyzer;

namespace UCOCompilador12023.CrossCutting
{
    public  class TablaSimbolos:TablaComponentes
    {
        private static TablaComponentes INSTANCE = new TablaComponentes();

        private TablaSimbolos() 
        {
            
        }

        public static TablaComponentes GetTablaSimbolos()
        {
            return INSTANCE;
        }

        public static void Inicializar()
        {
            INSTANCE.Initialize();
        }

        public static void Add(LexicalComponent component)
        {
            INSTANCE.Add(component);
        }

        public static  List<LexicalComponent> GetComponetsAsList() 
        {
            return INSTANCE.GetComponentsAsList();
        }

        public static Dictionary<string, List<LexicalComponent>> GetComponets()
        {
            return INSTANCE.GetComponents();
        }
    }
}
