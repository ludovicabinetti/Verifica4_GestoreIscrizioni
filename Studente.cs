using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreIscrizioni
{
    class Studente
    {
        // l'oggetto immatricolazione mi consente di associare lo studente a un Corso di Laurea
        private Immatricolazione _immatricolazione;
        // lista degli esami a cui uno studente si è iscritto
        private List<Esame> _esami = new List<Esame>();

        public string Nome { get; }
        public string Cognome { get; }
        public int AnnoDiNascita { get; }
        public List<Esame> ListaEsami { get { return new List<Esame>(_esami); } }
        public Boolean RichiestaLaurea { get; private set; }

        // quando creo uno studente significa implicitamente che lo sto immatricolando
        // a un corso di laurea, pertanto dovrò specificare il corso prescelto
        public Studente(string nome, string cognome, int annoDiNascita, CorsoDiLaurea corsoLaurea)
        {
            Nome = nome;
            Cognome = cognome;
            AnnoDiNascita = annoDiNascita;
            // al momento della creazione/immatricolazione dello studente
            // il flag per la richiesta della laurea è false
            RichiestaLaurea = false;
            _immatricolazione = new Immatricolazione(corsoLaurea);
        }

        // il metodo non fa altro che creare un'istanza della classe Esame
        // aggiungendo questa istanza alla lista degli esami che lo studente
        // deve sostenere
        public Esame RichiestaEsame(string nomeEsame)
        {
            Esame esame;
            // se lo studente non ha fatto richiesta di laurea
            if (!RichiestaLaurea)
                // se l'esame può essere sostenuto nell'ambito del suo corsi di laurea
                // e se l'esame non supera i CFU massimi previsti dal corso di laurea,
                // iscrivo lo studente all'esame
                foreach (Corso c in _immatricolazione.CorsoDiLaurea.Corsi)
                    if (c.NomeCorso == nomeEsame &&
                        _immatricolazione.CfuAccumulati + c.Cfu <= _immatricolazione.CorsoDiLaurea.Cfu)
                    {
                        esame = new Esame(c);
                        _esami.Add(esame);
                        return esame;
                    }


            return null;
        }

        // metodo che aggiorna lo stato di un esame, i numeri di cfu sostenuti
        // dallo studente e controlla se lo studente ha raggiunto i requisiti per 
        // richiedere la laurea
        public void EsamePassato(Esame esame)
        {
            // controllo che faccio perchè l'esame potrebbe essere nullo (se non presente nel corso di laurea)
            if (esame != null)
            {
                esame.AggiornaStatoEsame();
                _immatricolazione.AggiornaCfu(esame.Corso.Cfu);

                if (_immatricolazione.CfuAccumulati == _immatricolazione.CorsoDiLaurea.Cfu)
                    RichiestaLaurea = true;
            }
        }

        public string InfoStudente
        {
            get
            {
                return $"Studente: {Nome} {Cognome} \n" + _immatricolazione.InfoImmatricolazione;
            }
        }
    }
}
