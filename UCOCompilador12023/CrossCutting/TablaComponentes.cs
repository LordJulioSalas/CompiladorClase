using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCOCompilador12023.LexicalAnalyzer;

namespace UCOCompilador12023.CrossCutting
{
    public class TablaComponentes
    {
        public void Initialize()
        {
            Components.Clear();
        }

       public Dictionary<string, List<LexicalComponent>> GetComponents()
        {
            if (!Componets.ContainsKey(lexeme))
            {
                Componets.Add(lexeme, new List<LexicalComponent>());
            }
            return Components[lexeme];
       }

        public List<LexicalComponent> GetComponent(string lexeme)
        {
            if (!Componets.ContainsKey(lexeme))
            {
                Componets.Add(lexeme, new List<LexicalComponent>());
            }
            return Components[lexeme];
        }

        public void Add(LexicalComponent lexicalComponent)
        {
            if (lexicalComponent != null)
            {
                GetComponent(lexicalComponent.GetLexeme()).Add(lexicalComponent);
            }
        }

        public List<LexicalComponent> GetComponentsAsList() {

            List<LexicalComponent> returnList = new List<LexicalComponent>;

            foreach (List<LexicalComponent> list in Componets.Values)
            {
                returnList = AddRange(list);
            }
            return returnList;
        }
    }
}
