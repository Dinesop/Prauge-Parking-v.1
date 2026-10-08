using Spectre.Console;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

using static System.Runtime.InteropServices.JavaScript.JSType;

// Deklarera huvudvariabler
string[] parkingGarage = new string[100];
bool powerSwitch = true;

// Lista av förparkerade bilar för enklare testning av systemet.
// Avkommentera för att populera p-huset.
#region parkerade bilar
parkingGarage[0] = "BIL#AHF768#2026-10-05 18:24:12";
parkingGarage[1] = "MC#KAF501#2026-10-05 14:12:05";
parkingGarage[2] = "BIL#OFP808#2026-10-05 20:45:30";
parkingGarage[3] = "MC#IEY300#2026-10-05 11:33:18";
parkingGarage[4] = "MC#PUS593#2026-10-05 19:15:40|MC#OVQ857#2026-10-05 19:15:40";
parkingGarage[5] = "BIL#ABC123#2026-10-05 08:52:11";
parkingGarage[6] = "MC#JJF296#2026-10-05 17:04:55";
parkingGarage[7] = "MC#10TEECKEEN#2026-10-05 13:41:22";
parkingGarage[8] = "BIL#RVU203#2026-10-05 15:19:04";
parkingGarage[9] = "";
//parkingGarage[10] = "";
//parkingGarage[11] = "BIL#GGO258#2026-10-05 10:14:35";
//parkingGarage[12] = "BIL#FZN001#2026-10-05 16:38:50";
//parkingGarage[13] = "BIL#UKB395#2026-10-05 12:22:14";
//parkingGarage[14] = "";
//parkingGarage[15] = "MC#ASR526#2026-10-05 18:49:01|MC#CLL982#2026-10-05 18:49:01";
//parkingGarage[16] = "BIL#EXW266#2026-10-05 07:12:43";
//parkingGarage[17] = "BIL#TOU503#2026-10-05 19:58:22";
//parkingGarage[18] = "BIL#YWV308#2026-10-05 14:05:36";
//parkingGarage[19] = "";
//parkingGarage[20] = "BIL#MBT714#2026-10-05 20:59:15";
//parkingGarage[21] = "BIL#GWL257#2026-10-05 16:44:02";
//parkingGarage[22] = "BIL#IZQ451#2026-10-05 11:27:19";
//parkingGarage[23] = "BIL#IPF206#2026-10-05 09:18:44";
//parkingGarage[24] = "BIL#XWB262#2026-10-05 15:33:55";
//parkingGarage[25] = "BIL#YOM781#2026-10-05 13:02:10";
//parkingGarage[26] = "BIL#LLM769#2026-10-05 17:41:29";
//parkingGarage[27] = "BIL#KIW214#2026-10-05 19:24:50";
//parkingGarage[28] = "BIL#HGY485#2026-10-05 08:11:34";
//parkingGarage[29] = "BIL#ZVZ981#2026-10-05 20:15:42";
//parkingGarage[30] = "BIL#FKB392#2026-10-05 14:52:03";
//parkingGarage[31] = "MC#LKY957#2026-10-05 10:39:18";
//parkingGarage[32] = "BIL#HZP570#2026-10-05 16:11:25";
//parkingGarage[33] = "BIL#NWE901#2026-10-05 12:48:33";
//parkingGarage[34] = "BIL#RGD825#2026-10-05 18:05:12";
//parkingGarage[35] = "BIL#KPN927#2026-10-05 15:54:21";
//parkingGarage[36] = "BIL#KRH370#2026-10-05 07:44:09";
//parkingGarage[37] = "BIL#ZZB229#2026-10-05 19:33:14";
//parkingGarage[38] = "MC#WJE876#2026-10-05 11:15:22|MC#ZRA826#2026-10-05 11:15:22";
//parkingGarage[39] = "";
//parkingGarage[40] = "BIL#DCO267#2026-10-05 14:26:40";
//parkingGarage[41] = "BIL#QGM980#2026-10-05 16:58:11";
//parkingGarage[42] = "BIL#HAU627#2026-10-05 20:33:19";
//parkingGarage[43] = "BIL#LAB895#2026-10-05 13:19:45";
//parkingGarage[44] = "MC#PDD387#2026-10-05 17:22:11|MC#WXF217#2026-10-05 17:22:11";
//parkingGarage[45] = "MC#KQE989#2026-10-05 10:05:43|MC#VWA739#2026-10-05 10:05:43";
//parkingGarage[46] = "MC#WVG718#2026-10-05 19:04:12|MC#WFV437#2026-10-05 19:04:12";
//parkingGarage[47] = "BIL#AFI892#2026-10-05 15:12:35";
//parkingGarage[48] = "BIL#KZN919#2026-10-05 08:33:50";
//parkingGarage[49] = "BIL#ZGC473#2026-10-05 12:14:02";
//parkingGarage[50] = "BIL#NKO270#2026-10-05 20:51:14";
//parkingGarage[51] = "";
//parkingGarage[52] = "BIL#STR306#2026-10-05 16:22:45";
//parkingGarage[53] = "BIL#IWS334#2026-10-05 14:09:33";
//parkingGarage[54] = "BIL#HDK969#2026-10-05 18:31:04";
//parkingGarage[55] = "BIL#HOA245#2026-10-05 11:44:55";
//parkingGarage[56] = "MC#MLF497#2026-10-05 10:19:22";
//parkingGarage[57] = "BIL#CNQ387#2026-10-05 15:47:11";
//parkingGarage[58] = "MC#FFA248#2026-10-05 07:55:30";
//parkingGarage[59] = "BIL#KQF642#2026-10-05 19:42:15";
//parkingGarage[60] = "MC#ATU141#2026-10-05 13:28:40";
//parkingGarage[61] = "";
//parkingGarage[62] = "BIL#BGW486#2026-10-05 17:15:04";
//parkingGarage[63] = "";
//parkingGarage[64] = "BIL#YXP758#2026-10-05 09:41:22";
//parkingGarage[65] = "BIL#XTM226#2026-10-05 14:33:50";
//parkingGarage[66] = "MC#NQH022#2026-10-05 11:05:14";
//parkingGarage[67] = "BIL#ODG670#2026-10-05 20:22:41";
//parkingGarage[68] = "BIL#OKF495#2026-10-05 16:04:55";
//parkingGarage[69] = "MC#WTJ037#2026-10-05 18:12:33";
//parkingGarage[70] = "MC#YKT562#2026-10-05 12:51:04|MC#FLA364#2026-10-05 12:51:04";
//parkingGarage[71] = "BIL#MDQ035#2026-10-05 15:28:19";
//parkingGarage[72] = "BIL#QDM032#2026-10-05 08:14:50";
//parkingGarage[73] = "BIL#TJT820#2026-10-05 19:11:35";
//parkingGarage[74] = "BIL#OZJ676#2026-10-05 14:47:22";
//parkingGarage[75] = "MC#YFA116#2026-10-05 10:55:41";
//parkingGarage[76] = "BIL#FST167#2026-10-05 17:33:14";
//parkingGarage[77] = "BIL#VZC036#2026-10-05 13:09:55";
//parkingGarage[78] = "";
//parkingGarage[79] = "BIL#SBR617#2026-10-05 20:04:12";
//parkingGarage[80] = "MC#PDZ734#2026-10-05 16:41:50|MC#JNI881#2026-10-05 16:41:50";
//parkingGarage[81] = "";
//parkingGarage[82] = "BIL#VSL792#2026-10-05 11:41:04";
//parkingGarage[83] = "MC#NML728#2026-10-05 18:55:22|MC#VCW246#2026-10-05 18:55:22";
//parkingGarage[84] = "BIL#AWE273#2026-10-05 14:19:11";
//parkingGarage[85] = "MC#SHA907#2026-10-05 09:02:45|MC#MTR647#2026-10-05 09:02:45";
//parkingGarage[86] = "BIL#FRH545#2026-10-05 17:51:33";
//parkingGarage[87] = "BIL#TIS221#2026-10-05 13:38:14";
//parkingGarage[88] = "BIL#DNT124#2026-10-05 15:05:40";
//parkingGarage[89] = "MC#ZNH112#2026-10-05 19:47:22";
//parkingGarage[90] = "BIL#ANH956#2026-10-05 12:11:05";
//parkingGarage[91] = "BIL#WMW544#2026-10-05 20:39:14";
//parkingGarage[92] = "BIL#BYM840#2026-10-05 16:28:55";
//parkingGarage[93] = "BIL#BDO391#2026-10-05 10:47:11";
//parkingGarage[94] = "MC#PUF544#2026-10-05 14:38:22";
//parkingGarage[95] = "MC#ZHQ679#2026-10-05 18:19:40|MC#FFR110#2026-10-05 18:19:40";
//parkingGarage[96] = "BIL#LPH277#2026-10-05 11:58:14";
//parkingGarage[97] = "BIL#RYU669#2026-10-05 15:44:05";
//parkingGarage[98] = "BIL#OQX801#2026-10-05 03:26:19";
//parkingGarage[99] = "BIL#TOH166#2026-10-05 19:14:50";
#endregion

