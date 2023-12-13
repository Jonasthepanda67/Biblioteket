using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteket
{
    public class Laaner : Person
    {
        public readonly int LaanerNummer;
        public Laaner(int l, string n, string e) { 
        LaanerNummer = l;
        Navn = n;
        Email = e;
        }
    }
}
