namespace Biblioteket
{
    public class Mainp()
    { 
        Bibliotek Sønderborgbibliotek = new Bibliotek("Sønderborg bibliotek");
        
        public static void Main()
        {
            bool menuloop = true;
            string lnavn, lemail; int lnummer = 1; string opretnylaaner = "nej";
            Bibliotek Sønderborgbibliotek = new Bibliotek("Sønderborg bibliotek");
            do
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("|       ~Du kan vælge følgende~ \n|  V: Vis bibliotekets navn og dato");
                Console.WriteLine("|  O: Opret låner\n|  U: Udskriv lånere\n|  X: Afslut");
                Console.WriteLine("------------------------------------------");
                string result = Console.ReadLine();
                switch (result)
                {
                    case "v" or "V":
                        Console.Clear();
                        Console.WriteLine("\n" + Sønderborgbibliotek.HentBibliotek());
                        Console.WriteLine("\n\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "o" or "O":
                        do
                        {
                            Console.Clear();
                            Console.Write("\nindtast navn på låner du vil oprette her: ");
                            lnavn = Console.ReadLine();
                            Console.Write("\nindtast lånerens email her: ");
                            lemail = Console.ReadLine();
                            Console.Clear();
                            Sønderborgbibliotek.Opretlaaner(lnummer, lnavn, lemail);
                            string p2 = Sønderborgbibliotek.HentLaaner(lnummer, lnavn, lemail);
                            Console.WriteLine(p2);
                            lnummer++;
                            Console.Write("\nVil du oprette endnu en laaner? ja/nej: ");
                            opretnylaaner = Console.ReadLine();
                        } while (opretnylaaner == "ja" || opretnylaaner == "j" || opretnylaaner == "Ja" || opretnylaaner == "J");
                        Console.WriteLine("\n\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "u" or "U":
                        Console.Clear();
                        Console.WriteLine(Sønderborgbibliotek.HentAlleLaanere());
                        Console.WriteLine("\n\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "x" or "X":
                        Console.Clear();
                        Console.WriteLine("\nProgram afsluttet");
                        menuloop = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\nDu har indtastet forkert prøv igen");
                        Console.WriteLine("\n\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            } while (menuloop == true);
        }
    }
}