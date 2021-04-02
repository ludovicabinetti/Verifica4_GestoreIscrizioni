using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreIscrizioni
{
    // classe che identifica i singoli corsi che andranno a costituire un corso di laurea
    // RELAZIONI: un corso può appartenere a un solo corso di laurea
    class Corso
    {
        public string NomeCorso { get; }
        public int Cfu { get; }

        public Corso(string nomeCorso, int cfu)
        {
            NomeCorso = nomeCorso;
            Cfu = cfu;
        }
    }
}
