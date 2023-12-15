using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteket
{
    public class Bog
    {
        public string titel {  get; set; }
        public string forfatter { get; set; }
        public string isbnNummer { get; set; }
        public DateTime oprettelsesDato { get; set; }
        public string udlaant {  get; set; }
    }
}
