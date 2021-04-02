using System;
using System.Collections.Generic;

namespace GestoreIscrizioni
{
    class Program
    {
        static void Main(string[] args)
        {
            // creo dei corsi
            Corso linguaLatina = new Corso("Lingua latina", 6);
            Corso letteraturaLatina = new Corso("Letteratura latina", 12);
            Corso linguisticaApplicata = new Corso("Linguistica applicata", 6);
            Corso glottodidattica = new Corso("Glottodidattica", 6);

            Corso programmazioneJava = new Corso("Programmazione Java", 15);
            Corso dataMining = new Corso("Data mining", 6);
            Corso textAnalytics = new Corso("Text analytics", 6);
            Corso semanticWeb = new Corso("Semantic web", 6);

            // creo liste dei corsi che passerò ai costruttori dei corsi di laurea
            List<Corso> listaCorsiLettere = CreaListaCorsi(linguaLatina, letteraturaLatina, linguisticaApplicata, glottodidattica);
            List<Corso> listaCorsiInformatica = CreaListaCorsi(programmazioneJava, dataMining, textAnalytics, semanticWeb);

            // creo i corsi di laurea
            CorsoDiLaurea lettere = new CorsoDiLaurea(ListaCorsiLaurea.Lettere, listaCorsiLettere);
            CorsoDiLaurea informatica = new CorsoDiLaurea(ListaCorsiLaurea.Informatica, listaCorsiInformatica);

            // creo degli studenti
            Studente pino = new Studente("Pino", "Pini", 1999, lettere);
            Studente rosa = new Studente("Rosa", "Rosi", 1996, informatica);
            Studente paolo = new Studente("Paolo", "Paoli", 1997, informatica);

            Esame e1 = pino.RichiestaEsame("Letteratura latina");
            Esame e2 = rosa.RichiestaEsame("Text analytics");
            Esame e3 = paolo.RichiestaEsame("Glottodidattica");

            pino.EsamePassato(e1);
            rosa.EsamePassato(e2);
            paolo.EsamePassato(e3);

            Console.WriteLine(pino.InfoStudente);
            Console.WriteLine();
            Console.WriteLine(rosa.InfoStudente);
            Console.WriteLine();
            Console.WriteLine(paolo.InfoStudente);
        }

        // metodo per creare una lista a partire dai corsi passati come parametri
        public static List<Corso> CreaListaCorsi (params Corso[] corsi)
        {
            List<Corso> listaCorsi = new List<Corso>();

            foreach (Corso c in corsi)
                listaCorsi.Add(c);

            return listaCorsi;
        }
    }
}