while (powerSwitch)
{
    int valdMenyPunkt = menyDisplay();
    menyVal(valdMenyPunkt);
}

// ****************************** METODER ***************************************//
void sökaEfterFordon()
{ // Kod snippet för att söka efter fordon.

    string input = taEmotRegNr();
    List<int> i = genomsökaPhus(input);

    if (i[0] == 1001) // Fordonet finns inte i systemet
    {
        Console.WriteLine();
        Console.WriteLine("Tyvärr finns inte fordonet i vårt system, kontrollera angivet registeringsnummer.");
        sökaEfterFordon();
    }
    else if (i.Count > 1) // Om det finns mer än ett fordon med angivet regnr.
    {
        Console.WriteLine();
        Console.WriteLine($"Det finns {i.Count} bilar med det registreringsnumret du angav:");
        foreach (var fordon in i)
        {
            if (Regex.IsMatch(parkingGarage[fordon], "^[^|]*$")) // Det står inte 2 MC:s parkerade på p-platsen.
            {
                string[] fordonID = parkingGarage[fordon].Split('#');
                Console.WriteLine(fordonID[0] + "#" + fordonID[1]);
            }
            else // Det står två MC:s på p-platsen.
            {
                string pPlats = parkingGarage[fordon];
                string[] mcParking = pPlats.Split('|');
                foreach (var item in mcParking)
                {
                    if (item.Contains(input))
                    {
                        string[] fordonID = item.Split('#');
                        Console.WriteLine(fordonID[0] + "#" + fordonID[1]);
                    }

                }
            }
        }
        Console.WriteLine();
        Console.WriteLine("Var god specificera vilket av dom du eftersöker:");
        sökaEfterFordon();
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine($"Fordonet du söker står på plats {i[0] + 1}");
    }

    Console.WriteLine();
    Console.Write("\n\nTryck på valfri tangent för att återgå till huvudmenyn.");
    Console.ReadKey();
}
List<int> genomsökaPhus(string input)
{ // Genomsöker alla p-platser efter angivet registreringsnr samt kollar efter dubletter.

    List<int> pIndex = new List<int>();
    for (int i = 0; i < parkingGarage.Length; i++)
    {
        if (string.IsNullOrEmpty(parkingGarage[i]))
        {
            continue;
        }

        else if (parkingGarage[i].Contains(input))
        {
            pIndex.Add(i);
        }
    }

    if (pIndex.Count == 0)
    {
        pIndex.Add(1001);
        return (pIndex);
    }
    else
    {
        return (pIndex);
    }
}
void visualiseraPhusText()
{

    Console.Clear();
    int width = 160;
    int height = Console.WindowHeight;
    Console.SetWindowSize(width, height);

    int index = 0;

    // Tabell setup
    var table = new Table()
    .RoundedBorder()
    .ShowRowSeparators()
    .BorderColor(Spectre.Console.Color.Grey)
    .Title("[bold]Parkeringshuset[/]");

    // Kolumn setup
    for (int colSetup = 0; colSetup < 10; colSetup++)
    {
        table.AddColumn($"{colSetup + 1}", col => col.Width(100));// .PadLeft(1).PadRight(1)
    }

    // Rad setup
    for (int rowSetup = 0; rowSetup < 10; rowSetup++)
    {
        table.AddRow("", "", "", "", "", "", "", "", "", "");
    }

    // Fyll tabellen med stapeldiagram för att visa om p-platserna är fulla, halvfulla eller tomma. 

    for (int row = 0; row < 10; row++)
    {
        for (int col = 0; col < 10; col++)
        {
            if (string.IsNullOrEmpty(parkingGarage[index]))
            {
                table.UpdateCell(row, col, new Markup($" "));
            }

            else if (parkingGarage[index].Contains("|"))
            {
                string[] mcParking = parkingGarage[index].Split('|');
                string[] mcID1 = mcParking[0].Split('#');
                string[] mcID2 = mcParking[1].Split('#');
                table.UpdateCell(row, col, new Markup($"{mcID1[0]} {mcID1[1]} \n{mcID2[0]} {mcID2[1]}"));
            }

            else if (!string.IsNullOrEmpty(parkingGarage[index])) // Kollar om p-plats [i] är INTE är tom.
            {
                string[] fordonID = parkingGarage[index].Split('#');
                table.UpdateCell(row, col, new Markup($"{fordonID[0]} {fordonID[1]}"));
            }

            index++;
        }
    }

    // Skriver ut tabellen i konsolfönstret
    AnsiConsole.Write(table);

    Console.WriteLine();
    Console.WriteLine("Tryck Enter för att växla mellan färgkodade platser eller utskift av befintliga fordon eller tryck annan valfri tangent för att fortsätta.");
    var knapp = Console.ReadKey(false);
    if (knapp.Key == ConsoleKey.Enter)
    {
        Console.Clear();
        visualiseraPhusFärg();
    }

    else
    {
        Console.ReadKey();
        int[] beläggning = beläggningsKoll();
        beläggningsrapport(beläggning);
    }
}
void beläggningsrapport(int[] beläggning)
{ // Hanterar datan från beläggningskollen och skriver ut en enkel rapport. Om det finns singel parkerade MCs kan användaren direkt köra MC Optimeringsprogrammet. 

    Console.WriteLine("********** BELÄGGNINGSRAPPORT **********");
    Console.WriteLine($"Antal fulla p-platser: {beläggning[2]} \nAntal halvfulla p-platser: {beläggning[1]} \nAntal tomma p-platser: {beläggning[0]}");

    //Kollar om det finns singelparkerade MCs och föreslår optimeringsprogrammet.
    if (beläggning[1] != 0)
    {
        Console.WriteLine();
        Console.WriteLine("Det finns MCs som står singelparkerade, tryck Enter för att köra Optimera MC parkering, annars tryck på valfri tangent (utom Enter) för att återgå till huvudmenyn.\n");
        var knapp = Console.ReadKey(false);
        if (knapp.Key == ConsoleKey.Enter)
        {
            Console.WriteLine();
            optimeraMcParkering();
        }

        else
        {
            Console.ReadKey();
            menyVal(menyDisplay());
        }

    }
    else
    {
        Console.WriteLine();
        Console.Write("\n\nTryck på valfri tangent för att återgå till huvudmenyn.");
        Console.ReadKey();
    }
}
int[] beläggningsKoll()
{ // Går igenom parkeringshuset och tar status på alla p-platser.

    int[] beläggning = { 0, 0, 0 };

    for (int i = 0; i < parkingGarage.Length; i++)
    {
        if (string.IsNullOrEmpty(parkingGarage[i])) // Kollar om p-platsen är tom
        {
            beläggning[0]++;
        }
        else if (parkingGarage[i].Contains("MC") && Regex.IsMatch(parkingGarage[i], "^[^|]*$")) //Kollar om p-plats [i] innehåller endast en MC
        {
            beläggning[1]++;
        }
        else // Är p-platsen inte tom eller innehåller 1 MC räknas den som full
        {
            beläggning[2]++;
        }
    }
    return (beläggning);
}
void visualiseraPhusFärg()
{ // Skriver ut en tabell över p-huset med beläggningsstatus på varje plats.
    Console.Clear();
    int width = 160;
    int height = Console.WindowHeight;
    Console.SetWindowSize(width, height);

    int index = 0;

    // Tabell setup
    var table = new Table()
    .RoundedBorder()
    .ShowRowSeparators()
    .BorderColor(Spectre.Console.Color.Grey)
    .Title("[bold]Parkeringshuset[/]");

    // Kolumn setup
    for (int colSetup = 0; colSetup < 10; colSetup++)
    {
        table.AddColumn($"{colSetup + 1}", col => col.Width(100));// .PadLeft(1).PadRight(1)
    }

    // Rad setup
    for (int rowSetup = 0; rowSetup < 10; rowSetup++)
    {
        table.AddRow("", "", "", "", "", "", "", "", "", "");
    }

    // Fyll tabellen med stapeldiagram för att visa om p-platserna är fulla, halvfulla eller tomma. 
    for (int row = 0; row < 10; row++)
    {
        for (int col = 0; col < 10; col++)
        {
            // Kollar om p-platsen innehåller endast en MC
            if (string.IsNullOrEmpty(parkingGarage[index]))
            {
                table.UpdateCell(row, col, new BarChart()
                 .HideValues()
                 .AddItem($"", 1, Spectre.Console.Color.Green)
                 .AddItem($"", 1, Spectre.Console.Color.Green));
            }

            else if (parkingGarage[index].Contains("MC") && Regex.IsMatch(parkingGarage[index], "^[^|]*$"))
            {
                table.UpdateCell(row, col, new BarChart()
                .HideValues()
                .AddItem($"", 1, Spectre.Console.Color.Yellow));
            }
            // Kollar om p-platsen innehåller en bil eller 2 MCs.
            else //(parkingGarage[index].Contains("BIL") || parkingGarage[index].Contains("|"))
            {
                table.UpdateCell(row, col, new BarChart()
                 .HideValues()
                 .AddItem($"", 1, Spectre.Console.Color.Red3)
                 .AddItem($"", 1, Spectre.Console.Color.Red3));
            }

            index++;

        }
    }
    // Skriver ut tabellen i konsolfönstret
    AnsiConsole.Write(table);

    Console.WriteLine();
    Console.WriteLine("Tryck Enter för att växla mellan färgkodade platser eller utskift av befintliga fordon eller tryck annan valfri tangent för att fortsätta.");
    var knapp = Console.ReadKey(false);
    if (knapp.Key == ConsoleKey.Enter)
    {
        visualiseraPhusText();
    }

    else
    {
        Console.ReadKey();
        Console.WriteLine();
        int[] beläggning = beläggningsKoll();
        beläggningsrapport(beläggning);
    }

}
void hittaTommaPlatser()
{ // Identifierar de tomma platsern i p-huset
    List<int> tommaPlatser = new List<int>();
    for (int i = 0; i < parkingGarage.Length; i++)
    {
        if (string.IsNullOrEmpty(parkingGarage[i])) // Kollar om p-plats [i] är tom.
        {
            tommaPlatser.Add(i + 1); //konverterar från elementindext till platsindex.
        }
    }
    Console.Write("Tomma p-platser: ");
    foreach (var plats in tommaPlatser)
    {
        Console.Write(plats + "; ");
    }
}
void optimeraMcParkering()
{ // Söker igenom p-huset och kollar efter singelparkerade MCs och skriver ut hur de ska flyttas för optimal parkering vid behov.

    Console.Clear();
    int counter = 0;
    int[] mcID = new int[2]; // Lagrar första och andra funna singelparkerade MCs. 
    for (int i = 0; i < parkingGarage.Length; i++)
    {
        if (string.IsNullOrEmpty(parkingGarage[i]))
        {
            continue;
        }

        else if (parkingGarage[i].Contains("MC") && Regex.IsMatch(parkingGarage[i], "^[^|]*$")) //Kollar om p-plats [i] innehåller endast en MC
        {
            mcID[counter] = i;
            counter++;
        }
        // Om man har 2 singelparkerade MCs skrivs flyttinstruktioner ut.
        if (counter == 2)
        {
            string[] fordonID = parkingGarage[mcID[1]].Split('#');
            Console.WriteLine($"{fordonID[0]} {fordonID[1]} står på plats {mcID[1] + 1}, och ska flyttas till p-plats {mcID[0] + 1} ");
            parkingGarage[mcID[0]] = parkingGarage[mcID[0]] + "|" + parkingGarage[mcID[1]];
            // Här nollställs mcID och counter för att alltid bara ha 2 MCs aktiva.
            parkingGarage[mcID[1]] = "";
            counter = 0;
        }
        if (i == parkingGarage.Length - 1)
        {
            Console.WriteLine();
            Console.WriteLine("Alla MCs står optimalt.");
            break;
        }

    }
    Console.WriteLine();
    Console.Write("\n\nTryck på valfri tangent för att återgå till huvudmenyn.");
    Console.ReadKey();

}
void flyttaFordon()
{ // Flyttar fordon manuellt från en plats till en annan.

    string input = taEmotRegNr();
    List<int> i = genomsökaPhus(input);

    if (i[0] == 1001) // Fordonet finns inte i systemet
    {
        Console.WriteLine();
        Console.WriteLine("Tyvärr finns inte fordonet i vårt system, kontrollera angivet registeringsnummer.");
        flyttaFordon();
    }
    else if (i.Count > 1) // Om det finns mer än ett fordon med angivet regnr.
    {
        Console.WriteLine();
        Console.WriteLine($"Det finns {i.Count} fordon med det registreringsnumret du angav:");
        foreach (var fordon in i)
        {
            if (Regex.IsMatch(parkingGarage[fordon], "^[^|]*$")) // Det står inte 2 MC:s parkerade på p-platsen.
            {
                string[] fordonID = parkingGarage[fordon].Split('#');
                Console.WriteLine(fordonID[0] + "#" + fordonID[1]);
            }
            else // Det står två MC:s på p-platsen.
            {
                string pPlats = parkingGarage[fordon];
                string[] mcParking = pPlats.Split('|');
                foreach (var item in mcParking)
                {
                    if (item.Contains(input))
                    {
                        string[] fordonID = item.Split('#');
                        Console.WriteLine(fordonID[0] + "#" + fordonID[1]);
                    }

                }
            }
        }

        Console.WriteLine();
        Console.WriteLine("Var god specificera vilket av dom du eftersöker:");
        flyttaFordon();
    }
    else // Fordonet finns och saknar dubbletter, så fortsätter till att flytta ut fordonet ur systemet.
    {
        int index = i[0];
        int platsIndex = angePPlats();

        if (!string.IsNullOrEmpty(parkingGarage[platsIndex]))
        {
            Console.WriteLine("Tyvärr är den angivna p-plasten upptagen, försök igen.");
            hittaTommaPlatser();
            Console.WriteLine();
            platsIndex = angePPlats();
        }

        if (Regex.IsMatch(parkingGarage[index], "^[^|]*$")) //Om p-platsen inte innehåller 2 st MC
        {
            parkingGarage[platsIndex] = parkingGarage[index];
            parkingGarage[index] = "";
        }
        else // Om p-platsen innehåller 2 MC, delas dom.
        {
            string pPlats = parkingGarage[index];
            string[] mcParking = pPlats.Split('|');
            foreach (var item in mcParking)
            {
                if (item.Contains(input))
                {
                    parkingGarage[platsIndex] = item;
                }
                if (!item.Contains(input))
                {
                    parkingGarage[index] = item;
                }
            }
        }
        Console.WriteLine($"Fordon {input} står på plats {index + 1}, och flyttas nu till p-plats {platsIndex + 1}");
        Console.WriteLine();
        Console.Write("\n\nTryck på valfri tangent för att återgå till huvudmenyn.");
        Console.ReadKey();
    }
}
int angePPlats()
{ // Ber användaren ange registreringsnummer på det fordon som eftersöks.

    Console.WriteLine("Ange nummer på p-platsen du vill flytta fordonet till:");
    bool inputSafety = int.TryParse(Console.ReadLine(), out int platsIndex);
    platsIndex--; // konverterar från platsindex 1-100 till elementindex 0-99
    if (inputSafety == false)
    {
        Console.WriteLine("Du angav inte ett heltal, försök igen.");
        Console.WriteLine();
        angePPlats();
    }
    if (platsIndex > parkingGarage.Length)
    {
        Console.WriteLine($"Du angav inte en p-plats som finns i systemet, p-huset har parkingsplatser från 1 till {parkingGarage.Length}, ange en siffra inom det spannet.");
        Console.WriteLine();
        angePPlats();
    }

    return (platsIndex);
}
void hämtaUtFordon()
{ //Ber användare om regNr via "taEmotRegNr" och sedan söker reda på vektor index via "sökaFordon"
  //för att sedan ange vart fordonet kan hämtas och ta bort det ur systemet. 

    string input = taEmotRegNr();
    List<int> i = genomsökaPhus(input);

    if (i[0] == 1001) // Fordonet finns inte i systemet
    {
        Console.WriteLine();
        Console.WriteLine("Tyvärr finns inte fordonet i vårt system, kontrollera angivet registeringsnummer.");
        hämtaUtFordon();
    }
    else if (i.Count > 1) // Om det finns mer än ett fordon med angivet regnr.
    {
        Console.WriteLine();
        Console.WriteLine($"Det finns {i.Count} bilar med det registreringsnumret du angav:");
        foreach (var fordon in i)
        {
            if (Regex.IsMatch(parkingGarage[fordon], "^[^|]*$")) // Det står inte 2 MC:s parkerade på p-platsen.
            {
                string[] fordonID = parkingGarage[fordon].Split('#');
                Console.WriteLine(fordonID[0] + "#" + fordonID[1]);
            }
            else // Det står två MC:s på p-platsen.
            {
                string pPlats = parkingGarage[fordon];
                string[] mcParking = pPlats.Split('|');
                foreach (var item in mcParking)
                {
                    if (item.Contains(input))
                    {
                        string[] fordonID = item.Split('#');
                        Console.WriteLine(fordonID[0] + "#" + fordonID[1]);
                    }

                }
            }

        }
        Console.WriteLine();
        Console.WriteLine("Var god specificera vilket av dom du eftersöker:");
        hämtaUtFordon();
    }
    else // Fordonet finns och saknar dubbletter, så fortsätter till att hämta ut fordonet ur systemet.
    {
        int index = i[0];
        Console.WriteLine();

        if (Regex.IsMatch(parkingGarage[index], "^[^|]*$")) // Om p-platsen inte innehåller 2 MCs.
        {
            string[] fordonID2 = parkingGarage[index].Split('#');

            try
            {
                DateTime parkeringsStart = DateTime.ParseExact(fordonID2[2], "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                DateTime parkeringsSlut = DateTime.UtcNow;
                TimeSpan parkeringsTid = parkeringsSlut - parkeringsStart;
                int hours = (int)Math.Floor(parkeringsTid.TotalHours);
                string formatteradParkeringsTid = $"{hours}:{parkeringsTid.Minutes:D2}:{parkeringsTid.Seconds:D2}";

                Console.WriteLine($"Du kan hämta ut {fordonID2[0]} {fordonID2[1]} på plats {index + 1}. Den har varit parkerad i {formatteradParkeringsTid}");
            }
            catch
            {
                Console.WriteLine($"Du kan hämta ut {fordonID2[0]} {fordonID2[1]} på plats {index + 1}. Den har varit parkerad i mindre än en minut.");
            }
            parkingGarage[index] = "";
        }
        else // Om p-platsen innehåller 2 MCs.
        {
            string pPlats = parkingGarage[index];
            string[] mcParking = pPlats.Split('|');
            foreach (var item in mcParking)
            {
                if (item.Contains(input))
                {
                    string[] fordonID2 = item.Split('#');

                    try
                    {
                        DateTime parkeringsStart = DateTime.ParseExact(fordonID2[2], "yyyy-MM-dd HH:mm:ss +00:00", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime parkeringsSlut = DateTime.UtcNow;
                        TimeSpan parkeringsTid = parkeringsSlut - parkeringsStart;
                        int hours = (int)Math.Floor(parkeringsTid.TotalHours);
                        string formatteradParkeringsTid = $"{hours}:{parkeringsTid.Minutes:D2}:{parkeringsTid.Seconds:D2}";

                        Console.WriteLine($"Du kan hämta ut {fordonID2[0]} {fordonID2[1]} på plats {index + 1}. Den har varit parkerad i {formatteradParkeringsTid}");
                    }
                    catch
                    {
                        Console.WriteLine($"Något gick fel, var god försök igen");
                        menyVal(menyDisplay());
                    }

                }
                else
                {
                    parkingGarage[index] = item;
                }

            }


        }

    }
    Console.WriteLine();
    Console.Write("\n\nTryck på valfri tangent för att återgå till huvudmenyn.");
    Console.ReadKey();
}
string taEmotRegNr()
{ // Ber användaren ange registreringsnummer på det fordon som eftersöks.

    Console.WriteLine();
    Console.WriteLine("Ange reg nr på fordonet:");

    string input = Console.ReadLine().ToUpper().Trim();
    if (input.Length > 10)
    {
        Console.WriteLine("Registreringsnummer kan ha max 10 tecken, försök igen.");
        taEmotRegNr();
    }
    return (input);
}
void sorteraFordonsTyp(string fordonInput)
{ // Sorterar fordon efter om det är en bil eller en mc. Skickar sedan vidare till parkeraBil eller parkeraMC. 

    string[] fordonID = fordonInput.Split('#');

    if (fordonID[1].Length > 10)
    {
        Console.WriteLine("Registreringsnummer kan ha max 10 tecken, försök igen.");
        läggaTillFordon();
    }

    else if (fordonID[0] == "BIL")
    {
        parkeraBil(fordonID);
    }

    else if (fordonID[0] == "MC")
    {
        parkeraMc(fordonID);
    }
    else
        Console.WriteLine("Ogiltligt fordon.");

}
void parkeraMc(string[] fordonID)
{ // Letar upp första bästa parkeringsplats för en MC, antingen en tom p-plats eller en p-plats där endast en MC står parkerad.

    for (int i = 0; i < parkingGarage.Length; i++)
    {
        if (string.IsNullOrEmpty(parkingGarage[i])) // Kollar om p-plats [i] är tom. Detta för att undvika null krashar.
        {
            parkingGarage[i] = fordonID[0] + "#" + fordonID[1] + "#" + fordonID[2];
            Console.WriteLine($"Mc med regnr {fordonID[1]} är parkerad på plats nr {i + 1}");
            break;
        }
        else if (parkingGarage[i].Contains("MC")) //Kollar om p-plats [i] innehåller en MC
        {
            if (Regex.IsMatch(parkingGarage[i], "^[^|]*$")) // Kollar om p-plats [i] inte innehåller 2 MC
            {
                parkingGarage[i] = parkingGarage[i] + "|" + fordonID[0] + "#" + fordonID[1] + "#" + fordonID[2];
                Console.WriteLine($"Mc med regnr {fordonID[1]} är parkerad på plats nr {i + 1}");
                break;
            }
        }
        else if (i == parkingGarage.Length - 1)
        {
            Console.WriteLine("Tyvärr finns det inga lediga platser.");
        }
        else
        {
            continue;
        }
    }
    Console.WriteLine();
    Console.Write("\n\nTryck på valfri tangent för att återgå till huvudmenyn.");
    Console.ReadKey();
}
void parkeraBil(string[] fordonID)
{ // Letar upp första lediga p-plats att parkera en bil på.

    for (int i = 0; i < parkingGarage.Length; i++)
    {
        if (string.IsNullOrEmpty(parkingGarage[i]))
        {
            parkingGarage[i] = fordonID[0] + "#" + fordonID[1] + "#" + fordonID[2];
            Console.WriteLine($"Bil med regnr {fordonID[1]} är parkerad på plats nr {i + 1}");
            break;
        }
        else if (i == parkingGarage.Length - 1)
        {
            Console.WriteLine("Tyvärr finns det inga lediga platser.");
        }
    }
    Console.WriteLine();
    Console.Write("\n\nTryck på valfri tangent för att återgå till huvudmenyn.");
    Console.ReadKey();
}
void läggaTillFordon()
{ // Ber användaren ange fordonstyp och registeringsnummer för fordonet som ska parkeras. Skickar sedan vidare till sorteraFordonsTyp.

    Console.WriteLine();
    Console.WriteLine("Ange fordonstyp följt av registrering nummret på formen BIL#ABC123 alt. MC#ABC123:");
    string fordonInput = Console.ReadLine().ToUpper().Trim();
    if (!fordonInput.Contains("#") || !fordonInput.Contains("BIL") && !fordonInput.Contains("MC"))
    {
        Console.WriteLine("Var god mata in fordonet i formatet: BIL#ABC123 alt. MC#ABC123");
        läggaTillFordon();
    }

    List<int> index = genomsökaPhus(fordonInput); // Kollar om något av samma fordonstyp finns registrerat redan.
    if (index[0] == 1001) // Ingen dublett fanns.
    {
        fordonInput = fordonInput + "#" + DateTimeOffset.UtcNow;
        sorteraFordonsTyp(fordonInput);
    }
    else // samma regnr återfanns
    {
        foreach (var item in index)
        {
            string[] delatFordonInput = fordonInput.Split('#');
            string[] fordonID = parkingGarage[item].Split('#');
            if (delatFordonInput[0] == fordonID[0]) // Samma fordonstyp och regnr
            {
                Console.WriteLine($"Fordon {fordonInput} finns redan registrerad i systemet, kontrollera angivet regnr och fordonstyp och försök igen.");
                läggaTillFordon();
            }
            else // Det var inte samma fordonstyp
            {
                fordonInput = fordonInput + "#" + DateTimeOffset.UtcNow;
                sorteraFordonsTyp(fordonInput);
            }
        }
    }
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
            sökaEfterFordon();
            break;
        case 5:
            optimeraMcParkering();
            break;

        case 6:
            visualiseraPhusFärg();
            break;

        case 7:
            powerSwitch = false;
            return;
    }

}
int menyDisplay()
{ // Menydisplay
    Console.Clear();
    int valdMenyPunkt = 1;
    while (powerSwitch)
    {
        Console.Clear();
        Console.WriteLine("Använd piltangenterna (Upp/Ned) och tryck sedan på Enter:");
        Console.WriteLine(valdMenyPunkt == 1 ? "> Lägg till fordon" : "  Lägg till fordon");
        Console.WriteLine(valdMenyPunkt == 2 ? "> Flytta fordon" : "  Flytta fordon");
        Console.WriteLine(valdMenyPunkt == 3 ? "> Hämta fordon" : "  Hämta fordon");
        Console.WriteLine(valdMenyPunkt == 4 ? "> Sök efter fordon" : "  Sök efter fordon");
        Console.WriteLine(valdMenyPunkt == 5 ? "> Optimera MC parkering" : "  Optimera MC parkering");
        Console.WriteLine(valdMenyPunkt == 6 ? "> Parkeringshus översikt (helskärm rekommenderas)" : "  Parkeringshus översikt (helskärm rekommenderas)");
        Console.WriteLine(valdMenyPunkt == 7 ? "> Avsluta" : "  Avsluta");

        var knapp = Console.ReadKey(false);
        if (knapp.Key == ConsoleKey.DownArrow && valdMenyPunkt < 7) valdMenyPunkt++;


        else if (knapp.Key == ConsoleKey.UpArrow && valdMenyPunkt > 1) valdMenyPunkt--;
        else if (knapp.Key == ConsoleKey.Enter) break;
    }

    return (valdMenyPunkt);
}
