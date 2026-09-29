# Loggbok
## Instruktion:
*"Förutom den rena applikationen behöver du under projektets gång föra en dagbok, eller loggbok. I den
noterar du varje dag vad du har gjort i projektet. Du kan notera sådant som problem som uppstod och
hur de löstes. Loggboken kommer att vara en del av din inlämning."*

## Logg
### 21/9: 
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

Det är svårt att håkka koll på vilka problem man stött på när allt är ett problem man måste lösa, "hur funkade .ToUpper nu igen", "varför klagar VS på min string variabel" osv. 
Men tycker ändå det går bra, försöker bryta ner det i mindre bitar tills det blir hanterbart. Vi kan nu lägga till bilar och parkera dom på en tom parkeringsplats var på programmet skriver ut vart den står. Det är ändå *framsteg*.
