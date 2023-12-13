using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteket;

namespace Biblioteket
{
    public class Bibliotek
    {
        string BiblioteksNavn;
        List<Laaner> laanere;
        public Bibliotek(string n) {
            BiblioteksNavn = n;
            laanere = new List<Laaner>();
        }
        public string HentBibliotek() {
            return "Velkommen til " + BiblioteksNavn + " - datoen idag er: " + DateTime.Now.ToShortDateString();
        }
        public string Opretlaaner(int lNummer, string navn) {
            Laaner nyLaaner = new Laaner(lNummer, navn);
            laanere.Add(nyLaaner);
            return "Låner med nummeret: " + lNummer + " og navnet: " + navn + " er nu blevet oprettet";
        }
        public string HentLaaner(int lnummer, string lnavn) {
            return "Lånernummer: " + lnummer + " - Navn: " + lnavn + " er låner hos: " + BiblioteksNavn;
        }
        public StringBuilder HentAlleLaanere(){
            StringBuilder sb = new StringBuilder();
            foreach (Laaner laaner in laanere)
            {
                sb.AppendLine("Lånernummer: " + laaner.LaanerNummer + " Navn på låneren: " + laaner.Navn + Environment.NewLine);
            }
            return sb;
        }
    }
}
