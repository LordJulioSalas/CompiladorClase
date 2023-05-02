using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCOCompilador12023.Crosscutting
{
    public class TablaDummies:TablaComponentes
    {
        public static TablaComponentes INSTANCE= new TablaDummies();    

        private TablaDummies() { }  
        public static TablaComponentes GetTablaDummies()
        {
            return INSTANCE;
        }
    }
}
