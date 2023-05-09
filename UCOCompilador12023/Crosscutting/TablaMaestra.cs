using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCOCompilador12023.LexicalAnalyzer;

namespace UCOCompilador12023.CrossCutting
{
    public class TablaMaestra
    {
        private static Dictionary<ComponentType, TablaComponentes> TABLAS = new Dictionary<ComponentType, TablaComponentes>(); 

        static TablaMaestra()
        {
            TABLAS.Add(ComponentType.NORMAL, TablaSimbolos.GetTablaSimbolos());
            TABLAS.Add(ComponentType.DUMMY, TablaDeDummies.GetTablaDummies());
            TABLAS.Add(ComponentType.LITERAL, TablaDeLiterales.GetTablaLiterales());
            TABLAS.Add(ComponentType.PALABRA_RESERVADA, TablaPalabrasReservadas.GetTablaPalabrasReservadas());
        }
        public static void Inicializar()
        {
            TablaSimbolos.GetTablaSimbolos().Initialize();
            TablaPalabrasReservadas.GetTablaPalabrasReservadas().Initialize();
            TablaDeLiterales.GetTablaLiterales().Initialize();
            TablaDeDummies.GetTablaDummies().Initialize();
        }

        public static void Add(LexicalComponent component)
        {
            if (component != null)
            {
                component = TablaPalabrasReservadas.ComprobarComponente(component);
                TABLAS[component.GetType()].Add(component);
            }
        }
        public static List<LexicalComponent> GetComponetsAsList(ComponentType type)
        {
            return TABLAS[type].GetComponentsAsList();
        }

        public static Dictionary<string, List<LexicalComponent>> GetComponets(ComponentType type)
        {
            return TABLAS[type].GetComponents();
        }
    }
}
