# Loggbok
## Instruktion:
*"Förutom den rena applikationen behöver du under projektets gång föra en dagbok, eller loggbok. I den
noterar du varje dag vad du har gjort i projektet. Du kan notera sådant som problem som uppstod och
hur de löstes. Loggboken kommer att vara en del av din inlämning."*

## Logg
### 21/9:
##### 08:00 ish:
**Specifikation fasen**
Börjar sätta upp projekt struktur och kolla på kravspec. 
### 29/9:
##### Morgon
**Specifikation fasen**
Strukturera upp projektet, börja tänka på hur kodstrukturen ska se ut, definiera problemet. Min instinkt är att hoppa rakt in i design fasen men vet att det är bättre att göra en gedigen specifikation först. 
Något jag tog med mig från C# the yellow book var hur man ska ta sig an problem:
Specifying the problem
 - what information flows into the system
 - What comes out of the system
 - What does the system do with the information
 and start defining you program on paper first.
Så där tänker jag att jag börjar, så får vi se hur det går...

#### Vilken information matas in i systemet
Anställda kommer mata in fordonstyp och registreringsnummer (max 10 tecken)

#### Vilken information kommer ut ur systemet
Programmet kommer berätta vilken p-plats som fordonet ska parkeras på, flyttas till eller står på. Detta täcker de 4 efterfrågade menyalternativen.

#### Vad gör systemet med informationen?
Systemet tar registreringsnumret och söker upp en p-plats. Beroende på om fordonet är nytt eller redan i systemet kan detta vara en ny p-plats eller en befintlig. 

Detta är verkligen den mest basala versionen av vad programmet förväntas göra. IN: registreringsnummer, UT: p-plats.

**Design fasen**
Okej, så vi har ändå definierat problemet - regnr IN, p-plats UT. 
För planering av lösningen testade jag att köra lite postits på ett papper, jag vet att jag tänker bäst på fysisk media även om jag tycker det är bökigt. 
Men, menyn är ju det centrala för hela programmet med menyval
1) Lägg till fordon
2) Flytta fordon
3) Hämta fordon
4) Sök efter fordon

Kollar man sedan vad varje enskilt menyval ska göra är det ju tillbaka till basen: regnr IN, p-plats UT med visa extra steg vid varje val:
Menyval 1 ska lägga till fordonet i vektorn.
Menyval 2 ska flytta fordonet till ett annat index.
Menyval 3 ska ta bort fordonet ur vektorn.
Menyval 4 ska visa vilken p-plats fordonet är parkerat på. 

Uppgiften föreslår en vektor med längd 100 för att representera p-huset: `string[] parkingGarage = new string[100];`
Och vi kommer behöva en metod för 
 - utskrift av menyn
 - Inläsning av menyval
 - Lägga till ett fordon
 - Ta bort ett fordon
 - Flytta ett fordon som ropar på lägga till och ta bort metoderna
 - Söka efter fordon
 - Söka efter ledig p plats
 - Utskrift av p-plats
 - Utskrift av p-hus. 

##### Lunch tid
Det är svårt att hålla koll på vilka problem man stött på när allt är ett problem man måste lösa, "hur funkade .ToUpper nu igen", "varför klagar VS på min string variabel" osv. 
Men tycker ändå det går bra, försöker bryta ner det i mindre bitar tills det blir hanterbart. Vi kan nu lägga till bilar och parkera dom på en tom parkeringsplats var på programmet skriver ut vart den står. Det är ändå *framsteg*.

Ett exempel på problem jag just löste är att jag hade en strängvektor fordonID från min .Split av fordon och av någon anledning ville den inte köra på if(fordonID[0] == "MC"). Det visade sig att jag glömt byta namn på variabeln vid något tillfälle, så nu ska jag memorera ctrl+H för variabelnamn byte.

##### Eftermiddag
Det hade varit så hjälpsamt om man kunde tillräckligt för att bygga ett flödesschema för detta programmet. Nu gäller det att hålla tungan rätt i mun! 

