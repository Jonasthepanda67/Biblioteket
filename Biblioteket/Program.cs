namespace Biblioteket
{
    public class Mainp()
    {
        Bibliotek Sønderborgbibliotek = new Bibliotek("Sønderborg bibliotek");
        Laaner laaner1 = new Laaner(1, "Jonas");
        public static void Main()
        {
            Bibliotek Sønderborgbibliotek = new Bibliotek("Sønderborg bibliotek");
            Laaner laaner1 = new Laaner(1, "Jonas");
            Sønderborgbibliotek.Opretlaaner(laaner1.laanerNummer, laaner1.navn);
            string p1 = Sønderborgbibliotek.HentBibliotek();
            string p2 = Sønderborgbibliotek.HentLaaner(laaner1);
            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }
        
    }
}