# Bibliotek Readme

Min kode er en konsol applikation som først viser en menu hvor brugeren kan vælge mellem disse valg:

                       V: Vis bibliotekets navn og dato  
                       O: Opret låner                    
                       U: Udskriv lånere                 
                       F: Find låner                     
                       L: Lån en bog                     
                       T: Tilføj bog                     
                       H: Hent bøger                     
                       A: Aflever bog                   
                       X: Afslut
Hvert valg vil køre igennem en metode i en anden klasse.

#### Vis bibliotekets navn og dato
Den første metode vil tage imod en string som inderholder bibliotekets navn og vil return en string med noget tekst + navnet og dagsdato.

#### Opret låner
Min opret låner metode vil tage imod et navn og en mail den laver så et lånernummer
som den automatisk finder ved hjælp af en metode der tæller hvor mange lånere der er i forvejen
og så plusser det med 1.

Den vil så bruge disse variabler til at oprette en ny låner i min laanere.csv fil
og tilføje den til min liste over lånere som bruge i min lånertæller metode.

#### Udskriv lånere
Min udskriv lånere metode vil gå igennem min .csv fil ved hjælp af et foreach loop og finde
alle lånere og formatere outputtet så det bliver udskrevet til konsollen i en tabel.

#### Find låner
Min find låner metode vil ved hjælp af et lånernummer som brugeren indtaster finde
den specifikke låner og udskrive de oplysninger der er om låneren til konsollen.

#### Lån en bog
Min lån en bog metode vil først tage imod et isbnnummer på den bog der skal lånes
og så vil den tage imod et lånernummer på den låner som skal låne bogen.

Med disse to
variabler vil den først finde låneren med lånernummeret og så vil den køre igennem to
metoder for at finde den specifikke bog og oplysningerne på bogen ved hjælp af 
isbnnummeret. Når bogen er fundet så vil den først tjekke om bogen allerede er blevet udlånt
eller om den ikke er.

Hvis bogen ikke er blevet udlånt så vil den oprette et object i min liste over udlånt
bøger hvor alt info om bogen bliver sat ind sammen med en udlåns dato, afleveringsdato
og lånerens lånernummer.

Efter det så vil den gå ind i .csv filen og ændre på værdien om den er udlånt eller ej så
den passer. Og til sidst vil den udskrive en kort besked med at bogen er udlånt og hvem
den er udlånt til.

#### Tilføj bog
Min tilføj bog metode er meget simpel. De spørger om bogens titel, forfatter og isbnnummer
og bruger så variablerne til at skrive den ind i min boeger.csv fil på en ny linje
og sætter variablen udlånt til at være false da den ikke er udlånt endnu.

Til sidst skriver den en kort besked om at bogen er blevet tilføjet og viser titlen, 
forfatteren og isbnnummeret.

#### Hent bøger
Min hent bøger metode gør egentlig det samme som min udskriv lånere metode. Den udskriver
alle bøger i konsollen ved hjælp af et foreach loop som går igennem boeger.csv filen
og sørger for at det bliver udskrevet i en tabel.

#### Aflever bog
Min aflever bog metode spørger efter et lånernummer og isbnnummer. når den har fået dem
så vil den først gå igennem listen over lånere og ved hjælp af lånernummeret finde den
rigtige låner.

Så går den igennem 2 andre metoder for at finde bogen ved hjælp af isbnnummeret. Den 
sørger så først for at værdien for om bogen er udlånt eller ej i .csv filen bliver ændret
så den står som ikke udlånt.

Efter det så går den igennem listen over udlåntbøger og fjerne den derfra ved hjælp af isbnnummeret
. Til sidst udskriver den en kort besked der siger at bogen er blevet afleveret og hvem
der har afleveret den.

#### Afslut
Den sidste ting på min menu er afslut som egentlig bare stopper min menu fra at loope
og så lukker programmet.