### 30/9
##### Morgon
Börjat sätta upp parkera mc metoden. Min plan var att den skulle kolla om det redan stod en mc på platsen if (parkingGarage[i].StartsWith("MC")) och om den inte hade en till MC redan:  && Regex.IsMatch(parkingGarage[i], "^[^|]*$") men det leder ju till att programmet krashar vid första tomma cell då parkingGarage[i] är null. Så det funkar ju inte. Men nu när jag skriver ner det inser jag att det borde gå att lösa med en nästlad if sats... 

##### Eftermiddag
Jag fick det inte att funka med en nästlad if sats. Den hanterar inte att elementet är null. Men om jag lägger null statsen först kan man väl inte parkera två MCs på samma plats... eller?
Okej, det var verkligen så enkelt. Är det något jag lärt mig av den här uppgiften så är det att formulera sina tankar antingen till en kodanka eller till en loggbok gör problemlösningen mycket lättare.

Fick löst en sökfunktion och att man kan hämta ut fordon. Nu är det bara flytta fordon kvar att hammra ut, det känns som den bygger mycket på hämta ut och söka så borde gå ganska lätt...?

### 1/10
Började med att försöka bygga en manuell flyttfunktion och började plocka isär hämta ut fordon funktionen eftersom de kommer vara väldigt lika och det borde gå att dela upp dom så jag inte behöver använda samma kod på flera ställen utan bara kan kalla på en metod. Men det gick dåligt, det är svårt att få överblick, så slängde allt och byggde de separat för tillfället. Bättre att bygga något som fungerar än något som är optimerat men inte funkar. 
Jag trodde jag var klar med allt, men icke. Eftersom min sökfunktion bryter vid första tomma cellen i vektorn, blir det knas om man flyttar ett fordon så det finns tomma platser. Det funkar ju inte, för tomma platser kan ju alltid förekomma mellan parkerade bilar...
Jag har haft att den retunerar ett felmeddelande om den stöter på en tom plats, men hoppas att lösningen är så enkel som att be den att continue istället. 
Det var inte så enkelt men var simplet nog att lösa. 
Och nu funkar allt.
Är det snyggt - nej, men det funkar. 
Jag ska också testa på någon annan dator. 

### 2/10
Suttit och funderat på visualisering och testat lite olika delar av spectre.console. 
Snackade med Linnea med och insåg att jag glömt hantera ett fullt p-hus, så det är gjort nu.

Hade också velat ha något som haffar identiska regnr...

Tankar om optimeringsrutin:
Jag skulle vilja ha en lista som man lägger till indexen för singelparkerade mcs i. sen när man har kollat igenom hela phuset så kollar man listan bakifrån och flyttar ihop med första elementet i listan. det blir dock bökigt med ojämt antal singelparkerade mcs. och mycket loopar
om man istället tar första singelmcn och parkerar ihop den med andra singel mcs känns det som det blir en effektivare metod?
Men hur gör jag det egentligen? 
Nu har jag lagt in en räknare counter som räknar upp till 2 och sen händer ett optimeringsevent. Man skulle ju antingen kunna nollställa countern isf efter eventet eller ha att varje gång counter % 2 == 0 så sker eventet. Vad är skillnaden?
Nu var det enklare i just detta fall att nollställa räknaren så det var så det fick bli.

Nu ska vi justera användarinput. Undrar vilken nivå vi ska ligga på... basic är ju enkelt, men det är ju ändå VG, man kanske ska göra det lite snyggare ändå...
Jag tror jag är klar med det men, men svårt att komma på scenarion att testa för... det känns robust men det känns naivt att tro att det är det.
Testade runt och behöver säkra upp för om man vill flytta till en p-plats som inte är tom - löst.

Okej, jag har en fungerande visualisering, jag vill bara fixa så kolumnbredden blir bra, men den begränsande faktorn nu verkar vara fönster bredden på konsolfönstret så det blir nästa sak att tackla. 

