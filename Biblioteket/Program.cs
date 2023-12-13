namespace Biblioteket
{
    public class Mainp()
    {//hvis array er tilladt istedet for list så tilføj nye brugere baseret på deres laanernummer
        Bibliotek Sønderborgbibliotek = new Bibliotek("Sønderborg bibliotek");
        Laaner laaner1 = new Laaner(0, "Jonas");
        
        public static void Main()
        {
            string lnavn; int lnummer = 1; string opretnylaaner = "nej";
            Bibliotek Sønderborgbibliotek = new Bibliotek("Sønderborg bibliotek");
            do
            {
                Console.Clear();
                Console.Write("indtast navn på låner du vil oprette her: ");
                lnavn = Console.ReadLine();
                Console.Clear();
                Sønderborgbibliotek.Opretlaaner(lnummer, lnavn);
                string p2 = Sønderborgbibliotek.HentLaaner(lnummer, lnavn);
                Console.WriteLine(p2);
                lnummer++;
                Console.Write("\nVil du oprette endnu en laaner? ja/nej: ");
                opretnylaaner = Console.ReadLine();
            } while (opretnylaaner == "ja" || opretnylaaner == "j" || opretnylaaner == "Ja" || opretnylaaner == "J");
            Console.Clear();
            Console.WriteLine(Sønderborgbibliotek.HentBibliotek());
            Console.WriteLine(Sønderborgbibliotek.HentAlleLaanere());
        }
        
    }
}