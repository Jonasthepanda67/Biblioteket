namespace Biblioteket
{
    public class Mainp()
    { 
        Bibliotek Sønderborgbibliotek = new Bibliotek("Sønderborg bibliotek");
        public static void Main()
        {
            string menu = """

                    --------------------------------------  
                    |       Du kan vælge følgende        | 
                    |¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯| 
                    |   V: Vis bibliotekets navn og dato | 
                    |   O: Opret låner                   | 
                    |   U: Udskriv lånere                | 
                    |   F: Find låner                    | 
                    |   L: Lån en bog                    | 
                    |   T: Tilføj bog                    | 
                    |   H: Hent bøger                    | 
                    |   A: Aflever bog                   |
                    |   X: Afslut                        | 
                    --------------------------------------
                    Indtast valg her: 
                    """;
            bool menuloop = true;
            string lnavn, lemail, isbnnummer, titel, forfatter; int lnummer = 1; string opretnylaaner = "nej";
            Bibliotek Sønderborgbibliotek = new Bibliotek("Sønderborg bibliotek");
            Sønderborgbibliotek.laanertæller();
            do
            {
                Console.Clear();
                Console.Write(menu);
                string result = Console.ReadLine();
                Console.Clear();
                switch (result.ToLower())
                {
                    case "v":
                        Console.WriteLine("\n" + Sønderborgbibliotek.HentBibliotek());
                        Console.WriteLine("\n\nTryk på en hvilken som helst knap...");
                        Console.ReadKey();
                        break;
                    case "o":
                        do
                        {
                            Console.Write("\nindtast navn på låner du vil oprette her: ");
                            lnavn = Console.ReadLine();
                            Console.Write("\nindtast lånerens email her: ");
                            lemail = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("\n" + Sønderborgbibliotek.Opretlaaner(lnavn, lemail));
                            lnummer++;
                            Console.Write("\nVil du oprette endnu en laaner? ja/nej: ");
                            opretnylaaner = Console.ReadLine();
                        } while (opretnylaaner == "ja" || opretnylaaner == "j" || opretnylaaner == "Ja" || opretnylaaner == "J");
                        Console.WriteLine("\n\nTryk på en hvilken som helst knap...");
                        Console.ReadKey();
                        break;
                    case "u":
                        Console.WriteLine("\n" + Sønderborgbibliotek.HentAlleLaanere());
                        Console.WriteLine("\n\nTryk på en hvilken som helst knap...");
                        Console.ReadKey();
                        break;
                    case "f":
                        Console.Write("\nIndtast lånernummeret på den låner du vil finde: ");
                        lnummer = int.Parse(Console.ReadLine());
                        Console.WriteLine("\n" + Sønderborgbibliotek.FindLaaner(lnummer));
                        Console.WriteLine("\n\nTryk på en hvilken som helst knap...");
                        Console.ReadKey();
                        break;
                    case "l":
                        Console.Write("\nIndtast isbn nummeret på den bog du vile låne: ");
                        isbnnummer = Console.ReadLine();
                        Console.Write("Indtast dit lånernummer her: ");
                        lnummer = int.Parse(Console.ReadLine());
                        Console.WriteLine("\n" + Sønderborgbibliotek.laanBog(lnummer, isbnnummer));
                        Console.WriteLine("\n\nTryk på en hvilken som helst knap...");
                        Console.ReadKey();
                        break;
                    case "t":
                        Console.Write("\nIndtast titel på bogen her: ");
                        titel = Console.ReadLine();
                        Console.Write("Indtast forfatter på bogen her: ");
                        forfatter = Console.ReadLine();
                        Console.Write("Indtast isbn nummeret på bogen her: ");
                        isbnnummer = Console.ReadLine();
                        Console.WriteLine("\n" + Sønderborgbibliotek.TilfoejBog(titel, forfatter, isbnnummer));
                        Console.WriteLine("\n\nTryk på en hvilken som helst knap...");
                        Console.ReadKey();
                        break;
                    case "h":
                        Console.WriteLine("\n" + Sønderborgbibliotek.HentAlleBoeger());
                        Console.WriteLine("\n\nTryk på en hvilken som helst knap...");
                        Console.ReadKey();
                        break;
                    case "a":
                        Console.Write("\nIndtast dit lånernummer her: ");
                        lnummer = int.Parse(Console.ReadLine());
                        Console.Write("Indtast isbnnummeret på bogen her: ");
                        isbnnummer = Console.ReadLine();
                        Console.WriteLine("\n" + Sønderborgbibliotek.AfleverBog(lnummer, isbnnummer));
                        Console.WriteLine("\n\nTryk på en hvilken som helst knap...");
                        Console.ReadKey();
                        break;
                    case "x":
                        Console.WriteLine("\nProgram afsluttet");
                        menuloop = false;
                        break;
                    default:
                        Console.WriteLine("\nDu har indtastet forkert prøv igen");
                        Console.WriteLine("\n\nTryk på en hvilken som helst knap...");
                        Console.ReadKey();
                        break;
                }
            } while (menuloop == true);
        }
    }
}