### 3/10
##### Morgon
Okej så idag fortsatte jag att fibbla med visualiseringen och testade lite färgläggningar på tabellen Men kände att jag fortfarande egentligen vill ha lådor i tabell lådorna kollade runt lite igen och återgick till bar chart som jag tittade på innan och testade att stoppa ett bar chart i en tabell element det funkade känns som en optimal lösning - nej men jag jobbar med det jag har.
##### Eftermiddag
Försökte byta till grid istället för table för att kunna komma runt att man inte får ha bar charts i kolumnrubriken men det ledde till nya problem istället.  
Okej, googlade runt och försökte hitta något annat sätt att visa tabell data i C# men hittade inget på rak arm. Ska försöka igen imorgon kanske, men det ser ändå fint ut, även om jag stör mig till tusen på att jag måste ha en kolum rubrik rad högst upp. Oavsett, jag vill även fixa att den skriver ut en liten rapport efter tabellen så släpper tabellen för tillfället och går vidare.  
Och det var ändå enkelt löst. Får se om jag orkar presentera det snyggare än text rakt upp och ned. 
Det blir nog efter jag löst tidsstämplingen.

### 5/10
##### Morgon
Såg över min kommentering av koden och förbättrade det lite. Och ser nu hur jag skulle kunna bryta isär alla mina funktioner och göra så all utskrift sker i en separat funktion som bygger på en switch meny. Jag lägger det till högen av saker jag gör om jag hinner, annars får jag ta med det till nästa program. 

##### Kväll
Alltså, herregud. Sitter och ska lägga till tidsstämpel och bland det första jag skrev i projektet var ju metod för att lägga till fordon och sortera fordon och nu när jag tittar på det igen så är det bara att skaka på huvudet åt mig själv. Varför har jag tagit en sträng och sen delat den? Eller ja, jag vet varför, tänkte inte på Contains eller RegEx.IsMatch då och det står som tips i instruktionen att .Split eller .Join var användbart så hade det lättillgängligt. Men det känns ju omständigt så här i efterhand... Samtidigt, var det behändigt nu när jag skulle implementera datum och tids stämpling. Fått till det men vill byta till UTC tid och fixa formatet i utskriften för det var millisekunder med, och det känns överflödigt. 

### 6/10 
##### Morgon
Började sätta mig med UTC tiden igen och kände snabbt att jag inte alls var med på noterna, så fick fråga Gemini. Har aktivt försökt undvika både AI och att söka efter parkeringsgarage relaterade lösningar för att verkligen maxa lärandet och förståelsen, och det tror jag har varit bra men ibland får man ta lite genvägar. Minns nämligen när jag satt och lekte runt i C# i sommras att det var viktigt att ha tid i UTC, men jag vill fortfarande visa i lokal tid, så klart. Har jobbat med datorer som behövde ha sin klocka inställd på UTC tid pga vissa program, och avskydde att kolla på klockan och vara 1-2 timmar fel. Och fördelen med AI är ju att man kan bolla på ett helt annat sätt än man kan med StackOverflow eller Microsoft Learn. Sen blir det alltid en hel del felsökning när man frågar AI, vilket jag av någon anledning stör mig mer på än om jag själv måste felsöka min egna kod. 

Fick error när jag försökte plocka ut ett fordon jag precis lagt till så testade att byta från DateTime.ParseExact till TryParse och det verkar funka, dock får man en negativ tid om man parkerar i mindre än en minut. Så får testa try catch kanske. 
Och såg att min beläggningsrapport inte var så snygg med alla # och tidsstämplar nu så det får vi fixa med. Det ledde mig till min mc optimierings metod som jag behövde sätta mig in i igen. Variabel namn som tempArray är verkligen inte bra praxis. Och denna gången kom jag ihåg att använda ctrl + H. Och la till lite kommentarer. 

