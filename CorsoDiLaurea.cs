using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreIscrizioni
{
    enum ListaCorsiLaurea
    {
        Matematica,
        Fisica,
        Informatica,
        Ingegneria,
        Lettere
    }

    // RELAZIONI:
    // a un corso di Laurea possono essere associati più corsi
    // a un corso di Laurea possono essere immatricolati più studenti
    class CorsoDiLaurea
    {
        // suppongo che i corsi di laurea siano tutti triennali
        private const int ANNI_CORSO = 3;
        // facendo questa supposizione anche i CFU saranno costanti
        private const int CFU = 180;
        // un corso di laurea è identificato da un insieme di singoli corsi che devono essere sostenuti
        private List<Corso> _corsi = new List<Corso>();
        // in ogni corso ci sono molti studenti/immatricolazioni (è una lista
        // di immatricolazioni perchè la classe Immatricolazione è il tramite tra
        // CorsoDiLaurea e Studente)
        private List<Immatricolazione> _studentiImmatricolati = new List<Immatricolazione>();

        public ListaCorsiLaurea NomeCorsoLaurea { get; }
        public int AnniDiCorso { get; }

        public int Cfu { get; }
        public List<Corso> Corsi { get { return new List<Corso>(_corsi); } }

        // per essere creato un corso di laurea ha bisogno di essere identificato da uno
        // dei nomi presente nell'enum ListaCorsiLaurea e dalla lista dei corsi che devonoe
        // essere sostenuti
        public CorsoDiLaurea(ListaCorsiLaurea corsoLaurea, List<Corso> listaCorsi)
        {
            NomeCorsoLaurea = corsoLaurea;
            AnniDiCorso = ANNI_CORSO;
            Cfu = CFU;
            // copio il riferimento della lista che passo 
            _corsi = listaCorsi;
        }

        public void AggiungiMatricola(Immatricolazione matricola)
        {
            _studentiImmatricolati.Add(matricola);
        }
    }
}
