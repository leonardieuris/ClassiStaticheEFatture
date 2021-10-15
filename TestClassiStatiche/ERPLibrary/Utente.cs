namespace ERPLibrary
{
    public class Utente : Entity
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public MemoriaCentrale.RuoloUtente Ruolo { get; set; }
    }
}
