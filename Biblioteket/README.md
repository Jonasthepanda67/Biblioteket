# Bibliotek Readme

Min kode er en konsol applikation som f�rst viser en menu hvor brugeren kan v�lge mellem disse valg:

                       V: Vis bibliotekets navn og dato  
                       O: Opret l�ner                    
                       U: Udskriv l�nere                 
                       F: Find l�ner                     
                       L: L�n en bog                     
                       T: Tilf�j bog                     
                       H: Hent b�ger                     
                       A: Aflever bog                   
                       X: Afslut
Hvert valg vil k�re igennem en metode i en anden klasse.

#### Vis bibliotekets navn og dato
Den f�rste metode vil tage imod en string som inderholder bibliotekets navn og vil return en string med noget tekst + navnet og dagsdato.

#### Opret l�ner
Min opret l�ner metode vil tage imod et navn og en mail den laver s� et l�nernummer
som den automatisk finder ved hj�lp af en metode der t�ller hvor mange l�nere der er i forvejen
og s� plusser det med 1.

Den vil s� bruge disse variabler til at oprette en ny l�ner i min laanere.csv fil
og tilf�je den til min liste over l�nere som bruge i min l�nert�ller metode.

#### Udskriv l�nere
Min udskriv l�nere metode vil g� igennem min .csv fil ved hj�lp af et foreach loop og finde
alle l�nere og formatere outputtet s� det bliver udskrevet til konsollen i en tabel.

#### Find l�ner
Min find l�ner metode vil ved hj�lp af et l�nernummer som brugeren indtaster finde
den specifikke l�ner og udskrive de oplysninger der er om l�neren til konsollen.

#### L�n en bog
Min l�n en bog metode vil f�rst tage imod et isbnnummer p� den bog der skal l�nes
og s� vil den tage imod et l�nernummer p� den l�ner som skal l�ne bogen.

Med disse to
variabler vil den f�rst finde l�neren med l�nernummeret og s� vil den k�re igennem to
metoder for at finde den specifikke bog og oplysningerne p� bogen ved hj�lp af 
isbnnummeret. N�r bogen er fundet s� vil den f�rst tjekke om bogen allerede er blevet udl�nt
eller om den ikke er.

Hvis bogen ikke er blevet udl�nt s� vil den oprette et object i min liste over udl�nt
b�ger hvor alt info om bogen bliver sat ind sammen med en udl�ns dato, afleveringsdato
og l�nerens l�nernummer.

Efter det s� vil den g� ind i .csv filen og �ndre p� v�rdien om den er udl�nt eller ej s�
den passer. Og til sidst vil den udskrive en kort besked med at bogen er udl�nt og hvem
den er udl�nt til.

#### Tilf�j bog
Min tilf�j bog metode er meget simpel. De sp�rger om bogens titel, forfatter og isbnnummer
og bruger s� variablerne til at skrive den ind i min boeger.csv fil p� en ny linje
og s�tter variablen udl�nt til at v�re false da den ikke er udl�nt endnu.

Til sidst skriver den en kort besked om at bogen er blevet tilf�jet og viser titlen, 
forfatteren og isbnnummeret.

#### Hent b�ger
Min hent b�ger metode g�r egentlig det samme som min udskriv l�nere metode. Den udskriver
alle b�ger i konsollen ved hj�lp af et foreach loop som g�r igennem boeger.csv filen
og s�rger for at det bliver udskrevet i en tabel.

#### Aflever bog
Min aflever bog metode sp�rger efter et l�nernummer og isbnnummer. n�r den har f�et dem
s� vil den f�rst g� igennem listen over l�nere og ved hj�lp af l�nernummeret finde den
rigtige l�ner.

S� g�r den igennem 2 andre metoder for at finde bogen ved hj�lp af isbnnummeret. Den 
s�rger s� f�rst for at v�rdien for om bogen er udl�nt eller ej i .csv filen bliver �ndret
s� den st�r som ikke udl�nt.

Efter det s� g�r den igennem listen over udl�ntb�ger og fjerne den derfra ved hj�lp af isbnnummeret
. Til sidst udskriver den en kort besked der siger at bogen er blevet afleveret og hvem
der har afleveret den.

#### Afslut
Den sidste ting p� min menu er afslut som egentlig bare stopper min menu fra at loope
og s� lukker programmet.