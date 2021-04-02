using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreIscrizioni
{
    // classe che rappresenta il corso a cui uno studente si iscrive e che deve sostenere
    class Esame
    {
        private Corso _corso;
        public Corso Corso { get { return _corso; } }
        public Boolean Passato { get; private set; }

        public Esame(Corso corso)
        {
            _corso = corso;
            // al momento della creazione un esame non è ancora stato passato
            Passato = false;
        }

        // metodo per aggiornare la variabile booleana che tiene conto se l'esame è stato passato o meno
        public void AggiornaStatoEsame()
        {
            Passato = true;
        }
    }
}
