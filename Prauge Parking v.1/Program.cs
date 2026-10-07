using System.Numerics;
using System.Text.RegularExpressions;

string[] parkingGarage = new string[100];
# region parkerade bilar
//parkingGarage[0] = "BIL#AHF768";
//parkingGarage[1] = "BIL#KAF501";
//parkingGarage[2] = "BIL#OFP808";
//parkingGarage[3] = "MC#IEY300";
//parkingGarage[4] = "MC#PUS593|MC#OVQ857";
//parkingGarage[5] = "BIL#FHC212";
//parkingGarage[6] = "BIL#JJF296";
//parkingGarage[7] = "BIL#ESE396";
//parkingGarage[8] = "BIL#RVU203";
//parkingGarage[9] = "BIL#FYW363";
//parkingGarage[10] = "";
//parkingGarage[11] = "BIL#GGO258";
//parkingGarage[12] = "BIL#FZN001";
//parkingGarage[13] = "BIL#UKB395";
//parkingGarage[14] = "";
//parkingGarage[15] = "MC#ASR526|MC#CLL982";
//parkingGarage[16] = "BIL#EXW266";
//parkingGarage[17] = "BIL#TOU503";
//parkingGarage[18] = "BIL#YWV308";
//parkingGarage[19] = "";
//parkingGarage[20] = "BIL#MBT714";
//parkingGarage[21] = "BIL#GWL257";
//parkingGarage[22] = "BIL#IZQ451";
//parkingGarage[23] = "BIL#IPF206";
//parkingGarage[24] = "BIL#XWB262";
//parkingGarage[25] = "BIL#YOM781";
//parkingGarage[26] = "BIL#LLM769";
//parkingGarage[27] = "BIL#KIW214";
//parkingGarage[28] = "BIL#HGY485";
//parkingGarage[29] = "BIL#ZVZ981";
//parkingGarage[30] = "BIL#FKB392";
//parkingGarage[31] = "MC#LKY957";
//parkingGarage[32] = "BIL#HZP570";
//parkingGarage[33] = "BIL#NWE901";
//parkingGarage[34] = "BIL#RGD825";
//parkingGarage[35] = "BIL#KPN927";
//parkingGarage[36] = "BIL#KRH370";
//parkingGarage[37] = "BIL#ZZB229";
//parkingGarage[38] = "MC#WJE876|MC#ZRA826";
//parkingGarage[39] = "";
//parkingGarage[40] = "BIL#DCO267";
//parkingGarage[41] = "BIL#QGM980";
//parkingGarage[42] = "BIL#HAU627";
//parkingGarage[43] = "BIL#LAB895";
//parkingGarage[44] = "MC#PDD387|MC#WXF217";
//parkingGarage[45] = "MC#KQE989|MC#VWA739";
//parkingGarage[46] = "MC#WVG718|MC#WFV437";
//parkingGarage[47] = "BIL#AFI892";
//parkingGarage[48] = "BIL#KZN919";
//parkingGarage[49] = "BIL#ZGC473";
//parkingGarage[50] = "BIL#NKO270";
//parkingGarage[51] = "";
//parkingGarage[52] = "BIL#STR306";
//parkingGarage[53] = "BIL#IWS334";
//parkingGarage[54] = "BIL#HDK969";
//parkingGarage[55] = "BIL#HOA245";
//parkingGarage[56] = "MC#MLF497";
//parkingGarage[57] = "BIL#CNQ387";
//parkingGarage[58] = "MC#FFA248";
//parkingGarage[59] = "BIL#KQF642";
//parkingGarage[60] = "MC#ATU141";
//parkingGarage[61] = "";
//parkingGarage[62] = "BIL#BGW486";
//parkingGarage[63] = "";
//parkingGarage[64] = "BIL#YXP758";
//parkingGarage[65] = "BIL#XTM226";
//parkingGarage[66] = "MC#NQH022";
//parkingGarage[67] = "BIL#ODG670";
//parkingGarage[68] = "BIL#OKF495";
//parkingGarage[69] = "MC#WTJ037";
//parkingGarage[70] = "MC#YKT562|MC#FLA364";
//parkingGarage[71] = "BIL#MDQ035";
//parkingGarage[72] = "BIL#QDM032";
//parkingGarage[73] = "BIL#TJT820";
//parkingGarage[74] = "BIL#OZJ676";
//parkingGarage[75] = "MC#YFA116";
//parkingGarage[76] = "BIL#FST167";
//parkingGarage[77] = "BIL#VZC036";
//parkingGarage[78] = "";
//parkingGarage[79] = "BIL#SBR617";
//parkingGarage[80] = "MC#PDZ734|MC#JNI881";
//parkingGarage[81] = "";
//parkingGarage[82] = "BIL#VSL792";
//parkingGarage[83] = "MC#NML728|MC#VCW246";
//parkingGarage[84] = "BIL#AWE273";
//parkingGarage[85] = "MC#SHA907|MC#MTR647";
//parkingGarage[86] = "BIL#FRH545";
//parkingGarage[87] = "BIL#TIS221";
//parkingGarage[88] = "BIL#DNT124";
//parkingGarage[89] = "MC#ZNH112";
//parkingGarage[90] = "BIL#ANH956";
//parkingGarage[91] = "BIL#WMW544";
//parkingGarage[92] = "BIL#BYM840";
//parkingGarage[93] = "BIL#BDO391";
//parkingGarage[94] = "MC#PUF544";
//parkingGarage[95] = "MC#ZHQ679|MC#FFR110";
//parkingGarage[96] = "BIL#LPH277";
//parkingGarage[97] = "BIL#RYU669";
//parkingGarage[98] = "BIL#OQX801";
//parkingGarage[99] = "BIL#TOH166";
#endregion


