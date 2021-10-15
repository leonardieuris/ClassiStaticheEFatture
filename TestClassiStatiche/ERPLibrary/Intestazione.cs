using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPLibrary
{
    public class Intestazione
    {
        public Utente Utente { get; set; }
        public Cliente Cliente { get; set; }
        public string NumeroFattura { get; set; }
        public DateTime Data { get; set; }
        public double Totale { get; set; }
    }
}
