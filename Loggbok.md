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

##### 13:00 ish:
Det är svårt att hålla koll på vilka problem man stött på när allt är ett problem man måste lösa, "hur funkade .ToUpper nu igen", "varför klagar VS på min string variabel" osv. 
Men tycker ändå det går bra, försöker bryta ner det i mindre bitar tills det blir hanterbart. Vi kan nu lägga till bilar och parkera dom på en tom parkeringsplats var på programmet skriver ut vart den står. Det är ändå *framsteg*.

Ett exempel på problem jag just löste är att jag hade en strängvektor fordonID från min .Split av fordon och av någon anledning ville den inte köra på if(fordonID[0] == "MC"). Det visade sig att jag glömt byta namn på variabeln vid något tillfälle, så nu ska jag memorera ctrl+H för variabelnamn byte xD.

##### 15 ish:
Det hade varit så hjälpsamt om man kunde tillräckligt för att bygga ett flödesschema för detta programmet. Nu gäller det att hålla tungan rätt i mun! 

### 30/9
Börjat sätta upp parkera mc metoden. Min plan var att den skulle kolla om det redan stod en mc på platsen if (parkingGarage[i].StartsWith("MC")) och om den inte hade en till MC redan:  && Regex.IsMatch(parkingGarage[i], "^[^|]*$") men det leder ju till att programmet krashar vid första tomma cell då parkingGarage[i] är null. Så det funkar ju inte. Men nu när jag skriver ner det inser jag att det borde gå att lösa med en nästlad if sats... 
Jag fick det inte att funka med en nästlad if sats. Den hanterar inte att elementet är null. Men om jag lägger null statsen först kan man väl inte parkera två MCs på samma plats... eller?
Okej, det var verkligen så enkelt. Är det något jag lärt mig av den här uppgiften så är det att formulera sina tankar antingen till en kodanka eller till en loggbok gör problemlösningen mycket lättare.