menyVal(menyDisplay());

// ****************************** METODER ***************************************//
void flyttaFordon()
{
    string input = taEmotRegNr();
    int i = sökaFordon(input);
    if (i == 1001)
    {
        Console.WriteLine("Tyvärr finns inte fordonet i vårt system, kontrollera angivet registeringsnummer.");
    }
    else
    {
        int platsIndex = angePPlats();
        Console.WriteLine($"Fordon {input} står på plats {i + 1}, och flyttas nu till p-plats {platsIndex + 1}");

        if (Regex.IsMatch(parkingGarage[i], "^[^|]*$"))
        {
            parkingGarage[platsIndex] = parkingGarage[i];
            parkingGarage[i] = "";
        }
        else
        {
            string pPlats = parkingGarage[i];
            string[] mcParking = pPlats.Split('|');
            foreach (var item in mcParking)
            {
                if (item.Contains(input))
                {
                    parkingGarage[platsIndex] = item;
                }
                if (!item.Contains(input))
                {
                    parkingGarage[i] = item;
                }
            }
        }
    }
    Console.WriteLine();
    Console.Write("\n\nTryck på valfri tangent för att återgå till huvudmenyn.");
    Console.ReadKey();
    menyVal(menyDisplay());
}
int angePPlats()
{ // Ber användaren ange registreringsnummer på det fordon som eftersöks.

    Console.WriteLine("Ange nummer på p-platsen du vill flytta fordonet till:");
    int.TryParse(Console.ReadLine(), out int platsIndex);
    return (platsIndex-1);
}
void hämtaUtFordon()
{ //Ber användare om regNr via "taEmotRegNr" och sedan söker reda på vektor index via "sökaFordon"
  //för att sedan ange vart fordonet kan hämtas och ta bort det ur systemet. 

    string input = taEmotRegNr();
    int i = sökaFordon(input);
    if (i == 1001)
    {
        Console.WriteLine("Tyvärr finns inte fordonet i vårt system, kontrollera angivet registeringsnummer.");
    }
    else
    {
        Console.WriteLine($"Du kan hämta ut {input} på plats {i + 1}");
        if (Regex.IsMatch(parkingGarage[i], "^[^|]*$"))
        {
            parkingGarage[i] = "";
        }
        else
        {
            string pPlats = parkingGarage[i];
            string[] mcParking = pPlats.Split('|');
            foreach (var item in mcParking)
            {
                if (!item.Contains(input))
                {
                    parkingGarage[i] = item;
                }

            }
        }

    }
    Console.WriteLine();
    Console.Write("\n\nTryck på valfri tangent för att återgå till huvudmenyn.");
    Console.ReadKey();
    menyVal(menyDisplay());
}
string taEmotRegNr()
{ // Ber användaren ange registreringsnummer på det fordon som eftersöks.

    Console.WriteLine("Ange reg nr på fordonet:");
    string input = Console.ReadLine().ToUpper();
    return (input);
}
int sökaFordon(string input)
{ // Söker genom vektorn efter angivet registeringsnummer

    for (int i = 0; i < parkingGarage.Length; i++)
    {
        if (string.IsNullOrEmpty(parkingGarage[i]))
            continue;

        else if (parkingGarage[i].Contains(input))
        {
            return (i);
        }
    }
    return (1001);
}
void sorteraFordonsTyp(string fordonInput)
{ // Sorterar fordon efter om det är en bil eller en mc. Skickar sedan vidare till parkeraBil eller parkeraMC. 

    string[] fordonID = fordonInput.Split('#');

    if (fordonID[0] == "BIL")
    {
        parkeraBil(fordonID);
    }
    else if (fordonID[0] == "MC")
    {
        parkeraMc(fordonID);
    }
    else
        Console.WriteLine("Ogiltligt fordon.");
        läggaTillFordon();
}
void parkeraMc(string[] fordonID)
{ // Letar upp första bästa parkeringsplats för en MC, antingen en tom p-plats eller en p-plats där endast en MC står parkerad.

    for (int i = 0; i < parkingGarage.Length; i++)
    {
        if (string.IsNullOrEmpty(parkingGarage[i])) // Kollar om p-plats [i] är tom. Detta för att undvika null krashar.
        {
            parkingGarage[i] = fordonID[0] + "#" + fordonID[1];
            Console.WriteLine($"Mc med regnr {fordonID[1]} är parkerad på plats nr {i + 1}");
            Console.WriteLine($"Hela p-platsen id är {parkingGarage[i]}");
            break;
        }
        else if (parkingGarage[i].Contains("MC")) //Kollar om p-plats [i] innehåller en MC
        {
            if (Regex.IsMatch(parkingGarage[i], "^[^|]*$")) // Kollar om p-plats [i] inte innehåller 2 MC
            {
                parkingGarage[i] = parkingGarage[i] + "|" + fordonID[0] + "#" + fordonID[1];
                Console.WriteLine($"Mc med regnr {fordonID[1]} är parkerad på plats nr {i + 1}");
                Console.WriteLine($"Hela p-platsen id är {parkingGarage[i]}");
                break;
            }
        }
        else if (i == parkingGarage.Length - 1)
        {
            Console.WriteLine("Tyvärr finns det inga lediga p-platser.");
        }
        else
        {
            continue;
        }
    }
    Console.WriteLine();
    Console.Write("\n\nTryck på valfri tangent för att återgå till huvudmenyn.");
    Console.ReadKey();
    menyVal(menyDisplay());
}
void parkeraBil(string[] fordonID)
{ // Letar upp första lediga p-plats att parkera en bil på.

    for (int i = 0; i < parkingGarage.Length; i++)
    {
        if (string.IsNullOrEmpty(parkingGarage[i]))
        {
            parkingGarage[i] = fordonID[0] + "#" + fordonID[1];
            Console.WriteLine($"Bil med regnr {fordonID[1]} är parkerad på plats nr {i+1}");
            break;
        }
        else if (i == parkingGarage.Length - 1)
        {
            Console.WriteLine("Tyvärr finns det inga lediga p-platser.");
        }
        else
        {
            continue;
        }
    }

    Console.WriteLine();
    Console.Write("\n\nTryck på valfri tangent för att återgå till huvudmenyn.");
    Console.ReadKey();

    menyVal(menyDisplay());
}
void läggaTillFordon()
{ // Ber användaren ange fordonstyp och registeringsnummer för fordonet som ska parkeras. Skickar sedan vidare till sorteraFordonsTyp.

    Console.WriteLine();
    Console.WriteLine("Ange fordonstyp följt av registrering nummret på formen BIL#ABC123 alt. MC#ABC123:");
    string fordonInput = Console.ReadLine().ToUpper(); // Här hade jag velat ha någon form av spärr för om man inte matar in ett korrekt format.
    sorteraFordonsTyp(fordonInput);
}
void menyVal(int valdMenyPunkt)
{ // Styr vald meny i menyDisplay till rätt program.

    switch (valdMenyPunkt)
    {
        case 1:
            läggaTillFordon();
            break;

        case 2:
            flyttaFordon();
            break;

        case 3:
            hämtaUtFordon();
            break;

        case 4:
            string input = taEmotRegNr();
            int i = sökaFordon(input);
            if (i == 1001)
            {
                Console.WriteLine("Tyvärr finns inte fordonet i vårt system, kontrollera angivet registeringsnummer.");
            }
            else
            {
                Console.WriteLine($"Fordonet du söker står på plats {i + 1}");
            }

            Console.WriteLine();
            Console.Write("\n\nTryck på valfri tangent för att återgå till huvudmenyn.");
            Console.ReadKey();
            menyVal(menyDisplay());
            break;
    }
}
int menyDisplay()
{ // Menyn bygger på att vilkors operatorn ? : -> b ? x : y innebär att om b är sant händer x annars händer y. 
  // Om jag trycker på nedåt tangent och valdMenyPunkt är mindre än 3, kör vi valdMenyPunkt + 1 vilket flyttar pilmarkären nedåt 
  // eftersom att vi ovan states that om vald menypunkt är == 1, 2 eller 3 så har de en pil framför sig.

    int valdMenyPunkt = 1;
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Använd piltangenterna (Upp/Ned) och tryck sedan på Enter:");
        Console.WriteLine(valdMenyPunkt == 1 ? "> Lägg till fordon" : "  Lägg till fordon");
        Console.WriteLine(valdMenyPunkt == 2 ? "> Flytta fordon" : "  Flytta fordon");
        Console.WriteLine(valdMenyPunkt == 3 ? "> Hämta fordon" : "  Hämta fordon");
        Console.WriteLine(valdMenyPunkt == 4 ? "> Sök efter fordon" : "  Sök efter fordon");

        var knapp = Console.ReadKey(false);
        if (knapp.Key == ConsoleKey.DownArrow && valdMenyPunkt < 4) valdMenyPunkt++;


        else if (knapp.Key == ConsoleKey.UpArrow && valdMenyPunkt > 1) valdMenyPunkt--;
        else if (knapp.Key == ConsoleKey.Enter) break;
    }

    return (valdMenyPunkt);

}