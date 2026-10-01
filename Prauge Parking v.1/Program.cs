using System.Numerics;
using System.Text.RegularExpressions;

string[] parkingGarage = new string[100];
parkingGarage[0] = "BIL#ABC123";
parkingGarage[1] = "BIL#ABC321";
parkingGarage[2] = "MC#RTY678|MC#TYU456";
parkingGarage[3] = "BIL#FGH456";
parkingGarage[4] = "MC#BCD234";




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