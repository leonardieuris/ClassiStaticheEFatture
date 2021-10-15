using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPLibrary
{
    public class Prodotto : Entity
    {
        public string NomeProdotto { get; set; }
        public string DescrizioneProdotto { get; set; }
        public double PrezzoProdotto { get; set; }
        public float Iva { get; set; }

    }
}
