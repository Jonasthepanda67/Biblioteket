using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteket
{
    public class Laaner
    {
        public readonly int LaanerNummer;
        public readonly string Navn;
        public Laaner(int l, string n) { 
        LaanerNummer = l;
        Navn = n;
        }
    }
}
