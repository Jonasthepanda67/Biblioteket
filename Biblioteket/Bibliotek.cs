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
        List<Laaner> laanere = new List<Laaner>();
        public Bibliotek(string n) {
            BiblioteksNavn = n;
        }
        public string HentBibliotek() {
            return "Velkommen til " + BiblioteksNavn + " - datoen idag er: " + DateTime.Now;
        }
        public void Opretlaaner(int lNummer, string navn) {
            Laaner nyLaaner = new Laaner(lNummer, navn);
            laanere.Add(nyLaaner);
        }
        public string HentLaaner(Laaner laaner1) {
            return "Lånernummer: " + laaner1.laanerNummer + " - Navn: " + laaner1.navn + " er låner hos: " + BiblioteksNavn;
        }
    }
}
