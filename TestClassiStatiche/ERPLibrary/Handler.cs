using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPLibrary
{
    public class Handler
    {
        public Handler()
        {
            MemoriaCentrale.Initialize();
        }

        public bool insertUtente(string nome,
            string cognome, 
            MemoriaCentrale.RuoloUtente RuoloUtente)
        {
            var utente = new Utente
            {
                Cognome = cognome,
                Id = MemoriaCentrale.GetNextIdUtenti(),
                Nome = nome,
                Ruolo = RuoloUtente
            };

            MemoriaCentrale.Utenti.Add(utente);

            return true;
        }

        public bool insertCliente
            (string ragSoc,
           string piva,
           string indirizzo
           )
        {
            if (SearchClienteByPIVA(piva) != null)
                return false;

            var cliente = new Cliente
            {
                Ragsoc = ragSoc,
                Id = MemoriaCentrale.GetNextIdClienti(),
                Indirizzo = indirizzo,
                Piva = piva
            };
            MemoriaCentrale.Clienti.Add(cliente);

            return true;
        }

        public Cliente SearchClienteByPIVA(string piva)
        {
            return MemoriaCentrale.Clienti
                .Where(x => x.Piva.Equals(piva)).SingleOrDefault();
        }

        public bool InsertProdotto
            (string nome, string descrizione, double prezzo, float iva)
        {
            if (SearchProdottoByNome(nome) != null)
                return false;
            MemoriaCentrale.Prodotti.Add
                (
                    new Prodotto
                    {
                        DescrizioneProdotto = descrizione,
                        Id = MemoriaCentrale.GetNextIdProdotti(),
                        Iva = iva,
                        NomeProdotto = nome,
                        PrezzoProdotto = prezzo
                    }
                );

            return true;
        }

        public Prodotto SearchProdottoByNome(string nome)
        {
            return MemoriaCentrale.Prodotti
                .Where(x => x.NomeProdotto.Equals(nome)).SingleOrDefault();
        }


        public bool InsertFatura(int idCliente, int idUtente, List<int> prodotti)
        {
            var cliente = MemoriaCentrale.Clienti.Where(x => x.Id == idCliente).SingleOrDefault();
            var utente = MemoriaCentrale.Utenti.Where(c => c.Id == idUtente).SingleOrDefault();

            var prodottiPerDettaglio = MemoriaCentrale.Prodotti.
                Where(p => prodotti.Contains(p.Id)).ToList();

            if (cliente == null || utente == null || !prodottiPerDettaglio.Any())
                return false;

            var det = prodottiPerDettaglio.Select(
                x =>
                    new Dettaglio
                    {
                        Dettagli = x,
                        Quantità = 1
                    }
                );


            var fattura = new Fattura();
            fattura.Dettaglio = new List<Dettaglio>();
            fattura.Intestazione = new Intestazione
            {
                Cliente = cliente,
                Data = DateTime.Now,
                NumeroFattura = MemoriaCentrale.GetNextNumeroFattura(),
                Totale = det.Select(x =>
                (x.Quantità * x.Dettagli.PrezzoProdotto * x.Dettagli.Iva)).Sum(x => x),
                Utente = utente
            };

            MemoriaCentrale.Fatture.Add(fattura);
            return true;

        }
    }
}
