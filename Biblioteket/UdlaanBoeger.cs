using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteket
{
    public class UdlaanBoeger
    {
        public string titel {  get; set; }
        public string forfatter { get; set; }
        public string isbnNummer { get; set; }
        public string udlaansDato { get; set; }
        public string afleveringsDato { get; set; }
        public int laanerNummer { get; set; }

        public UdlaanBoeger(string t, string f, string i, string u, string a, int l)
        {
            titel = t;
            forfatter = f;
            isbnNummer = i;
            udlaansDato = u;
            afleveringsDato = a;
            laanerNummer = l;
        }
    }
}
