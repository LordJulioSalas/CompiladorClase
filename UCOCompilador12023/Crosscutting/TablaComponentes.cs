using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCOCompilador12023.LexicalAnalyzer;

namespace UCOCompilador12023.Crosscutting
{
    public class TablaComponentes
    {
        public static void Initialize()
        {
        }
        public Dictionary<string, List<LexicalComponent>>{}
    public List<LexicalComponent> GetComponent(string lexeme)
    {
        if (!Components.ContainsKey(lexeme))
        {
            Components.Add(lexeme, new List<LexicalComponent>());
        }
        return Components[lexeme];
    }
    public void Add(LexicalComponent lexicalComponent)
    {
        if(lexicalComponent == null)
        {
            GetComponent(lexicalComponent.GetLexeme()).Add(lexicalComponent);
        }
    }
    public List<LexicalComponent> GetComponentsAsList()
    {
        List<LexicalComponent> returnList = new List<LexicalComponent>();

        foreach(List<LexicalComponent> list in Components.Values) {
            returnList.AddRange(list);
        }
        return returnList;  
    }
    
}
