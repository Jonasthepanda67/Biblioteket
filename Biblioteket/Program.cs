using System;
using Biblioteket;

namespace Program
{
    public class Program()
    {
        Bibliotek Sønderborgbibliotek = new Bibliotek("Sønderborg bibliotek");
        static void Main(string[] args)
        {
            Bibliotek Sønderborgbibliotek = new Bibliotek("Sønderborg bibliotek");
            string print = Sønderborgbibliotek.HentBibliotek();
            Console.WriteLine(print);
        }
        
    }
}