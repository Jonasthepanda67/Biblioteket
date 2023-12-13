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
        public string Opretlaaner(int lNummer, string navn, string email) {
            Laaner nyLaaner = new Laaner(lNummer, navn, email);
            laanere.Add(nyLaaner);
            return "Låner med nummeret: " + lNummer + " navnet: " + navn + " og mailen: " + email + " er nu blevet oprettet";
        }
        public string HentLaaner(int lnummer, string lnavn, string lemail) {
            return "Lånernummer: " + lnummer + " - Navn: " + lnavn + " og mailen: " + lemail + " er låner hos: " + BiblioteksNavn;
        }
        public StringBuilder HentAlleLaanere(){
            StringBuilder sb = new StringBuilder();
            foreach (Laaner laaner in laanere)
            {
                sb.AppendLine("Lånernummer: " + laaner.LaanerNummer + " Navn på låneren: " + laaner.Navn + " lånerens email: " + laaner.Email + Environment.NewLine);
            }
            return sb;
        }
    }
}
