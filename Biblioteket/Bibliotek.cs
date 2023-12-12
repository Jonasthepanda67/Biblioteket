using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteket
{
    public class Bibliotek
    {
        string BiblioteksNavn;
        public Bibliotek(string n)
        {
            BiblioteksNavn = n;
        }
        public string HentBibliotek() {
            return "Velkommen til " + BiblioteksNavn + " - datoen idag er: " + DateTime.Now;
        }
    }
}