Nu läste jag i instruktionerna att "En lista som visar vilka regnr och fordonstyper som finns på vilken plats är minimum." och medan jag tycker att min färgtabell är otroligt överskådlig och snygg så vet jag inte om det räcker så övervägde ett kort tag att bara lägga till en utskriven lista, eftersom det är *minimum* men det hade ju inte varit lika **snyggt** som om man kunde växla tabellen mellan färg och utskriva fordonsIDn, som jag hade från början. Synd bara att jag slängt den koden. Hitta en liten kodsnippet i mitt Git repository som tur var. 
Och så ändrar man något som man tänker ska funka och så krashcar programmet. Då får man börja felsöka med debuggern - okej, min sträng blir tom, varför blir den det - ah, det är en tom p-plats, ja det måste vi ju kunna hantera. Så får man snickra ihop något runt det. 
Men nu funkar det, skulle dock behöva ändra kolumnbredden för att texten ska passa snyggare, vilket innebär att vi behöver ändra på färgtabellen med. Nu ska vi spara först och pusha upp till GitHub innan vi börjar med dumheter.
Okej, nu blir det nog inte bättre. Jag förstår inte hur jag får fönstret att bli större utan att användaren själv måste förstora det med. Har fipplat runt med Console.SetWindowSize och det gör ytan jag kan utnyttja större men själva rutan som öppnas är samma så det ser konstigt ut om man inte manuellt drar upp det till helskärm. Det verkar bara gå att göra genom att ladda ner massa extra .dll filer som känns lite utanför uppgiftens bredd, så jag lägger bara in en liten text om att köra fullskärm för bästa upplevelse. 
Skulle egentligen vilja ha en metod för tabell setup men vet inte ens om det är möjligt? Hur skulle det ens gå till? Testade lite snabbt och ja, det blir väldigt konstigt med all variabelaccess så som programmet är uppbyggt nu. 

##### Kväll
Okej, satt och försökte få det att funka på en annan dator och spectre console satte käppar i hjulet på det, och medans jag väntar på VS uppdatering frågade jag i klassens Discord kanal om folk lyckats lösa det utan extra tillägg. Och det har ju vissa så klart lyckats med. Och det fick verkligen kugghjulen att börja snurra igen på om man kanske kan få till det med halvfulla och fulla rutor. Och då tänkte jag på matriserna vi gjorde i måndags med symboler... och då slog det mig att det säkert finns en unicode symbol för det. En kort sökning senare bekräftar mina misstankar. Så frågan är om jag ska skriva om för att koppla bort spectre console. Är det värt det? Jag skulle behöva släppa denna uppgift och fokusera på att förstå klasser istället.
Och jag märker att jag tappat rutinen från mitt förrförra jobb att undvika mellanslag i filnamn.
Men efter lite fipplande med att få spectre console installerat på en annan dator och mindre justeringar i koden, en kod rad behövdes tas bort, så funkar det på en annan dator med. Nu ska vi testa på en annan person med. 

Användarfeedback: Varför återgår den inte till huvudmenyn automatiskt? Måste input ha # i sig? Starkare skilland mellan grönt och gult, rött för fulla platser, numrerade p-platser i visualiseringen? Att trycka escape för att komma tillbaka för att undvika att fastna om man trycker fel. Han hittade en bugg! När man skriver in flytta till nr 69 så säger den att den är full men sen står 69 i listan av lediga pplatser. Någonstans har vi ett index fel. Också flytta så tomma p-platser skrivs ut innan man erbjuds flytta till tom p-plats
Ev bugg runt att flytta till plats 13? 
Programmet skriver ut "parkerad i mindre än en minut" på alla nu
2 fordon med samma bokstäver men olika siffror lades in men bara 1 dyker upp om man söker på partiellt regnr. 
För nästa version - meny vid sidan av visualiseringen samt lediga platser visas vid sidan av 

## Att göra om tid / lärdomar till nästa gång:
 - All utskrift sker i en specifik funktion som läser in output från de andra funktionerna och baserat på en switch meny skriver ut olika saker på skärmen.
 - ctrl+H för variabelnamn byte
 - Skriv loggbok eller prata med en kodanka
 - Bygg in en avsluta knapp direkt, du vet att du kommer vilja ha en.
 - Något som haffar identiska regnr
 - Ett digitalt flödesschema som uppdateras under projektets gång.
 - Kolla efter hårdkodade värden och ändra så allt är på formen .Lenght, .GetLength etc samt att undvika hårdkodade variabel storlekar.
 - Bli bättre på att använda Git branches för delmål.
 - Inga mellanslag i filnamn
