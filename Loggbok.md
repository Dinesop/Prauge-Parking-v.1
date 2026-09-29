# Loggbok
## Instruktion:
*"Förutom den rena applikationen behöver du under projektets gång föra en dagbok, eller loggbok. I den
noterar du varje dag vad du har gjort i projektet. Du kan notera sådant som problem som uppstod och
hur de löstes. Loggboken kommer att vara en del av din inlämning."*

## Logg
### Specifikation fasen
**21/9:** 
Börjar sätta upp projekt struktur och kolla på kravspec. 

**29/9:** 
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

