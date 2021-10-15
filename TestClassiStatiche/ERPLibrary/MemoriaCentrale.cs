using System.Collections.Generic;
using System.Linq;
using System;

namespace ERPLibrary
{
    public static class MemoriaCentrale
    {
        public static List<Cliente> Clienti { get; set; }
        public static List<Utente> Utenti { get; set; }
        public static List<Fattura> Fatture{ get; set; }
        public static List<Prodotto> Prodotti { get; set; }

        public enum RuoloUtente
        {
            Amministatore,
            Direttore,
            Vicedirettore,
            Commesso,
            Magazziniere
        }

        public static void Initialize()
        {
            if (Clienti == null || Utenti == null || Fatture == null || Prodotti == null)
            {
                Clienti = new List<Cliente>();
                Utenti = new List<Utente>();
                Fatture = new List<Fattura>();
                Prodotti = new List<Prodotto>();
            }
        }

        public static int GetNextIdClienti()
        {
            return Clienti.Max(c => c.Id)+1;
        }

        public static int GetNextIdProdotti()
        {
            return Prodotti.Max(c => c.Id) + 1;
        }
        public static int GetNextIdUtenti()
        {
            return Utenti.Max(c => c.Id) + 1;
        }

        public static string GetNextNumeroFattura()
        {
           var partenumerica =  Fatture
                .Where(c=>
                c.Intestazione.NumeroFattura.Split("-")[1].Equals(DateTime.Now))
                .Max(
                c => c.Intestazione.NumeroFattura.Split("-")[0]
                );
            return $"{partenumerica}-{DateTime.Now}";
        }
    }
}
