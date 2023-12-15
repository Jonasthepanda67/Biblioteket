using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Biblioteket;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Biblioteket
{
    public class Bibliotek
    {
        string filepath = "..\\boeger.csv";
        string message = "titel,forfatter,isbnnummer,udlaant";
        string filepath2 = "..\\laanere.csv";
        string message2 = "Laanernummer,Navn,Email";
        StringBuilder sbf = new StringBuilder();
        string BiblioteksNavn;
        List<Laaner> laanere;
        string[] csvfil, csvfil2;
        List<UdlaanBoeger> udlaantBoeger;
        string str;
        /// <summary>
        /// Bruges til at initialisere diverse ting bl.a. strings, lister og string arrays.
        /// </summary>
        public Bibliotek(string n) {
            if (!File.Exists(filepath))
            {
                File.Create(filepath);
                File.WriteAllText(filepath, message + Environment.NewLine);
            }
            if (!File.Exists(filepath2))
            {
                File.Create(filepath2);
                File.WriteAllText(filepath2, message2 + Environment.NewLine);
            }
            BiblioteksNavn = n;
            laanere = new List<Laaner>();
            udlaantBoeger = new List<UdlaanBoeger>();
            csvfil = File.ReadAllLines(filepath);
            csvfil2 = File.ReadAllLines(filepath2);
        }
        /// <summary>
        /// Metode der sender en string med en kort besked, dagsdato og biblioteketsnavn som findes i klassen hvor metoden bliver kaldt.
        /// </summary>
        public string HentBibliotek() {
            return "Velkommen til " + BiblioteksNavn + " - datoen idag er: " + DateTime.Now.ToShortDateString();
        }
        /// <summary>
        /// Metode der opretter en låner med navn og email som brugeren sender. Opretter et låner objekt og tilføjer det til listen og tilføjer låneren
        /// til laanere.csv filen.
        /// </summary>
        public string Opretlaaner(string navn, string email) {
            int lnummer =  laanere.Count + 1;
            Laaner nyLaaner = new Laaner(lnummer, navn, email);
            laanere.Add(nyLaaner);
            string laaneroprettet = $"""
                Låner med nummeret: {lnummer}
                Navnet: {navn}
                Og mailen: {email}
                Er nu oprettet
                """;
            StreamWriter writer2 = File.AppendText(filepath2);
            writer2.WriteLine(lnummer + "," + navn + "," + email + Environment.NewLine);
            writer2.Close();
            return laaneroprettet;
        }
        /// <summary>
        /// Metode der bruger lånernummer til at finde låneren og sender en string med lånerensoplysninger.
        /// </summary>
        public string FindLaaner(int lnummer) {
            Laaner fLaaner = laanere.Where(i => i.LaanerNummer == lnummer).FirstOrDefault();
            return "Lånernummer: " + fLaaner.LaanerNummer + "\nNavn: " + fLaaner.Navn + "\nmail: " + fLaaner.Email;
        }
        /// <summary>
        /// Metode som læser hele laanere.csv filen og sender en multiline string med alle laanere formateret så det hele ligner en tabel.
        /// </summary>
        public StringBuilder HentAlleLaanere(){
            sbf.Clear();
            csvfil2 = File.ReadAllLines(filepath2);
            foreach (string line in csvfil2)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                var columns = line.Split(',');
                if (columns.Length == 3)
                {
                    sbf.AppendLine(string.Format("| {0,-12} | {1,-23} | {2,-30} |", columns[0], columns[1], columns[2]));
                }
            }
            return sbf;
        }
        /// <summary>
        /// Ved hjælp af lånernummer finder den låneren og ved hjælp af isbnnummeret finder den bogen og udlåner bogen til låneren ved at tilføje alt
        /// relevant info til et object og lægger objektet i en liste og ændre udlånt værdien i boeger.csv filen.
        /// </summary>
        public string laanBog(int lnummer, string isbnnummer)
        {
            string laanbog = "";
            Laaner fLaaner = laanere.Where(i => i.LaanerNummer == lnummer).FirstOrDefault();
            Bog boginfo = FindBog(isbnnummer, csvfil, filepath);
            if (boginfo == null) {
                laanbog = "Det indtastede isbnnummer er forkert eller kan ikke findes. Prøv igen...";
            }
            else if (boginfo != null)
            {
                string udlaansDato = DateTime.Now.ToShortDateString();
                string afleveringsDato = DateTime.Now.AddDays(14).ToShortDateString();
                if (boginfo.udlaant == "true")
                {
                    laanbog = "Bogen: " + boginfo.titel + " er allerede udlånt";
                }
                else if (boginfo.udlaant == "false")
                {
                    UdlaanBoeger bogen = new UdlaanBoeger(boginfo.titel, boginfo.forfatter, boginfo.isbnNummer, udlaansDato, afleveringsDato, fLaaner.LaanerNummer);
                    udlaantBoeger.Add(bogen);
                    lineChanger(isbnnummer, csvfil, filepath);
                    laanbog = fLaaner.Navn + " har nu lånt bogen: " + boginfo.titel;
                }
            }
            return laanbog;
        }
        /// <summary>
        /// Metode der ved hjælp af variabler brugeren sender laver en ny bog og sætter den ind i boeger.csv filen og sender en kort besked tilbage
        /// til brugeren.
        /// </summary>
        public string TilfoejBog(string titel, string forfatter, string isbnnummer)
        {
            string udlaant = "false";
            StreamWriter writer = File.AppendText(filepath);
            writer.WriteLine(titel + "," + forfatter + "," + isbnnummer + "," + udlaant + Environment.NewLine);
            writer.Close();
            return "Du har nu oprettet en bog med titlen: " + titel + "\nForfatteren: " + forfatter + "\nIsbn nummeret: " + isbnnummer;
        }
        /// <summary>
        /// Metode som læser hele boeger.csv filen og sender multiline string med alle bøger formateret så det hele ligner en tabel.
        /// </summary>
        public StringBuilder HentAlleBoeger()
        {
            sbf.Clear();
            csvfil = File.ReadAllLines(filepath);
            foreach (string line in csvfil)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                var columns = line.Split(',');
                if (columns.Length == 4)
                {
                    sbf.AppendLine(string.Format("| {0,-25} | {1,-25} | {2,-18} | {3,-10} |", columns[0], columns[1], columns[2], columns[3]));
                }
            }
            return sbf;
        }
        /// <summary>
        /// Metode som aflever bog ved hjælp af et lånernummer og isbnnummer. Ændre udlånt værdien i .csv filen og sletter bogen fra udlåntbøger listen.
        /// </summary>
        public string AfleverBog(int lnummer, string isbnNummer)
        {
            Laaner fLaaner = laanere.Where(i => i.LaanerNummer == lnummer).FirstOrDefault();
            Bog bog = FindBog(isbnNummer, csvfil, filepath);
            string aflevering = $"""
                {fLaaner.Navn} har nu afleveret
                bogen {bog.titel}
                """;
            lineChanger2(isbnNummer, csvfil, filepath);
            UdlaanBoeger bogen = udlaantBoeger.Where(i => i.isbnNummer == isbnNummer).FirstOrDefault();
            udlaantBoeger.Remove(bogen);
            return aflevering;
        }
        /// <summary>
        /// 2 Metoder der tilsammen finder alt info om en bog i boeger.csv filen ved hjælp af et isbnnummer som brugeren sender.
        /// </summary>
        private static Bog FindBog(string isbnnummer, string[] csvfil, string filepath)
        {
            csvfil = File.ReadAllLines(filepath);
            Bog bog = csvfil.Skip(1)
                .Select(BogSoegeFilter)
                .FirstOrDefault(p => p != null && p.isbnNummer == isbnnummer);
            return bog;
        }
        private static Bog BogSoegeFilter(string line)
        {
            try
            {
                string[] parts = line.Split(',');
                if (parts.Length < 4)
                {
                    return null;
                }
                return new Bog
                {
                    titel = parts[0],
                    forfatter = parts[1],
                    isbnNummer = parts[2],
                    udlaant = parts[3]
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Du har indtastet et forkert isbnnummer prøv igen...\n Fejl kode: {0}", ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 2 metoder som ændre værdien af udlånt i boeger.csv filen fra false til true eller true til false alt efter hvilken bliver brugt
        /// </summary>
        public static void lineChanger(string isbnNummer, string[] csvfil, string filepath)
        {
            string str = File.ReadAllText(filepath);
            string str2 = str.Replace(isbnNummer + ",false", isbnNummer + ",true");
            File.WriteAllText(filepath, str2);
        }
        public static void lineChanger2(string isbnNummer, string[] csvfil, string filepath)
        {
            string str = File.ReadAllText(filepath);
            string str2 = str.Replace(isbnNummer + ",true", isbnNummer + ",false");
            File.WriteAllText(filepath, str2);
        }
        /// <summary>
        /// Metode der finder antallet af lånere ved at læse laanere.csv filen og oprette dem i laanere listen
        /// </summary>
        public void laanertæller()
        {
            foreach (string line in csvfil2)
            {
                line.Skip(1);
                var columns = line.Split(",");
                if (int.TryParse(columns[0], out int parsedValue))
                {
                    Laaner nylaaner = new Laaner(parsedValue, columns[1], columns[2]);
                    laanere.Add(nylaaner);
                }   
            }
        }
    }
}
