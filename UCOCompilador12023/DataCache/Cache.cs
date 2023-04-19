using System.Collections.Generic;

namespace UCOCompilador12023.DataCache
{
    public class Cache
    {
        private readonly static Cache CACHE = new Cache();
        private Dictionary<int, Line> Lines = new Dictionary<int, Line>();

        public static void Clear()
        {
            CACHE.Lines.Clear();
        }

        public static void AddLine(Line line)
        {
            if(line != null && line.GetNumeroLinea() > 0)
            {
                CACHE.Lines.Add(line.GetNumeroLinea(), line);
            }
        }

        public static Line GetLine(int number)
        {
            Line line = Line.Create(CACHE.Lines.Count + 1, "@EOF@");

            if(CACHE.Lines.ContainsKey(number))
            {
                line = CACHE.Lines[number];
            }

            return line;
        }

    }
}
