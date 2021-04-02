using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreIscrizioni
{
    class Immatricolazione
    {
        private static int _matricola = 0;

        public CorsoDiLaurea CorsoDiLaurea { get; }
        public int Matricola { get; }
        public DateTime DataInizio { get; }
        public Boolean FuoriCorso { get; }
        public int CfuAccumulati { get; private set; }

        // il costruttore assegna una matricola,  la data di immatricolazione,
        // il flag di fuori corso, i cfu sostenuti e iscrive letteralmente lo
        // studente al corso aggiungendolo alla lista _studentiImmatricolati
        // (vedi classe CorsoDiLaurea)
        public Immatricolazione(CorsoDiLaurea corsoLaurea)
        {
            Matricola = ++_matricola;
            // suppongo che la data di inizio sia la data al momento dell'inserimento
            DataInizio = DateTime.Today;
            // al momento dell'imatricolazione non si è fuori corso
            FuoriCorso = false;
            // al momento dell'imatricolazione non si è in possesso di alcun cfu
            CfuAccumulati = 0;
            CorsoDiLaurea = corsoLaurea;
            // quando si crea un'immatricolazione significa che lo studente viene iscritto
            // a un corso di laurea, quindi lo aggiungo alla lista degli studenti iscritti
            corsoLaurea.AggiungiMatricola(this);

        }

        public void AggiornaCfu(int cfuAcquisiti)
        {
            CfuAccumulati += cfuAcquisiti;
        }

        public string InfoImmatricolazione
        {
            get
            {
                return $"Matricola: {Matricola} \n" +
                    $"Corso di laurea: {CorsoDiLaurea.NomeCorsoLaurea} \n" +
                    $"Numero cfu sostenuti: {CfuAccumulati}";
            }
        }
    }
}
