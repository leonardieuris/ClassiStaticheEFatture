using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPLibrary
{
    public class Fattura
    {
        public Intestazione Intestazione {get;set;}
        public List<Dettaglio> Dettaglio{get;set;}
    }
}
